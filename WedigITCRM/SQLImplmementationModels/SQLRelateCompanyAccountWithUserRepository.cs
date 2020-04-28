using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.Models
{
    public class SQLRelateCompanyAccountWithUserRepository : IRelateCompanyAccountWithUserRepository
    {
        private AppDbContext _dbcontext;
        public SQLRelateCompanyAccountWithUserRepository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

   

        public RelateCompanyAccountWithUser Add(RelateCompanyAccountWithUser companyAccountRelateToUser)
        {
            _dbcontext.relateCompanyAccountWithUsers.Add(companyAccountRelateToUser);
            _dbcontext.SaveChanges();
            return companyAccountRelateToUser;
        }

        public RelateCompanyAccountWithUser GetRelateCompanyAccountWithUser(string id)
        {
            return _dbcontext.relateCompanyAccountWithUsers.Find(id);
        }

        public RelateCompanyAccountWithUser Update(RelateCompanyAccountWithUser companyAccountRelateToUserChanges)
        {
            var companyAccountRelateToUser = _dbcontext.relateCompanyAccountWithUsers.Attach(companyAccountRelateToUserChanges);
            companyAccountRelateToUser.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbcontext.SaveChanges();
            return companyAccountRelateToUserChanges;
        }

        public RelateCompanyAccountWithUser Delete(int id)
        {
            RelateCompanyAccountWithUser relateCompanyAccountWithUser =  _dbcontext.relateCompanyAccountWithUsers.Find(id);

            if (relateCompanyAccountWithUser != null)
            {
                _dbcontext.relateCompanyAccountWithUsers.Remove(relateCompanyAccountWithUser);
                _dbcontext.SaveChanges();
            }
            return relateCompanyAccountWithUser;
        }

        public IEnumerable<RelateCompanyAccountWithUser> GetAllRelateCompanyAccountWithUser()
        {
           return _dbcontext.relateCompanyAccountWithUsers;

        }

       
      
    }
}
