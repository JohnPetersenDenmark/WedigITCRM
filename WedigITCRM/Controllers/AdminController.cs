using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WedigITCRM.Utilities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WedigITCRM.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {

        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        IRelateCompanyAccountWithUserRepository _relateCompanyAccountWithUserRepository;
        ICompanyAccountRepository _CompanyAccountRepository;
        IWebHostEnvironment _env;
        MiscUtility miscUtility;
       

        public AdminController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IRelateCompanyAccountWithUserRepository relateCompanyAccountWithUserRepository, ICompanyAccountRepository CompanyAccountRepository, IWebHostEnvironment env)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _relateCompanyAccountWithUserRepository = relateCompanyAccountWithUserRepository;
            _env = env;
            _CompanyAccountRepository = CompanyAccountRepository;
            miscUtility = new MiscUtility();
        }


        public IActionResult ShowUsers()
        {
            return View();
        }

        public async Task<IActionResult> GetUsers(CompanyAccount companyAccount)
        {
           
                List<RelateCompanyAccountWithUser> userWithCompanyAccountRelations = new List<RelateCompanyAccountWithUser>();

                if(User.IsInRole("SystemAdministrator"))
                {
                    userWithCompanyAccountRelations = _relateCompanyAccountWithUserRepository.GetAllRelateCompanyAccountWithUser().ToList();
                }
                else
                {
                    userWithCompanyAccountRelations = _relateCompanyAccountWithUserRepository.GetAllRelateCompanyAccountWithUser().Where(x => x.companyAccount == companyAccount.companyAccountId).ToList();
                }
                

                List<UserModel> userModel = new List<UserModel>();

                foreach (var userWithCompanyAccountRelation in userWithCompanyAccountRelations)
                {
                    IdentityUser user = await userManager.FindByIdAsync(userWithCompanyAccountRelation.user);
                    if (user != null)
                    {
                        UserModel userEntity = new UserModel();
                        userEntity.Id = user.Id;
                        userEntity.Email = user.Email;
                        userEntity.Name = user.Email;
                        userEntity.CompanyUserName = userWithCompanyAccountRelation.userName;
                        userEntity.DT_RowId = user.Id.ToString();
                        userEntity.userId = user.Id;



                        IList<string> roleNames = await userManager.GetRolesAsync(user);


                        foreach (var roleName in roleNames)
                        {
                            IdentityRole identityRole = await roleManager.FindByNameAsync(roleName);
                            if (identityRole != null)
                            {
                                // userEntity.roles.Add(identityRole);
                            }
                        }
                        userModel.Add(userEntity);
                    }
                }

                return Json(userModel);

           
        }

        //This action at EditCompany can bind JSON 
        [HttpPost]

        public async Task<IActionResult> EditUser([FromBody] UserModel model, CompanyAccount companyAccount)
        {

            if (ModelState.IsValid)
            {
                if (model.Action.Equals("edit"))
                {
                    var user = await userManager.FindByIdAsync(model.Id);


                    if (user != null)
                    {
                        user.Email = model.Email;
                        user.UserName = model.Email;

                        var result = await userManager.UpdateAsync(user);

                        if (result.Succeeded)
                        {
                            var relateCompanyAccountWithUsers = _relateCompanyAccountWithUserRepository.GetAllRelateCompanyAccountWithUser().Where(u => u.user.Equals(user.Id)).ToList();
                            if (relateCompanyAccountWithUsers.Count == 1)
                            {
                                RelateCompanyAccountWithUser RelateCompanyAccountWithUser = relateCompanyAccountWithUsers.First();
                                RelateCompanyAccountWithUser.userName = model.CompanyUserName;
                                _relateCompanyAccountWithUserRepository.Update(RelateCompanyAccountWithUser);
                            }
                            //return RedirectToAction("ListUsers");
                        }
                        else
                        {
                            UserOutputDataModel errorModel = new UserOutputDataModel();
                            foreach (var error in result.Errors)
                            {
                                string fieldName = miscUtility.GetFieldRelatedIdentityUserError(error);
                                ErrorFieldOutputModel ErrorFieldModel = new ErrorFieldOutputModel();
                                ErrorFieldModel.Name = fieldName;
                                ErrorFieldModel.Status = error.Description;
                                errorModel.fieldErrors.Add(ErrorFieldModel);
                            }
                            errorModel.data.Add(model);
                            return Json(errorModel);
                        }
                    }
                    else
                    {
                        //user not found
                    }
                }

                if (model.Action.Equals("create"))
                {
                    if (companyAccount != null)
                    {
                        var newUser = new IdentityUser { UserName = model.Email, Email = model.Email };
                        var result = await userManager.CreateAsync(newUser, model.Password);
                        if (result.Succeeded)
                        {
                            RelateCompanyAccountWithUser relateCompanyAccountWithUser = new RelateCompanyAccountWithUser();
                            relateCompanyAccountWithUser.user = newUser.Id;
                            relateCompanyAccountWithUser.userName = model.CompanyUserName;
                            relateCompanyAccountWithUser.companyAccount = companyAccount.companyAccountId;
                            relateCompanyAccountWithUser.CompanyName = companyAccount.CompanyName;
                            _relateCompanyAccountWithUserRepository.Add(relateCompanyAccountWithUser);

                            //return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            UserOutputDataModel errorModel = new UserOutputDataModel();
                            foreach (var error in result.Errors)
                            {
                                string fieldName = miscUtility.GetFieldRelatedIdentityUserError(error);
                                ErrorFieldOutputModel ErrorFieldModel = new ErrorFieldOutputModel();                               
                                ErrorFieldModel.Name = fieldName;
                                ErrorFieldModel.Status = error.Description;                                
                                errorModel.fieldErrors.Add(ErrorFieldModel);
                            }
                            errorModel.data.Add(model);
                            return Json(errorModel);
                        }

                    }
                }

                if (model.Action.Equals("remove"))
                {
                    var user = await userManager.FindByIdAsync(model.Id);
                    if (user != null)
                    {
                        var result = await userManager.DeleteAsync(user);

                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }
            }


            UserOutputDataModel outputModel = new UserOutputDataModel();

            outputModel.data.Add(model);

            return Json(outputModel);
        }

        public class ErrorOutputModelAAA
        {
            public ErrorOutputModelAAA()
            {
                this.fieldErrors = new List<ErrorFieldOutputModel>();
            }
            public List<ErrorFieldOutputModel> fieldErrors { get; set; }
           
        }
        public class ErrorFieldOutputModel
        {
            public string Name { get; set; }
            public string Status { get; set; }
        }
        public class UserOutputDataModel
        {
            public UserOutputDataModel()
            {
                this.data = new List<UserModel>();
                this.fieldErrors = new List<ErrorFieldOutputModel>();
            }
            public List<UserModel> data { get; set; }
            public List<ErrorFieldOutputModel> fieldErrors { get; set; }

        }
        public class UserModel
        {
            public string DT_RowId { get; set; }
            public string Action { get; set; }
            public string Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string CompanyUserName { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
            public string userId { get; set; }


        }

        public IActionResult ShowRoles(CompanyAccount companyAccount)
        {
            return View();
        }

        public IActionResult AdministrateRolesOnUser(CompanyAccount companyAccount)
        {
            return View();
        }

        public IActionResult GetRoles(CompanyAccount companyAccount)
        {

            IEnumerable<IdentityRole> model = roleManager.Roles.ToList().Where( role => !role.Name.Equals("SystemAdministrator"));
            return Json(model);
        }

        public async Task<IActionResult> EditRole([FromBody] RoleModel model, CompanyAccount companyAccount)
        {

            if (ModelState.IsValid)
            {
                if (model.Action.Equals("edit"))
                {
                    IdentityRole role = await roleManager.FindByIdAsync(model.Id);

                    if (role != null)
                    {
                        IdentityRole tmpRole = await roleManager.FindByNameAsync(model.Name);
                        if (tmpRole != null)
                        {
                            if (tmpRole.Id.Equals(role.Id))
                            {

                                role.Name = model.Name;
                                var updatedRole = roleManager.UpdateAsync(role);
                            }
                            else
                            {
                                RoleOutputDataModel errorModel = new RoleOutputDataModel();
                               
                                   
                                    ErrorFieldOutputModel ErrorFieldModel = new ErrorFieldOutputModel();
                                    ErrorFieldModel.Name = "name";
                                ErrorFieldModel.Status = "Der findes allerede en rolle med navnet: " + model.Name;
                                    errorModel.fieldErrors.Add(ErrorFieldModel);
                                
                                errorModel.data.Add(model);
                                return Json(errorModel);
                            }
                        }
                        else
                        {

                            role.Name = model.Name;
                            var updatedRole = await roleManager.UpdateAsync(role);
                        }

                    }
                }

                if (model.Action.Equals("create"))
                {
                    IdentityRole identityRole = new IdentityRole
                    {
                        Name = model.Name
                    };

                    IdentityResult result = await roleManager.CreateAsync(identityRole);

                    if (!result.Succeeded)
                    {
                        RoleOutputDataModel errorModel = new RoleOutputDataModel();
                        foreach (var error in result.Errors)
                        {
                            string fieldName = miscUtility.GetFieldRelatedIdentityUserError(error);
                            ErrorFieldOutputModel ErrorFieldModel = new ErrorFieldOutputModel();
                            ErrorFieldModel.Name = fieldName;
                            ErrorFieldModel.Status = error.Description;
                            errorModel.fieldErrors.Add(ErrorFieldModel);
                        }
                        errorModel.data.Add(model);
                        return Json(errorModel);
                    }
                }

                if (model.Action.Equals("remove"))
                {
                    IdentityRole role = await roleManager.FindByIdAsync(model.Id);

                    if (role != null)
                    {
                        var result = await roleManager.DeleteAsync(role);

                        if (!result.Succeeded)
                        {
                            ModelState.AddModelError("", "Kan ikke slette rolle: " + role.Name);
                        }
                    }
                }
            }


            RoleOutputDataModel outputModel = new RoleOutputDataModel();

            outputModel.data.Add(model);

            return Json(outputModel);
        }

        public class RoleOutputDataModel
        {
            public RoleOutputDataModel()
            {
                this.data = new List<RoleModel>();
                this.fieldErrors = new List<ErrorFieldOutputModel>();
            }
            public List<RoleModel> data { get; set; }
            public List<ErrorFieldOutputModel> fieldErrors { get; set; }

        }
        public class RoleModel
        {
            public string DT_RowId { get; set; }
            public string Action { get; set; }
            public string Id { get; set; }
            public string Name { get; set; }
            public string userId { get; set; }
            public int active { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> GetRolesForUser(string userId, CompanyAccount companyAccount)
        {
            RoleOutputDataModel outputModel = new RoleOutputDataModel();

            IdentityUser user = null;
            if (!string.IsNullOrEmpty(userId))
            {
                user = await userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    foreach (var role in roleManager.Roles)
                    {
                        if (!role.Name.Equals("SystemAdministrator"))
                        {
                            RoleModel roleModel = new RoleModel();

                            roleModel.DT_RowId = role.Id;
                            roleModel.Name = role.Name;
                            roleModel.Id = role.Id;

                            roleModel.userId = user.Id;
                            if (await userManager.IsInRoleAsync(user, role.Name))
                            {
                                roleModel.active = 1;
                            }
                            else
                            {
                                roleModel.active = 0;
                            }
                            outputModel.data.Add(roleModel);
                        }
                    }
                }
            }


            if (outputModel.data.Count == 0)
            {
               // outputModel.data.Add(new RoleModel { });
            }

            return Json(outputModel);
        }

        public async Task<IActionResult> AddOrRemoveRoleForUser([FromBody]RoleModel roleModel, CompanyAccount companyAccount)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = null;
                if (!string.IsNullOrEmpty(roleModel.userId))
                {
                    user = await userManager.FindByIdAsync(roleModel.userId);
                    if (user != null)
                    {
                        IdentityRole role = await roleManager.FindByIdAsync(roleModel.Id);
                        if (role != null)
                        {
                            var userHasRoleNames = await userManager.GetRolesAsync(user);

                            var roleList = userHasRoleNames.ToList<string>().Where(tmpRole => tmpRole.Equals(role.Name)).ToList();
                            if (roleList.Count == 0)
                            {
                                if (roleModel.active == 1)
                                {
                                    List<string> rolesList = new List<string>();
                                    rolesList.Add(role.Name);
                                    var roleArray = rolesList.ToArray<string>();
                                    var result = await userManager.AddToRolesAsync(user, roleArray);
                                }
                            }
                            else
                            {
                                if (roleModel.active == 0)
                                {
                                    List<string> rolesList = new List<string>();
                                    rolesList.Add(role.Name);
                                    var roleArray = rolesList.ToArray<string>();
                                    var result = await userManager.RemoveFromRolesAsync(user, roleArray);
                                }
                            }
                        }
                    }
                }
            }
            return Json(roleModel);
        }

       
    }
}
