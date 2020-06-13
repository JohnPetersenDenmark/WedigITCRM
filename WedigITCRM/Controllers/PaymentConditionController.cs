using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WedigITCRM.EntitityModels;
using WedigITCRM.StorageInterfaces;

namespace WedigITCRM.Controllers
{
    public class PaymentConditionController : Controller
    {
        private IPaymentConditionRepository _paymentConditionRepository;

        public PaymentConditionController(IPaymentConditionRepository paymentConditionRepository)
        {
            _paymentConditionRepository = paymentConditionRepository;
        }


        public IActionResult Index(CompanyAccount companyAccount)
        {
            List<PaymentCondition> paymentConditionList = _paymentConditionRepository.GetAllPaymentConditions().Where(paymentCondition => paymentCondition.companyAccountId == companyAccount.companyAccountId).ToList();
            return View(paymentConditionList);
        }

        [HttpGet]
        public IActionResult Create(CompanyAccount companyAccount)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PaymentCondition model, CompanyAccount companyAccount)
        {
            PaymentCondition paymentCondition = new PaymentCondition();

            paymentCondition.Id = model.Id;
            paymentCondition.Description = model.Description;
            paymentCondition.companyAccountId = companyAccount.companyAccountId;
            _paymentConditionRepository.Add(paymentCondition);

            return RedirectToAction("index", "PaymentCondition");
        }

        [HttpGet]
        public IActionResult Edit(string paymentConditionId, CompanyAccount companyAccount)
        {
            PaymentCondition paymentCondition = _paymentConditionRepository.GetPaymentCondition(Int32.Parse(paymentConditionId));
            if (paymentCondition != null)
            {
                PaymentConditionModel model = new PaymentConditionModel();
                model.Id = paymentCondition.Id;
                model.Description = paymentCondition.Description;
                return View(model);
            }

            // 

            return View();
        }

        [HttpPost]
        public IActionResult Edit(PaymentConditionModel model, CompanyAccount companyAccount)
        {
            PaymentCondition paymentCondition = _paymentConditionRepository.GetPaymentCondition(model.Id);

            if (paymentCondition != null)
            {
                paymentCondition.Description = model.Description;
                _paymentConditionRepository.Update(paymentCondition);
                return RedirectToAction("index", "PaymentCondition");
            }

            return View(model);
        }

        public IActionResult Delete(string paymentConditionId, CompanyAccount companyAccount)
        {

            PaymentCondition paymentCondition = _paymentConditionRepository.GetPaymentCondition(Int32.Parse(paymentConditionId));

            if (paymentCondition != null)
            {
                _paymentConditionRepository.Delete(Int32.Parse(paymentConditionId));
            }

            return RedirectToAction("index", "PaymentCondition");
        }

        public class PaymentConditionModel
        {
            public int Id { get; set; }
            public string Description { get; set; }
        }
    }

    
}
