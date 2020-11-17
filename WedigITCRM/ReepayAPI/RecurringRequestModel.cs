using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ReepayAPI
{
    public class RecurringRequestModel
    {
        [JsonProperty("button_text")]
        public string ButtonText { get; set; }


        //[JsonProperty("create_customer")]
        //public CreateCustomer CreateReepayCustomer { get; set; }

        [JsonProperty("customer")]
        public string CustomerId { get; set; }

        [JsonProperty("accept_url")]
        public string AcceptUrl { get; set; }

        [JsonProperty("cancel_url")]
        public string CancelUrl { get; set; }



        public partial class CreateCustomer
        {
            [JsonProperty("handle")]
            public string Handle { get; set; }
        }
    }
}
