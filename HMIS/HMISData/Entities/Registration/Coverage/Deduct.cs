using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMIS.Data.Entities.Registration.Coverage
{
    public class Deduct
    {
        public long SubscriberId { get; set; }
        public int ServiceType { get; set; }
        public decimal Deductible { get; set; }
    }
}
