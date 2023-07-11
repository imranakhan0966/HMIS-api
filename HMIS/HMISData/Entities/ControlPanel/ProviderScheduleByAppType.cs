using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMIS.Data.Entities.ControlPanel
{
    public class ProviderScheduleByAppType
    {
        public long PSID { get; set; }
        public long AppTypeId { get; set; }
        public long Duration { get; set; }
        public long? CPTGroupId { get; set; }
    }
}
