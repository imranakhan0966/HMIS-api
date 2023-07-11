using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMIS.Data.Entities.Registration
{
    public class RegAssignments
    {
            public string? MRno { get; set; }
            public int? ProviderId { get; set; }
            public int? DepartmentId { get; set; }
            public byte? FeeScheduleId { get; set; }
            public byte? FinancialClassId { get; set; }
            public int? LocationId { get; set; }
            public int? ReferringProviderId { get; set; }
            public byte? ReferralTypeId { get; set; }
            
            public bool? Active { get; set; }
            public string? ProofOfIncome { get; set; }

           public string? ReferringProviderName { get; set; }



    }
}
