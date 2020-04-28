using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
   public interface IPostalCodeRepository 
    {
        PostalCode getPostalCodeById(int Id);
        IEnumerable<PostalCode> getAllZips();
    }
}
