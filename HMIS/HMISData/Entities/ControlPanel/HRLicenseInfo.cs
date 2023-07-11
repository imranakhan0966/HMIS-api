using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMISData.Models
{
    public class HRLicenseInfo
    {
        [Key]
        public long HRLicenseId { get; set; }
        public int EmployeeId { get; set; }

        public string? LicenseName { get; set; }

        public string? LicenseNo { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public bool Active { get; set; }
    }
}
