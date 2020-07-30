using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using WedigITCRM.DineroAPI;
using WedigITCRM.EntitityModels;
using WedigITCRM.Models;
using WedigITCRM.StorageInterfaces;
using WedigITCRM.Utilities;
using WedigITCRM.ViewControllers;
using WedigITCRM.ViewModels;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WedigITCRM.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private EmailUtility _emailUtility;

        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        private ILogger<AccountController> _logger;
        private ICompanyAccountRepository _companyAccountRepository;
        private IContentTypeRepository _contentTypeRepository;
        private IAttachmentRepository _attachmentRepository;
        private IStockItemRepository _stockItemRepository;
        private ILicenseType _licenseTypeRepository;
        private ICompanyRepository _companyRepository;
        private IVendorRepository _vendorRepository;
        private readonly INyxiumSetupRepository _nyxiumSetupRepository;
        private IContactRepository _contactRepository;
        private IRelateCompanyAccountWithUserRepository _relateCompanyAccountWithUserRepository;
        private RoleManager<IdentityRole> _roleManager;
        private IWebHostEnvironment _env;
        private MiscUtility miscUtility;

        public AccountController(INyxiumSetupRepository nyxiumSetupRepository , IContactRepository contactRepository, IVendorRepository vendorRepository, EmailUtility emailUtility, IAttachmentRepository attachmentRepository, IContentTypeRepository contentTypeRepository, ILogger<AccountController> logger, ILicenseType licenseTypeRepository, IStockItemRepository stockItemRepository, ICompanyRepository companyRepository, RoleManager<IdentityRole> roleManager, ICompanyAccountRepository companyAccountRepository, IRelateCompanyAccountWithUserRepository relateCompanyAccountWithUserRepository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IWebHostEnvironment env)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _logger = logger;
            this._companyAccountRepository = companyAccountRepository;
            _companyRepository = companyRepository;
            _vendorRepository = vendorRepository;
            _nyxiumSetupRepository = nyxiumSetupRepository;
            _contactRepository = contactRepository;
            _stockItemRepository = stockItemRepository;
            _licenseTypeRepository = licenseTypeRepository;
            this._relateCompanyAccountWithUserRepository = relateCompanyAccountWithUserRepository;
            this._roleManager = roleManager;
            this._contentTypeRepository = contentTypeRepository;
            _attachmentRepository = attachmentRepository;
            _env = env;
            _emailUtility = emailUtility;

            miscUtility = new MiscUtility();

        }

           
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel model, CompanyAccount companyAccount)
        {
            if (ModelState.IsValid)
            {
                if (companyAccount != null)
                {
                    var newUser = new IdentityUser { UserName = model.Email, Email = model.Email };
                    var result = await userManager.CreateAsync(newUser, model.Password);
                    if (result.Succeeded)
                    {
                        RelateCompanyAccountWithUser relateCompanyAccountWithUser = new RelateCompanyAccountWithUser();
                        relateCompanyAccountWithUser.user = newUser.Id;
                        relateCompanyAccountWithUser.userName = model.UserName;
                        relateCompanyAccountWithUser.companyAccount = companyAccount.companyAccountId;
                        relateCompanyAccountWithUser.CompanyName = companyAccount.CompanyName;
                        _relateCompanyAccountWithUserRepository.Add(relateCompanyAccountWithUser);

                        //await signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string ReturnUrl)
        {
            LoginViewModel loginViewController = new LoginViewModel();
            loginViewController.ReturnUrl = ReturnUrl;

            loginViewController.ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            return View(loginViewController);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {

                //if (!ModelState.GetValidationState("LoginEmail").Equals(ModelValidationState.Invalid) && !ModelState.GetValidationState("LoginPassword").Equals(ModelValidationState.Invalid))
                //{
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.LoginRememberMe, false);


                if (result.Succeeded)
                {
                    IdentityUser loggedInUser = userManager.FindByNameAsync(model.Email).Result;

                    if (checkIfFreeTrialHasExpired(loggedInUser))
                    {
                        string OriginalActivationKey = getActivationKeyFromCompanyAccount(loggedInUser);

                        await signInManager.SignOutAsync();


                        LicenseSelectionModel licenseSelectionModel = new LicenseSelectionModel();
                        licenseSelectionModel.ActivationKey = OriginalActivationKey;

                        return View("~/Views/FrontPage/BuyLicense.cshtml", licenseSelectionModel);

                        // return RedirectToAction("BuyLicense", "frontpage");
                    }
                    else
                    {
                        _logger.LogInformation(model.Email + " has successfully logged in XXXXXX");
                        return RedirectToAction("Index", "Home");
                    }

                }

                ModelState.AddModelError("Email", "Fejl i kodeord eller email");
                model.ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
                // }

            }

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl });
            var properties = signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }



        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            LoginViewModel loginViewController = new LoginViewModel();

            loginViewController.ReturnUrl = returnUrl;
            loginViewController.ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();


            if (remoteError != null)
            {
                ModelState
                    .AddModelError(string.Empty, $"Error from external provider: {remoteError}");

                return View("Login", loginViewController);
            }

            // Get the login information about the user from the external login provider
            var info = await signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ModelState.AddModelError(string.Empty, "Error loading external login information.");
                return View("Login", loginViewController);
            }

            // If the user already has a login (i.e if there is a record in AspNetUserLogins
            // table) then sign-in the user with this external login provider
            var signInResult = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if (signInResult.Succeeded)
            {
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                var user = await userManager.FindByEmailAsync(email);
                if (checkIfFreeTrialHasExpired(user))
                {
                    await signInManager.SignOutAsync();
                    return RedirectToAction("BuyLicense", "frontpage");

                }
                else
                {
                    // return LocalRedirect(returnUrl);
                    return RedirectToAction("Index", "Home");
                }


            }

            else
            {
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                var user = await userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    ModelState.AddModelError("LoginEmail", "Bruger er ikke oprettet");
                    return View("Login", loginViewController);
                }

                // Add a login (i.e insert a row for the user in AspNetUserLogins table)
                await userManager.AddLoginAsync(user, info);
                await signInManager.SignInAsync(user, isPersistent: false);
                return LocalRedirect(returnUrl);

            }
          

        }



        [HttpGet]       
        public IActionResult NyxiumSetup()
        {
            NyxiumSetup nyxiumSetup;

            List<NyxiumSetup> nyxiumSetups = _nyxiumSetupRepository.GetAllNyxiumSetups().ToList();
            if (nyxiumSetups.Count > 0)
            {
                 nyxiumSetup = nyxiumSetups.First();              
            }
            else
            {
                 nyxiumSetup = new NyxiumSetup();               
            }

            return View(nyxiumSetup);
        }

        [HttpPost]
        public IActionResult NyxiumSetup(NyxiumSetup model)
        {
            NyxiumSetup nyxiumSetup = _nyxiumSetupRepository.GetNyxiumSetup(model.Id);
            if (nyxiumSetup == null)
            {
                nyxiumSetup = new NyxiumSetup();
                nyxiumSetup.DineroAPIOrganization = model.DineroAPIOrganization;
                nyxiumSetup.DineroAPIOrganizationKey = model.DineroAPIOrganizationKey;
                nyxiumSetup.NyxiumSubscription1DineroProductGuid = model.NyxiumSubscription1DineroProductGuid;
                nyxiumSetup.NyxiumSubscription2DineroProductGuid = model.NyxiumSubscription2DineroProductGuid;
                nyxiumSetup.NyxiumSubscription1NumberOfMonths = model.NyxiumSubscription1NumberOfMonths;
                nyxiumSetup.NyxiumSubscription2NumberOfMonths = model.NyxiumSubscription2NumberOfMonths;
                nyxiumSetup.NyxiumSubscriptionPricePerMonth = model.NyxiumSubscriptionPricePerMonth;
                nyxiumSetup.PaymentConditionType = model.PaymentConditionType;
                nyxiumSetup.PaymentConditionNumberOfDays = model.PaymentConditionNumberOfDays;

                NyxiumSetup nyxiumSetupNew = _nyxiumSetupRepository.Add(nyxiumSetup);

                return View(nyxiumSetupNew);
            }
            else
            {
                nyxiumSetup.DineroAPIOrganization = model.DineroAPIOrganization;
                nyxiumSetup.DineroAPIOrganizationKey = model.DineroAPIOrganizationKey;
                nyxiumSetup.NyxiumSubscription1DineroProductGuid = model.NyxiumSubscription1DineroProductGuid;
                nyxiumSetup.NyxiumSubscription2DineroProductGuid = model.NyxiumSubscription2DineroProductGuid;
                nyxiumSetup.NyxiumSubscription1NumberOfMonths = model.NyxiumSubscription1NumberOfMonths;
                nyxiumSetup.NyxiumSubscription2NumberOfMonths = model.NyxiumSubscription2NumberOfMonths;
                nyxiumSetup.NyxiumSubscriptionPricePerMonth = model.NyxiumSubscriptionPricePerMonth;
                nyxiumSetup.PaymentConditionType = model.PaymentConditionType;
                nyxiumSetup.PaymentConditionNumberOfDays = model.PaymentConditionNumberOfDays;

                _nyxiumSetupRepository.Update(nyxiumSetup);
            }

            return View(nyxiumSetup);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult registerCompanyAccount()
        {
            return View();

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> registerCompanyAccount(RegisterCompanyAccountModel model)
        {
            if (ModelState.IsValid)
            {
                
                List<Company> companies = _companyRepository.GetAllCompanies().Where(company => company.CVRNumber != null &&  company.CVRNumber.Equals(model.CVRNumber)).ToList();
                if (companies.Count > 0)
                {
                    ModelState.AddModelError("CVRNumber", "Der er allerede oprettet en konto med CVR-nummer: " + model.CVRNumber);
                    return View(model);
                }

                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    IdentityRole adminRole = _roleManager.FindByNameAsync("Admin").Result;
                    if (adminRole != null)
                    {
                        var result1 = userManager.AddToRoleAsync(user, adminRole.Name).Result;

                    }

                    LicenseType licenseType = null;
                    List<LicenseType> licenseTypes = _licenseTypeRepository.GetAllLicenseTypes().Where(tmplicenseType => tmplicenseType.Name.Equals("Free")).ToList();
                    if (licenseTypes.Count == 1)
                    {
                        licenseType = licenseTypes.First();
                    }

                    CompanyAccount companyAccount = new CompanyAccount();
                    companyAccount.registrationDate = DateTime.Now;
                    companyAccount.activationKey = Guid.NewGuid();
                    if (licenseType != null)
                    {
                        companyAccount.NyxiumLicenseTypeName = licenseType.Name;
                        companyAccount.NyxiumLicenseTypeId = licenseType.Id;
                    }

                    companyAccount.CompanyName = model.CompanyName;
                    companyAccount.CompanyCVRNumber = model.CVRNumber;
                    companyAccount.CompanyStreet = model.CompanyStreet;
                    companyAccount.CompanyZip = model.CompanyZip;
                    companyAccount.CompanyCity = model.CompanyCity;



                    companyAccount.SubscriptionCRM = true;
                    companyAccount.SubscriptionInventory = true;
                    companyAccount.SubscriptionProcurement = true;
                    companyAccount.Booking = true;
                    companyAccount.SubscriptionVendor = true;
                    companyAccount.SalesStatistic = true;



                    CompanyAccount TheNewCompanyAccount = _companyAccountRepository.Add(companyAccount);

                    RelateCompanyAccountWithUser relateCompanyAccountWithUser = new RelateCompanyAccountWithUser();
                    relateCompanyAccountWithUser.companyAccount = TheNewCompanyAccount.companyAccountId;
                    relateCompanyAccountWithUser.user = user.Id;
                    relateCompanyAccountWithUser.userName = model.UserName;
                    relateCompanyAccountWithUser.CompanyName = model.CompanyName;
                    

                    _relateCompanyAccountWithUserRepository.Add(relateCompanyAccountWithUser);

                    string tmp = "";
                    if (HttpContext.Request.IsHttps)
                    {
                        tmp = "https://";
                    }
                    else
                    {
                        tmp = "http://";
                    }
                    var host = HttpContext.Request.Host;

                    string hostname = host.Value;
                    string activateUrl = tmp + hostname + "/" + "account" + "/" + "activateCompanyAccount" + "/?" + "activationkey=" + companyAccount.activationKey;

                    Dictionary<string, string> tokens = new Dictionary<string, string>();
                    tokens.Add("activationUrl", activateUrl);
                    tokens.Add("userName", model.UserName);
                    tokens.Add("companyName", model.CompanyName);

                    //EmailUtility emailUtility = new EmailUtility();

                    // AlternateView htmlView = _emailUtility.getFormattedBodyByMailtemplate(EmailUtility.MailTemplateType.AccountConfirmation, _env, tokens);
                    AlternateView htmlView = _emailUtility.getFormattedBodyByMailtemplate(EmailUtility.MailTemplateType.AccountConfirmation,  tokens);
                    _emailUtility.send(model.Email, "support@nyxium.dk", "Oprettelse af konto i wedigitCRM", htmlView, true, null);

                    model.companyAccountEmailSent = true;
                    model.companyAccountEmailSentMessage = "Email er sendt til: " + model.Email;
                    return View(model);

                }

                foreach (var error in result.Errors)
                {
                    string fieldName = miscUtility.GetFieldRelatedIdentityUserError(error);
                    ModelState.AddModelError(fieldName, error.Description);
                }
            }
            return View(model);

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult activateCompanyAccount(string activationKey)
        {
            createCompanyAccountViewModel model = new createCompanyAccountViewModel();

            if (!String.IsNullOrEmpty(activationKey))
            {
                var result = _companyAccountRepository.GetAllCompanyAccounts().Where(s => s.activationKey.ToString().Equals(activationKey)).ToList();
                if (result.Count == 1)
                {
                    CompanyAccount companyAccount = result.First();

                    if (companyAccount.activationDate.ToString().Equals("01-01-0001 00:00:00"))
                    {
                        companyAccount.activationDate = DateTime.Now;
                        companyAccount.Companyidentifier = Guid.NewGuid().ToString();
                        CompanyAccount updatedCompanyAccount = _companyAccountRepository.Update(companyAccount);


                        // send email to wedigit employees
                        Dictionary<string, string> tokens = new Dictionary<string, string>();
                        tokens.Add("companyName", companyAccount.CompanyName);
                        tokens.Add("companyAccountId", updatedCompanyAccount.companyAccountId.ToString());

                  
                        AlternateView htmlView = _emailUtility.getFormattedBodyByMailtemplate(EmailUtility.MailTemplateType.AccountConfirmationToWedigit,  tokens);

                        string fixedsendToList = "johnpetersen1959@gmail.com,jp@wedigit.dk,kv@wedigit.dk,tj@wedigit.dk,ad@wedigit.dk";
                        _emailUtility.send(fixedsendToList, "support@nyxium.dk", "Oprettelse af konto i wedigitCRM", htmlView, true, null);
                        // DONE send email to wedigit employees


                        List<NyxiumSetup> nyxiumSetups = _nyxiumSetupRepository.GetAllNyxiumSetups().ToList();
                        if (nyxiumSetups.Count > 0)
                        {
                            NyxiumSetup nyxiumSetup = nyxiumSetups.First();
                            if (! string.IsNullOrEmpty(nyxiumSetup.DineroAPIOrganizationKey))
                            {
                                NyxiumCustomerHandling nyxiumCustomerHandling = new NyxiumCustomerHandling();
                                string dineroCustomerId = nyxiumCustomerHandling.createNyxiumCustomerInDinero(nyxiumSetup, companyAccount);
                                if (dineroCustomerId != null)
                                {
                                    string dineroInvoiceId =  nyxiumCustomerHandling.createInvoiceInDinero(dineroCustomerId, nyxiumSetup, 1);
                                }
                                
                            }

                        }

                        model.message = "Din konto er nu aktiveret. Du kan logge ind via knappen ovenfor";
                        model.errorNumber = 1;
                    }
                    else
                    {
                        model.errorNumber = 2;
                        model.message = "Din konto er allerede aktiveret. Du kan logge ind via knappen ovenfor";
                    }

                }
                else
                {
                    model.errorNumber = 3;
                    model.message = "Dit aktiveringslink var ikke korrekt.";
                }
            }
            else
            {
                model.errorNumber = 3;
                model.message = "Dit aktiveringslink mangler en aktiveringskode.";
            }

            return View("~/Views/Account/activateCompanyAccount.cshtml", model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Terms()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]

        public IActionResult CompanyAccountSettings(CompanyAccount companyAccount)
        {
            CompanyAccountSettingsViewModel companyAccountSettingsViewModel = new CompanyAccountSettingsViewModel();
            companyAccountSettingsViewModel.CompanyName = companyAccount.CompanyName;
            companyAccountSettingsViewModel.CompanyStreet = companyAccount.CompanyStreet;
            companyAccountSettingsViewModel.CompanyZip = companyAccount.CompanyZip;
            companyAccountSettingsViewModel.CompanyCity = companyAccount.CompanyCity;
            companyAccountSettingsViewModel.CompanyCountryCode = companyAccount.CompanyCountryCode;
            companyAccountSettingsViewModel.SubscriptionCRM = companyAccount.SubscriptionCRM;
            companyAccountSettingsViewModel.synchronizeCustomerFromNyxiumToDinero = companyAccount.synchronizeCustomerFromNyxiumToDinero;
            companyAccountSettingsViewModel.synchronizeCustomerFromDineroToNyxium = companyAccount.synchronizeCustomerFromDineroToNyxium;
            companyAccountSettingsViewModel.SubscriptionInventory = companyAccount.SubscriptionInventory;
            companyAccountSettingsViewModel.synchronizeStockItemFromNyxiumToDinero = companyAccount.synchronizeStockItemFromNyxiumToDinero;
            companyAccountSettingsViewModel.synchronizeStockItemFromDineroToNyxium = companyAccount.synchronizeStockItemFromDineroToNyxium;

            companyAccountSettingsViewModel.SubscriptionProcurement = companyAccount.SubscriptionProcurement;
            companyAccountSettingsViewModel.SubscriptionVendor = companyAccount.SubscriptionVendor;
            companyAccountSettingsViewModel.SalesStatistic = companyAccount.SalesStatistic;
            companyAccountSettingsViewModel.Booking = companyAccount.Booking;
            companyAccountSettingsViewModel.IntegrationDinero = companyAccount.IntegrationDinero;
            companyAccountSettingsViewModel.DineroAPIOrganizationKey = companyAccount.DineroAPIOrganizationKey;
            companyAccountSettingsViewModel.DineroAPIOrganization = companyAccount.DineroAPIOrganization;
            companyAccountSettingsViewModel.companyAccountId = companyAccount.companyAccountId;

            if (!string.IsNullOrEmpty(companyAccount.LogoAttachmentIds))
            {

                List<string> logoAttachedmentIdList = companyAccount.LogoAttachmentIds.Split(",").ToList();
                List<string> AttachedLogoFilesTypeIconPath = new List<string>();
                List<string> logoFilePathAndNameList = new List<string>();
                List<string> logoFileNameOnlyList = new List<string>();

                foreach (var attachmentId in logoAttachedmentIdList)
                {
                    WedigITCRM.EntitityModels.Attachment attachment = _attachmentRepository.GetAttachment(Int32.Parse(attachmentId));
                    if (attachment != null)
                    {
                        logoFileNameOnlyList.Add(attachment.OriginalFileName);
                        logoFilePathAndNameList.Add(attachment.uniqueInternalFileName);

                        Utilities.MiscUtility miscUtility = new Utilities.MiscUtility();
                        string iconFilePathAndName = miscUtility.getIconFilenameAndPath(attachment.ContentType, _contentTypeRepository);
                        AttachedLogoFilesTypeIconPath.Add(iconFilePathAndName);
                    }
                }

                companyAccountSettingsViewModel.ExistingLogoAttachedmentIds = string.Join(",", logoAttachedmentIdList);
                companyAccountSettingsViewModel.ExistinglogoFileNameOnly = string.Join(",", logoFileNameOnlyList);
                companyAccountSettingsViewModel.ExistingAttachedLogoTypeIconPath = string.Join(",", AttachedLogoFilesTypeIconPath);
                companyAccountSettingsViewModel.ExistingAttachedLogoFilesNameAndPath = string.Join(",", logoFilePathAndNameList);
            }
            else
            {

            }



            //companyAccountSettingsViewModel.LogoAttachedmentId = companyAccount.LogoAttachmentIds.Split(",").ToList(); ;
            //companyAccountSettingsViewModel.ExistingLogoAttachedmentIds = companyAccount.LogoAttachmentIds;

            //if (!string.IsNullOrEmpty(companyAccount.logoFileNameOnly))
            //{
            //    companyAccountSettingsViewModel.LogoAttachedmentId = companyAccount.LogoAttachmentIds.Split(",").ToList(); ;
            //    companyAccountSettingsViewModel.ExistingLogoAttachedmentIds = companyAccount.LogoAttachmentIds;
            //}

            return View(companyAccountSettingsViewModel);
        }

        [HttpPost]
        public IActionResult CompanyAccountSettings(CompanyAccountSettingsViewModel model)
        {
            if (ModelState.IsValid)
            {
                CompanyAccount companyAccount = _companyAccountRepository.GetCompanyAccount(model.companyAccountId);

                companyAccount.CompanyName = model.CompanyName;
                companyAccount.CompanyStreet = model.CompanyStreet;
                companyAccount.CompanyZip = model.CompanyZip;
                companyAccount.CompanyCity = model.CompanyCity;
                companyAccount.CompanyCountryCode = model.CompanyCountryCode;

                companyAccount.synchronizeCustomerFromNyxiumToDinero = model.synchronizeCustomerFromNyxiumToDinero;
                companyAccount.synchronizeCustomerFromDineroToNyxium = model.synchronizeCustomerFromDineroToNyxium;
                companyAccount.synchronizeStockItemFromNyxiumToDinero = model.synchronizeStockItemFromNyxiumToDinero;
                companyAccount.synchronizeStockItemFromDineroToNyxium = model.synchronizeStockItemFromDineroToNyxium;
                companyAccount.IntegrationDinero = model.IntegrationDinero;
                companyAccount.DineroAPIOrganizationKey = model.DineroAPIOrganizationKey;
                companyAccount.DineroAPIOrganization = model.DineroAPIOrganization;



                List<string> uniqueFileNameList = new List<string>();
                List<string> contentTypeList = new List<string>();
                List<string> attachmentIds = new List<string>();

                if (model.AttachedLogo != null && model.AttachedLogo.Count > 0)
                {


                    string uploadsFolder = _env.WebRootPath + "\\" + "CustomerAttachments" + "\\" + "Logos";
                    int i = 0;
                    string[] fileNameArray = model.logoFileNameOnly.ToArray();

                    foreach (var AttachedLogoFile in model.AttachedLogo)
                    {

                        string fileExtension = Path.GetExtension(fileNameArray[i]);

                        string uniqueFileName = companyAccount.companyAccountId.ToString() + "_" + Guid.NewGuid().ToString();
                        string filePath = uploadsFolder + "\\" + uniqueFileName + fileExtension;

                        uniqueFileNameList.Add(uniqueFileName);
                        contentTypeList.Add(AttachedLogoFile.ContentType);

                        WedigITCRM.EntitityModels.Attachment attachment = new WedigITCRM.EntitityModels.Attachment();
                        attachment.ContentType = AttachedLogoFile.ContentType;
                        attachment.length = AttachedLogoFile.Length;
                        attachment.OriginalFileName = fileNameArray[i];
                        attachment.uniqueInternalFileName = uniqueFileName + fileExtension; 
                        attachment.companyAccountId = companyAccount.companyAccountId;
                        WedigITCRM.EntitityModels.Attachment newAttachment = _attachmentRepository.Add(attachment);

                        attachmentIds.Add(newAttachment.Id.ToString());

                        FileStream fs = new FileStream(filePath, FileMode.Create);

                        AttachedLogoFile.CopyTo(fs);
                        fs.Close();

                        i++;
                    }
                }

                companyAccount.LogoAttachmentIds = string.Join(",", attachmentIds);
                _companyAccountRepository.Update(companyAccount);


                return RedirectToAction("Index", "Home");

            }

            return View(model);
        }

        [HttpPost]
        public IActionResult CopyCustomerFromDineroToNyxium(DummyModel model, CompanyAccount companyAccount)
        {
            DineroAPIConnect dineroAPIConnect = new DineroAPIConnect();
            if (dineroAPIConnect.connectToDinero(companyAccount.DineroAPIOrganizationKey, companyAccount.DineroAPIOrganization) != null)
            {
                DineroContacts dineroContacts = new DineroContacts(dineroAPIConnect);
                dineroContacts.CopyCustomersFromDinero(companyAccount, _companyRepository, _vendorRepository, _contactRepository);
                companyAccount.ContactsToNyxiumLastSynchronizationDate = DateTime.Now;
                _companyAccountRepository.Update(companyAccount);

            }
            return Json(model);
        }

        [HttpPost]
        public IActionResult CopyCustomerFromNyxiumToDinero(DummyModel model, CompanyAccount companyAccount)
        {
            DineroAPIConnect dineroAPIConnect = new DineroAPIConnect();
            if (dineroAPIConnect.connectToDinero(companyAccount.DineroAPIOrganizationKey, companyAccount.DineroAPIOrganization) != null)
            {
                DineroContacts dineroContacts = new DineroContacts(dineroAPIConnect);
                dineroContacts.CopyCustomersToDinero(companyAccount, _companyRepository);
                companyAccount.ContactsToDineroLastSynchronizationDate = DateTime.Now;
                _companyAccountRepository.Update(companyAccount);
            }
            return Json(model);
        }

        public IActionResult CopyStockItemFromNyxiumToDinero(DummyModel model, CompanyAccount companyAccount)
        {
            DineroAPIConnect dineroAPIConnect = new DineroAPIConnect();
            if (dineroAPIConnect.connectToDinero(companyAccount.DineroAPIOrganizationKey, companyAccount.DineroAPIOrganization) != null)
            {
                DineroStockItem dineroStockItem = new DineroStockItem(dineroAPIConnect);
                dineroStockItem.CopyAllStockItemsFromNyxiumToDinero(companyAccount, _stockItemRepository);
                companyAccount.StockItemsToDineroLastSynchronizationDate = DateTime.Now;
                _companyAccountRepository.Update(companyAccount);
            }

            return Json(model);
        }

        public IActionResult CopyStockItemFromDineroToNyxium(DummyModel model, CompanyAccount companyAccount)
        {

            DineroAPIConnect dineroAPIConnect = new DineroAPIConnect();
            if (dineroAPIConnect.connectToDinero(companyAccount.DineroAPIOrganizationKey, companyAccount.DineroAPIOrganization) != null)
            {
                DineroStockItem dineroStockItem = new DineroStockItem(dineroAPIConnect);
                dineroStockItem.CopyAllStockItemsFromDineroToNyxium(companyAccount, _stockItemRepository);
                companyAccount.StockItemsToNyxiumSynchronizationDate = DateTime.Now;
                _companyAccountRepository.Update(companyAccount);
            }

            return Json(model);
        }

        public class DummyModel
        {
            public string dummy { get; set; }
        }

        public bool checkIfFreeTrialHasExpired(IdentityUser curuser)
        {

            List<RelateCompanyAccountWithUser> relateCompanyAccountWithUsers = _relateCompanyAccountWithUserRepository.GetAllRelateCompanyAccountWithUser().Where(x => x.user.Equals(curuser.Id)).ToList();
            if (relateCompanyAccountWithUsers.Count == 1)
            {
                RelateCompanyAccountWithUser RelateCompanyAccountWithUser = relateCompanyAccountWithUsers.First();
                CompanyAccount companyAccount = _companyAccountRepository.GetCompanyAccount(RelateCompanyAccountWithUser.companyAccount);
                if (companyAccount != null)
                {
                    DateTime registrationDate = companyAccount.registrationDate;
                    DateTime dueDate = registrationDate.AddDays(31);
                    if (dueDate < DateTime.Now)
                    {
                        return true;
                    }
                    else
                    {
                        // return true;
                        return false;
                    }
                }

            }




            return false;
        }

        public string getActivationKeyFromCompanyAccount(IdentityUser curuser)
        {

            List<RelateCompanyAccountWithUser> relateCompanyAccountWithUsers = _relateCompanyAccountWithUserRepository.GetAllRelateCompanyAccountWithUser().Where(x => x.user.Equals(curuser.Id)).ToList();
            if (relateCompanyAccountWithUsers.Count == 1)
            {
                RelateCompanyAccountWithUser RelateCompanyAccountWithUser = relateCompanyAccountWithUsers.First();
                CompanyAccount companyAccount = _companyAccountRepository.GetCompanyAccount(RelateCompanyAccountWithUser.companyAccount);
                if (companyAccount != null)
                {
                    return (companyAccount.activationKey.ToString());
                }

            }
            return null;
        }



        [HttpPost]
        [AllowAnonymous]
        public IActionResult BuyLicense(LicenseSelectionModel model)
        {

            List<CompanyAccount> companyAccounts = _companyAccountRepository.GetAllCompanyAccounts().Where(companyAccount => companyAccount.activationKey.ToString().Equals(model.ActivationKey)).ToList();

            if (companyAccounts.Count == 1)
            {
                CompanyAccount companyAccount = companyAccounts.First();
                List<LicenseType> licenseTypes = _licenseTypeRepository.GetAllLicenseTypes().Where(licenseType => licenseType.Name.Equals(model.licenseType)).ToList();

                if (licenseTypes.Count == 1)
                {
                    LicenseType licenseType = licenseTypes.First();
                    companyAccount.NyxiumLicenseTypeId = licenseType.Id;
                    companyAccount.NyxiumLicenseTypeName = licenseType.Name;
                    companyAccount.AmountToPayForLicense = licenseType.SalesPriceMonthlyPayment;

                    companyAccount.SubscriptionCRM = false;
                    companyAccount.SubscriptionInventory = false;
                    companyAccount.Booking = false;
                    companyAccount.SubscriptionVendor = false;
                    companyAccount.SalesStatistic = false;

                    if (!string.IsNullOrEmpty(model.applications))
                    {
                        string[] SelectedApplicationArray = model.applications.Split(",");

                        foreach (var selectedApplication in SelectedApplicationArray)
                        {
                            switch (selectedApplication)
                            {
                                case "licenseCRM":
                                    companyAccount.SubscriptionCRM = true;
                                    break;
                                case "licenseInventory":
                                    companyAccount.SubscriptionInventory = true;
                                    break;
                                case "licenseBooking":
                                    companyAccount.Booking = true;
                                    break;
                                case "licenseVendors":
                                    companyAccount.SubscriptionVendor = true;
                                    break;
                                case "licenseStatistic":
                                    companyAccount.SalesStatistic = true;
                                    break;
                                default:
                                    // code block
                                    break;
                            }
                        }
                    }

                    _companyAccountRepository.Update(companyAccount);
                }



            }

            // ændring
            return Json(model);
        }


        [HttpGet]
        public FileResult openLogo(string Id, CompanyAccount companyAccount)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                WedigITCRM.EntitityModels.Attachment attachment = _attachmentRepository.GetAttachment(Int32.Parse(Id));
                if (attachment != null)
                {
                    string PDFUrl = _env.WebRootPath + "\\" + "CustomerAttachments" + "\\" + "Logos" + "\\" + attachment.uniqueInternalFileName;
                    byte[] FileBytes = System.IO.File.ReadAllBytes(PDFUrl);
                    return File(FileBytes, attachment.ContentType);
                }
            }
            return null;
        }


        public FileResult downloadLogo(string Id, CompanyAccount companyAccount)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                WedigITCRM.EntitityModels.Attachment attachment = _attachmentRepository.GetAttachment(Int32.Parse(Id));
                if (attachment != null)
                {
                    string filePathAndFileName = _env.WebRootPath + "\\" + "CustomerAttachments" + "\\" + "Logos" + "\\" + attachment.uniqueInternalFileName;
                    byte[] FileBytes = System.IO.File.ReadAllBytes(filePathAndFileName);
                    return File(FileBytes, "application/force-download", attachment.uniqueInternalFileName);
                }
            }
            return null;

        }


        public IActionResult deleteLogo(string Id, CompanyAccount companyAccount)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                WedigITCRM.EntitityModels.Attachment attachment = _attachmentRepository.GetAttachment(Int32.Parse(Id));
                if (attachment != null)
                {
                    string filePathAndFileName = _env.WebRootPath + "\\" + "CustomerAttachments" + "\\" + "Logos" + "\\" + attachment.uniqueInternalFileName;
                    if (System.IO.File.Exists(filePathAndFileName))
                    {
                        System.IO.File.Delete(filePathAndFileName);
                    }
                    _attachmentRepository.Delete(attachment.Id);

                    List<string> ExistingLogoAttachedmentIdsList = companyAccount.LogoAttachmentIds.Split(",").ToList();
                    int index = ExistingLogoAttachedmentIdsList.IndexOf(Id);

                    ExistingLogoAttachedmentIdsList.RemoveAt(index);

                    companyAccount.LogoAttachmentIds = string.Join(",", ExistingLogoAttachedmentIdsList.ToArray());

                    _companyAccountRepository.Update(companyAccount);
                }
            }
            return RedirectToAction("Index", "Note");
        }
     
        public class CompanyAccountResultViewModel
        {
            public string label { get; set; }
            public string value { get; set; }
        }

        public class LicenseSelectionModel
        {
            public string licenseType { get; set; }
            public string applications { get; set; }

            public string ActivationKey { get; set; }
        }
    }


}
