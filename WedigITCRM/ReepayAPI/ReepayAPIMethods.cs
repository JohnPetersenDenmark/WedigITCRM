using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WedigITCRM.ReepayAPI
{
    public class ReepayAPIMethods
    {
        private string ReepayAPIEndpoint = "https://api.reepay.com";
        private string ReepayAPIVersion = "v1";

        private string ReepayCheckoutAPIEndpoint = "https://checkout-api.reepay.com";
        private string ReepayCheckoutAPIVersion = "v1";

        private string ReepayAPIPrivateKey = "priv_0fefb51ec57ec823174b0ce10dc5db83";

        private HttpClient httpClient;  
        private string partialResourceURL;
        private string partialCheckoutResourceURL;

        public ReepayAPIMethods(HttpClient httpClient)
        {
            this.httpClient = httpClient;

            Byte[]  bytesToEncode = System.Text.Encoding.UTF8.GetBytes(ReepayAPIPrivateKey + ":" + "");
            string _basicAuthenticationBase64Encoded = Convert.ToBase64String(bytesToEncode);
           
            this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _basicAuthenticationBase64Encoded);

            this.partialResourceURL = ReepayAPIEndpoint + "/" + ReepayAPIVersion + "/";
            this.partialCheckoutResourceURL = ReepayCheckoutAPIEndpoint + "/" + ReepayCheckoutAPIVersion + "/";
        }

        public async Task<string> GetFromReepayAPIAsync (string resourcePath)
        {
            // OBS. Remove following line
            resourcePath = "account/mail_settings";


            string resourceURL = partialResourceURL + resourcePath;
            var response = await httpClient.GetAsync(resourceURL);
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content;
                var y = await content.ReadAsStringAsync();
                return y;
            }

            return null;
        }

        public async Task<string> PostCustomerToReepayAPIAsync(OrderModel model)
        {
            
            var requestContent = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync(partialResourceURL + "customer", requestContent);

            if (result.IsSuccessStatusCode)
            {
                var resultContent = await result.Content.ReadAsStringAsync();

                var response = JsonConvert.DeserializeObject<string>(resultContent);
                return response;
            }
            return null;
        }

        public async Task<GetReepayChargeSessionResponseModel> GetChargeSessionIdAsync(OrderModel model)
        {
            string tmpContent = JsonConvert.SerializeObject(model);

            var requestContent = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync(partialCheckoutResourceURL + "session/charge", requestContent);
            if (result.IsSuccessStatusCode)
            {

                var resultContent = await result.Content.ReadAsStringAsync();

                var response = JsonConvert.DeserializeObject<GetReepayChargeSessionResponseModel>(resultContent);
                return response;
            }


            return null;
        }

       public class GetReepayChargeSessionModel
        {
            [JsonProperty("customer_handle")]
            public string CustomerHandle { get; set; }
        }
        public class GetReepayChargeSessionResponseModel
        {
            [JsonProperty("id")]
            public string SessionId { get; set; }

            [JsonProperty("url")]
            public string SessionUrl { get; set; }
        }
    }
}
