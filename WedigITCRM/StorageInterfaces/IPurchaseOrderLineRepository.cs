using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;

namespace WedigITCRM.StorageInterfaces
{
    public interface IPurchaseOrderLineRepository
    {
        PurchaseOrderLine GetPurchaseOrderLine(int id);
        PurchaseOrderLine Add(PurchaseOrderLine purchaseOrderLine);
        PurchaseOrderLine Update(PurchaseOrderLine purchaseOrderLineChanges);
        PurchaseOrderLine Delete(int id);
        IEnumerable<PurchaseOrderLine> GetAllpurchaseOrderLines();
    }
}
