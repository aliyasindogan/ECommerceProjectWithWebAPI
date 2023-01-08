using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class PageTypeConfiguration : IEntityTypeConfiguration<PageType>
    {
        public void Configure(EntityTypeBuilder<PageType> builder)
        {
            builder.ToTable("PageTypes", @"dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PageTypeName)
                .HasColumnName("PageTypeName")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasData(
                new PageType() { Id = 1, PageTypeName = "Admin",IsActive=true },
                new PageType() { Id = 2, PageTypeName = "Web", IsActive = true }
            );
        }
    }
}