using Core.Utilities.Responses;
using Entities.Concrete;
using Entities.Dtos.Languages;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILanguageService
    {
        Task<ApiDataResponse<List<LanguageDto>>> GetListAsync();
        Task<ApiDataResponse<List<LanguageDto>>> GetListDetailAsync();
        Task<ApiDataResponse<Language>> GetAsync(Expression<Func<Language, bool>> filter);
        Task<ApiDataResponse<LanguageDto>> GetByIdAsync(int id);
    }
}