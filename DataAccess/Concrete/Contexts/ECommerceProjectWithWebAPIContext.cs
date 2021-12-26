using DataAccess.Concrete.EntityFramework.Mapping;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Contexts
{
    public class ECommerceProjectWithWebAPIContext : DbContext
    {
        public ECommerceProjectWithWebAPIContext(DbContextOptions<ECommerceProjectWithWebAPIContext> options) : base(options)
        {
        }

        public ECommerceProjectWithWebAPIContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connString = "Data Source =DESKTOP-CDM97OQ\\SQLEXPRESS01; Initial Catalog = ECommerceProjectWithWebAPIDb; Integrated Security = True";
            optionsBuilder.UseSqlServer(connString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
        }

        public virtual DbSet<User> Users { get; set; }
    }
}