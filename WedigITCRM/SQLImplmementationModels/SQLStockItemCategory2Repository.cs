using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.Models
{
    public class SQLStockItemCategory2Repository : IStockItemCategory2Repository
    {
        private AppDbContext context;
        public SQLStockItemCategory2Repository(AppDbContext context)
        {
            this.context = context;
        }


        public StockItemCategory2 Add(StockItemCategory2 stockItemCategory2)
        {
            context.stockItemCategory2s.Add(stockItemCategory2);
            context.SaveChanges();
            return stockItemCategory2;
        }

        public StockItemCategory2 Delete(int id)
        {
            StockItemCategory2 stockItemCategory2 = context.stockItemCategory2s.Find(id);
            if (stockItemCategory2 != null)
            {
                context.stockItemCategory2s.Remove(stockItemCategory2);
                context.SaveChanges();
            }
            return stockItemCategory2;
        }

        public IEnumerable<StockItemCategory2> GetAllStockItemCategory2s()
        {
            return context.stockItemCategory2s;
        }

        public StockItemCategory2 GetStockItemCategory2(int id)
        {
            return context.stockItemCategory2s.Find(id);
        }

        public StockItemCategory2 Update(StockItemCategory2 stockItemCategory2Changes)
        {
            var stockItemCategory2 = context.stockItemCategory2s.Attach(stockItemCategory2Changes);
            stockItemCategory2.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return stockItemCategory2Changes;
        }
    }
}
