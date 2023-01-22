using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
                .IsRequired();

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
        }
    }
}
