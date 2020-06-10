using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;
using WedigITCRM.StorageInterfaces;

namespace WedigITCRM.SQLImplmementationModels
{
    public class SQLPurchaseOrderRepository : IPurchaseOrderRepository
    {
        private AppDbContext context;
        public SQLPurchaseOrderRepository(AppDbContext context)
        {
            this.context = context;
        }

        public PurchaseOrder Add(PurchaseOrder purchaseOrder)
        {
            context.PurchaseOrders.Add(purchaseOrder);
            context.SaveChanges();
            return purchaseOrder;
        }

        public PurchaseOrder Delete(int id)
        {
            PurchaseOrder purchaseOrder = context.PurchaseOrders.Find(id);
            if (purchaseOrder != null)
            {
                context.PurchaseOrders.Remove(purchaseOrder);
                context.SaveChanges();
            }
            return purchaseOrder;
        }

        public IEnumerable<PurchaseOrder> GetAllPurchaseOrders()
        {
            return context.PurchaseOrders;
        }

        public PurchaseOrder GetPurchaseOrder(int id)
        {
            return context.PurchaseOrders.Find(id);
        }

        public PurchaseOrder Update(PurchaseOrder purchaseOrderChanges)
        {
            var purchaseOrder = context.PurchaseOrders.Attach(purchaseOrderChanges);
            purchaseOrder.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return purchaseOrderChanges;
        }
    }
}
