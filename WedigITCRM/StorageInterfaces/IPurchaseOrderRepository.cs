using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;

namespace WedigITCRM.StorageInterfaces
{
    public interface IPurchaseOrderRepository
    {

        PurchaseOrder GetPurchaseOrder(int id);
        IEnumerable<PurchaseOrder> GetAllPurchaseOrders();
        PurchaseOrder Add(PurchaseOrder purchaseOrder);
        PurchaseOrder Update(PurchaseOrder purchaseOrderChanges);
        PurchaseOrder Delete(int id);
    }
}
