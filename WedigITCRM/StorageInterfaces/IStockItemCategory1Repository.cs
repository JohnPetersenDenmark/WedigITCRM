using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public interface IStockItemCategory1Repository
    {
        StockItemCategory1 GetStockItemCategory1(int id);
        IEnumerable<StockItemCategory1> GetAllStockItemCategory1s();
        StockItemCategory1 Add(StockItemCategory1 stockItemCategory1);
        StockItemCategory1 Update(StockItemCategory1 stockItemCategory1Changes);
        StockItemCategory1 Delete(int id);
    }
}
