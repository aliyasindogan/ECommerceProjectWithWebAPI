using Core.Utilities.Responses;
using Entities.Concrete;
using Entities.Dtos.ResourceDetails;
using Entities.Dtos.Resources;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IResourceDetailService
    {
        Task<ApiDataResponse<List<Entities.Dtos.ResourceDetails.ResourceDetailDto>>> GetListAsync();
        Task<ApiDataResponse<List<Entities.Dtos.ResourceDetails.ResourceDetailDto>>> GetListDetailAsync();
        Task<ApiDataResponse<ResourceDetail>> GetAsync(Expression<Func<ResourceDetail, bool>> filter);
        Task<ApiDataResponse<Entities.Dtos.ResourceDetails.ResourceDetailDto>> GetByIdAsync(int id);
        Task<ApiDataResponse<Entities.Dtos.ResourceDetails.ResourceDetailDto>> AddAsync(ResourceDetailAddDto resourceDetailAddDto);
        Task<ApiDataResponse<ResourceDetailUpdateDto>> UpdateAsync(ResourceDetailUpdateDto resourceDetailUpdateDto);
        Task<ApiDataResponse<bool>> DeleteAsync(int id);
    }
}