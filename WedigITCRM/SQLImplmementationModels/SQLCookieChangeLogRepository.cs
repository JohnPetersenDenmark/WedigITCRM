using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;
using WedigITCRM.StorageInterfaces;

namespace WedigITCRM.SQLImplmementationModels
{
    public class SQLCookieChangeLogRepository : ICookieChangeLog
    {

        private AppDbContext _context;

        public SQLCookieChangeLogRepository(AppDbContext context)
        {
            this._context = context;
        }


        public CookieChangeLog Add(CookieChangeLog cookieChangeLog)
        {
            _context.CookieChangeLog.Add(cookieChangeLog);
            _context.SaveChanges();
            return cookieChangeLog;
        }

        public CookieChangeLog Delete(int id)
        {
            CookieChangeLog cookieChangeLog = _context.CookieChangeLog.Find(id);
            if (cookieChangeLog != null)
            {
                _context.CookieChangeLog.Remove(cookieChangeLog);
                _context.SaveChanges();
            }
            return cookieChangeLog;
        }

        public IEnumerable<CookieChangeLog> GetAllCookieChangeLogs()
        {
            return _context.CookieChangeLog;
        }

        public CookieChangeLog getCookieChangeLog(int id)
        {
            CookieChangeLog cookieChangeLog = _context.CookieChangeLog.Find(id);
            return cookieChangeLog;
        }

        public CookieChangeLog Update(CookieChangeLog CookieChangeLogChanges)
        {
            var cookieChangeLog = _context.CookieChangeLog.Attach(CookieChangeLogChanges);
            cookieChangeLog.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return CookieChangeLogChanges; 
        }
    }
}
