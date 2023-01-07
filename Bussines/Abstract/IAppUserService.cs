using Core.Entities.Dtos;
using Core.Utilities.Responses;
using Entities.Concrete;
using Entities.Dtos.AppUsers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAppUserService
    {
        Task<ApiDataResponse<List<AppUserDto>>> GetListAsync();
        Task<ApiDataResponse<List<AppUserDto>>> GetListDetailAsync();

        Task<ApiDataResponse<AppUser>> GetAsync(Expression<Func<AppUser, bool>> filter);

        Task<ApiDataResponse<AppUserDto>> GetByIdAsync(int id);

        Task<ApiDataResponse<AppUserDto>> AddAsync(AppUserAddDto userAddDto);

        Task<ApiDataResponse<AppUserUpdateDto>> UpdateAsync(AppUserUpdateDto userUpdateDto);

        Task<ApiDataResponse<bool>> DeleteAsync(int id);

        Task<List<OperationClaimDto>> GetRolesAsync(AppUser user);
    }
}