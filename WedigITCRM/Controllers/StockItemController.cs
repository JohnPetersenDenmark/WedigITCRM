using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.DineroAPI;
using static WedigITCRM.DineroAPI.DineroInvoice;

namespace WedigITCRM.Controllers
{
    [Authorize]
    public class StockItemController : Controller
    {
        private IVendorRepository _vendorRepository;
        private IPostalCodeRepository _postalCodeRepository;
        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;
        private ICompanyAccountRepository _companyAccountRepository;
        private IRelateCompanyAccountWithUserRepository _relateCompanyAccountWithUserRepository;
        private IStockItemRepository _stockItemRepository;
      
        private IStockItemCategory1Repository _stockItemCategory1Repository;
        private IStockItemCategory2Repository _stockItemCategory2Repository;
        private IStockItemCategory3Repository _stockItemCategory3Repository;


        public StockItemController(IStockItemCategory1Repository stockItemCategory1Repository, IStockItemCategory2Repository stockItemCategory2Repository, IStockItemCategory3Repository stockItemCategory3Repository,  IStockItemRepository stockItemRepository, IVendorRepository vendorRepository, IRelateCompanyAccountWithUserRepository relateCompanyAccountWithUserRepository, ICompanyAccountRepository companyAccountRepository, IPostalCodeRepository postalCodeRepository, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _vendorRepository = vendorRepository;
            _postalCodeRepository = postalCodeRepository;
            _signInManager = signInManager;
            _userManager = userManager;
            _companyAccountRepository = companyAccountRepository;
            _relateCompanyAccountWithUserRepository = relateCompanyAccountWithUserRepository;
            _stockItemRepository = stockItemRepository;
           
            _stockItemCategory1Repository = stockItemCategory1Repository;
            _stockItemCategory2Repository = stockItemCategory2Repository;
            _stockItemCategory3Repository = stockItemCategory3Repository;
        }

        public IActionResult index()
        {
            return View();
        }

        public IActionResult ABCAnalasys()
        {
            return View();
        }

        public IActionResult getStockItems(CompanyAccount companyAccount)
        {
           
                NumberFormatInfo danishNumberAndCurrencyFormatInfo = CultureInfo.GetCultureInfo("da-DK").NumberFormat;

                var stockItemData = _stockItemRepository.GetAllstockItems().Where(company => company.companyAccountId == companyAccount.companyAccountId).ToList();

                List<ReducedStockItem> data1 = new List<ReducedStockItem>();

           

            foreach (var stockItem in stockItemData)
                {
                    DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;

                    

                    ReducedStockItem reducedStockItem = new ReducedStockItem();
                    reducedStockItem.Id = stockItem.Id.ToString();
                    reducedStockItem.ItemName = stockItem.ItemName;
                    reducedStockItem.ItemNumber = stockItem.ItemNumber;
                    reducedStockItem.Location = stockItem.Location;
                    reducedStockItem.VendorId = stockItem.VendorId.ToString();
                    if (stockItem.VendorId != 0)
                    {
                        Vendor vendor = _vendorRepository.GetVendor(stockItem.VendorId);
                        if (vendor != null)
                        {
                            reducedStockItem.VendorName = vendor.Name;
                        }
                    }

                    reducedStockItem.VendorItemNumber = stockItem.VendorItemNumber;

                   
                    
                    if (DateTime.MinValue != stockItem.Expirationdate)
                    {
                        reducedStockItem.Expirationdate = stockItem.Expirationdate.ToString(danishDateTimeformat.ShortDatePattern);
                    }
                    else
                    {
                        reducedStockItem.Expirationdate = "";
                    }


                    if (DateTime.MinValue != stockItem.InStockAgainDate)
                    {
                        reducedStockItem.InStockAgainDate = stockItem.InStockAgainDate.ToString(danishDateTimeformat.ShortDatePattern);
                    }
                    else
                    {
                        reducedStockItem.InStockAgainDate = "";
                    }

                    if ( stockItem.category1Id != 0)
                    {
                        StockItemCategory1 category1 = _stockItemCategory1Repository.GetStockItemCategory1(stockItem.category1Id);
                        if (category1 != null)
                        {
                            reducedStockItem.Category1 = category1.Name;
                            reducedStockItem.category1Id = category1.Id.ToString();
                        }
                    }

                    if (stockItem.category2Id != 0)
                    {
                        StockItemCategory2 category2 = _stockItemCategory2Repository.GetStockItemCategory2(stockItem.category2Id);
                        if (category2 != null)
                        {
                            reducedStockItem.Category2 = category2.Name;
                            reducedStockItem.category2Id = category2.Id.ToString();
                        }
                    }

                    if (stockItem.category3Id != 0)
                    {
                        StockItemCategory3 category3 = _stockItemCategory3Repository.GetStockItemCategory3(stockItem.category3Id);
                        if (category3 != null)
                        {
                            reducedStockItem.Category3 = category3.Name;
                            reducedStockItem.category3Id = category3.Id.ToString();
                        }
                    }




                    reducedStockItem.LastEditedDate = stockItem.LastEditedDate.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);
                    reducedStockItem.CreatedDate = stockItem.CreatedDate.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);
                    reducedStockItem.NumberInStock = stockItem.NumberInStock.ToString();
                    reducedStockItem.ReorderNumberInStock = stockItem.ReorderNumberInStock.ToString();
                    reducedStockItem.Category = stockItem.Category;
                   

