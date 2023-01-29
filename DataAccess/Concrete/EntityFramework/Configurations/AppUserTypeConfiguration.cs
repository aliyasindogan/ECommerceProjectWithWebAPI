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

            builder.HasData(new AppUserType() { Id = 1, ResourceID = 1,CreatedDate=DateTime.Now,CreatedUserId=-1 });
        }
    }
}