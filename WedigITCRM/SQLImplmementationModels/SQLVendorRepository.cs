using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.Models
{
    public class SQLVendorRepository : IVendorRepository
    {
        private AppDbContext context;
        public SQLVendorRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Vendor Add(Vendor vendor)
        {
            context.Vendors.Add(vendor);
            context.SaveChanges();
            return vendor;
        }

        public Vendor Delete(int id)
        {
            Vendor vendor = context.Vendors.Find(id); 

            if (vendor != null)
            {
                context.Vendors.Remove(vendor);
                context.SaveChanges();
            }
            return vendor;
        }

        public IEnumerable<Vendor> GetAllVendors()
        {
            return context.Vendors;
        }

        public Vendor GetVendor(int id)
        {
            Vendor vendor = context.Vendors.Find(id);
            return vendor;
        }

        public Vendor Update(Vendor vendorChanges)
        {
            var vendor = context.Vendors.Attach(vendorChanges);
            vendor.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return vendorChanges;
        }
    }
}
