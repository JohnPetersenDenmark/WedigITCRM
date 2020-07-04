using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;

namespace WedigITCRM.StorageInterfaces
{
    public interface IPurchaseBudgetLineRepository
    {
        PurchaseBudgetLine GetPurchaseBudgetLine(int id);
        PurchaseBudgetLine Add(PurchaseBudgetLine purchaseBudgetLine);
        PurchaseBudgetLine Update(PurchaseBudgetLine purchaseBudgetLineChanges);
        PurchaseBudgetLine Delete(int id);
        IEnumerable<PurchaseBudgetLine> GetAllPurchaseBudgetLines();
    }
}
