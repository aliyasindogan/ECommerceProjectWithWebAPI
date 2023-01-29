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

            builder.Property(x => x.ResourceName)
               .HasColumnName("ResourceName")
               .HasMaxLength(250)
               .IsRequired();

            builder.HasData(new Resource()
            {
                Id = 1,
                IsActive = true,
                ResourceName = Constants.AppUserType + "_" + Constants.SystemAdmin.Replace(" ", ""),
                CreatedDate=DateTime.Now,
                CreatedUserId=-1,
            }); 
        }
    }
}
