using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;





namespace WedigITCRM.CVRAPI
{
    public static class CVRAPICompany
    {

        public static List<CVRAPIresult> GetCompanyInfo(string name)
        {
            List<CVRAPIresult> res = new List<CVRAPIresult>();
            using (var webClient = new WebClient())
            {
                webClient.Headers["User-Agent"] = "wedigIT CRM";

                string resultContent = webClient.DownloadString(string.Format("http://cvrapi.dk/api?search={0}&country=dk", name));

                var token = Newtonsoft.Json.Linq.JToken.Parse(resultContent);

                if (token is Newtonsoft.Json.Linq.JArray)
                {
                    res = JsonConvert.DeserializeObject<List<CVRAPIresult>>(resultContent);
                }
                else if (token is Newtonsoft.Json.Linq.JObject)
                {
                    var tmpresult = JsonConvert.DeserializeObject<CVRAPIresult>(resultContent);
                    res.Add(tmpresult);
                }
            }

            return res;
        }
    }
}
