using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISDb.Domain.Mssql.Poco
{
    public partial class BaseContext : DbContext
    {
        // Scaffold-DbContext "Server=ISTN26959\SQLExpress;Database=ISDb;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context "AutoTempContext" -DataAnnotations
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {

        }

        public virtual DbSet<LoginLog> LoginLogs { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserAuth> UserAuth { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<LoginLog>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.LoginLogs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_LoginLog_User");
            });

            modelBuilder.Entity<UserAuth>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserAuth)
                    .HasForeignKey<UserAuth>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAuth_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=ISTN26959\\SQLExpress;Database=ISDb;Trusted_Connection=True;");
            }
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
