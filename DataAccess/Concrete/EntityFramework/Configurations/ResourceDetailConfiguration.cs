using Core.Utilities.Messages;
using Entities.Abstract.Enums;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class ResourceDetailConfiguration : IEntityTypeConfiguration<ResourceDetail>
    {
        public void Configure(EntityTypeBuilder<ResourceDetail> builder)
        {
            builder.ToTable("ResourceDetails", @"dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ResourceValue)
               .HasColumnName("ResourceValue")
               .HasMaxLength(250)
               .IsRequired();

            builder.Property(x => x.ResourceID)
              .HasColumnName("ResourceID")
              .IsRequired();

            builder.Property(x => x.LanguageID)
            .HasColumnName("LanguageID")
            .IsRequired();

            builder.HasData(new ResourceDetail()
            {
                Id = 1,
                IsActive = true,
                CreatedDate = DateTime.Now,
                CreatedUserId = -1,
                ResourceValue = Constants.SystemAdmin,
                LanguageID=(int)Languages.Turkish,
                ResourceID=1,
            });
            builder.HasData(new ResourceDetail()
            {
                Id = 2,
                IsActive = true,
                CreatedDate = DateTime.Now,
                CreatedUserId = -1,
                ResourceValue = Constants.SystemAdmin,
                LanguageID = (int)Languages.English,
                ResourceID = 1,
            });
        }
    }
}
