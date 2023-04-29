using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
                #region Sistem Ayarları
                new Page() { Id = 1, PageName = "Sistem Ayarları", DisplayOrder = 3, PageTypeID = 1, PageURL = "#", ParentID = null, IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },

                new Page() { Id = 2, PageName = "Kullanıcılar", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUser/List", ParentID = 1, IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 3, PageName = "Kullanıcılar", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUser/Add", ParentID = 2, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 4, PageName = "Kullanıcılar", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUser/Update", ParentID = 2, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 5, PageName = "Kullanıcılar", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUser/Delete", ParentID = 2, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 6, PageName = "Kullanıcılar", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUser/Detail", ParentID = 2, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },


                new Page() { Id = 7, PageName = "Kullanıcı Tipleri", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUserType/List", ParentID = 1, IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 8, PageName = "Kullanıcı Tipleri", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUserType/Add", ParentID = 7, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 9, PageName = "Kullanıcı Tipleri", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUserType/Update", ParentID = 7, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 10, PageName = "Kullanıcı Tipleri", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUserType/Delete", ParentID = 7, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 11, PageName = "Kullanıcı Tipleri", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUserType/Detail", ParentID = 7, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },

                new Page() { Id = 12, PageName = "Sayfalar", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Page/List", ParentID = 1, IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 13, PageName = "Sayfalar", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Page/Add", ParentID = 12, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 14, PageName = "Sayfalar", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Page/Update", ParentID = 12, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 15, PageName = "Sayfalar", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Page/Delete", ParentID = 12, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 16, PageName = "Sayfalar", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Page/Detail", ParentID = 12, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },

                new Page() { Id = 17, PageName = "Sayfa Yetkileri", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/PagePermisson/List", ParentID = 1, IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
            #endregion
             
                #region Ürünler
                new Page() { Id = 18, PageName = "Ürün", DisplayOrder = 1, PageTypeID = 1, PageURL = "#", ParentID = null, IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },

                new Page() { Id = 19, PageName = "Ürünler", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Product/List", ParentID = 18, IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 20, PageName = "Ürünler", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Product/Add", ParentID = 19, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 21, PageName = "Ürünler", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Product/Update", ParentID = 19, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 22, PageName = "Ürünler", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Product/Delete", ParentID = 19, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 23, PageName = "Ürünler", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Product/Detail", ParentID = 19, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },


                new Page() { Id = 24, PageName = "Ürün Tipleri", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/ProductType/List", ParentID = 18, IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 25, PageName = "Ürün Tipleri", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/ProductType/Add", ParentID = 24, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 26, PageName = "Ürün Tipleri", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/ProductType/Update", ParentID = 24, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 27, PageName = "Ürün Tipleri", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/ProductType/Delete", ParentID = 24, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 28, PageName = "Ürün Tipleri", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/ProductType/Detail", ParentID = 24, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },

            #endregion
                
                #region Genel Sayfalar
                new Page() { Id = 29, PageName = "Genel Sayfalar", DisplayOrder = 2, PageTypeID = 1, PageURL = "#", ParentID = null, IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 31, PageName = "Hakkımızda", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Contact/List", ParentID = 29, IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 32, PageName = "Hakkımızda", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Contact/Add", ParentID = 30, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 33, PageName = "Hakkımızda", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Contact/Update", ParentID = 30, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 34, PageName = "Hakkımızda", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Contact/Delete", ParentID = 30, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 35, PageName = "Hakkımızda", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Contact/Detail", ParentID = 30, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" }

                #endregion
            );
        }
    }
}