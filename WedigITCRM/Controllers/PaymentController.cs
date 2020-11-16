using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

            //CompanyAccount companyAccount = companyAccountRepository.GetCompanyAccount(14038);

            //CustomerMapper cm = new CustomerMapper();

            //CustomerModel model = cm.MapFromNyxiumToReepay(companyAccount);

            //var customerHandle = await repayMethods.PostCustomerToReepayAPIAsync(model);

             OrderModel reepayModel  = new OrderModel();
            reepayModel.Order.CustomerHandle = "14038";
            reepayModel.Order.Amount = "9900";
            reepayModel.Order.Handle = "x4";


            var sessionModel = await repayMethods.GetChargeSessionIdAsync(reepayModel);

            PaymentViewModel viewModel = new PaymentViewModel();
            viewModel.SessionId = sessionModel.SessionId;

            return View(viewModel);
        }

        //[HttpPost]
        //public IActionResult signUp(string reepaytoken)
        //{
        //    return View();
        //}
    }
}
