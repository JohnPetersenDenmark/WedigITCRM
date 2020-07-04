using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;

namespace WedigITCRM.StorageInterfaces
{
    public interface IPurchaseBudgetPeriodLineRepository
    {
        PurchaseBudgetPeriodLine GetPurchaseBudgetPeriodLine(int id);
        IEnumerable<PurchaseBudgetPeriodLine> GetAllPurchaseBudgetPeriodLines();
        PurchaseBudgetPeriodLine Add(PurchaseBudgetPeriodLine purchaseBudgetPeriodLine);
        PurchaseBudgetPeriodLine Update(PurchaseBudgetPeriodLine purchaseBudgetPeriodLineChanges);
        PurchaseBudgetPeriodLine Delete(int id);
    }
}
