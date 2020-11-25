using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WedigITCRM.EntitityModels;
using WedigITCRM.Models;
using WedigITCRM.ReepayAPI;
using static WedigITCRM.ReepayAPI.ReepayAPIMethods;

namespace WedigITCRM.Controllers
{
    public class PaymentController : Controller
       
    {
        public ICompanyAccountRepository companyAccountRepository;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IOptions<NyxiumSubscriptionDiscounts> optionsNyxiumDiscounts;
        private readonly IOptions<NyxiumModule> optionsNyxiumModule;
        private IOptions<NyxiumSubscription> optionsNyxiumSubscription;

        public UserManager<IdentityUser> UserManager { get; }

        public PaymentController(IOptions<NyxiumSubscriptionDiscounts> optionsNyxiumDiscounts, IOptions<NyxiumModule> optionsNyxiumModule, IOptions<NyxiumSubscription> optionsNyxiumSubscription, ICompanyAccountRepository companyAccountRepository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.companyAccountRepository = companyAccountRepository;
            UserManager = userManager;
            this.signInManager = signInManager;
            this.optionsNyxiumDiscounts = optionsNyxiumDiscounts;
            this.optionsNyxiumModule = optionsNyxiumModule;
            this.optionsNyxiumSubscription = optionsNyxiumSubscription;
        }


        [HttpGet]

        public async Task<IActionResult> SelectNyxiumSubscription(int companyAccountId, string curUserEmail)
        {
            HttpClient httpClient = new HttpClient();

            ReepayAPIMethods repayMethods = new ReepayAPIMethods(httpClient);         

            SelectNyxiumSubscriptionViewModel selectNyxiumSubscriptionViewModel = new SelectNyxiumSubscriptionViewModel();

            selectNyxiumSubscriptionViewModel.NyxiumDiscounts = optionsNyxiumDiscounts.Value;

            selectNyxiumSubscriptionViewModel.NyxiumModules = optionsNyxiumModule.Value;

            selectNyxiumSubscriptionViewModel.CompanyAccountId = companyAccountId.ToString();

            selectNyxiumSubscriptionViewModel.curUserEmail = curUserEmail;

            foreach (var subscriptionType in optionsNyxiumSubscription.Value.Subscriptions)
            {
                NyxiumSubscriptionViewModel NyxiumSubscriptionViewModel = new NyxiumSubscriptionViewModel();
                NyxiumSubscriptionViewModel.Id = subscriptionType.Id;
                NyxiumSubscriptionViewModel.Name = subscriptionType.Name;
                NyxiumSubscriptionViewModel.NumberOfNyxiumModules = subscriptionType.NumberOfNyxiumModules;
                NyxiumSubscriptionViewModel.ReepaySubscriptionPlanHandle = subscriptionType.ReepaySubscriptionPlanHandle;

                ReepayPlanResponseModel SubscriptionPlan = await repayMethods.GetPlanById(subscriptionType.ReepaySubscriptionPlanHandle);
                if (SubscriptionPlan != null)
                {
                    string priceFormatted = SubscriptionPlan.Amount;
                    priceFormatted = priceFormatted.Insert(priceFormatted.Length -2, ",");
                    NyxiumSubscriptionViewModel.price = "DKK " + priceFormatted;

                    NyxiumSubscriptionViewModel.Description = SubscriptionPlan.Description;
                }



                selectNyxiumSubscriptionViewModel.NyxiumSubscriptions.Add(NyxiumSubscriptionViewModel);
            }

            return View(selectNyxiumSubscriptionViewModel);
        }

        [HttpGet]
        public IActionResult Subscription(RecurringPaymentViewModel model)
        {
            return View("~/Views/payment/Subscription.cshtml", model);
        }

