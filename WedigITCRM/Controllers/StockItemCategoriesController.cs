using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WedigITCRM.Models;

namespace WedigITCRM.Controllers
{
    [Authorize]
    public class StockItemCategoriesController : Controller
    {
        private IStockItemCategory1Repository _stockItemCategory1Repository;
        private IStockItemCategory2Repository _stockItemCategory2Repository;
        private IStockItemCategory3Repository _stockItemCategory3Repository;

        public StockItemCategoriesController(IStockItemCategory1Repository stockItemCategory1Repository, IStockItemCategory2Repository stockItemCategory2Repository, IStockItemCategory3Repository stockItemCategory3Repository)
        {
            _stockItemCategory1Repository = stockItemCategory1Repository;
            _stockItemCategory2Repository = stockItemCategory2Repository;
            _stockItemCategory3Repository = stockItemCategory3Repository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateCategory1(CategoriesViewModel model, CompanyAccount companyAccount)
        {
            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(model.Category1))
                {
                    ModelState.AddModelError("Category1", "Kategori skal udfyldes");
                    return View("index");
                }
                var Cat1List = _stockItemCategory1Repository.GetAllStockItemCategory1s().Where(cat1 => cat1.Name.Equals(model.Category1) && cat1.companyAccountId == companyAccount.companyAccountId).ToList();
                if (Cat1List.Count != 0)
                {
                    ModelState.AddModelError("Category1", "Kategorien findes allerede");
                    return View("index");
                }

                StockItemCategory1 category1 = new StockItemCategory1();
                category1.Name = model.Category1;
                category1.companyAccountId = companyAccount.companyAccountId;
                _stockItemCategory1Repository.Add(category1);
            }
                return View("index");
        }

        [HttpPost]
        public IActionResult CreateCategory2(CategoriesViewModel model, CompanyAccount companyAccount)
        {
            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(model.Category2))
                {
                    ModelState.AddModelError("Category2", "Kategori skal udfyldes");
                    return View("index");
                }

                var Cat2List = _stockItemCategory2Repository.GetAllStockItemCategory2s().Where(cat2 => cat2.Name.Equals(model.Category2) && cat2.Category1Id == model.Category1Id && cat2.companyAccountId == companyAccount.companyAccountId).ToList();
                if (Cat2List.Count != 0)
                {
                    ModelState.AddModelError("Category2", "Kategorien findes allerede");
                    return View("index");
                }

