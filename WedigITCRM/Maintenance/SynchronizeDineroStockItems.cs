using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WedigITCRM.DineroAPI;
using WedigITCRM.Models;
using static WedigITCRM.DineroAPI.DineroStockItem;

namespace WedigITCRM.Maintenance
{
    public class SynchronizeDineroStockItems : IHostedService
    {

        private readonly IServiceScopeFactory scopeFactory;
        private Timer _timer;
        IStockItemRepository _stockItemRepository;
        DineroAPIConnect _dineroAPI;
        ICompanyAccountRepository _companyAccountRepository;


        public SynchronizeDineroStockItems(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }



        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(SynchronizeStockItems, null,  0, 3600000);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void SynchronizeStockItems(object state)
        {
            DateTimeFormatInfo SweedishTimeformat = CultureInfo.GetCultureInfo("sv-SE").DateTimeFormat;


            var scope = scopeFactory.CreateScope();

            _stockItemRepository = scope.ServiceProvider.GetRequiredService<IStockItemRepository>();
            _dineroAPI = scope.ServiceProvider.GetRequiredService<DineroAPI.DineroAPIConnect>();
            _companyAccountRepository = scope.ServiceProvider.GetRequiredService<ICompanyAccountRepository>();


            DineroAPIConnect dineroAPIConnect = new DineroAPIConnect();

            List<CompanyAccount> companyAccounts = _companyAccountRepository.GetAllCompanyAccounts().ToList();

            foreach (var companyAccount in companyAccounts)
            {      
                if (companyAccount.IntegrationDinero && companyAccount.synchronizeStockItemFromDineroToNyxium)
                {
                    if (dineroAPIConnect.connectToDinero(companyAccount) != null)
                    {
                        Int32 page;
                        Int32 pageSize;

                        DateTime LastupdatedDateTime = companyAccount.StockItemsToNyxiumSynchronizationDate;
                       // DateTime LastupdatedDateTime = new DateTime();

                        string dateStr = LastupdatedDateTime.ToUniversalTime().ToString(SweedishTimeformat.ShortDatePattern);
                        string timeStr = LastupdatedDateTime.ToUniversalTime().ToLongTimeString();
                        string LastupdatedToDineroAPIDateTime = dateStr + "T" + timeStr + "Z";

                        DineroStockItem dineroStockItemAPI = new DineroStockItem(dineroAPIConnect);



                        page = -1;
                        pageSize = 500;
                        DineroAPIStockItemCollection dineroAPIStockItemCollection;
                        do
                        {
                            page++;
                            dineroAPIStockItemCollection = dineroStockItemAPI.getStockItemsFromDinero(LastupdatedToDineroAPIDateTime, page, pageSize);
                            foreach (var dineroStockItem in dineroAPIStockItemCollection.Collection)
                            {
                                dineroStockItemAPI.updateOrAddStockItemInNyxium( dineroStockItem,  companyAccount, _stockItemRepository);
                            }

                        } while (dineroAPIStockItemCollection.Pagination.Result == pageSize);
                    }
                }


                companyAccount.StockItemsToNyxiumSynchronizationDate = DateTime.Now;
                _companyAccountRepository.Update(companyAccount);
            }
        }


    }
}
