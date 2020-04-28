using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.Models
{
    public interface ICompanyRepository
    {
        Company GetCompany(int id);
        IEnumerable<Company> GetAllCompanies();
        Company Add(Company company);
        Company Update(Company companyChanges);
        Company Delete(int id);
    }
}
