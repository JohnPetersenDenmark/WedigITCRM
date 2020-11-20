using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.EntitityModels
{
    public class NyxiumModule
    {
        public NyxiumModuleDetails[] Modules { get; set; }
    }

    public class NyxiumModuleDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool SelectableByCustomer { get; set; }
        public NyxiumDependencyModuleDetails[] DependencyModules { get; set; }
    }

    public class NyxiumDependencyModuleDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}