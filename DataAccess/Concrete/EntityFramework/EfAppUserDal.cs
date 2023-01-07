using Core.DataAccess.EntityFramework;
using Core.Entities.Dtos;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;
using Entities.Dtos.AppUsers;
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
                             join appOperationClaim in context.AppOperationClaims on appUserTypeAppOperationClaim.OperationClaimID equals appOperationClaim.Id
                             join appUserType in context.AppUserTypes on appUserTypeAppOperationClaim.AUserTypeID equals appUserType.Id
                             where appUserTypeAppOperationClaim.AUserTypeID == user.AppUserTypeID
                             select new OperationClaimDto
                             {
                                 Id = appOperationClaim.Id,
                                 Name = appOperationClaim.Name + "." + appUserTypeAppOperationClaim.Status
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<List<AppUserDto>> GetListDetailAsync()
        {
            using (var context = new ECommerceDbContext())
            {
                var result = from appUser in context.AppUsers
                             join appUserType in context.AppUserTypes on appUser.AppUserTypeID equals appUserType.Id
                             select new AppUserDto
                             {
                                 Id = appUser.Id,
                                 AppUserTypeName = appUserType.UserTypeName,
                                 AppUserTypeID = appUser.AppUserTypeID,
                                 Email = appUser.Email,
                                 FirstName = appUser.FirstName,
                                 GsmNumber = appUser.GsmNumber,
                                 LastName = appUser.LastName,
                                 ProfileImageUrl = appUser.ProfileImageUrl,
                                 UserName = appUser.UserName,
                             };
                return await result.ToListAsync();
            }
        }
    }
}