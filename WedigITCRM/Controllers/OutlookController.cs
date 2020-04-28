using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WedigITCRM.GraphAPI;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WedigITCRM.Controllers
{
    public class OutlookController : Controller
    {
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            string clientId = "5a689d62-4d0f-46ee-ac1c-50b3ab548d96";
            string clientSecrete = "MOEc@-DNF[Y]vaFfPRAqE1RFobTgt311";

            ConnectToGraphApi connectToGraphApi = new ConnectToGraphApi();

            var token = ConnectToGraphApi.gettokenToAppInAzure(clientId, clientSecrete);
            var user = await ConnectToGraphApi.GetCalendarEvents(token.Result, "jp@wedigit.dk");
            return View();
        }
    }
}
