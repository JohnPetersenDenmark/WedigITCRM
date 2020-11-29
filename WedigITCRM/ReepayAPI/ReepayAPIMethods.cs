﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static WedigITCRM.Controllers.PaymentController;

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


        public async Task<GetReepaySessionResponseModel> GetRecurringSessionIdAsync(RecurringRequestModel model)
        {
            string tmpContent = JsonConvert.SerializeObject(model);

            var requestContent = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync(partialCheckoutResourceURL + "session/recurring", requestContent);
            if (result.IsSuccessStatusCode)
            {

                var resultContent = await result.Content.ReadAsStringAsync();

                var response = JsonConvert.DeserializeObject<GetReepaySessionResponseModel>(resultContent);
                return response;
            }


            return null;
        }

        public async Task<GetReepayAddSubscriptionResponseModel> AddSubscription(AddSubscription model)
        {
            string tmpContent = JsonConvert.SerializeObject(model);

            var requestContent = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync(partialResourceURL + "subscription", requestContent);
            if (result.IsSuccessStatusCode)
            {

                var resultContent = await result.Content.ReadAsStringAsync();

                var response = JsonConvert.DeserializeObject<GetReepayAddSubscriptionResponseModel>(resultContent);
                return response;
            }


            return null;
        }

        public async Task<ReepayPlanResponseModel> GetPlanById(string planId)
        {
            string resourceURL = partialResourceURL + "plan" + "/" + planId + "/" + "current";
            var result = await httpClient.GetAsync(resourceURL);
            if (result.IsSuccessStatusCode)
            {
                var resultContent = await result.Content.ReadAsStringAsync();

                var response = JsonConvert.DeserializeObject<ReepayPlanResponseModel>(resultContent);
                return response;
            }

            return null;
        }

     

        public async Task<string> AddSubscriptionDiscount(SubscriptionAddDiscount model)
        {
            string tmpContent = JsonConvert.SerializeObject(model);

            var requestContent = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync(partialResourceURL + "subscription" +"/" + model.SubscriptionId + "/" + "discount", requestContent);
            if (result.IsSuccessStatusCode)
            {

                var resultContent = await result.Content.ReadAsStringAsync();

                var response = JsonConvert.DeserializeObject<string>(resultContent);
                return response;
            }


            return null;
        }

       

       
        public class GetReepaySessionResponseModel
        {
            [JsonProperty("id")]
            public string SessionId { get; set; }

            [JsonProperty("url")]
            public string SessionUrl { get; set; }
        }

        public class GetReepayAddSubscriptionResponseModel
        {
            [JsonProperty("handle")]
            public string SubscriptionId { get; set; }

        }

        public class ReepayPlanResponseModel
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("amount")]
            public string Amount { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }
        }
    }
}