using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Responses;
using Core.Utilities.Security.Token;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.User;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Aspects.Autofac.Caching;
using Core.Entities.Concrete;
using Entities.Dtos.AppOperationClaim;
using Core.Entities.Dtos;

namespace Business.Concrete

{
    public class AppUserService : IAppUserService
    {
        #region DI

        private readonly IAppUserDal _appUserDal;
        private readonly AppSettings _appSettings;
        private IMapper _mapper;

        public AppUserService(IAppUserDal appUserDal, IOptions<AppSettings> appSettings, IMapper mapper)
        {
            _appUserDal = appUserDal;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        #endregion DI

        [CacheAspect(10)]
        public async Task<ApiDataResponse<IEnumerable<UserDetailDto>>> GetListAsync()
        {

            var response = await _appUserDal.GetListAsync();
            var userDetailDtos = _mapper.Map<IEnumerable<UserDetailDto>>(response);
            return new SuccessApiDataResponse<IEnumerable<UserDetailDto>>(userDetailDtos, Messages.Listed);

        }

        public async Task<ApiDataResponse<AppUserDto>> GetAsync(Expression<Func<AppUser, bool>> filter)
        {
            var user = await _appUserDal.GetAsync(filter);
            if (user != null)
            {
                var userDto = _mapper.Map<AppUserDto>(user);
                return new SuccessApiDataResponse<AppUserDto>(userDto, Messages.Listed);
            }
            return new ErrorApiDataResponse<AppUserDto>(null, Messages.NotListed);
        }

        public async Task<ApiDataResponse<AppUserDto>> GetByIdAsync(int id)
        {
            var user = await _appUserDal.GetAsync(x => x.Id == id);
            if (user != null)
            {
                var userDto = _mapper.Map<AppUserDto>(user);
                return new SuccessApiDataResponse<AppUserDto>(userDto, Messages.Listed);
            }
            return new ErrorApiDataResponse<AppUserDto>(null, Messages.NotListed);
        }
        [TransactionScopeAspect]
        [CacheRemoveAspect("IUserService.GetListAsync")]
        public async Task<ApiDataResponse<AppUserDto>> AddAsync(UserAddDto userAddDto)
        {
            var user = _mapper.Map<AppUser>(userAddDto);
            //Todo:12.10.2021 CreatedDate ve CreatedUserId düzenlenecek.
            user.CreatedDate = DateTime.Now;
            user.CreatedUserId = 1;
            var userAdd = await _appUserDal.AddAsync(user);
            var userDto = _mapper.Map<AppUserDto>(userAdd);
            return new SuccessApiDataResponse<AppUserDto>(userDto, Messages.Added);
        }

        public async Task<ApiDataResponse<UserUpdateDto>> UpdateAsync(UserUpdateDto userUpdateDto)
        {
            var getUser = await _appUserDal.GetAsync(x => x.Id == userUpdateDto.Id);
            var user = _mapper.Map<AppUser>(userUpdateDto);
            //Todo:12.10.2021 CreatedDate ve CreatedUserId düzenlenecek.
           // user.Password = getUser.Password;
            user.CreatedDate = getUser.CreatedDate;
            user.CreatedUserId = getUser.CreatedUserId;
            user.UpdatedDate = DateTime.Now;
            user.UpdatedUserId = 1;
          //  user.Token = userUpdateDto.Token;
           // user.TokenExpireDate = userUpdateDto.TokenExpireDate;
            var resultUpdate = await _appUserDal.UpdateAsync(user);
            var userUpdataMap = _mapper.Map<UserUpdateDto>(resultUpdate);

            return new SuccessApiDataResponse<UserUpdateDto>(userUpdataMap, Messages.Updated);
        }

        public async Task<ApiDataResponse<bool>> DeleteAsync(int id)
        {
            return new SuccessApiDataResponse<bool>(await _appUserDal.DeleteAsync(id), Messages.Deleted);
        }

        public async Task<List<OperationClaimDto>> GetRolesAsync(User user)
        {
            return await _appUserDal.GetRolesAsync(user);
        }
    }
}