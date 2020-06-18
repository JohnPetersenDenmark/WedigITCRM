using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WedigITCRM.Utilities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WedigITCRM.Controllers
{
    [Authorize]
    public class SupportController : Controller
    {
        private IWebHostEnvironment _env;
        private ILogger<SupportController> _logger;
        private EmailUtility _emailUtility;


        public SupportController(EmailUtility emailUtility, ILogger<SupportController> logger, IWebHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            _emailUtility = emailUtility;
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]      
        public IActionResult SendSupportTicket()
        {
            SupportTicket supportTicket = new SupportTicket();

            supportTicket.Navn = "";
            supportTicket.Email = "";
            supportTicket.Beskrivelse = "";

            return View(supportTicket);
        }

        [HttpPost]      
        public IActionResult SendSupportTicket(SupportTicket model)
        {
            SupportTicket supportTicket = new SupportTicket();

            if (ModelState.IsValid)
            {
                string email = model.Email;
                string beskrivelse = model.Beskrivelse;
                string navn = model.Navn;
                string message = navn + "\n" + email + "\n" + beskrivelse;

                Dictionary<string, string> tokens = new Dictionary<string, string>();

                tokens.Add("name", model.Navn);
                tokens.Add("problemdescription", model.Beskrivelse);
                tokens.Add("useremail", model.Email);

               // EmailUtility emailUtility = new EmailUtility();

                AlternateView htmlView = _emailUtility.getFormattedBodyByMailtemplate(EmailUtility.MailTemplateType.SupportTicket,  tokens);

                _emailUtility.send("support@nyxium.dk", "support@nyxium.dk", "Support", htmlView, true, null);

            }
            return View(supportTicket);
        }
    }
}
