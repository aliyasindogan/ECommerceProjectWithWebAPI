using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class PageLanguageConfiguration : IEntityTypeConfiguration<PageLanguage>
    {
        public void Configure(EntityTypeBuilder<PageLanguage> builder)
        {
            #region builder
            builder.ToTable("PageLanguages", @"dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PageID)
               .HasColumnName("PageID")
               .IsRequired();

            builder.Property(x => x.LanguageID)
            .HasColumnName("LanguageID")
            .IsRequired();

            builder.Property(x => x.PageName)
                .HasColumnName("PageName")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.PageSeoURL)
            .HasColumnName("PageSeoURL")
            .HasMaxLength(250);

            builder.Property(x => x.MetaTitle)
           .HasColumnName("MetaTitle")
           .HasMaxLength(70);

            builder.Property(x => x.MetaKeywords)
           .HasColumnName("MetaKeywords")
           .HasMaxLength(260);

            builder.Property(x => x.MetaDescription)
           .HasColumnName("MetaDescription")
           .HasMaxLength(160);
            #endregion

            builder.HasData(
            #region PageLanguage
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 1, LanguageID = 1, PageID = 1, PageName = "Sistem Ayarları", IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 2, LanguageID = 1, PageID = 2, PageName = "Kullanıcılar", IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 3, LanguageID = 1, PageID = 3, PageName = "Kullanıcılar", IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 4, LanguageID = 1, PageID = 4, PageName = "Kullanıcılar", IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 5, LanguageID = 1, PageID = 5, PageName = "Kullanıcılar", IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 6, LanguageID = 1, PageID = 6, PageName = "Kullanıcılar", IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 7, LanguageID = 1, PageID = 7, PageName = "Kullanıcı Tipleri", IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 8, LanguageID = 1, PageID = 8, PageName = "Kullanıcı Tipleri", IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 9, LanguageID = 1, PageID = 9, PageName = "Kullanıcı Tipleri", IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 10, LanguageID = 1, PageID = 10, PageName = "Kullanıcı Tipleri", IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 11, LanguageID = 1, PageID = 11, PageName = "Kullanıcı Tipleri", IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 12, LanguageID = 1, PageID = 12, PageName = "Sayfalar", IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 13, LanguageID = 1, PageID = 13, PageName = "Sayfalar", IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 14, LanguageID = 1, PageID = 14, PageName = "Sayfalar", IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 15, LanguageID = 1, PageID = 15, PageName = "Sayfalar", IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 16, LanguageID = 1, PageID = 16, PageName = "Sayfalar", IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 17, LanguageID = 1, PageID = 17, PageName = "Sayfa Yetkileri", IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 18, LanguageID = 1, PageID = 18, PageName = "Ürün", IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 19, LanguageID = 1, PageID = 19, PageName = "Ürünler", IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 20, LanguageID = 1, PageID = 20, PageName = "Ürünler", IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 21, LanguageID = 1, PageID = 21, PageName = "Ürünler", IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 22, LanguageID = 1, PageID = 22, PageName = "Ürünler", IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 23, LanguageID = 1, PageID = 23, PageName = "Ürünler", IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 24, LanguageID = 1, PageID = 24, PageName = "Ürün Tipleri", IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 25, LanguageID = 1, PageID = 25, PageName = "Ürün Tipleri", IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 26, LanguageID = 1, PageID = 26, PageName = "Ürün Tipleri", IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 27, LanguageID = 1, PageID = 27, PageName = "Ürün Tipleri", IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 28, LanguageID = 1, PageID = 28, PageName = "Ürün Tipleri", IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 29, LanguageID = 1, PageID = 29, PageName = "Genel Sayfalar", IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 31, LanguageID = 1, PageID = 31, PageName = "Hakkımızda", IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 32, LanguageID = 1, PageID = 32, PageName = "Hakkımızda", IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 33, LanguageID = 1, PageID = 33, PageName = "Hakkımızda", IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 34, LanguageID = 1, PageID = 34, PageName = "Hakkımızda", IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new PageLanguage() { CreatedDate = DateTime.Now, CreatedUserId = -1, Id = 35, LanguageID = 1, PageID = 35, PageName = "Hakkımızda", IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" }

                #endregion
            );
        }
    }
}