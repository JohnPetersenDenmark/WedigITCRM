using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.Models
{
    public class SQLCompanyRepository : ICompanyRepository
    {
        private AppDbContext context;
        public SQLCompanyRepository(AppDbContext context)
        {
            this.context = context;
        }

       

        public Company Add(Company company)
        {
          
            int i = context.Companies.Count<Company>();
            //company.Id = i;
            context.Companies.Add(company);
            context.SaveChanges();
            return company;
        }

        public Company Delete(int id)
        {
            Company company;

            company = context.Companies.Find(id);
            if ( company != null)
            {
                context.Companies.Remove(company);
                context.SaveChanges();
            }
            return company;
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return context.Companies;
        }

        public Company GetCompany(int id)
        {
            return context.Companies.Find(id);
        }

        public Company Update(Company companyChanges)
        {
            var company = context.Companies.Attach(companyChanges);
            company.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return companyChanges;
        }
    }
}
