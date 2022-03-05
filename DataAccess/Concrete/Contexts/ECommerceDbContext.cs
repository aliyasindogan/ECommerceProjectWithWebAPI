using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess.Concrete.Contexts
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {
        }

        public ECommerceDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connString = "Data Source =DESKTOP-CDM97OQ\\SQLEXPRESS01; Initial Catalog = ECommerceDb; Integrated Security = True";
            optionsBuilder.UseSqlServer(connString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            base.OnModelCreating(modelBuilder);
            Assembly assemblyConfiguration = GetType().Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assemblyConfiguration);
        }

        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<AppOperationClaim> AppOperationClaims { get; set; }
        public virtual DbSet<AppUserTypeAppOperationClaim> AppUserTypeAppOperationClaims { get; set; }
        public virtual DbSet<AppUserType> AppUserTypes { get; set; }
    }
}