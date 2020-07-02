using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;

namespace WedigITCRM.StorageInterfaces
{
    public interface IPurchaseBudgetRepository
    {
        PurchaseBudget GetPurchaseBudget(int id);
        IEnumerable<PurchaseBudget> GetAllPurchaseBudgets();
        PurchaseBudget Add(PurchaseBudget purchaseBudget);
        PurchaseBudget Update(PurchaseBudget purchaseBudgetChanges);
        PurchaseBudget Delete(int id);
    }
}
