using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.Models
{
    public class SQLRelateCompanyAccountWithRoleRepository : IRelateCompanyAccountWithRoleRepository
    {
        private AppDbContext _dbcontext;
        public SQLRelateCompanyAccountWithRoleRepository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public RelateCompanyAccountWithRole Add(RelateCompanyAccountWithRole relateCompanyAccountWithRole)
        {
            _dbcontext.relateCompanyAccountWithRoles.Add(relateCompanyAccountWithRole);
            _dbcontext.SaveChanges();
            return relateCompanyAccountWithRole;
        }

        public RelateCompanyAccountWithRole Delete(int id)
        {
            RelateCompanyAccountWithRole relateCompanyAccountWithRole = _dbcontext.relateCompanyAccountWithRoles.Find(id);

            if (relateCompanyAccountWithRole != null)
            {
                _dbcontext.relateCompanyAccountWithRoles.Remove(relateCompanyAccountWithRole);
                _dbcontext.SaveChanges();
            }
            return relateCompanyAccountWithRole;
        }

        public IEnumerable<RelateCompanyAccountWithRole> GetAllRelateCompanyAccountWithRole()
        {
            return _dbcontext.relateCompanyAccountWithRoles;
        }

        public RelateCompanyAccountWithRole GetRelateCompanyAccountWithRole(string id)
        {
            return _dbcontext.relateCompanyAccountWithRoles.Find(id);

        }

        public RelateCompanyAccountWithRole Update(RelateCompanyAccountWithRole relateCompanyAccountWithRoleChanges)
        {
            var relateCompanyAccountWithRole = _dbcontext.relateCompanyAccountWithRoles.Attach(relateCompanyAccountWithRoleChanges);
            relateCompanyAccountWithRole.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbcontext.SaveChanges();
            return relateCompanyAccountWithRoleChanges;
        }
    }
}
