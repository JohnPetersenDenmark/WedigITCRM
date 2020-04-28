using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using WedigITCRM.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using WedigITCRM.Utilities;
using System.Net.Mail;
using System.Globalization;
using Microsoft.Extensions.Logging;
using WedigITCRM.StorageInterfaces;

namespace WedigITCRM.Maintenance
{
    public class SendActivitiesNotificationsservice : IHostedService
    {
        private Timer _timer;
        private readonly IServiceScopeFactory scopeFactory;
        private ILogger<SendActivitiesNotificationsservice> _logger;

        public SendActivitiesNotificationsservice(IServiceScopeFactory scopeFactory, ILogger<SendActivitiesNotificationsservice> logger)
        {
            this.scopeFactory = scopeFactory;
            this._logger = logger;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(SendNotifications, null, 0, 60000);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            //New Timer does not have a stop. 
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void SendNotifications(object state)
        {
            var scope = scopeFactory.CreateScope();
            
            var activityRepository = scope.ServiceProvider.GetRequiredService<IActivityRepository>();
            var contactPersonRepository = scope.ServiceProvider.GetRequiredService<IContactPersonRepository>();
            var companyRepository = scope.ServiceProvider.GetRequiredService<ICompanyRepository>();
            var companyAccountRepository = scope.ServiceProvider.GetRequiredService<ICompanyAccountRepository>();
            var attachmentRepository = scope.ServiceProvider.GetRequiredService<IAttachmentRepository>();
            var relateUserWithCompanyAccountRepository = scope.ServiceProvider.GetRequiredService<IRelateCompanyAccountWithUserRepository>();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var env = scope.ServiceProvider.GetRequiredService<Microsoft.AspNetCore.Hosting.IHostingEnvironment>();

            var activities = activityRepository.GetAllActivities().Where(activity => activity.NotifyOffset != null && activity.UserId != null && activity.NotificationIsSent == false).ToList();

            DateTime testDate;
            DateTime now = DateTime.Now;

            int testInteger;

            foreach (var activity in activities)
            {
                DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;

                DateTime ActivityDate = activity.Date;

                if (int.TryParse(activity.NotifyOffset, out testInteger))
                {

                    int NotifyOffset = int.Parse(activity.NotifyOffset) * (-1);
                    ActivityDate = ActivityDate.AddMinutes(NotifyOffset);


                    int diff = ActivityDate.CompareTo(now);
                    if (diff < 0)
                    {
                        ContactPerson contactPerson = null;
                        Company company = null;

                        if (activity.contactPersonId != 0)
                        {
                            contactPerson = contactPersonRepository.GetContactPerson(activity.contactPersonId);
                        }
                        else
                        {
                            if (activity.CompanyId != 0)
                            {
                                company = companyRepository.GetCompany(activity.CompanyId);
                            }
                        }

                        var user = userManager.FindByIdAsync(activity.UserId).Result;

                        RelateCompanyAccountWithUser relateCompanyAccountWithUser = new RelateCompanyAccountWithUser();
                        var ListOfRelateUserWithCompanyAccount = relateUserWithCompanyAccountRepository.GetAllRelateCompanyAccountWithUser().Where(u => u.user.Equals(user.Id));
                        if (ListOfRelateUserWithCompanyAccount.Count() == 1)
                        {
                            relateCompanyAccountWithUser = ListOfRelateUserWithCompanyAccount.First();
                        }

                        Dictionary<string, string> tokens = new Dictionary<string, string>();

                        tokens.Add("activitysubject", activity.Subject);
                        tokens.Add("activitydescription", activity.Description);

                        _logger.Log(LogLevel.Information, "maintenance activity format date ");
                        tokens.Add("activitydate", activity.Date.ToString(danishDateTimeformat.ShortDatePattern ));
                        tokens.Add("activitytime", activity.Date.ToString(danishDateTimeformat.ShortTimePattern));
                      
                        _logger.Log(LogLevel.Information, "maintenance activity done format date ");

                        tokens.Add("username", relateCompanyAccountWithUser.userName);

                        if (contactPerson != null)
                        {
                            
                            tokens.Add("typeContactPerson", "Kontaktperson");
                            tokens.Add("contacttitle", contactPerson.Title);
                            tokens.Add("contactname", contactPerson.FirstName + " " + contactPerson.LastName);
                            tokens.Add("contactmobilphone", contactPerson.CellPhone);
                            tokens.Add("contactPhone", contactPerson.PhoneNumber);
                            tokens.Add("contactEmail", contactPerson.Email);
                        }
                        else
                        {
                            tokens.Add("typeContactPerson", "");
                            tokens.Add("contacttitle", "");
                            tokens.Add("contactname", "");
                            tokens.Add("contactmobilphone","");
                            tokens.Add("contactPhone", "");
                            tokens.Add("contactEmail", "");
                        }

                        if (company != null)
                        {
                            tokens.Add("typeCompany", "Firma");
                            tokens.Add("companyname", company.Name);
                            tokens.Add("companystreet", company.Street);
                            tokens.Add("companyzip", company.Zip);
                            tokens.Add("companycity", company.City);
                            tokens.Add("companyphone", company.PhoneNumber);
                            tokens.Add("companyhomepageurl", company.PhoneNumber);
                        }
                        else
                        {
                            tokens.Add("typeCompany", "");
                            tokens.Add("companyname", "");
                            tokens.Add("companystreet", "");
                            tokens.Add("companyzip", "");
                            tokens.Add("companycity", "");
                            tokens.Add("companyphone", "");
                            tokens.Add("companyhomepageurl", "");
                        }


                        CompanyAccount companyAccount = companyAccountRepository.GetCompanyAccount(activity.companyAccountId);

                        AlternateView htmlView = EmailUtility.getFormattedBodyByMailtemplate(EmailUtility.MailTemplateType.ActivityNotification, env, tokens, companyAccount, attachmentRepository);
                        EmailUtility.send(user.Email, "support@nyxium.dk", "Aktivitet", htmlView, true);



                        activity.NotificationIsSent = true;
                        activityRepository.Update(activity);
                    }
                }

            }
        }
    }
}
