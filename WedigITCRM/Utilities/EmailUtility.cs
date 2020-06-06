using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using WedigITCRM.StorageInterfaces;

namespace WedigITCRM.Utilities
{
    public class EmailUtility
    {
        private IWebHostEnvironment _env;
      
        public EmailUtility(IWebHostEnvironment env)
        {
            _env = env;
  
        }


        public void send(string sendTo, string sentFrom, string subject, AlternateView htmlView, bool IsBodyHtml)
        {
            // You have to enable login from other timezone / ip for your google account.
            // to do this follow the link https://g.co/allowaccess and allow access by clicking the continue button. 
            // And that's it. Here you go. Now you will be able to login from any of the computer and by any means of app to your google account.


            MailMessage message = new MailMessage(sentFrom, sendTo);

            message.Subject = subject;
            message.Body = "Plain Text body";
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = IsBodyHtml;
            message.AlternateViews.Add(htmlView);


            SmtpClient client = new SmtpClient("smtp.unoeuro.com", 587);
            System.Net.NetworkCredential basicCredential1 = new System.Net.NetworkCredential("admin@nyxium.dk", "Kronhjort1234");

            // If it fails with a message lige not logged in to service in google then use this link:
            // https://myaccount.google.com/lesssecureapps


            //sentFrom = "johnpetersen1959@gmail.com";
            //SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            //System.Net.NetworkCredential basicCredential1 = new System.Net.NetworkCredential("johnpetersen1959@gmail.com", "Keiler1234");

            client.EnableSsl = true;
            // hvis det fejler at med at sende email så brug dette link: https://accounts.google.com/b/0/DisplayUnlockCaptcha
            client.Credentials = basicCredential1;

            client.Send(message);

        }

      


        public AlternateView getFormattedBodyByMailtemplate(MailTemplateType mailTemplateType,  Dictionary<string, string> tokens, CompanyAccount companyAccount, IAttachmentRepository _attachmentRepository)
        {
          
                string body = string.Empty;
                string mailtemplateFileName = "";

                switch (mailTemplateType)
                {
                    case MailTemplateType.AccountConfirmationToWedigit:
                        mailtemplateFileName = "AccountConfirmationWedigitEmail.html";
                        break;

                    case MailTemplateType.AccountConfirmation:
                        mailtemplateFileName = "AccountConfirmationEmail.html";
                        break;

                    case MailTemplateType.SupportTicket:
                        mailtemplateFileName = "SupportTicketEmail.html";
                        break;

                    case MailTemplateType.Resetpassword:
                        mailtemplateFileName = "ResetPassword.html";
                        break;

                    case MailTemplateType.ActivityNotification:
                        mailtemplateFileName = "ActivityNotification.html";
                        break;


                }

                StreamReader reader = new StreamReader(_env.WebRootPath + "/" + "MailTemplates" + "/" + mailtemplateFileName);
                {
                    body = reader.ReadToEnd();
                }

                foreach (var tokenKeyAndValue in tokens)
                {
                    string tokenStr = "{" + tokenKeyAndValue.Key + "}";

                    if (body.IndexOf(tokenStr) > (-1))
                    {
                        if (!string.IsNullOrEmpty(tokenKeyAndValue.Value))
                        {
                            body = body.Replace("{" + tokenKeyAndValue.Key + "}", tokenKeyAndValue.Value);
                        }
                        else
                        {
                            body = body.Replace("{" + tokenKeyAndValue.Key + "}", "");
                        }

                    }

                }

                LinkedResource LinkedImage = null;

                if (mailTemplateType == MailTemplateType.ActivityNotification)
                {
                    if (!string.IsNullOrEmpty(companyAccount.LogoAttachmentIds))
                    {
                        WedigITCRM.EntitityModels.Attachment attachment = _attachmentRepository.GetAttachment(Int32.Parse(companyAccount.LogoAttachmentIds));
                        if (attachment != null)
                        {

                            LinkedImage = new LinkedResource(_env.WebRootPath + "/" + "CustomerAttachments" + "/" + "Logos" + "/" + attachment.uniqueInternalFileName, attachment.ContentType);
                        }
                    }

                }
                else
                {
                    LinkedImage = new LinkedResource(_env.WebRootPath + "/" + "frontpage" + "/" + "img" + "/" + "nyxium-logo.png", "image/png");
                }

                AlternateView htmlView = null;
                if (LinkedImage != null)
                {
                    LinkedImage.ContentId = "logoInEmail";
                    body = body.Replace("{logocid}", LinkedImage.ContentId);
                    htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
                    htmlView.LinkedResources.Add(LinkedImage);
                }
                else
                {
                    body = body.Replace("{logocid}", "");
                    htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
                }

                return htmlView;
          
            
        }

        public AlternateView getFormattedBodyByMailtemplate(MailTemplateType mailTemplateType,  Dictionary<string, string> tokens)
        {
         
                string body = string.Empty;
                string mailtemplateFileName = "";

                switch (mailTemplateType)
                {
                    case MailTemplateType.AccountConfirmationToWedigit:
                        mailtemplateFileName = "AccountConfirmationWedigitEmail.html";
                        break;

                    case MailTemplateType.AccountConfirmation:
                        mailtemplateFileName = "AccountConfirmationEmail.html";
                        break;

                    case MailTemplateType.SupportTicket:
                        mailtemplateFileName = "SupportTicketEmail.html";
                        break;

                    case MailTemplateType.Resetpassword:
                        mailtemplateFileName = "ResetPassword.html";
                        break;

                    case MailTemplateType.ActivityNotification:
                        mailtemplateFileName = "ActivityNotification.html";
                        break;

                case MailTemplateType.SupportTicketSystemError:
                    mailtemplateFileName = "SupportTicketsystemError.html";
                    break;


            }

                StreamReader reader = new StreamReader(_env.WebRootPath + "/" + "MailTemplates" + "/" + mailtemplateFileName);
                {
                    body = reader.ReadToEnd();
                }

                foreach (var tokenKeyAndValue in tokens)
                {
                    string tokenStr = "{" + tokenKeyAndValue.Key + "}";

                    if (body.IndexOf(tokenStr) > (-1))
                    {
                        if (!string.IsNullOrEmpty(tokenKeyAndValue.Value))
                        {
                            body = body.Replace("{" + tokenKeyAndValue.Key + "}", tokenKeyAndValue.Value);
                        }
                        else
                        {
                            body = body.Replace("{" + tokenKeyAndValue.Key + "}", "");
                        }

                    }

                }

                LinkedResource LinkedImage = new LinkedResource(_env.WebRootPath + "/" + "frontpage" + "/" + "img" + "/" + "nyxium-logo.png", "image/png");

                LinkedImage.ContentId = "logoInEmail";
                body = body.Replace("{logocid}", LinkedImage.ContentId);

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
                htmlView.LinkedResources.Add(LinkedImage);

                return htmlView;
          
        }

        public enum MailTemplateType
        {
            AccountConfirmationToWedigit,
            AccountConfirmation,
            Resetpassword,
            SupportTicket,
            ActivityNotification,
            SupportTicketSystemError
        }
    }
}



