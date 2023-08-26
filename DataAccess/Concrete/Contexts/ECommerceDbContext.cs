using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess.Concrete.Contexts
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {
            //this.Database.SetCommandTimeout(999999);
        }

        public ECommerceDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connString = "Data Source =.; Initial Catalog = ECommerceDb; Integrated Security = True";

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
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<PageType> PageTypes { get; set; }
        public virtual DbSet<PagePermisson> PagePermissons { get; set; }
        public virtual DbSet<PageLanguage> PageLanguages { get; set; }
        public virtual DbSet<Language> Laguages { get; set; }
    }
}