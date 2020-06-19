using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WedigITCRM.VirkAPI
{
    public class Companies
    {
        public string UserId = "wedigIT_CVR_I_SKYEN";
        public string Password = "799574c4-e11e-4374-b9ee-902595bb1113";
        public string endPoint = "http://distribution.virk.dk/cvr-permanent/_search";

        public async Task<VirkResponse> search(VirkQuery virkquery)
        {
            VirkResponse virkResponse = null; 

            string jsonQueryString = JsonConvert.SerializeObject(virkquery);

            byte[] encodedBytes = System.Text.Encoding.UTF8.GetBytes(UserId + ":" + Password);
            String _basicAuthenticationBase64Encoded = Convert.ToBase64String(encodedBytes);


            HttpClient client = new HttpClient();
            var requestContent = new StringContent(jsonQueryString);
            requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _basicAuthenticationBase64Encoded);

            var response = client.PostAsync(endPoint, requestContent);

            if (response.Result.IsSuccessStatusCode)
            {
                string responseContent = await response.Result.Content.ReadAsStringAsync();

                virkResponse = JsonConvert.DeserializeObject<VirkResponse>(responseContent);
            }

            client.Dispose();
            return virkResponse;
        }

    }
}
