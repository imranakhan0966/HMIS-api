using System;
using System.Collections.Generic;
using System.Data;
using HMIS.Data.Entities.Common;
using HMIS.Data.Entities.ControlPanel;
using HMISData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HMIS.Data.Entities
{
    public partial class HMIS_dbContext : DbContext
    {
        public HMIS_dbContext()
        {
        }

        public HMIS_dbContext(DbContextOptions<HMIS_dbContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<AuthenticationToken> AuthenticationToken { get; set; } = null!;

        //public virtual DbSet<Users> Users { get; set; } = null!;
        public virtual DbSet<HREmployee> HREmployee { get; set; } = null!;

        public virtual DbSet<LoginUserHistory> LoginUserHistory { get; set; } = null!;

        //   public virtual DbSet<Role> Role { get; set; } = null!;
        // public virtual DbSet<RolePermission> RolePermission { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-CTBVEGF; Initial Catalog=TSM_db; user id=sa;password=123qwe; integrated security=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthenticationToken>(entity =>
            {
                entity.HasKey(e => e.Token)
                    .HasName("PK__Authenti__1EB4F816C1CD78D7");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AuthenticationToken)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AuthenticationToken_Users");
            });









            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
