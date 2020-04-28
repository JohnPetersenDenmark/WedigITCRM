using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public interface IRelateCompanyAccountWithUserRepository
    {
        
        RelateCompanyAccountWithUser GetRelateCompanyAccountWithUser(string id);
        IEnumerable<RelateCompanyAccountWithUser> GetAllRelateCompanyAccountWithUser();
        RelateCompanyAccountWithUser Add(RelateCompanyAccountWithUser companyAccount);
        RelateCompanyAccountWithUser Update(RelateCompanyAccountWithUser companyAccountChanges);
        RelateCompanyAccountWithUser Delete(int id);
        
    }
}