        [HttpPost]   
        public async Task<IActionResult> SomeAction(SubscriptionSelectedModel model)
        {
            HttpClient httpClient = new HttpClient();

            ReepayAPIMethods repayMethods = new ReepayAPIMethods(httpClient);


            CompanyAccount companyAccount = companyAccountRepository.GetCompanyAccount(int.Parse(model.companyAccountId));

            IdentityUser currentUser = await UserManager.FindByNameAsync(model.curUserEmail);            
          
            RecurringRequestModel recurringModel = new RecurringRequestModel();

            recurringModel.CreateReepayCustomer.Handle = model.companyAccountId;
            recurringModel.CreateReepayCustomer.CustomerName = companyAccount.CompanyName;
            recurringModel.CreateReepayCustomer.CustomerStreet = companyAccount.CompanyStreet;
            recurringModel.CreateReepayCustomer.CustomerZip = companyAccount.CompanyZip;
            recurringModel.CreateReepayCustomer.CustomerCity = companyAccount.CompanyCity;
            recurringModel.CreateReepayCustomer.CustomerCVRNumber = companyAccount.CompanyCVRNumber;
            recurringModel.CreateReepayCustomer.CustomerCountryCode = companyAccount.CompanyCountryCode;

            recurringModel.CreateReepayCustomer.CustomerEmail = currentUser.Email;
            recurringModel.CreateReepayCustomer.CustomerLastName = currentUser.UserName;

            recurringModel.ButtonText = "Bliv medlem";



            var sessionModel = await repayMethods.GetRecurringSessionIdAsync(recurringModel);

            RecurringPaymentViewModel viewModel = new RecurringPaymentViewModel();
            viewModel.SessionId = sessionModel.SessionId;
            viewModel.ReepayPlanId = model.subscriptiontype;
            viewModel.ReepayDiscountId = model.ReepayDiscountId;
            viewModel.AcceptUrl = "/payment/accept";
            viewModel.CancelUrl = "https://tv2.dk";

            return Json(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Accept(PaymentAcceptModel model)
        {
            HttpClient httpClient = new HttpClient();

            ReepayAPIMethods repayMethods = new ReepayAPIMethods(httpClient);

            AddSubscription addSubscription = new AddSubscription();
            addSubscription.Plan = model.ReepayPlanId;
            addSubscription.Customer = model.customer;
            addSubscription.Source = model.payment_method;
            addSubscription.SignupMethod = "source";
            addSubscription.GenerateHandle = true;



            var noget = await repayMethods.AddSubscription(addSubscription);

            SubscriptionAddDiscount subscriptionAddDiscount = new SubscriptionAddDiscount();
            subscriptionAddDiscount.SubscriptionId = noget.SubscriptionId;
            subscriptionAddDiscount.DiscountHandle = model.ReepayDiscountId;
            var svar = await repayMethods.AddSubscriptionDiscount(subscriptionAddDiscount);





            return null;
        }

        public class SubscriptionAddDiscount
        {
            [JsonProperty("handle")]
            public string SubscriptionId { get; set; }

            [JsonProperty("discount")]
            public string DiscountHandle { get; set; }
        }

        public class SelectNyxiumSubscriptionViewModel
        {
            public SelectNyxiumSubscriptionViewModel()
            {
                this.NyxiumSubscriptions = new List<NyxiumSubscriptionViewModel>();
            }
            public List<NyxiumSubscriptionViewModel> NyxiumSubscriptions { get; set; }
            public NyxiumModule NyxiumModules { get; set; }
            public NyxiumSubscriptionDiscounts NyxiumDiscounts { get; set; }
            public string CompanyAccountId { get; set; }
            public string curUserEmail { get; set; }
            

        }

        public class SubscriptionSelectedModel
        {
            public string  subscriptiontype { get; set; }
            public string nyxiummodules { get; set; }
            public string ReepayDiscountId { get; set; }
            public string companyAccountId { get; set; }
            public string curUserEmail { get; set; }
        }

        public class NyxiumSubscriptionViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public string Description { get; set; }
            public int NumberOfNyxiumModules { get; set; }
            public string ReepaySubscriptionPlanHandle { get; set; }
            public string price { get; set; }

        }


            public class PaymentAcceptModel
        {
            public string id { get; set; }
            public string ReepayPlanId  { get; set; }
            public string ReepayDiscountId { get; set; }
            public string invoice { get; set; }
            public string customer { get; set; }
            public string subscription { get; set; }
            public string payment_method { get; set; }
            public string error { get; set; }
        }
        public partial class AddSubscription
        {
          

            [JsonProperty("plan")]
            public string Plan { get; set; }

            [JsonProperty("signup_method")]
            public string SignupMethod { get; set; }

            [JsonProperty("customer")]
            public string Customer { get; set; }

            [JsonProperty("generate_handle")]
            public bool GenerateHandle { get; set; }

            
           

            [JsonProperty("source")]
            public string Source { get; set; }
        }      

     
        
    }

  
}
