using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ReepayAPI
{
    public class RecurringRequestModel
    {
        public RecurringRequestModel()
        {
            this.CreateReepayCustomer = new CreateCustomer();
        }

        [JsonProperty("button_text")]
        public string ButtonText { get; set; }


        [JsonProperty("create_customer")]
        public CreateCustomer CreateReepayCustomer { get; set; }

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

            [JsonProperty("company")]
            public string CustomerName { get; set; }

            [JsonProperty("vat")]
            public string CustomerCVRNumber { get; set; }

            [JsonProperty("address")]
            public string CustomerStreet { get; set; }

            [JsonProperty("postal code")]
            public string CustomerZip { get; set; }

            [JsonProperty("city")]
            public string CustomerCity { get; set; }

            [JsonProperty("country")]
            public string CustomerCountryCode { get; set; }

            [JsonProperty("email")]
            public string CustomerEmail { get; set; }

            [JsonProperty("first_name")]
            public string CustomerFirstName { get; set; }

            [JsonProperty("last_name")]
            public string CustomerLastName { get; set; }

        }
    }
}
