using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WedigITCRM.DineroAPI;
using WedigITCRM.Models;

namespace WedigITCRM.Maintenance
{
    public class SynchronizeDineroContactsService : IHostedService
    {
        private Timer _timer;
        private readonly IServiceScopeFactory scopeFactory;
        private ILogger<SynchronizeDineroContactsService> _logger;

        ICompanyRepository _companyRepository;
        DineroAPIConnect _dineroAPI;
        ICompanyAccountRepository _companyAccountRepository;


        public SynchronizeDineroContactsService(IServiceScopeFactory scopeFactory, ILogger<SynchronizeDineroContactsService> logger)
        {
            this.scopeFactory = scopeFactory;
            this._logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(SynchronizeDineroContacts, null, 0, 3600000);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            //New Timer does not have a stop. 
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void HelloWorld(object state)
        {
            Debug.WriteLine("Hello SynchronizeDineroService!");
        }

        public void SynchronizeDineroContacts(object state)
        {
            try
            { 
            DateTimeFormatInfo SweedishTimeformat = CultureInfo.GetCultureInfo("sv-SE").DateTimeFormat;

            var scope = scopeFactory.CreateScope();

            _companyRepository = scope.ServiceProvider.GetRequiredService<ICompanyRepository>();
            _dineroAPI = scope.ServiceProvider.GetRequiredService<DineroAPI.DineroAPIConnect>();
            _companyAccountRepository = scope.ServiceProvider.GetRequiredService<ICompanyAccountRepository>();

            DineroAPIConnect dineroAPIConnect = new DineroAPIConnect();

            List<CompanyAccount> companyAccounts = _companyAccountRepository.GetAllCompanyAccounts().ToList();

            foreach (var companyAccount in companyAccounts)
            {
                if (companyAccount.IntegrationDinero && companyAccount.synchronizeCustomerFromDineroToNyxium)
                {
                    if (dineroAPIConnect.connectToDinero(companyAccount) != null)
                    {
                        DineroContacts dineroContactsToNyxium = new DineroContacts(dineroAPIConnect);

                        Int32 page;
                        Int32 pageSize;

                        DateTime LastupdatedDateTime = companyAccount.ContactsToNyxiumLastSynchronizationDate;
                        
                        string dateStr = LastupdatedDateTime.ToUniversalTime().ToString(SweedishTimeformat.ShortDatePattern);
                        string timeStr = LastupdatedDateTime.ToUniversalTime().ToLongTimeString();
                        string LastupdatedToDineroAPIDateTime = dateStr + "T" + timeStr + "Z";


                        page = -1;
                        pageSize = 500;
                        READDineroAPIcollection readDineroAPIcollection;
                        do
                        {
                            page++;
                            readDineroAPIcollection = dineroContactsToNyxium.getContactsFromDinero(LastupdatedToDineroAPIDateTime, page, pageSize);
                            foreach (var dineroContact in readDineroAPIcollection.Collection)
                            {
                                dineroContactsToNyxium.updateOrAddContactInNyxium(dineroContact, dineroContactsToNyxium, companyAccount, _companyRepository);
                            }

                        } while (readDineroAPIcollection.Pagination.Result == pageSize);

                    }

                      

                    companyAccount.ContactsToNyxiumLastSynchronizationDate = DateTime.Now;
                    _companyAccountRepository.Update(companyAccount);
                }
            }
        }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
}


       
    }
}



