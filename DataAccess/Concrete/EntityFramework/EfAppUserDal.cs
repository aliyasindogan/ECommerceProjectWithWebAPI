using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAppUserDal : EfBaseRepository<AppUser, ECommerceDbContext>, IAppUserDal
    {
        public async Task<List<OperationClaimDto>> GetRolesAsync(AppUser user)
        {
            using (var context = new ECommerceDbContext())
            {
                var result = from appUserTypeAppOperationClaim in context.AppUserTypeAppOperationClaims
                             join appOperationClaim in context.AppOperationClaims on appUserTypeAppOperationClaim.AppOperationClaimID equals appOperationClaim.Id
                             join appUserType in context.AppUserTypes on appUserTypeAppOperationClaim.AppUserTypeID equals appUserType.Id
                             where appUserTypeAppOperationClaim.AppUserTypeID == user.AppUserTypeID
                             select new OperationClaimDto
                             {
                                 Id = appOperationClaim.Id,
                                 Name = appOperationClaim.Name+ "."+ appUserTypeAppOperationClaim.Status
                             };
                return await result.ToListAsync();
            }
        }
    }
}