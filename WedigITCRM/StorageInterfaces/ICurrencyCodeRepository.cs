using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;

namespace WedigITCRM.StorageInterfaces
{
    public interface ICurrencyCodeRepository
    {
        CurrencyCode getCurrencyCodeById(int Id);
        IEnumerable<CurrencyCode> getAllCurrencyCodes();
    }
}
