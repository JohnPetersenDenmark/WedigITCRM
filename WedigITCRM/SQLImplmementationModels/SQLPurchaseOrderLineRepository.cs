using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;
using WedigITCRM.StorageInterfaces;

namespace WedigITCRM.SQLImplmementationModels
{
    public class SQLPurchaseOrderLineRepository : IPurchaseOrderLineRepository
    {
        private AppDbContext _context;

        public SQLPurchaseOrderLineRepository(AppDbContext context)
        {
            this._context = context;
        }

        public PurchaseOrderLine Add(PurchaseOrderLine purchaseOrderLine)
        {
            _context.PurchaseOrderLines.Add(purchaseOrderLine);
            _context.SaveChanges();
            return purchaseOrderLine;
        }

        public PurchaseOrderLine Delete(int id)
        {
            PurchaseOrderLine purchaseOrderLine = _context.PurchaseOrderLines.Find(id);
            if (purchaseOrderLine != null)
            {
                _context.PurchaseOrderLines.Remove(purchaseOrderLine);
                _context.SaveChanges();
            }
            return purchaseOrderLine;
        }

        public IEnumerable<PurchaseOrderLine> GetAllpurchaseOrderLines()
        {
            return _context.PurchaseOrderLines;
        }

        public PurchaseOrderLine GetPurchaseOrderLine(int id)
        {
            return  _context.PurchaseOrderLines.Find(id);
        }

        public PurchaseOrderLine Update(PurchaseOrderLine purchaseOrderLineChanges)
        {
            var purchaseOrderLine = _context.PurchaseOrderLines.Attach(purchaseOrderLineChanges);
            purchaseOrderLine.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return purchaseOrderLineChanges;
        }
    }
}
