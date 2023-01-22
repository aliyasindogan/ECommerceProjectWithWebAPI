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

            builder.HasData(new Language() { Id = 1, LanguageName = "Türkçe",DisplayOrder=1,IsActive=true,LanguageCode="tr-TR"});
            builder.HasData(new Language() { Id = 2, LanguageName = "English", DisplayOrder = 2, IsActive = true, LanguageCode = "en-EN" });
        }
    }
}
