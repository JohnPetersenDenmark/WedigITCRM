using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using static WedigITCRM.Controllers.AccountController;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WedigITCRM.Controllers
{
    public class FrontPageController : Controller
    {
        private IHostingEnvironment _env;
        public FrontPageController(IHostingEnvironment env)
        {
            _env = env;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Prices()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BuyLicense()
        {
           
            return View();
        }

        public IActionResult Support()
        {
            return View();
        }

        public IActionResult Integrations()
        {
            return View();
        }

        public IActionResult IntegrationDinero()
        {
            return View();
        }

        [HttpGet]
        public FileResult GetPDF(string fileName)
        {
           
            string PDFUrl = _env.WebRootPath +  "/Help/" + fileName;
            byte[] FileBytes = System.IO.File.ReadAllBytes(PDFUrl);
            return File(FileBytes, "application/pdf");
        }
    }
}
