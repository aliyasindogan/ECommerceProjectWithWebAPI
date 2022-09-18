using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAppOperationClaimDal : EfBaseRepository<AppOperationClaim, ECommerceDbContext>, IAppOperationClaimDal
    {
    }
}