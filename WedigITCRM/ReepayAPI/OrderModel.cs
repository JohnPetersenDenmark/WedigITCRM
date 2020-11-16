using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ReepayAPI
{
    public partial class OrderModel
    {
        public OrderModel()
        {
            this.Order = new Order();
        }   
        

        [JsonProperty("order")]
        public Order Order { get; set; }
    }

    public partial class Order
    {
        [JsonProperty("customer_handle")]       
        public string CustomerHandle { get; set; }

        [JsonProperty("handle")]      
        public string Handle { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }
    }

   

}
