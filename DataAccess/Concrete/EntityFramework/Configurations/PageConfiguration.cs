using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class PageConfiguration : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
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

            builder.HasData(
                new Page() { Id = 1, PageName = "Sistem Ayarları",DisplayOrder=1,PageTypeID=1,PageURL="#",ParentID=null,IsActive=true,PageSeoURL="",MetaDescription="",MetaKeywords="",MetaTitle="" },
                new Page() { Id = 2, PageName = "Kullanıcılar",DisplayOrder=1,PageTypeID=1,PageURL="/Admin/AppUsers/List",ParentID=1,IsActive=true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 3, PageName = "Kullanıcı Tipleri", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/AppUserTypes/List", ParentID = 1, IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 4, PageName = "Sayfalar", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/Pages/List", ParentID = 1, IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" },
                new Page() { Id = 5, PageName = "Sayfa Yetkileri", DisplayOrder = 1, PageTypeID = 1, PageURL = "/Admin/PagePermissons/List", ParentID = 1, IsActive = true, PageSeoURL = "", MetaDescription = "", MetaKeywords = "", MetaTitle = "" }
            );
        }
    }
}