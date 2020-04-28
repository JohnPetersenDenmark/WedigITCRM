using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public interface IStockItemCategory3Repository
    {
        StockItemCategory3 GetStockItemCategory3(int id);
        IEnumerable<StockItemCategory3> GetAllStockItemCategory3s();
        StockItemCategory3 Add(StockItemCategory3 stockItemCategory3);
        StockItemCategory3 Update(StockItemCategory3 stockItemCategory3Changes);
        StockItemCategory3 Delete(int id);
    }
}