                    reducedStockItem.SalesPrice = stockItem.SalesPrice.ToString("C", danishNumberAndCurrencyFormatInfo);
                    reducedStockItem.CostPrice = stockItem.CostPrice.ToString("C", danishNumberAndCurrencyFormatInfo);

                    Decimal stockItemValue = stockItem.CostPrice * stockItem.NumberInStock;
                    reducedStockItem.StockValue = stockItemValue.ToString("C", danishNumberAndCurrencyFormatInfo);
                    data1.Add(reducedStockItem);
                }

                return Json(data1);

           
        }


        public IActionResult EditStockItem([FromBody] ReducedStockItem datamodelInput, CompanyAccount companyAccount)
        {

            if (ModelState.IsValid)
            {
                NumberFormatInfo danishNumberAndCurrencyFormatInfo = CultureInfo.GetCultureInfo("da-DK").NumberFormat;

                

                if (datamodelInput.action.Equals("edit"))
                {
                    DateTime testdate;
                    Int32 testInteger;
                    Decimal testDecimal;

                    StockItem stockItem = _stockItemRepository.getStockItem(int.Parse(datamodelInput.Id));
                    if (stockItem != null)
                    {
                        DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;

                        stockItem.ItemName = datamodelInput.ItemName;
                        stockItem.ItemNumber = datamodelInput.ItemNumber;
                        stockItem.Location = datamodelInput.Location;

                        if (!string.IsNullOrEmpty(datamodelInput.VendorId))
                        {
                            if (Int32.TryParse(datamodelInput.VendorId, out testInteger))
                            {
                                stockItem.VendorId = Int32.Parse(datamodelInput.VendorId);
                                Vendor vendor = _vendorRepository.GetVendor(stockItem.VendorId);
                                if (vendor != null)
                                {
                                    datamodelInput.VendorName = vendor.Name;
                                }
                                else
                                {
                                    datamodelInput.VendorName = "";
                                }
                            }
                        }

                        stockItem.VendorItemNumber = datamodelInput.VendorItemNumber;


                        if (!string.IsNullOrEmpty(datamodelInput.Expirationdate))
                        {
                            if (DateTime.TryParse(datamodelInput.Expirationdate, out testdate))
                            {
                                stockItem.Expirationdate = DateTime.Parse(datamodelInput.Expirationdate, danishDateTimeformat);
                            }
                        }

                        if (!string.IsNullOrEmpty(datamodelInput.NumberInStock))
                        {
                            if (Int32.TryParse(datamodelInput.NumberInStock, out testInteger))
                            {
                                stockItem.NumberInStock = Int32.Parse(datamodelInput.NumberInStock);
                            }

                        }

                        if (!string.IsNullOrEmpty(datamodelInput.ReorderNumberInStock))
                        {
                            if (Int32.TryParse(datamodelInput.ReorderNumberInStock, out testInteger))
                            {
                                stockItem.ReorderNumberInStock = Int32.Parse(datamodelInput.ReorderNumberInStock);
                            }

                        }


                        if (!string.IsNullOrEmpty(datamodelInput.category1Id))
                        {
                            StockItemCategory1 category1 = _stockItemCategory1Repository.GetStockItemCategory1(Int32.Parse(datamodelInput.category1Id));
                            if (category1 != null)
                            {
                                stockItem.category1Id = category1.Id;
                                datamodelInput.Category1 = category1.Name;
                            }
                            else
                            {
                                stockItem.category1Id = 0;
                            }
                        }

                        if (!string.IsNullOrEmpty(datamodelInput.category2Id))
                        {
                            StockItemCategory2 category2 = _stockItemCategory2Repository.GetStockItemCategory2(Int32.Parse(datamodelInput.category2Id));
                            if (category2 != null)
                            {
                                stockItem.category2Id = category2.Id;
                                datamodelInput.Category2 = category2.Name;
                            }
                            else
                            {
                                stockItem.category2Id = 0;
                            }
                        }

                        if (!string.IsNullOrEmpty(datamodelInput.category3Id))
                        {
                            StockItemCategory3 category3 = _stockItemCategory3Repository.GetStockItemCategory3(Int32.Parse(datamodelInput.category3Id));
                            if (category3 != null)
                            {
                                stockItem.category3Id = category3.Id;
                                datamodelInput.Category3 = category3.Name;
                            }
                            else
                            {
                                stockItem.category3Id = 0;
                            }
                        }

                        stockItem.Category = datamodelInput.Category;


                        if (!string.IsNullOrEmpty(datamodelInput.InStockAgainDate))
                        {
                            if (DateTime.TryParse(datamodelInput.InStockAgainDate, out testdate))
                            {
                                stockItem.InStockAgainDate = DateTime.Parse(datamodelInput.InStockAgainDate, danishDateTimeformat);
                            }
                        }
                                          

                        if (!string.IsNullOrEmpty(datamodelInput.SalesPrice))
                        {
                            if (Decimal.TryParse(datamodelInput.SalesPrice, NumberStyles.Currency, danishNumberAndCurrencyFormatInfo, out testDecimal))
                            {
                                stockItem.SalesPrice = Decimal.Parse(datamodelInput.SalesPrice, NumberStyles.Currency, danishNumberAndCurrencyFormatInfo);
                                datamodelInput.SalesPrice = stockItem.SalesPrice.ToString("C", danishNumberAndCurrencyFormatInfo);
                            }

                        }
                        if (!string.IsNullOrEmpty(datamodelInput.CostPrice))
                        {
                            if (Decimal.TryParse(datamodelInput.CostPrice, NumberStyles.Currency, danishNumberAndCurrencyFormatInfo, out testDecimal))
                            {
                                stockItem.CostPrice = Decimal.Parse(datamodelInput.CostPrice, NumberStyles.Currency, danishNumberAndCurrencyFormatInfo);
                                datamodelInput.CostPrice = stockItem.CostPrice.ToString("C", danishNumberAndCurrencyFormatInfo);
                            }
                        }

                        stockItem.StockValue = 0;
                        datamodelInput.StockValue = "";
                        if (!string.IsNullOrEmpty(datamodelInput.CostPrice) && !string.IsNullOrEmpty(datamodelInput.NumberInStock))
                        {
                            if (Decimal.TryParse(datamodelInput.CostPrice, NumberStyles.Currency, danishNumberAndCurrencyFormatInfo, out testDecimal) && Int32.TryParse(datamodelInput.NumberInStock, out testInteger))
                            {
                                Decimal stockItemValue = stockItem.CostPrice * stockItem.NumberInStock;
                                stockItem.StockValue = stockItemValue;
                                datamodelInput.StockValue = stockItemValue.ToString("C", danishNumberAndCurrencyFormatInfo);
                            }
                        }

                        stockItem.Unit = "parts";

                        stockItem.LastEditedDate = DateTime.Now;
                        StockItem  stockItemToUpdate = _stockItemRepository.Update(stockItem);

                        if (companyAccount.IntegrationDinero && companyAccount.synchronizeStockItemFromNyxiumToDinero)
                        {
                            DineroAPIConnect dineroAPIConnect = new DineroAPIConnect();
                            if (dineroAPIConnect.connectToDinero(companyAccount) != null)
                            {
                                DineroStockItem dineroStockItem = new DineroStockItem(dineroAPIConnect);
                                string status = dineroStockItem.UpdateStockItemInDinero(stockItemToUpdate);
                            }
                        }
                      
                    }
                }

                if (datamodelInput.action.Equals("create"))
                {
                    DateTime testdate;
                    Int32 testInteger;
                    Decimal testDecimal;

                    StockItem stockItem = new StockItem();
                    DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;

                    stockItem.ItemName = datamodelInput.ItemName;
                    stockItem.ItemNumber = datamodelInput.ItemNumber;
                    stockItem.Location = datamodelInput.Location;

                    if (!string.IsNullOrEmpty(datamodelInput.VendorId))
                    {
                        if (Int32.TryParse(datamodelInput.VendorId, out testInteger))
                        {
                            stockItem.VendorId = Int32.Parse(datamodelInput.VendorId);
                            Vendor vendor = _vendorRepository.GetVendor(stockItem.VendorId);
                            if (vendor != null)
                            {
                                datamodelInput.VendorName = vendor.Name;
                            }
                        }
                    }

                    stockItem.VendorItemNumber = datamodelInput.VendorItemNumber;

                    if (!string.IsNullOrEmpty(datamodelInput.Expirationdate))
                    {
                        if (DateTime.TryParse(datamodelInput.Expirationdate, out testdate))
                        {
                            stockItem.Expirationdate = DateTime.Parse(datamodelInput.Expirationdate, danishDateTimeformat);
                        }
                    }

                    if (!string.IsNullOrEmpty(datamodelInput.NumberInStock))
                    {
                        if (Int32.TryParse(datamodelInput.NumberInStock, out testInteger))
                        {
                            stockItem.NumberInStock = Int32.Parse(datamodelInput.NumberInStock);
                        }
                        
                    }

                    stockItem.Category = datamodelInput.Category;

                    if (!string.IsNullOrEmpty(datamodelInput.InStockAgainDate))
                    {
                        if (DateTime.TryParse(datamodelInput.InStockAgainDate, out testdate))
                        {
                            stockItem.InStockAgainDate = DateTime.Parse(datamodelInput.InStockAgainDate, danishDateTimeformat);
                        }
                    }
                    if (!string.IsNullOrEmpty(datamodelInput.SalesPrice))
                    {
                        if (Decimal.TryParse(datamodelInput.SalesPrice, NumberStyles.Currency, danishNumberAndCurrencyFormatInfo, out testDecimal))
                        {
                            stockItem.SalesPrice = Decimal.Parse(datamodelInput.SalesPrice);
                        }

                    }
                    if (!string.IsNullOrEmpty(datamodelInput.CostPrice))
                    {
                        if (Decimal.TryParse(datamodelInput.CostPrice, NumberStyles.Currency, danishNumberAndCurrencyFormatInfo, out testDecimal))
                        {
                            stockItem.CostPrice = Decimal.Parse(datamodelInput.CostPrice);
                        }
                    }

                    stockItem.StockValue = 0;
                    datamodelInput.StockValue = "";
                    if (!string.IsNullOrEmpty(datamodelInput.CostPrice) && !string.IsNullOrEmpty(datamodelInput.NumberInStock))
                    {
                        if (Decimal.TryParse(datamodelInput.CostPrice, NumberStyles.Currency, danishNumberAndCurrencyFormatInfo, out testDecimal) && Int32.TryParse(datamodelInput.NumberInStock, out testInteger))
                        {
                            Decimal stockItemValue = stockItem.CostPrice * stockItem.NumberInStock;
                            stockItem.StockValue = stockItemValue;
                            datamodelInput.StockValue = stockItemValue.ToString("C", danishNumberAndCurrencyFormatInfo);
                        }
                    }

                    stockItem.Unit = "parts";

                    stockItem.CreatedDate = DateTime.Now;
                    stockItem.LastEditedDate = DateTime.Now;

                    stockItem.companyAccountId = companyAccount.companyAccountId;

                    StockItem theNewStockItem = _stockItemRepository.Add(stockItem);

                    datamodelInput.Id = theNewStockItem.Id.ToString();

                    string NowDanishdatetime = DateTime.Now.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);

                    datamodelInput.LastEditedDate = NowDanishdatetime;
                    datamodelInput.CreatedDate = NowDanishdatetime;

                    if (companyAccount.IntegrationDinero && companyAccount.synchronizeStockItemFromNyxiumToDinero)
                    {
                        DineroAPIConnect dineroAPIConnect = new DineroAPIConnect();
                        if (dineroAPIConnect.connectToDinero(companyAccount) != null)
                        {
                            DineroStockItem dineroStockItem = new DineroStockItem(dineroAPIConnect);
                            string status = dineroStockItem.AddStockItemToDinero(theNewStockItem);
                            if (!status.Equals("NotOK"))
                            {
                                theNewStockItem.DineroGuiD = Guid.Parse(status);
                                _stockItemRepository.Update(theNewStockItem);                               
                            }
                        }                                              
                    }
                }

                if (datamodelInput.action.Equals("remove"))
                {
                    StockItem stockItem = _stockItemRepository.getStockItem(int.Parse(datamodelInput.Id));
                    if (stockItem != null)
                    {
                        _stockItemRepository.Delete(int.Parse(datamodelInput.Id));

                        if (companyAccount.IntegrationDinero && companyAccount.synchronizeStockItemFromNyxiumToDinero)
                        {
                            DineroAPIConnect dineroAPIConnect = new DineroAPIConnect();
                            if (dineroAPIConnect.connectToDinero(companyAccount) != null)
                            {
                                DineroStockItem dineroStockItem = new DineroStockItem(dineroAPIConnect);
                                string status = dineroStockItem.DeleteStockItemInDinero(stockItem.DineroGuiD);
                            }                               
                        }
                    }
                }
            }

            StockItemOutputDataModel datamodelOutput = new StockItemOutputDataModel();
            datamodelInput.DT_RowId = datamodelInput.Id;

            datamodelOutput.data.Add(datamodelInput);

            return Json(datamodelOutput);
        }

        public IActionResult EditStockItemCategories([FromBody] StockItemCategoriesModel datamodelInput, CompanyAccount companyAccount)
        {

            if (ModelState.IsValid)
            {
                if (datamodelInput.Id != 0)
                {
                    StockItem stockItem = _stockItemRepository.getStockItem(datamodelInput.Id);
                    if (stockItem != null)
                    {
                        if (!string.IsNullOrEmpty(datamodelInput.Category1Id ))
                        {
                            StockItemCategory1 category1 = _stockItemCategory1Repository.GetStockItemCategory1(Int32.Parse(datamodelInput.Category1Id));
                            if (category1 != null)
                            {
                                stockItem.category1Id = category1.Id;
                                datamodelInput.Category1 = category1.Name;
                            }
                        }

                        if (!string.IsNullOrEmpty(datamodelInput.Category2Id))
                        {
                            StockItemCategory2 category2 = _stockItemCategory2Repository.GetStockItemCategory2(Int32.Parse(datamodelInput.Category2Id));
                            if (category2 != null)
                            {
                                stockItem.category2Id = category2.Id;
                                datamodelInput.Category2 = category2.Name;
                            }
                        }

                        if (!string.IsNullOrEmpty(datamodelInput.Category3Id))
                        {
                            StockItemCategory3 category3 = _stockItemCategory3Repository.GetStockItemCategory3(Int32.Parse(datamodelInput.Category3Id));
                            if (category3 != null)
                            {
                                stockItem.category3Id = category3.Id;
                                datamodelInput.Category3 = category3.Name;
                            }
                        }

                        StockItem updatedStockItem = _stockItemRepository.Update(stockItem);
                    }

                }
            }
                return Json(datamodelInput);
        }

       
        public IActionResult searchstockItemByName(string term, CompanyAccount companyAccount)
        {
           

            var stockItemData = _stockItemRepository.GetAllstockItems().Where(stockitem => stockitem.companyAccountId == companyAccount.companyAccountId && stockitem.ItemName.ToLower().Contains(term.ToLower())).ToList();

                List<StockItemSearckResultViewModel> data = new List<StockItemSearckResultViewModel>();
                foreach (var stockItem in stockItemData)
                {
                    DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;

                    StockItemSearckResultViewModel outputModel = new StockItemSearckResultViewModel();
                    outputModel.label = stockItem.ItemName;
                    outputModel.StockItemId = stockItem.Id.ToString();
                    data.Add(outputModel); 
                }

                return Json(data);

        }

        public class StockItemSearckResultViewModel
        {
            public string label { get; set; }
          //  public string value { get; set; }

            public string StockItemId { get; set; }
        }

        public IActionResult ABCAnalasysGetData(CompanyAccount companyAccount)
        {

            if (!companyAccount.IntegrationDinero )
            {
                List<string> emptyList = new List<string>();
                return Json(emptyList);
            }

           

            Decimal TotalTurnOver = 0;
            Decimal TotalPicks = 0;
            Dictionary<string, StockItemAccumulation> stockItemAccumulationList = new Dictionary<string, StockItemAccumulation>();

            READDineroAPIInvoicecollection rEADDineroAPIInvoicecollection = new READDineroAPIInvoicecollection();
            DineroAPIConnect dineroAPIConnect = new DineroAPIConnect();
            if (dineroAPIConnect.connectToDinero(companyAccount) != null)
            {
                DineroInvoice dineroInvoice = new DineroInvoice(dineroAPIConnect);
                rEADDineroAPIInvoicecollection = dineroInvoice.getInvoicesFromDinero();         
            }
            else
            {              
                return Json(rEADDineroAPIInvoicecollection);
            }



          
            foreach (var invoice in rEADDineroAPIInvoicecollection.Collection)
            {
                DineroInvoice dineroInvoice = new DineroInvoice(dineroAPIConnect);
                READDineroAPIInvoiceProductLines rEADDineroAPIInvoiceProductLines = dineroInvoice.getInvoiceLinesFromDinero(invoice.Guid.ToString());

                TotalTurnOver = TotalTurnOver + rEADDineroAPIInvoiceProductLines.TotalExclVat;

                if (rEADDineroAPIInvoiceProductLines.ProductLines != null)
                {

                    foreach (var productLine in rEADDineroAPIInvoiceProductLines.ProductLines)
                    {
                        if (productLine.ProductGuid != null)
                        {
                            var stockItemList =_stockItemRepository.GetAllstockItems().Where(StockItem => StockItem.DineroGuiD.ToString() == productLine.ProductGuid).ToList();

                            if (stockItemList.Count == 1)
                            {
                                StockItem stockItem = stockItemList.First();

                                if (productLine.Quantity > 0 && productLine.baseamountvalue > 0)
                                {
                                    if (stockItemAccumulationList.ContainsKey(productLine.ProductGuid))
                                    {
                                        stockItemAccumulationList[productLine.ProductGuid].AccumulatedTurnOver = stockItemAccumulationList[productLine.ProductGuid].AccumulatedTurnOver + productLine.TotalAmount;
                                        stockItemAccumulationList[productLine.ProductGuid].AccumulatedQuantity = stockItemAccumulationList[productLine.ProductGuid].AccumulatedQuantity + productLine.Quantity;
                                        stockItemAccumulationList[productLine.ProductGuid].AccumulatedPicks++;
                                        TotalPicks++;
                                    }
                                    else
                                    {
                                        StockItemAccumulation stockItemAccumulation = new StockItemAccumulation();
                                        stockItemAccumulationList.Add(productLine.ProductGuid, stockItemAccumulation);
                                        stockItemAccumulationList[productLine.ProductGuid].ProductGuid = productLine.ProductGuid;
                                      
                                         if (stockItem != null)
                                        {

                                            stockItemAccumulationList[productLine.ProductGuid].ItemName = stockItem.ItemName;
                                            stockItemAccumulationList[productLine.ProductGuid].ItemNumber = stockItem.ItemNumber;
                                            stockItemAccumulationList[productLine.ProductGuid].CostPrice = stockItem.CostPrice;
                                        }


                                        stockItemAccumulationList[productLine.ProductGuid].AccumulatedTurnOver = productLine.TotalAmount;
                                        stockItemAccumulationList[productLine.ProductGuid].AccumulatedQuantity = productLine.Quantity;
                                        stockItemAccumulationList[productLine.ProductGuid].AccumulatedPicks = 1;
                                        TotalPicks++;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            List<StockItemAccumulation> ABClistOfStockItemsTurnOver = stockItemAccumulationList.Values.OrderByDescending(stockItemAccumulation => stockItemAccumulation.AccumulatedTurnOver).ToList();

            // We have to qualify the ABC rule. Most often it is a 80/20. 

            int PercentageSum = 0;
            int percentageCategory = 80;
            if (TotalTurnOver > 0)
            {
                foreach (var stockItemAccumulation in ABClistOfStockItemsTurnOver)
                {

                    stockItemAccumulation.StockItemTurnOverPercentage = (int)((stockItemAccumulation.AccumulatedTurnOver / TotalTurnOver) * 100);



                    if (percentageCategory == 80)
                    {
                        if (PercentageSum <= 80)
                        {
                            stockItemAccumulation.ABCCategoryTurnOver = "A";
                            PercentageSum = PercentageSum + stockItemAccumulation.StockItemTurnOverPercentage;
                        }
                        else
                        {
                            stockItemAccumulation.ABCCategoryTurnOver = "B";
                            percentageCategory = 20;
                            PercentageSum = stockItemAccumulation.StockItemTurnOverPercentage;
                        }
                    }


                    if (percentageCategory == 20)
                    {
                        if (PercentageSum <= 20)
                        {
                            stockItemAccumulation.ABCCategoryTurnOver = "B";
                            PercentageSum = PercentageSum + stockItemAccumulation.StockItemTurnOverPercentage;
                        }
                        else
                        {
                            stockItemAccumulation.ABCCategoryTurnOver = "C";
                            percentageCategory = 5;
                            PercentageSum = stockItemAccumulation.StockItemTurnOverPercentage;
                        }
                    }

                    if (percentageCategory == 5)
                    {
                        if (PercentageSum <= 5)
                        {
                            stockItemAccumulation.ABCCategoryTurnOver = "C";
                            PercentageSum = PercentageSum + stockItemAccumulation.StockItemTurnOverPercentage;
                        }
                        else
                        {
                            stockItemAccumulation.ABCCategoryTurnOver = "D";
                            percentageCategory = 4;
                            PercentageSum = stockItemAccumulation.StockItemTurnOverPercentage;
                        }
                    }

                    if (percentageCategory == 4)
                    {
                        stockItemAccumulation.ABCCategoryTurnOver = "D";
                    }
                }
            }


            List<StockItemAccumulation> ABClistOfStockItemsByPicks = stockItemAccumulationList.Values.OrderByDescending(stockItemAccumulation => stockItemAccumulation.AccumulatedPicks).ToList();


            PercentageSum = 0;
            percentageCategory = 80;

            if (TotalPicks > 0)
            {
                foreach (var stockItemAccumulation in ABClistOfStockItemsByPicks)
                {
                    stockItemAccumulation.StockItemPicksPercentage = (int)((stockItemAccumulation.AccumulatedPicks / TotalPicks) * 100);

                    if (percentageCategory == 80)
                    {
                        if (PercentageSum < 80)
                        {
                            stockItemAccumulation.ABCCategoryPicks = "A";
                            PercentageSum = PercentageSum + stockItemAccumulation.StockItemPicksPercentage;
                        }
                        else
                        {
                            stockItemAccumulation.ABCCategoryPicks = "B";
                            percentageCategory = 20;
                            PercentageSum = stockItemAccumulation.StockItemPicksPercentage;
                        }
                    }
                    if (percentageCategory == 20)
                    {
                        if (PercentageSum < 20)
                        {
                            stockItemAccumulation.ABCCategoryPicks = "B";
                            PercentageSum = PercentageSum + stockItemAccumulation.StockItemPicksPercentage;
                        }
                        else
                        {
                            stockItemAccumulation.ABCCategoryPicks = "C";
                            percentageCategory = 5;
                            PercentageSum = stockItemAccumulation.StockItemPicksPercentage;
                        }
                    }

                    if (percentageCategory == 5)
                    {
                        if (PercentageSum < 5)
                        {
                            stockItemAccumulation.ABCCategoryPicks = "C";
                            PercentageSum = PercentageSum + stockItemAccumulation.StockItemPicksPercentage;
                        }
                        else
                        {
                            stockItemAccumulation.ABCCategoryPicks = "D";
                            percentageCategory = 4;
                            PercentageSum = stockItemAccumulation.StockItemPicksPercentage;
                        }
                    }

                    if (percentageCategory == 4)
                    {
                        stockItemAccumulation.ABCCategoryPicks = "D";
                    }
                }
            }

            return Json(ABClistOfStockItemsByPicks);

        }

        public class StockItemCategoriesModel
        {
            public int Id { get; set; }
            public string Category1Id { get; set; }
            public string Category2Id { get; set; }
            public string Category3Id { get; set; }
            public string Category1 { get; set; }
            public string Category2 { get; set; }
            public string Category3 { get; set; }
        }

      public class StockItemAccumulation
        {
            public string ProductGuid { get; set; }

            public string ItemName { get; set; }
            public string ItemNumber { get; set; }
            public Decimal CostPrice { get; set; }
            public Decimal AccumulatedTurnOver { get; set; }
            public Decimal AccumulatedQuantity { get; set; }
            public Decimal AccumulatedPicks { get; set; }

     
            public string ABCCategoryTurnOver { get; set; }
            public string ABCCategoryPicks { get; set; }
            public int StockItemTurnOverPercentage { get; set; }
            public int StockItemPicksPercentage { get; set; }

        }

        public class ReducedStockItem
        {
            public string DT_RowId { get; set; }
            public string action { get; set; }

            public string Id { get; set; }
            public string ItemName { get; set; }

            public string ItemNumber { get; set; }

            public string Category1 { get; set; }
            public string Category2 { get; set; }
            public string Category3 { get; set; }
            public string category1Id { get; set; }
            public string category2Id { get; set; }
            public string category3Id { get; set; }
            public string NumberInStock { get; set; }

            public string ReorderNumberInStock { get; set; }
            public string Location { get; set; }

            public string Category { get; set; }
            public string VendorId { get; set; }
            public string VendorName { get; set; }

            public string VendorItemNumber { get; set; }
            public string Expirationdate { get; set; }
            public string InStockAgainDate { get; set; }

            public string CostPrice { get; set; }

            public string StockValue { get; set; }

            public string SalesPrice { get; set; }

            public int companyAccountId { get; set; }

            public string LastEditedDate { get; set; }

            public string CreatedDate { get; set; }
        }

        public class StockItemOutputDataModel
        {
            public StockItemOutputDataModel()
            {
                this.data = new List<ReducedStockItem>();
            }
            public List<ReducedStockItem> data { get; set; }

        }


    }
}
