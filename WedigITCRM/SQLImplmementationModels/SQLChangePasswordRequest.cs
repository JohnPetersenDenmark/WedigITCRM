using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.Models
{
    public class SQLChangePasswordRequest : IChangePasswordRequests
    {

        private AppDbContext context;
        public SQLChangePasswordRequest(AppDbContext context)
        {
            this.context = context;
        }

        public ChangePasswordRequest Add(ChangePasswordRequest ChangePasswordRequest)
        {
            context.changePasswordRequests.Add(ChangePasswordRequest);
            context.SaveChanges();
            return ChangePasswordRequest;
        }

        public ChangePasswordRequest Delete(int id)
        {
            ChangePasswordRequest ChangePasswordRequest;

            ChangePasswordRequest = context.changePasswordRequests.Find(id);
            if (ChangePasswordRequest != null)
            {
                context.changePasswordRequests.Remove(ChangePasswordRequest);
                context.SaveChanges();
            }
            return ChangePasswordRequest;
        }

        public IEnumerable<ChangePasswordRequest> GetAllChangePasswordRequest()
        {
            return context.changePasswordRequests;
        }

        public ChangePasswordRequest GetChangePasswordRequest(int id)
        {

            return context.changePasswordRequests.Find(id);
        }

        public ChangePasswordRequest Update(ChangePasswordRequest ChangePasswordRequestChanges)
        {
            var company = context.changePasswordRequests.Attach(ChangePasswordRequestChanges);
            company.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return ChangePasswordRequestChanges;
        }
    }
}
