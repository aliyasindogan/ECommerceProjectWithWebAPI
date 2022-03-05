using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IAppUserDal : IBaseRepository<User>
    {
    }
}