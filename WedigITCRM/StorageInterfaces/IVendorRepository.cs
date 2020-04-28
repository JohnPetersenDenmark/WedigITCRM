using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public interface IVendorRepository
    {
        Vendor GetVendor(int id);
        IEnumerable<Vendor> GetAllVendors();
        Vendor Add(Vendor vendor);
        Vendor Update(Vendor vendorChanges);
        Vendor Delete(int id);
    }
}
