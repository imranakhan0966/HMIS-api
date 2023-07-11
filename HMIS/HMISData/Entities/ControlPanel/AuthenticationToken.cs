using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HMIS.Data.Entities.ControlPanel
{
    public partial class AuthenticationToken
    {
        [Key]
        public long Token { get; set; }
        public long? UserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SessionStart { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SessionEnd { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? LastActive { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? UserLogout { get; set; }
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

        [ForeignKey("UserId")]
        [InverseProperty("AuthenticationToken")]
        public virtual Users? User { get; set; }
    }
}
