using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;

namespace WedigITCRM.StorageInterfaces
{
    public interface ICookieChangeLog
    {
        CookieChangeLog getCookieChangeLog(int id);
        CookieChangeLog Add(CookieChangeLog cookieChangeLog);
        CookieChangeLog Update(CookieChangeLog CookieChangeLogChanges);
        CookieChangeLog Delete(int id);
        IEnumerable<CookieChangeLog> GetAllCookieChangeLogs();

    }
}
