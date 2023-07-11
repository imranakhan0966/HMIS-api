using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMIS.Data.Entities.Common
{
    public partial class LoginUserHistory
    {

        [Key]
        public long UserLoginHistoryId { get; set; }


        public string Token { get; set; }


        public string LoginUserName { get; set; }


        public string IPAddress { get; set; }

        public DateTime? LoginTime { get; set; }



        public DateTime? LogoffTime { get; set; }

        public DateTime? LastActivityTime { get; set; }



        public bool UserLogOut { get; set; }


        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }


        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }


    }
}
