using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class PagePermissonConfiguration : IEntityTypeConfiguration<PagePermisson>
    {
        public void Configure(EntityTypeBuilder<PagePermisson> builder)
        {
            builder.ToTable("PagePermissons", @"dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PageID)
                .HasColumnName("PageID")
                .IsRequired();

            builder.Property(x => x.UserTypeID)
              .HasColumnName("UserTypeID")
              .IsRequired();

            builder.Property(x => x.OperationClaimID)
             .HasColumnName("OperationClaimID")
             .IsRequired();

            //builder.HasData(
            //    new PagePermisson() { Id = 1, PageID = 2, UserTypeID=AppUserTypes., OperationClaimID=1 }
            //);
        }
    }
}