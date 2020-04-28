using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public interface IStockItemCategory2Repository
    {
        StockItemCategory2 GetStockItemCategory2(int id);
        IEnumerable<StockItemCategory2> GetAllStockItemCategory2s();
        StockItemCategory2 Add(StockItemCategory2 stockItemCategory2);
        StockItemCategory2 Update(StockItemCategory2 stockItemCategory2Changes);
        StockItemCategory2 Delete(int id);
    }
}
