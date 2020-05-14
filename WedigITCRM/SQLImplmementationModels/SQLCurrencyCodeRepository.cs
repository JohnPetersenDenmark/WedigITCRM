using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;
using WedigITCRM.StorageInterfaces;

namespace WedigITCRM.SQLImplmementationModels
{

    public class SQLCurrencyCodeRepository : ICurrencyCodeRepository
    {
        private AppDbContext context;
        public SQLCurrencyCodeRepository(AppDbContext context)
        {
            this.context = context;
        }


        public IEnumerable<CurrencyCode> getAllCurrencyCodes()
        {
            return context.CurrencyCodes;
        }

        public CurrencyCode getCurrencyCodeById(int Id)
        {
            return context.CurrencyCodes.Find(Id);
        }
    }
}
