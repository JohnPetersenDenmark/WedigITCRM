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
using WedigITCRM.StorageInterfaces;

namespace WedigITCRM.Maintenance
{
    public class SynchronizeDineroContactsService : IHostedService
    {
        private Timer _timer;
        private readonly IServiceScopeFactory scopeFactory;
        private ILogger<SynchronizeDineroContactsService> _logger;

        private ICompanyRepository _companyRepository;
        private IVendorRepository _vendorRepository;
        private DineroAPIConnect _dineroAPI;
        private ICompanyAccountRepository _companyAccountRepository;
        private IContactRepository _contactRepository;


        public SynchronizeDineroContactsService(IServiceScopeFactory scopeFactory, ILogger<SynchronizeDineroContactsService> logger)
        {
            this.scopeFactory = scopeFactory;
            this._logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(SynchronizeDineroContacts, null, 0, 60000);
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
                _vendorRepository = scope.ServiceProvider.GetRequiredService<IVendorRepository>();
                _contactRepository = scope.ServiceProvider.GetRequiredService<IContactRepository>();

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

                            // DateTime LastupdatedDateTime = companyAccount.ContactsToNyxiumLastSynchronizationDate;




                            DateTime LastupdatedDateTime = new DateTime(1980, 01, 01);


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
                                    if (dineroContact.IsDebitor )
                                    {
                                        dineroContactsToNyxium.updateOrAddCustomerContactInNyxium(dineroContact, dineroContactsToNyxium, companyAccount, _companyRepository);
                                    }

                                    if (dineroContact.IsCreditor)
                                    {
                                        dineroContactsToNyxium.updateOrAddVendorInNyxium(dineroContact, dineroContactsToNyxium, companyAccount, _vendorRepository);                                        
                                    }

                                    if (!dineroContact.IsCreditor && !dineroContact.IsDebitor)
                                    {
                                        dineroContactsToNyxium.updateOrAddContactInNyxium(dineroContact, dineroContactsToNyxium, companyAccount, _contactRepository); 
                                    }
                                    
                                    if (dineroContact.IsDebitor && !dineroContact.IsCreditor)
                                    {
                                        // remove from vendor table if exists
                                        dineroContactsToNyxium.deleteVendor(dineroContact.ContactGuid, _vendorRepository);
                                        // remove from contact table if exists
                                        dineroContactsToNyxium.deleteContact(dineroContact.ContactGuid, _contactRepository);
                                    }

                                    if (!dineroContact.IsDebitor && dineroContact.IsCreditor)
                                    {
                                        // remove from customer table if exists
                                        dineroContactsToNyxium.deleteCustomer(dineroContact.ContactGuid, _companyRepository);
                                        // remove from contact table if exists
                                        dineroContactsToNyxium.deleteContact(dineroContact.ContactGuid, _contactRepository);
                                    }

                                    if (!dineroContact.IsCreditor && !dineroContact.IsDebitor)
                                    {
                                        // remove from customer table if exists
                                        dineroContactsToNyxium.deleteCustomer(dineroContact.ContactGuid, _companyRepository);
                                        // remove from vendor table if exists
                                        dineroContactsToNyxium.deleteVendor(dineroContact.ContactGuid, _vendorRepository);
                                    }

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



