using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public interface IRelateCompanyAccountWithRoleRepository
    {

        RelateCompanyAccountWithRole GetRelateCompanyAccountWithRole(string id);
        IEnumerable<RelateCompanyAccountWithRole> GetAllRelateCompanyAccountWithRole();
        RelateCompanyAccountWithRole Add(RelateCompanyAccountWithRole relateCompanyAccountWithRole);
        RelateCompanyAccountWithRole Update(RelateCompanyAccountWithRole relateCompanyAccountWithRoleChanges);
        RelateCompanyAccountWithRole Delete(int id);
    }
}
