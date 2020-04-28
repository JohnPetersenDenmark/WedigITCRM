using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.Models
{
    public class SQLStockItemCategory3Repository : IStockItemCategory3Repository
    {
        private AppDbContext context;
        public SQLStockItemCategory3Repository(AppDbContext context)
        {
            this.context = context;
        }


        public StockItemCategory3 Add(StockItemCategory3 stockItemCategory3)
        {
            context.stockItemCategory3s.Add(stockItemCategory3);
            context.SaveChanges();
            return stockItemCategory3;
        }

        public StockItemCategory3 Delete(int id)
        {
            StockItemCategory3 stockItemCategory3 = context.stockItemCategory3s.Find(id);
            if (stockItemCategory3 != null)
            {
                context.stockItemCategory3s.Remove(stockItemCategory3);
                context.SaveChanges();
            }
            return stockItemCategory3;
        }

        public IEnumerable<StockItemCategory3> GetAllStockItemCategory3s()
        {
            return context.stockItemCategory3s;
        }

        public StockItemCategory3 GetStockItemCategory3(int id)
        {
            return context.stockItemCategory3s.Find(id);
        }

        public StockItemCategory3 Update(StockItemCategory3 stockItemCategory3Changes)
        {
            var stockItemCategory3 = context.stockItemCategory3s.Attach(stockItemCategory3Changes);
            stockItemCategory3.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return stockItemCategory3Changes;
        }
    }
}
