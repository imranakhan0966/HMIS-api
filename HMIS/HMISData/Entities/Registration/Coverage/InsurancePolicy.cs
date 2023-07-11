using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMIS.Data.Entities.Registration.Coverage
{
    public class InsurancePolicy
    {
        public DateTime EffectiveDate { get; set; }
        public DateTime TerminationDate { get; set; }
        public string GroupNo { get; set; }
        public int? NoOfVisits { get; set; }
        public bool? Status { get; set; }
        public long SubscriberId { get; set; }
        public decimal? Amount { get; set; }
       
    }
}
