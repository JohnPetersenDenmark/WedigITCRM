using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.Models
{
    public class SQLCountryRepository : ICountryRepository
    {

        private AppDbContext context;
        public SQLCountryRepository(AppDbContext context)
        {
            this.context = context;
        }


        public IEnumerable<Country> getAllCountries()
        {
            return context.Countries;
        }

        public Country getCountryById(int Id)
        {
            return context.Countries.Find(Id);
        }
    }
}
