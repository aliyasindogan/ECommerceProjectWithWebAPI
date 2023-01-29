using Core.Utilities.Responses;
using Entities.Concrete;
using Entities.Dtos.Resources;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IResourceService
    {
        Task<ApiDataResponse<List<ResourceDto>>> GetListAsync();
        Task<ApiDataResponse<List<ResourceDto>>> GetListDetailAsync();
        Task<ApiDataResponse<Resource>> GetAsync(Expression<Func<Resource, bool>> filter);
        Task<ApiDataResponse<ResourceDto>> GetByIdAsync(int id);
        Task<ApiDataResponse<ResourceDto>> AddAsync(ResourceAddDto resourceAddDto);
        Task<ApiDataResponse<ResourceUpdateDto>> UpdateAsync(ResourceUpdateDto resourceUpdateDto);
        Task<ApiDataResponse<bool>> DeleteAsync(int id);
    }
}