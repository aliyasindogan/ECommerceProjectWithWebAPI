using Core.Entities.Concrete;
using Core.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class AppUserTypeAppOperationClaimConfiguration : IEntityTypeConfiguration<AppUserTypeAppOperationClaim>
    {
        public void Configure(EntityTypeBuilder<AppUserTypeAppOperationClaim> builder)
        {
            builder.ToTable("AppUserTypeAppOperationClaims", @"dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.AppOperationClaimID)
                .HasColumnName("OperationClaimId")
                .IsRequired();

            builder.Property(x => x.AppUserTypeID)
             .HasColumnName("UserTypeId")
             .IsRequired();

            builder.Property(x => x.Status)
              .HasColumnName("Status")
              .HasColumnType("char(4)")
              .HasMaxLength(4)
              .IsRequired();
            /*
             * Category sayfası
            * CRUD
            * 1111
            * 0111
            */
            //builder.HasData(
            //    new AppUserTypeAppOperationClaim() { Id = -1, AppUserTypeID = (int)AppUserTypes.Admin, AppOperationClaimID = 1, Status = "1011" },
            //    new AppUserTypeAppOperationClaim() { Id = -2, AppUserTypeID = (int)AppUserTypes.Admin, AppOperationClaimID = 2, Status = "1111" },
            //    new AppUserTypeAppOperationClaim() { Id = -3, AppUserTypeID = (int)AppUserTypes.Admin, AppOperationClaimID = 3, Status = "1111" });
        }
    }
}