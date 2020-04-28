using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.Models
{
    public class SQLLicenseTypeRepository : ILicenseType
    {

        private AppDbContext context;
        public SQLLicenseTypeRepository(AppDbContext context)
        {
            this.context = context;
        }

        public LicenseType Add(LicenseType licenseType)
        {
            context.LicenseTypes.Add(licenseType);
            context.SaveChanges();
            return licenseType;
        }

        public LicenseType Delete(int id)
        {
            LicenseType licenseType = context.LicenseTypes.Find(id);
            if (licenseType != null)
            {
                context.LicenseTypes.Remove(licenseType);
                context.SaveChanges();
            }
            return licenseType;
        }

        public IEnumerable<LicenseType> GetAllLicenseTypes()
        {
            return context.LicenseTypes;
        }

        public LicenseType GetLicense(int id)
        {
            return context.LicenseTypes.Find(id);
        }

        public LicenseType Update(LicenseType licenseTypeChanges)
        {
            var licenseType = context.LicenseTypes.Attach(licenseTypeChanges);
            licenseType.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return licenseTypeChanges;
        }
    }
}
