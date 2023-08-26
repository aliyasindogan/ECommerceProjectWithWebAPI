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


            builder.Property(x => x.PageURL)
              .HasColumnName("PageURL")
              .HasMaxLength(250)
              .IsRequired();

            builder.Property(x => x.ParentPageID)
             .HasColumnName("ParentPageID");


            builder.Property(x => x.PageTypeID)
            .HasColumnName("PageTypeID")
            .IsRequired();

            builder.Property(x => x.DisplayOrder)
           .HasColumnName("DisplayOrder")
           .IsRequired();
            #endregion

            builder.HasData(
            #region Sistem Ayarları
                new Page() { Id = 1, DisplayOrder = 3, PageTypeID = 1, PageURL = "#", ParentPageID = null, IsActive = true },
                new Page() { Id = 2, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUser/List", ParentPageID = 1, IsActive = true },
                new Page() { Id = 3, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUser/Add", ParentPageID = 2, IsActive = false },
                new Page() { Id = 4, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUser/Update", ParentPageID = 2, IsActive = false },
                new Page() { Id = 5, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUser/Delete", ParentPageID = 2, IsActive = false },
                new Page() { Id = 6, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUser/Detail", ParentPageID = 2, IsActive = false },


                new Page() { Id = 7, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUserType/List", ParentPageID = 1, IsActive = true },
                new Page() { Id = 8, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUserType/Add", ParentPageID = 7, IsActive = false },
                new Page() { Id = 9, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUserType/Update", ParentPageID = 7, IsActive = false },
                new Page() { Id = 10, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUserType/Delete", ParentPageID = 7, IsActive = false },
                new Page() { Id = 11, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUserType/Detail", ParentPageID = 7, IsActive = false },

                new Page() { Id = 12, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Page/List", ParentPageID = 1, IsActive = true },
                new Page() { Id = 13, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Page/Add", ParentPageID = 12, IsActive = false },
                new Page() { Id = 14, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Page/Update", ParentPageID = 12, IsActive = false },
                new Page() { Id = 15, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Page/Delete", ParentPageID = 12, IsActive = false },
                new Page() { Id = 16, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Page/Detail", ParentPageID = 12, IsActive = false },

                new Page() { Id = 17, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/PagePermisson/List", ParentPageID = 1, IsActive = true },
            #endregion

            #region Ürünler
                new Page() { Id = 18, DisplayOrder = 1, PageTypeID = 1, PageURL = "#", ParentPageID = null, IsActive = true },

                new Page() { Id = 19, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Product/List", ParentPageID = 18, IsActive = true },
                new Page() { Id = 20, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Product/Add", ParentPageID = 19, IsActive = false },
                new Page() { Id = 21, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Product/Update", ParentPageID = 19, IsActive = false },
                new Page() { Id = 22, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Product/Delete", ParentPageID = 19, IsActive = false },
                new Page() { Id = 23, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Product/Detail", ParentPageID = 19, IsActive = false },


                new Page() { Id = 24, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/ProductType/List", ParentPageID = 18, IsActive = true },
                new Page() { Id = 25, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/ProductType/Add", ParentPageID = 24, IsActive = false },
                new Page() { Id = 26, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/ProductType/Update", ParentPageID = 24, IsActive = false },
                new Page() { Id = 27, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/ProductType/Delete", ParentPageID = 24, IsActive = false },
                new Page() { Id = 28, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/ProductType/Detail", ParentPageID = 24, IsActive = false },

            #endregion

            #region Genel Sayfalar
                new Page() { Id = 29, DisplayOrder = 2, PageTypeID = 1, PageURL = "#", ParentPageID = null, IsActive = true },
                new Page() { Id = 31, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Contact/List", ParentPageID = 29, IsActive = true },
                new Page() { Id = 32, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Contact/Add", ParentPageID = 30, IsActive = false },
                new Page() { Id = 33, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Contact/Update", ParentPageID = 30, IsActive = false },
                new Page() { Id = 34, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Contact/Delete", ParentPageID = 30, IsActive = false },
                new Page() { Id = 35, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Contact/Detail", ParentPageID = 30, IsActive = false }

                #endregion
            );
        }
    }
}