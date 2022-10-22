using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ControlUsuarios.Models
{
    public partial class userContext : DbContext
    {
        public userContext()
        {
        }

        public userContext(DbContextOptions<userContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("namerole");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Usuarios");

                entity.HasIndex(e => e.ID, "idUser");

                Console.WriteLine("Getting User");
                entity.Property(e => e.ID)
                    .HasColumnName("idUser")
                    .IsRequired();

                Console.WriteLine("Getting UserNAme");
                entity.Property(e => e.userName)
                    .HasMaxLength(30)
                    .HasColumnName("userName")
                    .IsRequired();

                Console.WriteLine("Getting Pass");
                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .HasColumnName("strpass")
                    .IsRequired();

                Console.WriteLine("Getting Role");
                entity.Property(e => e.IdRole).HasColumnName("RoleId");

                Console.WriteLine("Getting DocID");
                entity.Property(e => e.IDDoctor)
                    .HasColumnName("idDoc")
                    .IsRequired();

                entity.HasOne(e => e.IdRoleNavigation)
                    .WithMany(d => d.Users)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_ibfk_1");
            });

            base.OnModelCreating(modelBuilder);
            //base.OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
