using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class PageConfiguration : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            #region builder
            builder.ToTable("Pages", @"dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PageName)
                .HasColumnName("PageName")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.PageURL)
              .HasColumnName("PageURL")
              .HasMaxLength(250)
              .IsRequired();

            builder.Property(x => x.ParentID)
             .HasColumnName("ParentID");

            builder.Property(x => x.PageSeoURL)
            .HasColumnName("PageSeoURL")
            .HasMaxLength(250);

            builder.Property(x => x.PageTypeID)
            .HasColumnName("PageTypeID")
            .IsRequired();

            builder.Property(x => x.DisplayOrder)
           .HasColumnName("DisplayOrder")
           .IsRequired();

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
                new Page() { Id = 1, PageName = "Sistem Ayarları", DisplayOrder = 1, PageTypeID = 1, PageURL = "#", ParentID = null, IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },

                new Page() { Id = 2, PageName = "Kullanıcılar", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUsers/List", ParentID = 1, IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 3, PageName = "Kullanıcılar", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUsers/Add", ParentID = 2, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 4, PageName = "Kullanıcılar", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUsers/Update", ParentID = 2, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 5, PageName = "Kullanıcılar", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUsers/Delete", ParentID = 2, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 6, PageName = "Kullanıcılar", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUsers/Detail", ParentID = 2, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },


                new Page() { Id = 7, PageName = "Kullanıcı Tipleri", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUserTypes/List", ParentID = 1, IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 8, PageName = "Kullanıcı Tipleri", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUserTypes/Add", ParentID = 7, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 9, PageName = "Kullanıcı Tipleri", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUserTypes/Update", ParentID = 7, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 10, PageName = "Kullanıcı Tipleri", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUserTypes/Delete", ParentID = 7, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 11, PageName = "Kullanıcı Tipleri", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUserTypes/Detail", ParentID = 7, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },

                new Page() { Id = 12, PageName = "Sayfalar", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Pages/List", ParentID = 1, IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 13, PageName = "Sayfalar", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Pages/Add", ParentID = 12, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 14, PageName = "Sayfalar", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Pages/Update", ParentID = 12, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 15, PageName = "Sayfalar", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Pages/Delete", ParentID = 12, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 16, PageName = "Sayfalar", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Pages/Detail", ParentID = 12, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },

                new Page() { Id = 17, PageName = "Sayfa Yetkileri", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/PagePermissons/List", ParentID = 1, IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
            #endregion
                #region Ürünler
                new Page() { Id = 18, PageName = "Ürün", DisplayOrder = 1, PageTypeID = 1, PageURL = "#", ParentID = null, IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },

                new Page() { Id = 19, PageName = "Ürünler", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Products/List", ParentID = 18, IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 20, PageName = "Ürünler", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Products/Add", ParentID = 19, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 21, PageName = "Ürünler", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Products/Update", ParentID = 19, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 22, PageName = "Ürünler", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Products/Delete", ParentID = 19, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 23, PageName = "Ürünler", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Products/Detail", ParentID = 19, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },


                new Page() { Id = 24, PageName = "Ürün Tipleri", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/ProductTypes/List", ParentID = 18, IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 25, PageName = "Ürün Tipleri", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/ProductTypes/Add", ParentID = 24, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 26, PageName = "Ürün Tipleri", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/ProductTypes/Update", ParentID = 24, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 27, PageName = "Ürün Tipleri", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/ProductTypes/Delete", ParentID = 24, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 28, PageName = "Ürün Tipleri", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/ProductTypes/Detail", ParentID = 24, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },

            #endregion
                new Page() { Id = 29, PageName = "Genel Sayfalar", DisplayOrder = 1, PageTypeID = 1, PageURL = "#", ParentID = null, IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 31, PageName = "Hakkımızda", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Contacts/List", ParentID = 29, IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 32, PageName = "Hakkımızda", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Contacts/Add", ParentID = 30, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 33, PageName = "Hakkımızda", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Contacts/Update", ParentID = 30, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 34, PageName = "Hakkımızda", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Contacts/Delete", ParentID = 30, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 35, PageName = "Hakkımızda", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Contacts/Detail", ParentID = 30, IsActive = false, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" }

            );
        }
    }
}