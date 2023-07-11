using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMIS.Data.Entities.Registration.Coverage
{
    public class InsurranceCoverage
    {

        public long SubscriberId { get; set; }

        public string MRNo { get; set; }

        public string RelationCode { get; set; }

        public byte CoverageOrder { get; set; }

        public bool IsSelected { get; set; }
    }
}
