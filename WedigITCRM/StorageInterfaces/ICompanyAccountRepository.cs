using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public interface ICompanyAccountRepository
    {
        
        CompanyAccount GetCompanyAccount(int id);
        IEnumerable<CompanyAccount> GetAllCompanyAccounts();
        CompanyAccount Add(CompanyAccount companyAccount);
        CompanyAccount Update(CompanyAccount companyAccountChanges);
        CompanyAccount Delete(int id);
        
    }
}
