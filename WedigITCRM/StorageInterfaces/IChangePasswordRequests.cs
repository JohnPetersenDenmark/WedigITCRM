using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public interface IChangePasswordRequests
    {
        ChangePasswordRequest GetChangePasswordRequest(int id);
        IEnumerable<ChangePasswordRequest> GetAllChangePasswordRequest();
        ChangePasswordRequest Add(ChangePasswordRequest ChangePasswordRequest);
        ChangePasswordRequest Update(ChangePasswordRequest ChangePasswordRequestChanges);
        ChangePasswordRequest Delete(int id);
    }
}
