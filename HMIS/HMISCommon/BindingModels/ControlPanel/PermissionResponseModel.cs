using HMIS.Common.BindingModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMIS.Common.BindingModels.ControlPanel
{
    public class PermissionResponseModel
    {
        public List<Module> Modules { get; set; }

        public List<Roles> Roles { get; set; }


        public List<string> Permissions { get; set; } 
    }
}
