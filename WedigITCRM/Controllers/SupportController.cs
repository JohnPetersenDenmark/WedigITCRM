using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WedigITCRM.Utilities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WedigITCRM.Controllers
{
    [Authorize]
    public class SupportController : Controller
    {
        private IHostingEnvironment _env;
        public SupportController(IHostingEnvironment env)
        {
            _env = env;
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


                AlternateView htmlView = EmailUtility.getFormattedBodyByMailtemplate(EmailUtility.MailTemplateType.SupportTicket, _env, tokens);
               
                EmailUtility.send("support@nyxium.dk", "support@nyxium.dk", "Support", htmlView, true);

            }
            return View(supportTicket);
        }
    }
}
