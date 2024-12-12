using Microsoft.EntityFrameworkCore;
using prueba_tecnica.Models;

namespace prueba_tecnica.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<DataSet> DataSets { get; set; }
        public DbSet<Field> Fields { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación muchos a muchos entre User y Role a través de UserRole
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => ur.ID);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserID);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleID);

            // Relación uno a muchos entre User y Procedure (Creación)
            modelBuilder.Entity<Procedure>()
                .HasOne(p => p.CreatedByUser)
                .WithMany(u => u.CreatedProcedures)
                .HasForeignKey(p => p.CreatedByUserID)
                .OnDelete(DeleteBehavior.Restrict);  // Para evitar eliminar a un usuario si hay procedimientos creados

            // Relación uno a muchos entre User y Procedure (Modificación)
            modelBuilder.Entity<Procedure>()
                .HasOne(p => p.LastModifiedUser)
                .WithMany(u => u.LastModifiedProcedures)
                .HasForeignKey(p => p.LastModifiedUserID)
                .OnDelete(DeleteBehavior.Restrict);  // Similar al caso de creación

            // Relación entre Procedure y DataSet
            modelBuilder.Entity<DataSet>()
                .HasOne(ds => ds.Procedure)
                .WithMany(p => p.DataSets)
                .HasForeignKey(ds => ds.ProcedureID);

            // Relación entre DataSet y Field
            modelBuilder.Entity<DataSet>()
                .HasOne(ds => ds.Field)
                .WithMany(f => f.DataSets)
                .HasForeignKey(ds => ds.FieldID);
        }
    }
}
