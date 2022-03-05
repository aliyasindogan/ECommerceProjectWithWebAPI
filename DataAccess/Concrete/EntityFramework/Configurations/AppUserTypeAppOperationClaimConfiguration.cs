using Core.Entities.Enums;
using Entities.Concrete;
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

            builder.Property(x => x.OperationClaimId)
                .HasColumnName("OperationClaimId")
                .IsRequired();

            builder.Property(x => x.UserTypeId)
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
            builder.HasData(
                new AppUserTypeAppOperationClaim() { Id = -1, UserTypeId = (int)AppUserTypes.Admin, OperationClaimId = 1, Status = "1111" }
                );
        }
    }
}