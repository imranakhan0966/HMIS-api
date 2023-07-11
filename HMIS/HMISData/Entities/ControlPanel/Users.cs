using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HMIS.Data.Entities.ControlPanel
{
    public partial class Users
    {
        public Users()
        {
            AuthenticationToken = new HashSet<AuthenticationToken>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? UserId { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? Password { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? UserName { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? MobileNumber { get; set; }
        public long? InvitationId { get; set; }
        public long? RoleId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? UpdatedBy { get; set; }


        public virtual ICollection<AuthenticationToken> AuthenticationToken { get; set; }

    }
}
