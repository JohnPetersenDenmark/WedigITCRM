using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static WedigITCRM.DineroAPI.DineroStockItem;

namespace WedigITCRM.DineroAPI
{
    public class DineroServiceToProduct
    {
        private DineroAPIConnect _dineroAPIConnect;
        public DineroServiceToProduct(DineroAPIConnect dineroAPIConnect)
        {
            _dineroAPIConnect = dineroAPIConnect;
        }

        public string AddServiceToDinero(BookingService bookingService)
        {
            DineroAPIStockItem dineroAPIStockItem = new DineroAPIStockItem();

            dineroAPIStockItem.AccountNumber = 1000;
            dineroAPIStockItem.BaseAmountValue = bookingService.SalesPrice;
            dineroAPIStockItem.Name = bookingService.Name;
            dineroAPIStockItem.ProductNumber = bookingService.ProductNumber;
            dineroAPIStockItem.Quantity = 1;
            dineroAPIStockItem.Unit = "hours";



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

        public string UpdateServiceToStockItem(BookingService bookingService)
        {
            DineroAPIStockItem dineroAPIStockItem = new DineroAPIStockItem();

            dineroAPIStockItem.AccountNumber = 1000;
            dineroAPIStockItem.BaseAmountValue = bookingService.SalesPrice;
            dineroAPIStockItem.Name = bookingService.Name;
            dineroAPIStockItem.ProductNumber = bookingService.ProductNumber;
            dineroAPIStockItem.Quantity = 1;
            dineroAPIStockItem.Unit = "hours";


            HttpClient client = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(dineroAPIStockItem), System.Text.Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _dineroAPIConnect._APItoken);

            var result = client.PutAsync(_dineroAPIConnect.APIEndpoint + "/" + _dineroAPIConnect.APIversion + "/" + _dineroAPIConnect.APIOrganization + "/" + "products" + "/" + bookingService.DineroGuiD.ToString(), content).Result;
            if (result.IsSuccessStatusCode)
            {
                return "OK";
            }
            return ("NotOK");
        }

        public string DeleteServiceStockItem(Guid dineroProductId)
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
    }
}
