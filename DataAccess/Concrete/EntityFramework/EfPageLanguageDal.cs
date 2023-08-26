using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;
using Entities.Dtos.PageLanguages;
using Entities.Dtos.Pages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPageLanguageDal : EfBaseRepository<PageLanguage, ECommerceDbContext>, IPageLanguageDal
    {
        //public async Task<List<PageDto>> GetListDetailAsync()
        //{
        //    using (var context = new ECommerceDbContext())
        //    {
        //        var result = from page in context.Pages
        //                     join pageType in context.PageTypes on page.PageTypeID equals pageType.Id
        //                     join pageLanguage in context.PageLaguages on page.Id equals pageLanguage.PageID
        //                     where page.IsActive==true
        //                     select new PageDto
        //                     {
        //                         Id = page.Id,
        //                         DisplayOrder = page.DisplayOrder,
        //                         //MetaDescription = page.MetaDescription,
        //                         //MetaKeywords = page.MetaKeywords,
        //                         //MetaTitle = page.MetaTitle,
        //                         //PageName = page.PageName,
        //                         //PageSeoURL = page.PageSeoURL,
        //                         PageTypeID = page.PageTypeID,
        //                         PageTypeName = pageType.PageTypeName,
        //                         PageURL = page.PageURL,
        //                         ParentPageID = page.ParentPageID,
        //                         IsActive = page.IsActive,
        //                     };
        //        return await result.ToListAsync();
        //    }
        //}
        public Task<List<Entities.Dtos.PageLanguages.PageLanguageDto>> GetListDetailAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}