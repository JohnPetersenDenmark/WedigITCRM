using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using WedigITCRM.CVRAPI;

namespace WedigITCRM.DineroAPI
{
    public class DineroAPIConnect
    {
        static string APIAuthenticationEndpoint = "https://authz.dinero.dk/dineroapi/oauth/token";
        static string APIclientId = "WeDigIT";
        static string APIclientSecret = "99Jf7J1TPlWTTWQw5zdnwhS8a4iFjJDmBwgC1Ka15s";

        // static string APIOrganizationKey = "919325c42dd84abf977d3205063c88ce";  // Wedigit  ApS 
        // public string APIOrganization = "271862";

        // string APIOrganizationKey = "f85b6d7eeef6469bbdd55066df17e046"; // Wedigit Testfirma
        //public string APIOrganization = "285545"; // Wedigit Testfirma

        public string APIOrganizationKey;
        public string APIOrganization ;

        public string APIEndpoint = "https://api.dinero.dk";
        public string APIversion = "v1";               
        public string _APItoken;

    

        private string _basicAuthenticationBase64Encoded;

        public DineroAPIConnect()
        {
       
        }

        public string connectToDinero(string DineroAPIOrganizationKey)
        {
            APIOrganizationKey = DineroAPIOrganizationKey;
            //APIOrganization = companyAccount.DineroAPIOrganization;

            byte[] encodedBytes = System.Text.Encoding.UTF8.GetBytes(APIclientId + ":" + APIclientSecret);
            _basicAuthenticationBase64Encoded = Convert.ToBase64String(encodedBytes);
            string authenticationContent = "grant_type=password&scope=read write&username=" + APIOrganizationKey + "&password=" + APIOrganizationKey;


            HttpClient client = new HttpClient();
            var requestContent = new StringContent(authenticationContent);
            requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _basicAuthenticationBase64Encoded);

            var response = client.PostAsync(APIAuthenticationEndpoint, requestContent);

            if (response.Result.IsSuccessStatusCode)
            {
                Task<string> result = response.Result.Content.ReadAsStringAsync();
                var token = Newtonsoft.Json.Linq.JToken.Parse(result.Result);
                _APItoken = token.SelectToken("access_token").ToString();
                return _APItoken;
            }

            client.Dispose();
            return (null);
        }

    }
}
