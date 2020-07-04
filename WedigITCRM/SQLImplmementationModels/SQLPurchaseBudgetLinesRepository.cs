using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;
using WedigITCRM.StorageInterfaces;

namespace WedigITCRM.SQLImplmementationModels
{
    public class SQLPurchaseBudgetLinesRepository : IPurchaseBudgetLineRepository
    {
        private AppDbContext context;
        public SQLPurchaseBudgetLinesRepository(AppDbContext context)
        {
            this.context = context;
        }

        public PurchaseBudgetLine Add(PurchaseBudgetLine purchaseBudgetLine)
        {
            context.PurchaseBudgetLines.Add(purchaseBudgetLine);
            context.SaveChanges();
            return purchaseBudgetLine;
        }

        public PurchaseBudgetLine Delete(int id)
        {
            PurchaseBudgetLine purchaseBudgetLine = context.PurchaseBudgetLines.Find(id);
            if (purchaseBudgetLine != null)
            {
                context.PurchaseBudgetLines.Remove(purchaseBudgetLine);
                context.SaveChanges();
            }
            return purchaseBudgetLine;
        }

        public IEnumerable<PurchaseBudgetLine> GetAllPurchaseBudgetLines()
        {
            return context.PurchaseBudgetLines;
        }

        public PurchaseBudgetLine GetPurchaseBudgetLine(int id)
        {
            return context.PurchaseBudgetLines.Find(id);
        }

        public PurchaseBudgetLine Update(PurchaseBudgetLine purchaseBudgetLineChanges)
        {
            var purchaseBudgetLine = context.PurchaseBudgetLines.Attach(purchaseBudgetLineChanges);
            purchaseBudgetLine.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return purchaseBudgetLineChanges;
        }
    }
}
