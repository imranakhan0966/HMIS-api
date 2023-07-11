using HMIS.Data.Entities.ControlPanel;
using HMISData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMIS.Common.BindingModels.ControlPanel
{
    public class AuthenticateUserResponse
    {


        public HREmployee User { get; set; }
        public List<Permissions> permissions { get; set; }
    }
}
