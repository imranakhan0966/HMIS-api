using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMISData.Models
{
    public class HREmployeeFacility
    {
        [Key]
        public long EmployeeFacilityID { get; set; } 
        public int EmployeeId { get; set; }

        public int FacilityID { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public string? UpdatedBy { get; set; }
    }
}
