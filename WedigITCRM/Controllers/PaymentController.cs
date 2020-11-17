using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WedigITCRM.Models;
using WedigITCRM.ReepayAPI;
using static WedigITCRM.ReepayAPI.ReepayAPIMethods;

namespace WedigITCRM.Controllers
{
    public class PaymentController : Controller
       
    {
        public ICompanyAccountRepository companyAccountRepository;

        public PaymentController( ICompanyAccountRepository companyAccountRepository)
        {
            this.companyAccountRepository = companyAccountRepository;
        }


        [HttpGet]
        public IActionResult GetPayment()
        {
            return View();
        }

        [HttpGet]
        public IActionResult signUp(string reepaytoken)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Charge(string reepaytoken)
        {
            HttpClient httpClient = new HttpClient();

            ReepayAPIMethods repayMethods = new ReepayAPIMethods(httpClient);

        

             OrderModel reepayModel  = new OrderModel();
            reepayModel.Order.CustomerHandle = "14038";
            reepayModel.Order.Amount = "9900";
            reepayModel.Order.Handle = "x4";


            var sessionModel = await repayMethods.GetChargeSessionIdAsync(reepayModel);

            PaymentViewModel viewModel = new PaymentViewModel();
            viewModel.SessionId = sessionModel.SessionId;

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Subscription(string reepaytoken)
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
