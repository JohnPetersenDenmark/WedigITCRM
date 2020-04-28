using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public interface ICountryRepository
    {
        Country getCountryById(int Id);
        IEnumerable<Country> getAllCountries();
    }
}
