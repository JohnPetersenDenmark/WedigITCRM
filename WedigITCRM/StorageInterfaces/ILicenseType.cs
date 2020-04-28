using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public interface ILicenseType
    {
        LicenseType GetLicense(int id);
        IEnumerable<LicenseType> GetAllLicenseTypes();
        LicenseType Add(LicenseType licenseType);
        LicenseType Update(LicenseType licenseTypeChanges);
        LicenseType Delete(int id);
    }
}
