using Core.Utilities.Responses;
using Entities.Dtos.Languages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPIWithCoreMvc.ApiServices.Interfaces
{
    public interface ILanguageApiService
    {
        Task<ApiDataResponse<List<LanguageDto>>> GetListAsync();
    }
}