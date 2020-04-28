using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public interface IStockItemRepository
    {
        StockItem getStockItem(int id);
        StockItem Add(StockItem stockItem);
        StockItem Update(StockItem stockItemChanges);
        StockItem Delete(int id);
        IEnumerable<StockItem> GetAllstockItems();

    }
}
