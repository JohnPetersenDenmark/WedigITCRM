using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;

namespace WedigITCRM.StorageInterfaces
{
    public interface INyxiumSetupRepository
    {
        NyxiumSetup GetNyxiumSetup(int id);
        IEnumerable<NyxiumSetup> GetAllNyxiumSetups();
        NyxiumSetup Add(NyxiumSetup nyxiumSetup);
        NyxiumSetup Update(NyxiumSetup nyxiumSetupChanges);
        NyxiumSetup Delete(int id);
     
    }
}
