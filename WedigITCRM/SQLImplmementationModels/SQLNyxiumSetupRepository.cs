using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;
using WedigITCRM.StorageInterfaces;

namespace WedigITCRM.SQLImplmementationModels
{
    public class SQLNyxiumSetupRepository : INyxiumSetupRepository
    {
        private AppDbContext context;
        public SQLNyxiumSetupRepository(AppDbContext context)
        {
            this.context = context;
        }

        public NyxiumSetup Add(NyxiumSetup nyxiumSetup)
        {
            context.NyxiumSetups.Add(nyxiumSetup);
            context.SaveChanges();
            return nyxiumSetup;
        }

        public NyxiumSetup Delete(int id)
        {
            NyxiumSetup nyxiumSetup =  context.NyxiumSetups.Find(id);
            if (nyxiumSetup != null)
            {
                context.NyxiumSetups.Remove(nyxiumSetup);
                context.SaveChanges();
            }
            return nyxiumSetup;
        }

        public IEnumerable<NyxiumSetup> GetAllNyxiumSetups()
        {
            return context.NyxiumSetups;
        }

        public NyxiumSetup GetNyxiumSetup(int id)
        {
            return context.NyxiumSetups.Find(id);
        }

        public NyxiumSetup Update(NyxiumSetup nyxiumSetupChanges)
        {
            var nyxiumSetup = context.NyxiumSetups.Attach(nyxiumSetupChanges);
            nyxiumSetup.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return nyxiumSetupChanges;
        }
    }
}
