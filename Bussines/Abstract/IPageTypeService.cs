using Core.Utilities.Responses;
using Entities.Dtos.PageTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPageTypeService
    {
        Task<ApiDataResponse<List<PageTypeDto>>> GetListAsync();
    }
}