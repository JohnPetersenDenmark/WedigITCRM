using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WedigITCRM.DineroAPI;
using static WedigITCRM.DineroAPI.DineroInvoice;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WedigITCRM.Controllers
{
    [Authorize]
    public class SalesController : Controller
    {
        private IStockItemRepository _stockItemRepository;      
        private IStockItemCategory1Repository _stockItemCategory1Repository;
        private IStockItemCategory2Repository _stockItemCategory2Repository;
        private IStockItemCategory3Repository _stockItemCategory3Repository;

        public SalesController(IStockItemCategory1Repository stockItemCategory1Repository, IStockItemCategory2Repository stockItemCategory2Repository, IStockItemCategory3Repository stockItemCategory3Repository, IStockItemRepository stockItemRepository)
        {
            _stockItemRepository = stockItemRepository;
          
            _stockItemCategory1Repository = stockItemCategory1Repository;
            _stockItemCategory2Repository = stockItemCategory2Repository;
            _stockItemCategory3Repository = stockItemCategory3Repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        

        [HttpGet]
        public IActionResult StatisticsTurnOver( CompanyAccount companyAccount)
        {


            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;

            StatisticsTurnOverViewModel model = new StatisticsTurnOverViewModel();

            DateTime Startdate = DateTime.Now.AddMonths(-1);
            DateTime Enddate = DateTime.Now;

            model.StartDate = Startdate.ToString(danishDateTimeformat.ShortDatePattern);
            model.EndDate = Enddate.ToString(danishDateTimeformat.ShortDatePattern );

          
            return View(model);
        }

        [HttpPost]
        public IActionResult StatisticsTurnOver(StatisticsTurnOverViewModel model, CompanyAccount companyAccount)
        {
            DateTime testdate;
            Int32 testInteger;
            DateTime Startdate = DateTime.Now.AddDays(-7);
            DateTime Enddate = DateTime.Now;
            StockItem stockItem = null;
            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
            DateTimeFormatInfo sweedishDateTimeformat = CultureInfo.GetCultureInfo("sv-SE").DateTimeFormat;
            Int32 category1Id = 0;
            Int32 category2Id = 0;
            Int32 category3Id = 0;

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!companyAccount.IntegrationDinero)
            {
                List<string> emptyList = new List<string>();
                return Json(emptyList);
            }

            DineroAPIConnect dineroAPIConnect = new DineroAPIConnect();
            if (dineroAPIConnect.connectToDinero(companyAccount.DineroAPIOrganizationKey) == null)
            {
                List<string> emptyList = new List<string>();
                return Json(emptyList);
            }
         

            if (!string.IsNullOrEmpty(model.StartDate))
            {
                if (DateTime.TryParse(model.StartDate, out testdate))
                {
                    Startdate = DateTime.Parse(model.StartDate, danishDateTimeformat);
                }
            }

            if (!string.IsNullOrEmpty(model.EndDate))
            {
                if (DateTime.TryParse(model.EndDate, out testdate))
                {
                    Enddate = DateTime.Parse(model.EndDate, danishDateTimeformat);
                }
            }

            if (!string.IsNullOrEmpty(model.category1Id))
            {
                if (Int32.TryParse(model.category1Id, out testInteger))
                {
                    category1Id = Int32.Parse(model.category1Id);
                    StockItemCategory1 category1 = _stockItemCategory1Repository.GetStockItemCategory1(category1Id);
                    if (category1 != null)
                    {
                        category1Id = category1.Id;
                    }
                    else
                    {
                        category1Id = 0;
                    }
                }
            }
            else
            {
                category1Id = 0;
            }

            if (!string.IsNullOrEmpty(model.category2Id))
            {
                if (Int32.TryParse(model.category2Id, out testInteger))
                {
                    category2Id = Int32.Parse(model.category2Id);
                    StockItemCategory2 category2 = _stockItemCategory2Repository.GetStockItemCategory2(category2Id);
                    if (category2 != null)
                    {
                        category2Id = category2.Id;
                    }
                    else
                    {
                        category2Id = 0;
                    }
                }
            }
            else
            {
                category2Id = 0;
            }

            if (!string.IsNullOrEmpty(model.category3Id))
            {
                if (Int32.TryParse(model.category3Id, out testInteger))
                {
                    category3Id = Int32.Parse(model.category3Id);
                    StockItemCategory3 category3 = _stockItemCategory3Repository.GetStockItemCategory3(category3Id);
                    if (category3 != null)
                    {
                        category3Id = category3.Id;
                    }
                    else
                    {
                        category3Id = 0;
                    }
                }
            }
            else
            {
                category3Id = 0;
            }


            if (!string.IsNullOrEmpty(model.StockItemId))
            {
                stockItem = _stockItemRepository.getStockItem(Int32.Parse(model.StockItemId));
            }

            List<StockItem> stockItems = new List<StockItem>();

            if (stockItem != null)
            {
                stockItems.Add(stockItem);
            }
            else
            {
                if (category1Id != 0 && category2Id != 0 && category3Id != 0)

                {
                    stockItems = _stockItemRepository.GetAllstockItems().Where(stockItemTmp => stockItemTmp.category1Id == category1Id && stockItemTmp.category2Id == category2Id && stockItemTmp.category3Id == category3Id && stockItemTmp.companyAccountId == companyAccount.companyAccountId).ToList();
                }
                else
                {
                    if (category1Id != 0 && category2Id != 0)
                    {
                        stockItems = _stockItemRepository.GetAllstockItems().Where(stockItemTmp => stockItemTmp.category1Id == category1Id && stockItemTmp.category2Id == category2Id && stockItemTmp.companyAccountId == companyAccount.companyAccountId).ToList();
                    }
                    else
                    {
                        if (category1Id != 0)
                        {
                            stockItems = _stockItemRepository.GetAllstockItems().Where(stockItemTmp => stockItemTmp.category1Id == category1Id && stockItemTmp.companyAccountId == companyAccount.companyAccountId).ToList();
                        }
                    }
                }
            }

            Dictionary<string, StockItemTurnOverAccumulation> stockItemAccumulationList = new Dictionary<string, StockItemTurnOverAccumulation>();

            DineroInvoice dineroInvoice = new DineroInvoice(dineroAPIConnect);
            READDineroAPIInvoicecollection rEADDineroAPIInvoicecollection = dineroInvoice.getInvoicesFromDinero();

            foreach (var invoice in rEADDineroAPIInvoicecollection.Collection)
            {
                if (!string.IsNullOrEmpty(invoice.Date))
                {
                    if (DateTime.TryParse(invoice.Date, out testdate))
                    {
                        DateTime invoiceDate = DateTime.Parse(invoice.Date, sweedishDateTimeformat);

                        if (invoiceDate > Startdate && invoiceDate < Enddate)
                        {
                            READDineroAPIInvoiceProductLines rEADDineroAPIInvoiceProductLines = dineroInvoice.getInvoiceLinesFromDinero(invoice.Guid.ToString());
                            foreach (var productLine in rEADDineroAPIInvoiceProductLines.ProductLines)
                            {
                                StockItem stockItemFromInvoice = stockItems.Find(x => x.DineroGuiD.ToString() == productLine.ProductGuid);
                                if (stockItemFromInvoice != null)
                                {
                                    if (productLine.Quantity > 0 && productLine.baseamountvalue > 0)
                                    {
                                        if (stockItemAccumulationList.ContainsKey(productLine.ProductGuid))
                                        {
                                            stockItemAccumulationList[productLine.ProductGuid].AccumulatedTurnOver = stockItemAccumulationList[productLine.ProductGuid].AccumulatedTurnOver + productLine.TotalAmount;
                                            stockItemAccumulationList[productLine.ProductGuid].AccumulatedQuantity = stockItemAccumulationList[productLine.ProductGuid].AccumulatedQuantity + productLine.Quantity;
                                            Decimal GrossProfit = productLine.TotalAmount - (productLine.Quantity * stockItemFromInvoice.CostPrice);
                                            stockItemAccumulationList[productLine.ProductGuid].AccumulatedGrossProfit = stockItemAccumulationList[productLine.ProductGuid].AccumulatedGrossProfit + GrossProfit;
                                        }
                                        else
                                        {
                                            StockItemTurnOverAccumulation stockItemAccumulation = new StockItemTurnOverAccumulation();
                                            stockItemAccumulationList.Add(productLine.ProductGuid, stockItemAccumulation);
                                            stockItemAccumulationList[productLine.ProductGuid].ProductGuid = productLine.ProductGuid;

                                            if (stockItemFromInvoice != null)
                                            {

                                                stockItemAccumulationList[productLine.ProductGuid].ItemName = stockItemFromInvoice.ItemName;
                                                stockItemAccumulationList[productLine.ProductGuid].ItemNumber = stockItemFromInvoice.ItemNumber;
                                                stockItemAccumulationList[productLine.ProductGuid].CostPrice = stockItemFromInvoice.CostPrice;
                                            }

                                            stockItemAccumulationList[productLine.ProductGuid].AccumulatedTurnOver = productLine.TotalAmount;
                                            stockItemAccumulationList[productLine.ProductGuid].AccumulatedQuantity = productLine.Quantity;
                                            Decimal GrossProfit = productLine.TotalAmount - (productLine.Quantity * stockItemFromInvoice.CostPrice);
                                            stockItemAccumulationList[productLine.ProductGuid].AccumulatedGrossProfit = GrossProfit;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }


            }

           

           
            model.stockItemTurnOverAccumulations = stockItemAccumulationList.Values.ToList();
            foreach (var stockItemTurnOverAccumulation in model.stockItemTurnOverAccumulations)
            {
                if (stockItemTurnOverAccumulation.AccumulatedTurnOver != 0)
                    stockItemTurnOverAccumulation.AccumulatedGrossProfitInPercentage = (stockItemTurnOverAccumulation.AccumulatedGrossProfit / stockItemTurnOverAccumulation.AccumulatedTurnOver) * 100;
            }

            return View(model);
        }


    }




    public class StatisticsTurnOverViewModel
    {
        [Display(Name = "Startdato")]
        public string StartDate { get; set; }
        [Display(Name = "Slutdato")]
        public string EndDate { get; set; }

        [Display(Name = "Kategori 1")]
        public string Category1 { get; set; }
        [Display(Name = "Kategori 2")]
        public string Category2 { get; set; }
        [Display(Name = "Kategori 3")]
        public string Category3 { get; set; }
        public string category1Id { get; set; }
        public string category2Id { get; set; }
        public string category3Id { get; set; }
        [Display(Name = "Vare")]

        public string StockItemName { get; set; }
        [Display(Name = "Varenummer")]
        public string StockItemNumber { get; set; }
        public string StockItemId { get; set; }

        public List<StockItemTurnOverAccumulation> stockItemTurnOverAccumulations { get; set; }

      

    }

    public class StockItemTurnOverAccumulation
    {
        public string ProductGuid { get; set; }
        public string ItemName { get; set; }
        public string ItemNumber { get; set; }
        public Decimal CostPrice { get; set; }
        public Decimal AccumulatedTurnOver { get; set; }
        public Decimal AccumulatedGrossProfit { get; set; }
        public Decimal AccumulatedGrossProfitInPercentage { get; set; }
        public Decimal AccumulatedQuantity { get; set; }
        public int StockItemTurnOverPercentage { get; set; }
    }

}
