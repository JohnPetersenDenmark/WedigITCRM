using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.Models
{
    public class SQLCompanyAccountRepository : ICompanyAccountRepository
    {
        private AppDbContext context;
        public SQLCompanyAccountRepository(AppDbContext context)
        {
            this.context = context;
        }

        public CompanyAccount Add(CompanyAccount companyAccount)
        {
            context.companyAccounts.Add(companyAccount);
            context.SaveChanges();
            return companyAccount;
        }

        public CompanyAccount GetCompanyAccount(int id)
        {
            return context.companyAccounts.Find(id);
        }

        public CompanyAccount Update(CompanyAccount companyAccountChanges)
        {
            var companyAccount = context.companyAccounts.Attach(companyAccountChanges);
            companyAccount.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return companyAccountChanges;
        }

        public CompanyAccount Delete(int id)
        {
            CompanyAccount companyAccount;

            companyAccount = context.companyAccounts.Find(id);
            if (companyAccount != null)
            {
                context.companyAccounts.Remove(companyAccount);
                context.SaveChanges();
            }
            return companyAccount;
        }

        public IEnumerable<CompanyAccount> GetAllCompanyAccounts()
        {
            return context.companyAccounts;
        }

       

       
    }
}
