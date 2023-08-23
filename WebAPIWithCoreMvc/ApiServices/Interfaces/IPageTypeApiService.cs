using Core.Utilities.Responses;
using Entities.Dtos.PageTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPIWithCoreMvc.ApiServices.Interfaces
{
    public interface IPageTypeApiService
    {
        Task<ApiDataResponse<List<PageTypeDto>>> GetListAsync();
    }
}