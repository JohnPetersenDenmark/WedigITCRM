using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;
using WedigITCRM.StorageInterfaces;

namespace WedigITCRM.SQLImplmementationModels
{
    public class SQLPurchaseBudgetPeriodLineRepository : IPurchaseBudgetPeriodLineRepository
    {
        private AppDbContext context;
        public SQLPurchaseBudgetPeriodLineRepository(AppDbContext context)
        {
            this.context = context;
        }

        public PurchaseBudgetPeriodLine Add(PurchaseBudgetPeriodLine purchaseBudgetPeriodLine)
        {
            context.PurchaseBudgetPeriodLines.Add(purchaseBudgetPeriodLine);
            context.SaveChanges();
            return purchaseBudgetPeriodLine;
        }

        public PurchaseBudgetPeriodLine Delete(int id)
        {
            PurchaseBudgetPeriodLine purchaseBudgetPeriodLine = context.PurchaseBudgetPeriodLines.Find(id);
            if (purchaseBudgetPeriodLine != null)
            {
                context.PurchaseBudgetPeriodLines.Remove(purchaseBudgetPeriodLine);
                context.SaveChanges();
            }
            return purchaseBudgetPeriodLine;
        }

        public IEnumerable<PurchaseBudgetPeriodLine> GetAllPurchaseBudgetPeriodLines()
        {
            return context.PurchaseBudgetPeriodLines;
        }

        public PurchaseBudgetPeriodLine GetPurchaseBudgetPeriodLine(int id)
        {
            return context.PurchaseBudgetPeriodLines.Find(id);
        }

        public PurchaseBudgetPeriodLine Update(PurchaseBudgetPeriodLine purchaseBudgetPeriodLineChanges)
        {
            var purchaseBudgetPeriodLine = context.PurchaseBudgetPeriodLines.Attach(purchaseBudgetPeriodLineChanges);
            purchaseBudgetPeriodLine.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return purchaseBudgetPeriodLineChanges;
        }
    }
}
