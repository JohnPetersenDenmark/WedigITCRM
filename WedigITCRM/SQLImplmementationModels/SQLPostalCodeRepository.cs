using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.Models
{
    public class SQLPostalCodeRepository : IPostalCodeRepository
    {
        private AppDbContext context;
        public SQLPostalCodeRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<PostalCode> getAllZips()
        {
            return context.postnumre;
        }

        public PostalCode getPostalCodeById(int Id)
        {
            return context.postnumre.Find(Id);
        }

        public PostalCode GetZity(string ZipNumber)
        {
            return context.postnumre.Find(ZipNumber);
        }
    }
}
