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

            builder.Property(x => x.ParentID)
             .HasColumnName("ParentID");


            builder.Property(x => x.PageTypeID)
            .HasColumnName("PageTypeID")
            .IsRequired();

            builder.Property(x => x.DisplayOrder)
           .HasColumnName("DisplayOrder")
           .IsRequired();
            #endregion

            builder.HasData(
            #region Sistem Ayarları
                new Page() { Id = 1, DisplayOrder = 3, PageTypeID = 1, PageURL = "#", ParentID = null, IsActive = true },
                new Page() { Id = 2, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUser/List", ParentID = 1, IsActive = true },
                new Page() { Id = 3, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUser/Add", ParentID = 2, IsActive = false },
                new Page() { Id = 4, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUser/Update", ParentID = 2, IsActive = false },
                new Page() { Id = 5, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUser/Delete", ParentID = 2, IsActive = false },
                new Page() { Id = 6, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUser/Detail", ParentID = 2, IsActive = false },


                new Page() { Id = 7, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUserType/List", ParentID = 1, IsActive = true },
                new Page() { Id = 8, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUserType/Add", ParentID = 7, IsActive = false },
                new Page() { Id = 9, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUserType/Update", ParentID = 7, IsActive = false },
                new Page() { Id = 10, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUserType/Delete", ParentID = 7, IsActive = false },
                new Page() { Id = 11, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUserType/Detail", ParentID = 7, IsActive = false },

                new Page() { Id = 12, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Page/List", ParentID = 1, IsActive = true },
                new Page() { Id = 13, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Page/Add", ParentID = 12, IsActive = false },
                new Page() { Id = 14, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Page/Update", ParentID = 12, IsActive = false },
                new Page() { Id = 15, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Page/Delete", ParentID = 12, IsActive = false },
                new Page() { Id = 16, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Page/Detail", ParentID = 12, IsActive = false },

                new Page() { Id = 17, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/PagePermisson/List", ParentID = 1, IsActive = true },
            #endregion

            #region Ürünler
                new Page() { Id = 18, DisplayOrder = 1, PageTypeID = 1, PageURL = "#", ParentID = null, IsActive = true },

                new Page() { Id = 19, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Product/List", ParentID = 18, IsActive = true },
                new Page() { Id = 20, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Product/Add", ParentID = 19, IsActive = false },
                new Page() { Id = 21, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Product/Update", ParentID = 19, IsActive = false },
                new Page() { Id = 22, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Product/Delete", ParentID = 19, IsActive = false },
                new Page() { Id = 23, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Product/Detail", ParentID = 19, IsActive = false },


                new Page() { Id = 24, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/ProductType/List", ParentID = 18, IsActive = true },
                new Page() { Id = 25, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/ProductType/Add", ParentID = 24, IsActive = false },
                new Page() { Id = 26, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/ProductType/Update", ParentID = 24, IsActive = false },
                new Page() { Id = 27, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/ProductType/Delete", ParentID = 24, IsActive = false },
                new Page() { Id = 28, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/ProductType/Detail", ParentID = 24, IsActive = false },

            #endregion

            #region Genel Sayfalar
                new Page() { Id = 29, DisplayOrder = 2, PageTypeID = 1, PageURL = "#", ParentID = null, IsActive = true },
                new Page() { Id = 31, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Contact/List", ParentID = 29, IsActive = true },
                new Page() { Id = 32, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Contact/Add", ParentID = 30, IsActive = false },
                new Page() { Id = 33, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Contact/Update", ParentID = 30, IsActive = false },
                new Page() { Id = 34, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Contact/Delete", ParentID = 30, IsActive = false },
                new Page() { Id = 35, DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Contact/Detail", ParentID = 30, IsActive = false }

                #endregion
            );
        }
    }
}