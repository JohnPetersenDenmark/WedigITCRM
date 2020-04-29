using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WedigITCRM.Models;
using WedigITCRM.ViewControllers;
using X.PagedList.Mvc.Core;  // https://github.com/dncuug/X.PagedList
using X.PagedList;          // https://github.com/dncuug/X.PagedList
using WedigITCRM.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Hosting;
using System.Net.Mail;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WedigITCRM.Controllers
{
    [Authorize]
    public class AdministrationController : Controller
    {
        private ILogger<AdministrationController> _logger;
        private ILogger<EmailUtility> _emailUtilitylogger;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        IRelateCompanyAccountWithUserRepository _relateCompanyAccountWithUserRepository;      
        ICompanyAccountRepository _CompanyAccountRepository;
        Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        int ElementsPerPage = 5;

        public AdministrationController(ILogger<EmailUtility> emailUtilitylogger, ILogger<AdministrationController> logger, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IRelateCompanyAccountWithUserRepository relateCompanyAccountWithUserRepository,  ICompanyAccountRepository CompanyAccountRepository, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _relateCompanyAccountWithUserRepository = relateCompanyAccountWithUserRepository;
            _env = env;            
            _CompanyAccountRepository = CompanyAccountRepository;
            _logger = logger;
            _emailUtilitylogger = emailUtilitylogger;
        }

        [HttpGet]
        [Authorize(Roles = "SystemAdministrator")]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "SystemAdministrator")]
        public async Task<IActionResult> CreateRole(CreateRoleViewController model)
        {
            if (ModelState.IsValid)
            {
                // We just need to specify a unique role name to create a new role
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                // Saves the role in the underlying AspNetRoles table
                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "Administration");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }


        [HttpGet]
        [Authorize(Roles = "SystemAdministrator")]
        public async Task<IActionResult> EditRole(string id)
        {
            // Find the role by Role ID
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }

            
            var model = new EditRoleViewModel();

            model.role = role;


            // Retrieve all the Users 
            foreach (var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.userswithTheRole.Add(user);
                }
            }

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "SystemAdministrator")]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.role.Id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {model.role.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                role.Name = model.role.Name;
                // Update the Role using UpdateAsync
                var result = await roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }

        [Authorize(Roles = "SystemAdministrator")]
        public async Task<IActionResult> RoleDetails(string id)
        {
            // Find the role by Role ID
            var role = await roleManager.FindByIdAsync(id);

          

            var model = new DetailsRoleViewModel();
            model.role = role;

            List<IdentityUser> users = new List<IdentityUser>();


            // Retrieve all the Users 
            foreach (var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    users.Add(user);
                }
            }

            model.userswithTheRole = users;

            return View(model);
        }


        [HttpGet]
        [Authorize(Roles = "SystemAdministrator, Admin")]       
        public async Task<IActionResult> ListUsers(string searchBy, string searchString, int? Page, string sortColumn, string sortDirection, CompanyAccount companyAccount)
        {
            List<RelateCompanyAccountWithUser> userWithCompanyAccountRelations = _relateCompanyAccountWithUserRepository.GetAllRelateCompanyAccountWithUser().Where(x => x.companyAccount == companyAccount.companyAccountId).ToList();

            List<ExtendingdentityUser> userList = new List<ExtendingdentityUser>();
           

            foreach (var userWithCompanyAccountRelation in userWithCompanyAccountRelations)
            {
                IdentityUser user = await userManager.FindByIdAsync(userWithCompanyAccountRelation.user);
                if (user != null)
                {
                    ExtendingdentityUser xtendingdentityUser = new ExtendingdentityUser();
                    xtendingdentityUser.User = user;
                    xtendingdentityUser.userName = userWithCompanyAccountRelation.userName;
                    userList.Add(xtendingdentityUser);             
                }
               
            }

            IEnumerable<ExtendingdentityUser> model = userList.AsEnumerable();

            if (String.IsNullOrEmpty(searchString))
            {
                model = model.OrderBy(user => user.User.UserName);
            }
            else
            {
                switch (searchBy)
                {

                    case "Name":
                        model = model.Where(s => s.userName != null && s.userName.Contains(searchString));
                        break;

                    case "UserName":
                        model = model.Where(s => s.User.UserName != null && s.User.UserName.Contains(searchString));
                        break;

                    case "Email":
                        model = model.Where(s => s.User.Email != null && s.User.Email.Contains(searchString));
                        break;

                    case "UserId":
                        model = model.Where(s => s.User.Id != null && s.User.Id.Contains(searchString));
                        break;

                    default:
                        break;
                }

            }


            if (!String.IsNullOrEmpty(sortColumn))
            {
                switch (sortColumn)
                {
                    case "Name":
                        if (sortDirection.Equals("Ascending"))
                        {
                            model = model.OrderBy(s => s.userName);
                        }
                        else
                        {
                            model = model.OrderByDescending(s => s.userName);
                        }
                        break;

                    case "UserName":
                        if (sortDirection.Equals("Ascending"))
                        {
                            model = model.OrderBy(s => s.User.UserName);
                        }
                        else
                        {
                            model = model.OrderByDescending(s => s.User.UserName);
                        }
                        break;
                    case "Email":
                        if (sortDirection.Equals("Ascending"))
                        {
                            model = model.OrderBy(s => s.User.Email);
                        }
                        else
                        {
                            model = model.OrderByDescending(s => s.User.Email);
                        }
                        break;
                    case "UserId":
                        if (sortDirection.Equals("Ascending"))
                        {
                            model = model.OrderBy(s => s.User.Id);
                        }
                        else
                        {
                            model = model.OrderByDescending(s => s.User.Id);
                        }
                        break;
                    default:
                        model = model.OrderBy(s => s.User.UserName);
                        break;
                }

            }
            else
            {
                model = model.OrderBy(s => s.User.UserName);
            }

            ListUsersViewModel listUsersViewModel = new ListUsersViewModel();
            listUsersViewModel.users = model.ToList().ToPagedList(Page ?? 1, ElementsPerPage);
            listUsersViewModel.searchString = searchString;
            listUsersViewModel.searchBy = searchBy;
            listUsersViewModel.sortDirection = sortDirection;
            listUsersViewModel.sortColumn = sortColumn;
            return View(listUsersViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "SystemAdministrator")]
        public async Task<IActionResult> ListRoles()
        {
            IEnumerable<IdentityRole> model = roleManager.Roles.AsEnumerable();

            return View(model);
        }

        [Authorize(Roles = "SystemAdministrator, Admin")]
        public async Task<IActionResult> UserDetails(string id)
        {
            IdentityUser user = await userManager.FindByIdAsync(id);

            DetailsUserViewModel detailsUserViewModel = new DetailsUserViewModel();

            detailsUserViewModel.user = user;

            var relateCompanyAccountWithUsers = _relateCompanyAccountWithUserRepository.GetAllRelateCompanyAccountWithUser().Where(u => u.user.Equals(user.Id)).ToList();
            if (relateCompanyAccountWithUsers.Count == 1) 
            {
                RelateCompanyAccountWithUser RelateCompanyAccountWithUser = relateCompanyAccountWithUsers.First();
                detailsUserViewModel.userName = RelateCompanyAccountWithUser.userName;
            }
           


            IList<string> roleNames = await userManager.GetRolesAsync(user);
            List<IdentityRole> rolesList = new List<IdentityRole>();

            foreach (var roleName in roleNames)
            {
                IdentityRole identityRole = await roleManager.FindByNameAsync(roleName);
                if (identityRole != null)
                {
                    rolesList.Add(identityRole);

                }
            }

            detailsUserViewModel.Roles = rolesList;

            return View("Views/Administration/DetailsUser.cshtml", detailsUserViewModel);
        }


        [HttpGet]
        [Authorize(Roles = "SystemAdministrator, Admin")]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }

            EditUserViewModel editUserViewModel = new EditUserViewModel();
            editUserViewModel.user = user;

            var relateCompanyAccountWithUsers = _relateCompanyAccountWithUserRepository.GetAllRelateCompanyAccountWithUser().Where(u => u.user.Equals(user.Id)).ToList();
            if (relateCompanyAccountWithUsers.Count == 1)
            {
                RelateCompanyAccountWithUser RelateCompanyAccountWithUser = relateCompanyAccountWithUsers.First();
                editUserViewModel.userName = RelateCompanyAccountWithUser.userName;
            }

            IList<string> roleNames = await userManager.GetRolesAsync(user);
            List<IdentityRole> rolesList = new List<IdentityRole>();

            foreach (var roleName in roleNames)
            {
                IdentityRole identityRole = await roleManager.FindByNameAsync(roleName);
                if (identityRole != null)
                {
                    rolesList.Add(identityRole);
                }
            }
            editUserViewModel.Roles = rolesList;

            return View("Views/Administration/EditUser.cshtml", editUserViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "SystemAdministrator, Admin")]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.user.Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.user.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                user.Email = model.user.Email;
                user.UserName = model.user.UserName;


                var result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    var relateCompanyAccountWithUsers = _relateCompanyAccountWithUserRepository.GetAllRelateCompanyAccountWithUser().Where(u => u.user.Equals(user.Id)).ToList();
                    if (relateCompanyAccountWithUsers.Count == 1)
                    {
                        RelateCompanyAccountWithUser RelateCompanyAccountWithUser = relateCompanyAccountWithUsers.First();
                        RelateCompanyAccountWithUser.userName = model.userName;
                        _relateCompanyAccountWithUserRepository.Update(RelateCompanyAccountWithUser);
                    }
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }

        [Authorize(Roles = "SystemAdministrator, Admin")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("ListUsers");
            }
        }

        [HttpGet]
        [Authorize(Roles = "SystemAdministrator")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = await roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("ListRoles");
            }
        }


        [HttpGet]
        [Authorize(Roles = "SystemAdministrator, Admin")]
        public async Task<IActionResult> EditUsersInRole(string roleId, CompanyAccount companyAccount)
        {
            ViewBag.roleId = roleId;

            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }

            

            UserRoleViewModel userRoleViewModel = new UserRoleViewModel();

            userRoleViewModel.role = role;

            foreach (var user in userManager.Users)
            {

                CompanyAccount companyAccountForUser = GetCompanyAccountForUser(user.Id);

                
                    if (companyAccountForUser.companyAccountId == companyAccount.companyAccountId)
                    {
                        userRoleViewModel.users.Add(user);

                        if (await userManager.IsInRoleAsync(user, role.Name))
                        {
                            userRoleViewModel.IsSelected.Add(true);
                        }
                        else
                        {
                            userRoleViewModel.IsSelected.Add(false);
                        }
                    }
            }

            return View(userRoleViewModel);
        }



        [HttpPost]
        [Authorize(Roles = "SystemAdministrator, Admin")]
        public async Task<IActionResult> EditUsersInRole(UserRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.role.Id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {model.role.Id} cannot be found";
                return View("NotFound");
            }

            for (int i = 0; i < model.users.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model.users[i].Id);

                IdentityResult result = null;

                if (model.IsSelected[i] && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model.IsSelected[i] && await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.users.Count - 1))
                        continue;
                    else
                        return RedirectToAction("EditRole", new { Id = model.role.Id });
                }
            }

            return RedirectToAction("EditRole", new { Id = model.role.Id });
        }

        [HttpGet]
        [Authorize(Roles = "SystemAdministrator, Admin")]
        public async Task<IActionResult> ManageUserRoles(string userId)
        {
            ViewBag.userId = userId;

            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            var model = new List<UserRolesViewModel>();

            foreach (var role in roleManager.Roles)
            {
                var userRolesViewModel = new UserRolesViewModel
                {

                    RoleId = role.Id,
                    RoleName = role.Name
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.IsSelected = true;
                }
                else
                {
                    userRolesViewModel.IsSelected = false;
                }

                model.Add(userRolesViewModel);
            }

            return View(model);
        }


        [HttpPost]
        [Authorize(Roles = "SystemAdministrator, Admin")]
        public async Task<IActionResult> ManageUserRoles(List<UserRolesViewModel> model, string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            var roles = await userManager.GetRolesAsync(user);
            var result = await userManager.RemoveFromRolesAsync(user, roles);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }

            result = await userManager.AddToRolesAsync(user,
                model.Where(x => x.IsSelected).Select(y => y.RoleName));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }

            return RedirectToAction("EditUser", new { Id = userId });
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult ChangePassword(string changepasswordemail)
        {
            ChangePasswordViewModel changePasswordViewModel = new ChangePasswordViewModel();

            if (!String.IsNullOrEmpty(changepasswordemail))
            {
                changePasswordViewModel.Email = changepasswordemail;
            }
            return View(changePasswordViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            GeneralReplyViewModel generalReplyViewModel = new GeneralReplyViewModel();

            IdentityUser user = await userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                // if (await userManager.IsEmailConfirmedAsync(user))
                // {
                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                var changePasswordUrl = Url.Action("EnterNewPassword", "Administration", new { email = model.Email, token = token }, Request.Scheme);
                Dictionary<string, string> tokens = new Dictionary<string, string>();
                tokens.Add("changePasswordUrl", changePasswordUrl);


                EmailUtility emailUtility = new EmailUtility(_emailUtilitylogger);

                AlternateView htmlView = emailUtility.getFormattedBodyByMailtemplate(EmailUtility.MailTemplateType.Resetpassword, _env, tokens);
                emailUtility.send(model.Email, "support@nyxium.dk",  "Ændring af kodeord.", htmlView, true);
                // }
            }

            generalReplyViewModel.PageTitle = "Der er nu sendt en email til dig.";
            generalReplyViewModel.ConfirmText = "I den fremsendte email skal du følge instruktionen.";
            return View("GeneralReply", generalReplyViewModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult EnterNewPassword(string email, string token)
        {

            if (String.IsNullOrEmpty(email) || String.IsNullOrEmpty(token))
            {
                ModelState.AddModelError("", "Email validering fejlede");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> EnterNewPassword(EnterNewPasswordViewModel model)
        {
            GeneralReplyViewModel generalReplyViewModel = new GeneralReplyViewModel();

            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByEmailAsync(model.email);
                if (user != null)
                {
                    var result = await userManager.ResetPasswordAsync(user, model.token, model.Password);
                    if (result.Succeeded)
                    {
                       
                        generalReplyViewModel.PageTitle = "Dit kodeord er ændret.";
                        generalReplyViewModel.ConfirmText = "Dit kodeord er ændret. Du kan nu logge ind via linket nedenfor";
                        generalReplyViewModel.LinkDescription1 = "Login";
                        generalReplyViewModel.LinkText1 = "Login";
                        generalReplyViewModel.Link1 =  Url.Action("Login", "Account"); 
                        return View("GeneralReply", generalReplyViewModel);
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                        return View(model);
                    }
                }
               
                generalReplyViewModel.PageTitle = "Fejl ved ændring af kodeord.";
                generalReplyViewModel.ConfirmText = "Du kan desværre ikke bruge det nye kodeord endnu.";  
                
                return View("GeneralReply", generalReplyViewModel);
            }

            return View(model);
        }

        public CompanyAccount GetCompanyAccountForUser(string userId)
        {
            CompanyAccount companyAccount = null;

            List<RelateCompanyAccountWithUser> relateCompanyAccountWithUsers = _relateCompanyAccountWithUserRepository.GetAllRelateCompanyAccountWithUser().Where(x => x.user.Equals(userId)).ToList();
            if (relateCompanyAccountWithUsers.Count == 1)
            {
                RelateCompanyAccountWithUser RelateCompanyAccountWithUser = relateCompanyAccountWithUsers.First();
                companyAccount = _CompanyAccountRepository.GetCompanyAccount(RelateCompanyAccountWithUser.companyAccount);
            }

            return companyAccount;
        }

       
    }


}
