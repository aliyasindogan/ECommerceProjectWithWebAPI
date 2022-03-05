using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAppUserTypeAppOperationClaimDal : EfBaseRepository<AppUserTypeAppOperationClaim, ECommerceDbContext>, IAppUserTypeAppOperationClaimDal
    {
    }
}