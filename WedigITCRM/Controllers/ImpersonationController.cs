using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WedigITCRM.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WedigITCRM.Controllers
{
    public class ImpersonationController : Controller
    {

        // https://tech.trailmax.info/2017/07/user-impersonation-in-asp-net-core/


        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        private ICompanyAccountRepository _companyAccountRepository;
        private IRelateCompanyAccountWithUserRepository _relateCompanyAccountWithUserRepository;
        public ImpersonationController(IRelateCompanyAccountWithUserRepository relateCompanyAccountWithUserRepository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ICompanyAccountRepository companyAccountRepository)
        {
            _userManager = userManager;
           _signInManager = signInManager;
            _companyAccountRepository = companyAccountRepository;
            _relateCompanyAccountWithUserRepository = relateCompanyAccountWithUserRepository;
        }


        [HttpGet]
        public IActionResult SelectUserToImpersonate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>  SelectUserToImpersonate(ImpersonateCustomerUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(model.UserToImpersonateId))
                {
                    var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                    var impersonatedUser = await _userManager.FindByIdAsync(model.UserToImpersonateId);

                    var userPrincipal = await _signInManager.CreateUserPrincipalAsync(impersonatedUser);

                    userPrincipal.Identities.First().AddClaim(new Claim("OriginalUserId", currentUserId));
                    userPrincipal.Identities.First().AddClaim(new Claim("IsImpersonating", "true"));

                    // sign out the current user
                    await _signInManager.SignOutAsync();



                    // await HttpContext.SignInAsync(cookieOptions.ApplicationCookieAuthenticationScheme, userPrincipal);
                    await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, userPrincipal);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("Bruger", "Bruger skal angives");
            }


            return View();
        }


        public async Task<IActionResult> ImpersonateUser(String userId)
        {
            if (ModelState.IsValid)
            {

                var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                var impersonatedUser = await _userManager.FindByIdAsync(userId);

                var userPrincipal = await _signInManager.CreateUserPrincipalAsync(impersonatedUser);

                userPrincipal.Identities.First().AddClaim(new Claim("OriginalUserId", currentUserId));
                userPrincipal.Identities.First().AddClaim(new Claim("IsImpersonating", "true"));

                // sign out the current user
                await _signInManager.SignOutAsync();



                // await HttpContext.SignInAsync(cookieOptions.ApplicationCookieAuthenticationScheme, userPrincipal);
                await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, userPrincipal);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        


        public async Task<IActionResult> StopImpersonation()
        {
           
            if (!User.HasClaim("IsImpersonating", "true"))
            {
                throw new Exception("You are not impersonating now. Can't stop impersonation");
            }

            var originalUserId = User.FindFirst("OriginalUserId").Value;

            var originalUser = await _userManager.FindByIdAsync(originalUserId);

            await _signInManager.SignOutAsync();

            await _signInManager.SignInAsync(originalUser, isPersistent: true);

            return RedirectToAction("Index", "Home");
        }


        public IActionResult searchCompanyAccount(string term)

        {
            List<CompanyAccount> companyAccountList = _companyAccountRepository.GetAllCompanyAccounts().Where(account => account.CompanyName.ToLower().Contains(term.ToLower())).ToList();
            List<CompanyAccountResultViewModel> data = new List<CompanyAccountResultViewModel>();

            foreach (var companyAccount in companyAccountList)
            {
                CompanyAccountResultViewModel outputModel = new CompanyAccountResultViewModel();

                outputModel.label = companyAccount.CompanyName;

                outputModel.value = companyAccount.companyAccountId.ToString();

                data.Add(outputModel);
            }

            return Json(data);
        }

        [HttpPost]
        public IActionResult getUsersForCompanyAccount(ImpersonateCustomerUserViewModel model, CompanyAccount companyAccount)
        {
            List<CompanyAccountUserModel> companyAccountUserList = new List<CompanyAccountUserModel>();
            if (ModelState.IsValid)
            {
                if(! string.IsNullOrEmpty(model.companyAccountId))
                {
                    List<RelateCompanyAccountWithUser> relationList = _relateCompanyAccountWithUserRepository.GetAllRelateCompanyAccountWithUser().Where(relation => relation.companyAccount.ToString().Equals(model.companyAccountId)).ToList();

                    foreach(var companyAccountUserRelation in relationList)
                    {
                        if (!string.IsNullOrEmpty(companyAccountUserRelation.user))
                        {
                            IdentityUser user = _userManager.FindByIdAsync(companyAccountUserRelation.user).Result;
                            if (user != null)
                            {
                                CompanyAccountUserModel companyAccountUserModel = new CompanyAccountUserModel();
                                companyAccountUserModel.UserID = user.Id;
                                companyAccountUserModel.UserName = user.UserName;

                                companyAccountUserList.Add(companyAccountUserModel);
                            }
                        }
                       
                    }
                }
            }

           return Json (companyAccountUserList);
        }

        public IActionResult searchUser(string term)
        {
            List<UserModel> userserList = new List<UserModel>();

            List<IdentityUser> userList = _userManager.Users.Where(user => user.UserName.Contains(term)).ToList();

            foreach (var user in userList)
            {
                UserModel userModel = new UserModel();
                userModel.value = user.Id;
                userModel.label = user.UserName;

                userserList.Add(userModel);
            }

            return Json(userserList);
        }

        public class UserModel
        {
            public string label { get; set; }
            public string value { get; set; }
        }

        public class CompanyAccountUserModel
        {
            public string UserName { get; set; }
            public string UserID { get; set; }
        }

        

        public class CompanyAccountResultViewModel
        {
            public string label { get; set; }
            public string value { get; set; }
        }
    }
}
