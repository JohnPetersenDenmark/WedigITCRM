using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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
        private readonly IOptions<NyxiumModule> optionsNyxiumModule;
        private IOptions<NyxiumSubscription> optionsNyxiumSubscription;

        public PaymentController(IOptions<NyxiumModule> optionsNyxiumModule, IOptions<NyxiumSubscription> optionsNyxiumSubscription, ICompanyAccountRepository companyAccountRepository)
        {
            this.companyAccountRepository = companyAccountRepository;
            this.optionsNyxiumModule = optionsNyxiumModule;
            this.optionsNyxiumSubscription = optionsNyxiumSubscription;
        }


        [HttpGet]

        public async Task<IActionResult> SelectNyxiumSubscription(CompanyAccount companyAccount)
        {
            HttpClient httpClient = new HttpClient();

            ReepayAPIMethods repayMethods = new ReepayAPIMethods(httpClient);

            ReepayPlanResponseModel[] reepayPlans =  await repayMethods.GetAllPlans();

            return View();
        }



        [HttpGet]
    
        public async Task<IActionResult> Subscription(CompanyAccount companyAccount )
        {
            HttpClient httpClient = new HttpClient();

            ReepayAPIMethods repayMethods = new ReepayAPIMethods(httpClient);



            RecurringRequestModel recurringModel = new RecurringRequestModel();

            recurringModel.CustomerId = "14038";
            recurringModel.ButtonText = "Bliv medlem";



            var sessionModel = await repayMethods.GetRecurringSessionIdAsync(recurringModel);

            RecurringPaymentViewModel viewModel = new RecurringPaymentViewModel();
            viewModel.SessionId = sessionModel.SessionId;
            viewModel.AcceptUrl = "/payment/accept";
            viewModel.CancelUrl = "https://tv2.dk";

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Accept(PaymentAcceptModel model)
        {
            HttpClient httpClient = new HttpClient();

            ReepayAPIMethods repayMethods = new ReepayAPIMethods(httpClient);

            AddSubscription addSubscription = new AddSubscription();
            addSubscription.Plan = "plan-4f411";
            addSubscription.Customer = model.customer;
            addSubscription.SignupMethod = "source";
            addSubscription.Handle = "aaa14038";
            addSubscription.Source = model.payment_method;

            var noget = await repayMethods.AddSubscription(addSubscription);


            return null;
        }

        public class PaymentAcceptModel
        {
            public string id { get; set; }
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

            [JsonProperty("handle")]
            public string Handle { get; set; }

            [JsonProperty("source")]
            public string Source { get; set; }
        }      
    }

  
}
