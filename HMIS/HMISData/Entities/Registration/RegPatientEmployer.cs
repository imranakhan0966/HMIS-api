using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMIS.Data.Entities.Registration
{
    public class RegPatientEmployer
    {
        public string? MRno { get; set; }
        public string? EmploymentOccupation { get; set; }
        public byte? EmploymentTypeId { get; set; }
        public byte? EmploymentStatusId { get; set; }
        public string? EmploymentCompanyName { get; set; }
    }
}
