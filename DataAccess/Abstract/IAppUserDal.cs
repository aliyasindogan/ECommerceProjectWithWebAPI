using Core.DataAccess;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IAppUserDal : IBaseRepository<AppUser>
    {
        Task<List<OperationClaimDto>> GetRolesAsync(AppUser user);
    }
}