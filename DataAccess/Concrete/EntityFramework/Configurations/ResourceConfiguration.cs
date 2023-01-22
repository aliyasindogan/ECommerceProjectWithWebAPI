using Core.Utilities.Messages;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.ToTable("Resources", @"dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ResourceValue)
               .HasColumnName("ResourceValue")
               .HasMaxLength(250)
               .IsRequired();

            builder.Property(x => x.ResourceGroup)
              .HasColumnName("ResourceGroup")
              .HasMaxLength(250)
              .IsRequired();

            builder.Property(x => x.LanguageID)
            .HasColumnName("LanguageID")
            .IsRequired();

            builder.HasData(new Resource()
            {
                Id = 1,
                IsActive = true,
                LanguageID = 1,
                ResourceGroup = Constants.AppUserType,
                ResourceValue = "System Admin"
            });
            builder.HasData(new Resource()
            {
                Id = 2,
                IsActive = true,
                LanguageID = 2,
                ResourceGroup = Constants.AppUserType,
                ResourceValue = "System Admin"
            });
        }
    }
}
