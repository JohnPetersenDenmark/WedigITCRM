using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.Models
{
    public class SQLStockItemCategory1Repository : IStockItemCategory1Repository
    {
        private AppDbContext context;
        public SQLStockItemCategory1Repository(AppDbContext context)
        {
            this.context = context;
        }

        public StockItemCategory1 Add(StockItemCategory1 stockItemCategory1)
        {
            
            context.stockItemCategory1s.Add(stockItemCategory1);
            context.SaveChanges();
            return stockItemCategory1;
        }

        public StockItemCategory1 Delete(int id)
        {

            StockItemCategory1 stockItemCategory1 = context.stockItemCategory1s.Find(id);
            if (stockItemCategory1 != null)
            {
                context.stockItemCategory1s.Remove(stockItemCategory1);
                context.SaveChanges();
            }
            return stockItemCategory1;
        }

        public IEnumerable<StockItemCategory1> GetAllStockItemCategory1s()
        {
            return context.stockItemCategory1s;
        }

        public StockItemCategory1 GetStockItemCategory1(int id)
        {
           return context.stockItemCategory1s.Find(id);
        }

        public StockItemCategory1 Update(StockItemCategory1 stockItemCategory1Changes)
        {
            var stockItemCategory1 = context.stockItemCategory1s.Attach(stockItemCategory1Changes);
            stockItemCategory1.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return stockItemCategory1Changes;
        }
    }
}