                StockItemCategory2 category2 = new StockItemCategory2();
                category2.Name = model.Category2;
                category2.companyAccountId = companyAccount.companyAccountId;
                category2.Category1Id = model.Category1Id;
                _stockItemCategory2Repository.Add(category2);
            }
            return View("index");
        }


        [HttpPost]
        public IActionResult CreateCategory3(CategoriesViewModel model, CompanyAccount companyAccount)
        {
            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(model.Category3))
                {
                    ModelState.AddModelError("Category3", "Kategori skal udfyldes");
                    return View("index");
                }
                var Cat3List = _stockItemCategory3Repository.GetAllStockItemCategory3s().Where(cat3 => cat3.Name.Equals(model.Category3) && cat3.Category2Id == model.Category2Id && cat3.companyAccountId == companyAccount.companyAccountId).ToList();
                if (Cat3List.Count != 0)
                {
                    ModelState.AddModelError("Category3", "Kategorien findes allerede");
                    return View("index");
                }

                StockItemCategory3 category3 = new StockItemCategory3();
                category3.Name = model.Category3;
                category3.companyAccountId = companyAccount.companyAccountId;
                category3.Category2Id = model.Category2Id;
                _stockItemCategory3Repository.Add(category3);
            }
           
            return View("index");
        }

        public IActionResult DeleteCategory1(CategoriesViewModel model, CompanyAccount companyAccount)
        {
            if (ModelState.IsValid)
            {
                var Cat1List = _stockItemCategory1Repository.GetAllStockItemCategory1s().Where(cat1 => cat1.Id == model.Category1DeleteId).ToList();
                if (Cat1List.Count == 1)
                {
                    StockItemCategory1 category1 = Cat1List.First();
                    int category1Id = category1.Id;
                    _stockItemCategory1Repository.Delete(category1Id);

                    var Cat2List = _stockItemCategory2Repository.GetAllStockItemCategory2s().Where(cat2 => cat2.Category1Id == category1Id).ToList();
                    foreach( var category2 in Cat2List)
                    {
                        var Cat3List = _stockItemCategory3Repository.GetAllStockItemCategory3s().Where(cat3 => cat3.Category2Id == category2.Id).ToList();
                        foreach (var category3 in Cat3List)
                        {
                            _stockItemCategory3Repository.Delete(category3.Id);
                        }

                        _stockItemCategory2Repository.Delete(category2.Id);
                    }
                }
            }

            return View("index");
        }

        public IActionResult DeleteCategory2(CategoriesViewModel model, CompanyAccount companyAccount)
        {
            if (ModelState.IsValid)
            {
                var Cat2List = _stockItemCategory2Repository.GetAllStockItemCategory2s().Where(cat2 => cat2.Id == model.Category2DeleteId).ToList();
                if (Cat2List.Count == 1)
                {
                    StockItemCategory2 category2 = Cat2List.First();
                    int category2Id = category2.Id;
                    _stockItemCategory2Repository.Delete(category2Id);

                    var Cat3List = _stockItemCategory3Repository.GetAllStockItemCategory3s().Where(cat3 => cat3.Category2Id == category2Id).ToList();
                    foreach (var category3 in Cat3List)
                    {
                        _stockItemCategory3Repository.Delete(category3.Id);
                    }                   
                }                
            }
            return View("index");
        }

        public IActionResult DeleteCategory3(CategoriesViewModel model, CompanyAccount companyAccount)
        {
            if (ModelState.IsValid)
            {
                var Cat3List = _stockItemCategory3Repository.GetAllStockItemCategory3s().Where(cat3 => cat3.Id == model.Category3DeleteId).ToList();
                if (Cat3List.Count == 1)
                {
                    StockItemCategory3 category3 = Cat3List.First();
                    int category3Id = category3.Id;
                    _stockItemCategory3Repository.Delete(category3Id);                   
                }
            }
            return View("index");
        }

        public IActionResult getAllCategory1s(CompanyAccount companyAccount)
        {
            var Cat1List = _stockItemCategory1Repository.GetAllStockItemCategory1s().Where(cat1 => cat1.companyAccountId == companyAccount.companyAccountId).ToList();
            return Json(Cat1List);
        }

        [HttpPost]
        public IActionResult getCategory1Ajax([FromBody] Category1ViewModelAjax model, CompanyAccount companyAccount)
        {
           
            StockItemCategory1 Cat1 = null;
            if (ModelState.IsValid)
            {

                if (!string.IsNullOrEmpty(model.Category1Id))
                {
                    Cat1 = _stockItemCategory1Repository.GetStockItemCategory1(Int32.Parse(model.Category1Id));
                    if (Cat1 != null)
                    {
                        model.Category1 = Cat1.Name;
                    }
                }
            }

            return Json(model);
        }

        [HttpPost]
        public IActionResult getCategory2Ajax([FromBody] Category2ViewModelAjax model, CompanyAccount companyAccount)
        {
           
            StockItemCategory2 Cat2 = null;
            if (ModelState.IsValid)
            {

                if (!string.IsNullOrEmpty(model.Category2Id))
                {
                    Cat2 = _stockItemCategory2Repository.GetStockItemCategory2(Int32.Parse(model.Category2Id));
                    if (Cat2 != null)
                    {
                        model.Category2 = Cat2.Name;
                    }
                }
            }

            return Json(model);
        }

        [HttpPost]
        public IActionResult getCategory3Ajax([FromBody] Category3ViewModelAjax model, CompanyAccount companyAccount)
        {
            throw new Exception("StockItemCategoryController. Method Category3ViewModelAjax");
            StockItemCategory3 Cat3 = null;
            if (ModelState.IsValid)
            {

                if (!string.IsNullOrEmpty(model.Category3Id))
                {
                    Cat3 = _stockItemCategory3Repository.GetStockItemCategory3(Int32.Parse(model.Category3Id));
                    if (Cat3 != null)
                    {
                        model.Category3 = Cat3.Name;
                    }
                }
            }

            return Json(model);
        }

        public IActionResult getAllCategory2s([FromBody] Category1ViewModelAjax model, CompanyAccount companyAccount)
        {
           
            var Cat2List = _stockItemCategory2Repository.GetAllStockItemCategory2s().ToList().Where(cat2 => cat2.Category1Id.ToString().Equals(model.Category1Id) && cat2.companyAccountId == companyAccount.companyAccountId).ToList();
            return Json(Cat2List);
        }

        public IActionResult getAllCategory2ByCategory1s(int Category1Id, CompanyAccount companyAccount)
        {
            

            var Cat2List = _stockItemCategory2Repository.GetAllStockItemCategory2s().ToList().Where(cat2 => cat2.Category1Id == Category1Id && cat2.companyAccountId == companyAccount.companyAccountId).ToList();
            return Json(Cat2List);
        }

        public IActionResult getAllCategory3ByCategory2s([FromBody] Category2ViewModelAjax model, CompanyAccount companyAccount)
        {
           
            var Cat3List = _stockItemCategory3Repository.GetAllStockItemCategory3s().ToList().Where(cat2 => cat2.Category2Id.ToString().Equals(model.Category2Id)   && cat2.companyAccountId == companyAccount.companyAccountId).ToList();
            return Json(Cat3List);
        }
        public IActionResult getAllCategory2Raw( CompanyAccount companyAccount)
        {
            var Cat2List = _stockItemCategory2Repository.GetAllStockItemCategory2s().ToList().Where(cat2 => cat2.companyAccountId == companyAccount.companyAccountId).ToList();
            return Json(Cat2List);
        }

        public IActionResult getAllCategory3s(int Category2Id, CompanyAccount companyAccount)
        {
            var Cat3List = _stockItemCategory3Repository.GetAllStockItemCategory3s().ToList().Where(cat3 => cat3.Category2Id == Category2Id && cat3.companyAccountId == companyAccount.companyAccountId).ToList();
            return Json(Cat3List);
        }


        public IActionResult getAllCategory2sAjax([FromBody] Category1ViewModelAjax model, CompanyAccount companyAccount)  
     
        {
            var Cat2List = _stockItemCategory2Repository.GetAllStockItemCategory2s().ToList().Where(cat2 => cat2.Category1Id.ToString().Equals(model.Category1Id) && cat2.companyAccountId == companyAccount.companyAccountId).ToList();
            return Json(Cat2List);
        }

        public IActionResult getAllCategory3sAjax([FromBody] Category2ViewModelAjax model, CompanyAccount companyAccount)

        {
            var Cat3List = _stockItemCategory3Repository.GetAllStockItemCategory3s().ToList().Where(cat3 => cat3.Category2Id.ToString().Equals(model.Category2Id) && cat3.companyAccountId == companyAccount.companyAccountId).ToList();
            return Json(Cat3List);
        }


    }

    public class Category1ViewModelAjax
    {
        public string Category1Id { get; set; }
        public string Category1 { get; set; }
    }
    public class Category2ViewModelAjax
    {
        public string Category2Id { get; set; }
        public string Category2 { get; set; }
    }

    public class Category3ViewModelAjax
    {
        public string Category3Id { get; set; }
        public string Category3 { get; set; }
    }

    public class CategoriesViewModel
    {
        public string Category1 { get; set; }
        public string Category2 { get; set; }
        public string Category3 { get; set; }
        public int Category1Id { get; set; }
        public int Category2Id { get; set; }
        public int Category3Id { get; set; }

        public int Category1DeleteId { get; set; }
        public int Category2DeleteId { get; set; }
        public int Category3DeleteId { get; set; }
        

    }


}
