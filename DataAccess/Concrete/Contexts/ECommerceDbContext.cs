using DataAccess.Concrete.EntityFramework.Configurations;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

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
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
        }

        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<AppOperationClaim> AppOperationClaims { get; set; }
        public virtual DbSet<AppUserAppOperationClaim> AppUserAppOperationClaims { get; set; }
    }
}