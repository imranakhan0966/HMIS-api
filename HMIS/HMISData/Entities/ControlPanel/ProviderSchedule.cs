using HMIS.Data.Entities.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMIS.Data.Entities.ControlPanel
{
    public class ProviderSchedule
    {
        public long PSId { get; set; }
        public long? ProviderId { get; set; }
        public int? SiteId { get; set; }
        public int? UsageId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
       // public long? Days { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? BreakStartTime { get; set; }
        public string? BreakEndTime { get; set; }
        public string? BreakReason { get; set; }
        public short? AppPerHour { get; set; }
        public short? MaxOverloadApps { get; set; }
        public int? Priority { get; set; }
        public bool? Active { get; set; }
        public string? CreatedBy { get; set; }
        //  public string? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? Sunday { get; set; }
        public bool? Monday { get; set; }
        public bool? Tuesday { get; set; }
        public bool? Wednesday { get; set; }
        public bool? Thursday { get; set; }
        public bool? Friday { get; set; }
        public bool? Saturday { get; set; }

        public List<ProviderScheduleByAppType>? providerScheduleByAppType { get; set; }

    }
}
