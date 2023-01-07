using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos.AppUsers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IAppUserTypeDal : IBaseRepository<AppUserType>
    {
    }
}