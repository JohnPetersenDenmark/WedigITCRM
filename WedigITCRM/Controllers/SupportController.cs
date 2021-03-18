using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WedigITCRM.Utilities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WedigITCRM.Controllers
{
    
    public class SupportController : Controller
    {
        private IWebHostEnvironment _env;
        private ILogger<SupportController> _logger;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private EmailUtility _emailUtility;


        public SupportController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, EmailUtility emailUtility, ILogger<SupportController> logger, IWebHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            this.userManager = userManager;
            this.signInManager = signInManager;
            _emailUtility = emailUtility;
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]      
        public async Task<IActionResult> SendSupportTicketAsync()
        {
            SupportTicket supportTicket = new SupportTicket();

            if (signInManager.IsSignedIn(User))
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var curUser = await userManager.FindByIdAsync(userId);
                if (curUser != null)
                {
                    supportTicket.Email = curUser.Email;
                }
            }


            //supportTicket.Navn = "";
            //supportTicket.Email = "";
            //supportTicket.Beskrivelse = "";

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
