using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WedigITCRM.EntitityModels;
using WedigITCRM.StorageInterfaces;

namespace WedigITCRM.Controllers
{
    public class DeliveryConditionController : Controller
    {
        private IDeliveryConditionRepository _deliveryConditionRepository;
        public DeliveryConditionController(IDeliveryConditionRepository deliveryConditionRepository )
        {
            _deliveryConditionRepository = deliveryConditionRepository;
        }


        public IActionResult Index(CompanyAccount companyAccount)
        {
            List<DeliveryCondition> deliveryConditionList = _deliveryConditionRepository.GetAllDeliveryConditions().Where(deliveryCondition => deliveryCondition.companyAccountId == companyAccount.companyAccountId).ToList();
            return View(deliveryConditionList);
        }

        [HttpGet]
        public IActionResult Create(CompanyAccount companyAccount)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DeliveryCondition model, CompanyAccount companyAccount)
        {
            DeliveryCondition deliveryCondition = new DeliveryCondition();

            deliveryCondition.Id = model.Id;
            deliveryCondition.Description = model.Description;
            deliveryCondition.companyAccountId = companyAccount.companyAccountId;
            _deliveryConditionRepository.Add(deliveryCondition);

            

            return RedirectToAction("index", "DeliveryCondition");
        }

        [HttpGet]
        public IActionResult Edit(string deliveryConditionId, CompanyAccount companyAccount)
        {
            DeliveryCondition deliveryCondition = _deliveryConditionRepository.GetDeliveryCondition(Int32.Parse(deliveryConditionId));
            if (deliveryCondition != null)
            {
                DeliveryConditionModel model = new DeliveryConditionModel();
                model.Id = deliveryCondition.Id;
                model.Description = deliveryCondition.Description;
                return View(model);
            }

           // 

            return View();
        }

        [HttpPost]
        public IActionResult Edit(DeliveryConditionModel model, CompanyAccount companyAccount)
        {
            DeliveryCondition deliveryCondition = _deliveryConditionRepository.GetDeliveryCondition(model.Id);

            if (deliveryCondition != null)
            {
                deliveryCondition.Description = model.Description;
                _deliveryConditionRepository.Update(deliveryCondition);
                return RedirectToAction("index", "DeliveryCondition");
            }
           
            return View();
        }

        public IActionResult Delete(string deliveryConditionId, CompanyAccount companyAccount)
        {

            DeliveryCondition deliveryCondition = _deliveryConditionRepository.GetDeliveryCondition(Int32.Parse(deliveryConditionId));
            if (deliveryCondition != null)
            {
                _deliveryConditionRepository.Delete(Int32.Parse(deliveryConditionId));
            }

            return RedirectToAction("index", "DeliveryCondition");
        }

        public class DeliveryConditionModel
        {
            public int Id { get; set; }
            public string Description { get; set; }
        }
    }
}
