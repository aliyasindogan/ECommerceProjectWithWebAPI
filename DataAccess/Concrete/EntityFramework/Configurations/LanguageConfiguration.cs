using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Languages", @"dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.LanguageName)
                .HasColumnName("LanguageName")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.LanguageCode)
               .HasColumnName("LanguageCode")
               .HasMaxLength(10)
               .IsRequired();

            builder.Property(x => x.DisplayOrder)
              .HasColumnName("DisplayOrder")
              .IsRequired();

        }
    }
}
