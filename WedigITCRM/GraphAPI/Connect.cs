using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WedigITCRM.GraphAPI
{
    public class ConnectToGraphApi
    {

       


        public static async Task<string> gettokenToAppInAzure(string clientId, string clientSecrete)
        {
            string access_token = null;

            

            string clientIdParameter = "client_id=" + clientId;
            string scopeParameter = "scope=https://graph.microsoft.com/.default";
            string grant_typeParameter = "grant_type=client_credentials";                     
            string client_secretParameter = "client_secret=" + clientSecrete;

            string tenant = "wedigit.dk";

            string AuthenticationEndpoint = "https://login.microsoftonline.com/" + tenant + "/oauth2/v2.0/token";
        


            string authenticationContent = clientIdParameter + "&" + client_secretParameter + "&" + scopeParameter + "&" + grant_typeParameter;

            HttpClient client = new HttpClient();
            var requestContent = new StringContent(authenticationContent);
            requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
           

            var response = client.PostAsync(AuthenticationEndpoint, requestContent);

            if (response.Result.IsSuccessStatusCode)
            {
                Task<string> result = response.Result.Content.ReadAsStringAsync();
                var token = Newtonsoft.Json.Linq.JToken.Parse(result.Result);
                access_token = token.SelectToken("access_token").ToString();
            }

            client.Dispose();
            return access_token;
        }

        public static async Task<string> GetCalendarEvents(string token, string userEmailName)
        {

            WebClient client = new WebClient();
            client.Headers.Add("Authorization", "Bearer " + token);
            String JsonString = client.DownloadString("https://graph.microsoft.com/v1.0/users/" + userEmailName + "/events");


            return JsonString;
        }

       
    }

   
}
