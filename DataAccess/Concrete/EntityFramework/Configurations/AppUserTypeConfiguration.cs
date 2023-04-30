using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class AppUserTypeConfiguration : IEntityTypeConfiguration<AppUserType>
    {
        public void Configure(EntityTypeBuilder<AppUserType> builder)
        {
            builder.ToTable("AppUserTypes", @"dbo");

            builder.HasKey(x => x.Id);

            builder.HasData(new AppUserType() { Id = -1, UserTypeName = "System Admin", CreatedDate = DateTime.Now, CreatedUserId = -1 });
            builder.HasData(new AppUserType() { Id = -2, UserTypeName = "Admin", CreatedDate = DateTime.Now, CreatedUserId = -1 });
        }
    }
}