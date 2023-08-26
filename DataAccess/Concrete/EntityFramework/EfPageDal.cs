using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Abstract.Enums;
using Entities.Concrete;
using Entities.Dtos.PagePageLanguages;
using Entities.Dtos.Pages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPageDal : EfBaseRepository<Page, ECommerceDbContext>, IPageDal
    {
        public async Task<List<PagePageLanguageDto>> GetListAdminPanelLeftMenuAsync()
        {
            using (var context = new ECommerceDbContext())
            {
                var result = (from page in context.Pages
                              join pageType in context.PageTypes on page.PageTypeID equals pageType.Id
                              join pageLanguage in context.PageLanguages on page.Id equals pageLanguage.PageID
                              where page.IsActive == true
                              select new PagePageLanguageDto
                              {
                                  Id = page.Id,
                                  DisplayOrder = page.DisplayOrder,
                                  MetaDescription = pageLanguage.MetaDescription,
                                  MetaKeywords = pageLanguage.MetaKeywords,
                                  MetaTitle = pageLanguage.MetaTitle,
                                  PageName = pageLanguage.PageName,
                                  PageSeoURL = pageLanguage.PageSeoURL,
                                  PageTypeID = page.PageTypeID,
                                  PageTypeName = pageType.PageTypeName,
                                  PageURL = page.PageURL,
                                  ParentPageID = page.ParentPageID,
                                  IsActive = page.IsActive,
                                  LanguageName = "Türkçe",
                                  LanguageID = (int)EnumLanguages.Turkish,// Admin Panel sadece türkçe dil olcağı için statik olarak türkçe verildi.
                                  PageID = page.Id
                              }).ToListAsync();
                return await result;
            }

        }

        public Task<List<PageDto>> GetListDetailAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}