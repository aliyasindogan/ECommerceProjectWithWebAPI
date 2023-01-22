using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class AppUserTypeConfiguration : IEntityTypeConfiguration<AppUserType>
    {
        public void Configure(EntityTypeBuilder<AppUserType> builder)
        {
            builder.ToTable("AppUserTypes", @"dbo");

            builder.HasKey(x => x.Id);

            //builder.Property(x => x.UserTypeName)
            //    .HasColumnName("UserTypeName")
            //    .HasMaxLength(50)
            //    .IsRequired();

            builder.HasData(new AppUserType() { Id = 1, ResourceID = 1 });
            builder.HasData(new AppUserType() { Id = 2, ResourceID = 2 });
        }
    }
}