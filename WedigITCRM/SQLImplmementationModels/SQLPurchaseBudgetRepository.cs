using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;
using WedigITCRM.StorageInterfaces;

namespace WedigITCRM.SQLImplmementationModels
{
    public class SQLPurchaseBudgetRepository : IPurchaseBudgetRepository
    {
        private AppDbContext context;
        public SQLPurchaseBudgetRepository(AppDbContext context)
        {
            this.context = context;
        }

        public PurchaseBudget Add(PurchaseBudget purchaseBudget)
        {
            context.PurchaseBudgets.Add(purchaseBudget);
            context.SaveChanges();
            return purchaseBudget;
        }

        public PurchaseBudget Delete(int id)
        {
            PurchaseBudget purchaseBudget = context.PurchaseBudgets.Find(id);
            if (purchaseBudget != null)
            {
                context.PurchaseBudgets.Remove(purchaseBudget);
                context.SaveChanges();
            }

            return purchaseBudget;
        }

        public IEnumerable<PurchaseBudget> GetAllPurchaseBudgets()
        {
            return context.PurchaseBudgets;
        }

        public PurchaseBudget GetPurchaseBudget(int id)
        {
            return context.PurchaseBudgets.Find(id);
        }

        public PurchaseBudget Update(PurchaseBudget purchaseBudgetChanges)
        {
            var purchaseBudget = context.PurchaseBudgets.Attach(purchaseBudgetChanges);
            purchaseBudget.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return purchaseBudgetChanges;
        }
    }
}
