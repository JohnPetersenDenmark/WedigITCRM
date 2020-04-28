using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.Models
{
    public class SQLStockItemRepository : IStockItemRepository
    {
        private AppDbContext _context;

        public SQLStockItemRepository(AppDbContext context)
        {
            this._context = context;
        }


        public StockItem Add(StockItem stockItem)
        {
             _context.stockItems.Add(stockItem);
            _context.SaveChanges();
            return stockItem;
        }

        public StockItem Delete(int id)
        {
            StockItem stockItem = _context.stockItems.Find(id);
            if (stockItem != null)
            {
                _context.stockItems.Remove(stockItem);
                _context.SaveChanges();
            }
            return stockItem;
        }

        public IEnumerable<StockItem> GetAllstockItems()
        {
            return _context.stockItems;
        }

        public StockItem getStockItem(int id)
        {
            return _context.stockItems.Find(id);
        }

        public StockItem Update(StockItem stockItemChanges)
        {
            var stockItem = _context.stockItems.Attach(stockItemChanges);
            stockItem.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return stockItemChanges;
        }
    }
}
