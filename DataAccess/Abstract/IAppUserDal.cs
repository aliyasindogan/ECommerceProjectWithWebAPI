using Core.DataAccess;
using Core.Entities.Dtos;
using Entities.Concrete;
using Entities.Dtos.AppUsers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IAppUserDal : IBaseRepository<AppUser>
    {
        Task<List<OperationClaimDto>> GetRolesAsync(AppUser user);
        Task<List<AppUserDto>> GetListDetailAsync();
    }
}