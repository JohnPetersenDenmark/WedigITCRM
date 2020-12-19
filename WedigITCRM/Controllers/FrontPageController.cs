using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WedigITCRM.EntitityModels;
using WedigITCRM.ReepayAPI;
using static WedigITCRM.Controllers.AccountController;
using static WedigITCRM.Controllers.PaymentController;
using static WedigITCRM.ReepayAPI.ReepayAPIMethods;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WedigITCRM.Controllers
{
    public class FrontPageController : Controller
    {
        private IWebHostEnvironment _env;
        private readonly IOptions<NyxiumSubscription> optionsNyxiumSubscription;

        public FrontPageController(IWebHostEnvironment env, IOptions<NyxiumSubscription> optionsNyxiumSubscription)
        {
            _env = env;
            this.optionsNyxiumSubscription = optionsNyxiumSubscription;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public async Task<IActionResult> Prices()
        {
            HttpClient httpClient = new HttpClient();

            ReepayAPIMethods repayMethods = new ReepayAPIMethods(httpClient);

            SelectNyxiumSubscriptionViewModel selectNyxiumSubscriptionViewModel = new SelectNyxiumSubscriptionViewModel();

            foreach (var subscriptionType in optionsNyxiumSubscription.Value.Subscriptions)
            {
                NyxiumSubscriptionViewModel NyxiumSubscriptionViewModel = new NyxiumSubscriptionViewModel();

                if (subscriptionType.NumberOfNyxiumModules.Equals("all"))
                {
                    NyxiumSubscriptionViewModel.NumberOfNyxiumModules = -1;
                }
                else
                {
                    NyxiumSubscriptionViewModel.NumberOfNyxiumModules = int.Parse(subscriptionType.NumberOfNyxiumModules);
                }

                NyxiumSubscriptionViewModel.ReepaySubscriptionPlanHandle = subscriptionType.ReepaySubscriptionPlanHandle;

                ReepayPlanResponseModel subscriptionPlan = await repayMethods.GetPlanById(subscriptionType.ReepaySubscriptionPlanHandle);
                if (subscriptionPlan != null)
                {

                    NyxiumSubscriptionViewModel.Name = subscriptionPlan.Name;

                    Decimal priceInclVAT = Decimal.Parse(subscriptionPlan.Amount) / 100;

                    Decimal priceExclVAT = priceInclVAT * 8;
                    priceExclVAT = priceExclVAT / 10;

                    string priceFormatted = priceExclVAT.ToString();
                    priceFormatted = priceFormatted.Insert(priceFormatted.Length - 2, ",");
                    NyxiumSubscriptionViewModel.price = "DKK " + priceFormatted;

                    NyxiumSubscriptionViewModel.Description = subscriptionPlan.Description;

                    selectNyxiumSubscriptionViewModel.NyxiumSubscriptions.Add(NyxiumSubscriptionViewModel);
                }
            }
            return View(selectNyxiumSubscriptionViewModel);           
        }

        [HttpGet]
        public IActionResult BuyLicense()
        {

            return View();
        }

        public IActionResult Support()
        {
            return View();
        }

        public IActionResult Integrations()
        {
            return View();
        }

        public IActionResult IntegrationDinero()
        {
            return View();
        }

        [HttpGet]
        public FileResult GetPDF(string fileName)
        {

            string PDFUrl = _env.WebRootPath + "/Help/" + fileName;
            byte[] FileBytes = System.IO.File.ReadAllBytes(PDFUrl);
            return File(FileBytes, "application/pdf");
        }
    }
}
