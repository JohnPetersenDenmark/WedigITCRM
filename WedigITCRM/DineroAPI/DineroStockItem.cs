using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WedigITCRM.DineroAPI
{
    public class DineroStockItem
    {
        private DineroAPIConnect _dineroAPIConnect;
        public DineroStockItem(DineroAPIConnect dineroAPIConnect)
        {
            _dineroAPIConnect = dineroAPIConnect;
        }

        public string AddStockItemToDinero(StockItem nyxiumStockItem)
        {
            DineroAPIStockItem dineroAPIStockItem = new DineroAPIStockItem();

            dineroAPIStockItem.AccountNumber = 1000;
            dineroAPIStockItem.BaseAmountValue = nyxiumStockItem.SalesPrice;
            dineroAPIStockItem.Name = nyxiumStockItem.ItemName;
            dineroAPIStockItem.ProductNumber = nyxiumStockItem.ItemNumber;
            dineroAPIStockItem.Quantity = nyxiumStockItem.NumberInStock;
            dineroAPIStockItem.Unit = nyxiumStockItem.Unit;



            string tmp = JsonConvert.SerializeObject(dineroAPIStockItem);

            HttpClient client = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(dineroAPIStockItem), System.Text.Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _dineroAPIConnect._APItoken);

            var result = client.PostAsync(_dineroAPIConnect.APIEndpoint + "/" + _dineroAPIConnect.APIversion + "/" + _dineroAPIConnect.APIOrganization + "/" + "products", content).Result;
            if (result.IsSuccessStatusCode)
            {
                JObject JsonObj = JsonConvert.DeserializeObject<JObject>(result.Content.ReadAsStringAsync().Result);
                string returnValue = JsonObj.GetValue("ProductGuid").ToString();
                return returnValue;
            }
            return ("NotOK");
        }

        public string UpdateStockItemInDinero(StockItem nyxiumStockItem)
        {
            DineroAPIStockItem dineroAPIStockItem = new DineroAPIStockItem();

            dineroAPIStockItem.AccountNumber = 1000;
            dineroAPIStockItem.BaseAmountValue = nyxiumStockItem.SalesPrice;
            dineroAPIStockItem.Name = nyxiumStockItem.ItemName;
            dineroAPIStockItem.ProductNumber = nyxiumStockItem.ItemNumber;
            dineroAPIStockItem.Quantity = nyxiumStockItem.NumberInStock;
            dineroAPIStockItem.Unit = nyxiumStockItem.Unit;



            HttpClient client = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(dineroAPIStockItem), System.Text.Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _dineroAPIConnect._APItoken);

            var result = client.PutAsync(_dineroAPIConnect.APIEndpoint + "/" + _dineroAPIConnect.APIversion + "/" + _dineroAPIConnect.APIOrganization + "/" + "products" + "/" + nyxiumStockItem.DineroGuiD.ToString(), content).Result;
            if (result.IsSuccessStatusCode)
            {
                return "OK";
            }
            return ("NotOK");
        }


        public DineroAPIStockItem getStockItemFromDinero(Guid dineroProductId)
        {
            string dineroIdStr = dineroProductId.ToString();
            WebClient client = new WebClient();
            client.Headers.Add("Authorization", "Bearer " + _dineroAPIConnect._APItoken);

            String JsonString = client.DownloadString(_dineroAPIConnect.APIEndpoint + "/" + _dineroAPIConnect.APIversion + "/" + _dineroAPIConnect.APIOrganization + "/" + "products" + "/" + dineroIdStr);
            DineroAPIStockItem dineroAPIStockItem = (JsonConvert.DeserializeObject<DineroAPIStockItem>(JsonString));


            return dineroAPIStockItem;
        }


        public string DeleteStockItemInDinero(Guid dineroProductId)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _dineroAPIConnect._APItoken);

            var response = client.DeleteAsync(_dineroAPIConnect.APIEndpoint + "/" + _dineroAPIConnect.APIversion + "/" + _dineroAPIConnect.APIOrganization + "/" + "products" + "/" + dineroProductId);
            if (response.Result.IsSuccessStatusCode)
            {
                return "OK";
            }
            return ("NotOK");
        }

        public DineroAPIStockItemCollection getStockItemsFromDinero(string LastupdatedDateTime, Int32 page, Int32 pageSize)
        {


            DineroAPIStockItem dineroAPIStockItem = new DineroAPIStockItem();

            string fieldList = "ProductGuid,ProductNumber,Name,BaseAmountValue,TotalAmount,Quantity,AccountNumber,Unit,ExternalReference,Comment,CreatedAt,DeletedAt,UpdatedAt";

            WebClient client = new WebClient();
            client.Headers.Add("Authorization", "Bearer " + _dineroAPIConnect._APItoken);


            String JsonString = client.DownloadString(_dineroAPIConnect.APIEndpoint + "/" + _dineroAPIConnect.APIversion + "/" + _dineroAPIConnect.APIOrganization + "/" + "products" + "?fields=" + fieldList + "&changesSince=" + LastupdatedDateTime + "&page=" + page + "&pageSize=" + pageSize);

            return (JsonConvert.DeserializeObject<DineroAPIStockItemCollection>(JsonString));
        }


        public void CopyAllStockItemsFromNyxiumToDinero(CompanyAccount companyAccount, IStockItemRepository _stockItemRepository)
        {
            List<StockItem> stockItems = _stockItemRepository.GetAllstockItems().Where(company => company.companyAccountId == companyAccount.companyAccountId).ToList();

            foreach (var stockItem in stockItems)
            {
                string status = AddStockItemToDinero(stockItem);
                if (!status.Equals("NotOK"))
                {
                    Guid DineroGuidId = Guid.Parse(status);
                    stockItem.DineroGuiD = DineroGuidId;
                    _stockItemRepository.Update(stockItem);
                }
            }
        }

        public void CopyAllStockItemsFromDineroToNyxium(CompanyAccount companyAccount, IStockItemRepository _stockItemRepository)
        {
            DateTimeFormatInfo SweedishTimeformat = CultureInfo.GetCultureInfo("sv-SE").DateTimeFormat;

            DineroAPIConnect dineroAPIConnect = new DineroAPIConnect();

            if (dineroAPIConnect.connectToDinero(companyAccount) != null)
            {
                Int32 page;
                Int32 pageSize;

                DateTime LastupdatedDateTime = new DateTime(1980, 01, 01);


                string dateStr = LastupdatedDateTime.ToUniversalTime().ToString(SweedishTimeformat.ShortDatePattern);
                string timeStr = LastupdatedDateTime.ToUniversalTime().ToLongTimeString();
                string LastupdatedToDineroAPIDateTime = dateStr + "T" + timeStr + "Z";

                DineroStockItem dineroStockItemAPI = new DineroStockItem(dineroAPIConnect);



                page = -1;
                pageSize = 500;
                DineroAPIStockItemCollection dineroAPIStockItemCollection;
                do
                {
                    page++;
                    dineroAPIStockItemCollection = dineroStockItemAPI.getStockItemsFromDinero(LastupdatedToDineroAPIDateTime, page, pageSize);
                    foreach (var dineroStockItem in dineroAPIStockItemCollection.Collection)
                    {
                        updateOrAddStockItemInNyxium(dineroStockItem, companyAccount, _stockItemRepository);
                    }

                } while (dineroAPIStockItemCollection.Pagination.Result == pageSize);
            }
        }

        public void updateOrAddStockItemInNyxium(DineroAPIStockItem dineroStockItem, CompanyAccount companyAccount, IStockItemRepository _stockItemRepository)
        {
            if (!string.IsNullOrEmpty(dineroStockItem.ProductGuid))
            {
                Guid dineroGuid = Guid.Parse(dineroStockItem.ProductGuid);
                List<StockItem> stockItemList = _stockItemRepository.GetAllstockItems().Where(tmpStockItem => tmpStockItem.companyAccountId == companyAccount.companyAccountId && tmpStockItem.DineroGuiD == dineroGuid).ToList();
                if (stockItemList.Count == 1)
                {
                    StockItem stockItem = stockItemList.First();
                    stockItem.ItemName = dineroStockItem.Name;
                    stockItem.CostPrice = dineroStockItem.BaseAmountValue;
                    stockItem.NumberInStock = (Int32)(dineroStockItem.Quantity);
                    stockItem.ItemNumber = dineroStockItem.ProductNumber;
                    stockItem.Unit = dineroStockItem.Unit;
                    stockItem.SalesPrice = dineroStockItem.TotalAmount;

                    stockItem.LastEditedDate = DateTime.Now;
                    _stockItemRepository.Update(stockItem);
                }
                else
                {
                    if (stockItemList.Count == 0)
                    {
                        StockItem stockItem = new StockItem();
                        stockItem.ItemName = dineroStockItem.Name;
                        stockItem.CostPrice = dineroStockItem.BaseAmountValue;
                        stockItem.NumberInStock = (Int32)(dineroStockItem.Quantity);
                        stockItem.ItemNumber = dineroStockItem.ProductNumber;
                        stockItem.Unit = dineroStockItem.Unit;
                        stockItem.CostPrice = dineroStockItem.BaseAmountValue;

                        stockItem.DineroGuiD = dineroGuid;
                        stockItem.LastEditedDate = DateTime.Now;
                        stockItem.CreatedDate = DateTime.Now;
                        stockItem.companyAccountId = companyAccount.companyAccountId;
                        _stockItemRepository.Add(stockItem);
                    }
                }
            }
        }

        public void CopyAllStockItemsFromDineroToNyxiumAAA(CompanyAccount companyAccount, IStockItemRepository _stockItemRepository)
        {
            DateTimeFormatInfo SweedishTimeformat = CultureInfo.GetCultureInfo("sv-SE").DateTimeFormat;
            Int32 page;
            Int32 pageSize;


            DateTime LastupdatedDateTime = new DateTime();
            // DateTime LastupdatedDateTime = companyAccount.StockItemsToNyxiumSynchronizationDate;
            string dateStr = LastupdatedDateTime.ToUniversalTime().ToString(SweedishTimeformat.ShortDatePattern);
            string timeStr = LastupdatedDateTime.ToUniversalTime().ToLongTimeString();
            string LastupdatedToDineroAPIDateTime = dateStr + "T" + timeStr + "Z";

            page = -1;
            pageSize = 1000;

            DineroAPIStockItemCollection dineroAPIStockItemCollection = getStockItemsFromDinero(LastupdatedToDineroAPIDateTime, page, pageSize);
            foreach (var dineroStockItem in dineroAPIStockItemCollection.Collection)
            {
                StockItem stockItem = new StockItem();

                stockItem.ItemName = dineroStockItem.Name;
                stockItem.CostPrice = dineroStockItem.BaseAmountValue;
                stockItem.NumberInStock = (Int32)(dineroStockItem.Quantity);
                stockItem.ItemNumber = dineroStockItem.ProductNumber;
                stockItem.Unit = dineroStockItem.Unit;
                stockItem.CostPrice = dineroStockItem.BaseAmountValue;

                Guid dineroGuid = Guid.Parse(dineroStockItem.ProductGuid);
                stockItem.DineroGuiD = dineroGuid;
                stockItem.LastEditedDate = DateTime.Now;
                stockItem.CreatedDate = DateTime.Now;
                stockItem.companyAccountId = companyAccount.companyAccountId;
                _stockItemRepository.Add(stockItem);
            }
        }


        public class DineroAPIStockItem
        {
            public string ProductNumber { get; set; }
            public string Name { get; set; }
            public string ProductGuid { get; set; }

            public decimal BaseAmountValue { get; set; }

            public decimal TotalAmount { get; set; }
            public decimal Quantity { get; set; }
            public Int32 AccountNumber { get; set; }
            public string Unit { get; set; }
            public string ExternalReference { get; set; }
            public string Comment { get; set; }
            public string CreatedAt { get; set; }
            public string UpdatedAt { get; set; }
            public string DeletedAt { get; set; }
        }

        public class DineroAPIStockItemCollection
        {
            public DineroAPIStockItem[] Collection { get; set; }
            public DineroAPIPagination Pagination { get; set; }
        }
    }


}
