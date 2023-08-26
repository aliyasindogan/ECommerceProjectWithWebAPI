using AutoMapper;
using Business.Abstract;
using Business.Validations.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.SecuredOperation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Entities.Dtos;
using Core.Utilities.Localization;
using Core.Utilities.Messages;
using Core.Utilities.Responses;
using Core.Utilities.Security.Hash.Sha512;
using Core.Utilities.Security.Token;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.AppUsers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Concrete

{
    public class AppUserService : IAppUserService
    {
        #region DI

        private readonly IAppUserDal _appUserDal;
        private readonly AppSettings _appSettings;
        private IMapper _mapper;
        private readonly ILocalizationService _localizationService;
        public AppUserService(IAppUserDal appUserDal, IOptions<AppSettings> appSettings, IMapper mapper, ILocalizationService localizationService)
        {
            _appUserDal = appUserDal;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _localizationService = localizationService;
        }

        #endregion DI

        [CacheAspect(10)]
        [SecuredOperationAspect("AppUser.List")]
        public async Task<ApiDataResponse<List<AppUserDto>>> GetListAsync()
        {
            var response = await _appUserDal.GetListAsync();
            var userDtos = _mapper.Map<List<AppUserDto>>(response);
            return new SuccessApiDataResponse<List<AppUserDto>>(data: userDtos, message: _localizationService[ResultCodes.HTTP_OK], resultCount: userDtos.Count);

        }

        [CacheAspect(10)]
        [SecuredOperationAspect("AppUser.List")]
        public async Task<ApiDataResponse<List<AppUserDto>>> GetListDetailAsync()
        {
            var response = await _appUserDal.GetListDetailAsync();
            var userDtos = _mapper.Map<List<AppUserDto>>(response);
            return new SuccessApiDataResponse<List<AppUserDto>>(userDtos, message: _localizationService[ResultCodes.HTTP_OK],resultCount:userDtos.Count);

        }
        public async Task<ApiDataResponse<AppUser>> GetAsync(Expression<Func<AppUser, bool>> filter)
        {
            var user = await _appUserDal.GetAsync(filter);
            return new SuccessApiDataResponse<AppUser>(data: user, user == null ? _localizationService[ResultCodes.ERROR_UserNotFound] : _localizationService[ResultCodes.HTTP_OK]);

        }
        [CacheAspect(10)]
        [SecuredOperationAspect("AppUser.List")]
        public async Task<ApiDataResponse<AppUserDto>> GetByIdAsync(int id)
        {
            var user = await _appUserDal.GetAsync(x => x.Id == id);
            var userDto = _mapper.Map<AppUserDto>(user);
            return new SuccessApiDataResponse<AppUserDto>(data: userDto, userDto == null ? _localizationService[ResultCodes.ERROR_UserNotFound] : _localizationService[ResultCodes.HTTP_OK]);
        }


        //[TransactionScopeAspect]
        [CacheRemoveAspect("IAppUserService.GetListAsync,IAppUserService.GetListDetailAsync")]
        [ValidationAspect(typeof(AppUserAddDtoValidator))]
        [LogAspect(typeof(FileLogger))]
        [SecuredOperationAspect()]
        public async Task<ApiDataResponse<AppUserDto>> AddAsync(AppUserAddDto userAddDto)
        {
            //Aynı username ve email adresi var mı kontrolü yapılıyor
            var getUserExist = await _appUserDal.GetAsync(x => x.UserName == userAddDto.UserName || x.Email == userAddDto.Email);
            if (!Equals(getUserExist, null))
                return new ErrorApiDataResponse<AppUserDto>(null, message: _localizationService[ResultCodes.HTTP_Conflict], resultCodes: ResultCodes.HTTP_Conflict);
            else
            {
                byte[] passwordHash, passwordSalt;
                var user = _mapper.Map<AppUser>(userAddDto);
                Sha512Helper.CreatePasswordHash(userAddDto.Password, out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                var userAdd = await _appUserDal.AddAsync(user);
                var userDto = _mapper.Map<AppUserDto>(userAdd);
                return new SuccessApiDataResponse<AppUserDto>(userDto, message: _localizationService[ResultCodes.HTTP_OK]);
            }
        }
        //[TransactionScopeAspect]
        [CacheRemoveAspect("IAppUserService.GetListAsync,IAppUserService.GetListDetailAsync")]
        [ValidationAspect(typeof(AppUserUpdateDtoValidator))]
        [LogAspect(typeof(FileLogger))]
        public async Task<ApiDataResponse<AppUserUpdateDto>> UpdateAsync(AppUserUpdateDto userUpdateDto)
        {
            var getUser = await _appUserDal.GetAsync(x => x.Id == userUpdateDto.Id);
            var user = _mapper.Map<AppUser>(userUpdateDto);
            if (String.IsNullOrEmpty(userUpdateDto.Password))
            {
                user.PasswordHash = getUser.PasswordHash;
                user.PasswordSalt = getUser.PasswordSalt;
            }
            else if (!Sha512Helper.VerifyPasswordHash(userUpdateDto.Password, getUser.PasswordHash, getUser.PasswordSalt))
            {
                //Yeni Şifre
                byte[] passwordHash, passwordSalt;
                Sha512Helper.CreatePasswordHash(userUpdateDto.Password, out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }
            user.CreatedDate = getUser.CreatedDate;
            user.CreatedUserId = getUser.CreatedUserId;
            var resultUpdate = await _appUserDal.UpdateAsync(user);
            if (resultUpdate == null)
                return new ErrorApiDataResponse<AppUserUpdateDto>(null, _localizationService[ResultCodes.ERROR_NotUpdated]);

            var userUpdataMap = _mapper.Map<AppUserUpdateDto>(resultUpdate);
            return new SuccessApiDataResponse<AppUserUpdateDto>(userUpdataMap, _localizationService[ResultCodes.HTTP_OK]);
        }

        [CacheRemoveAspect("IAppUserService.GetListAsync,IAppUserService.GetListDetailAsync")]
        [LogAspect(typeof(FileLogger))]
        public async Task<ApiDataResponse<bool>> DeleteAsync(int id)
        {
            return new SuccessApiDataResponse<bool>(await _appUserDal.DeleteAsync(id), _localizationService[ResultCodes.HTTP_OK]);
        }

        public async Task<List<OperationClaimDto>> GetRolesAsync(AppUser user)
        {
            return await _appUserDal.GetRolesAsync(user);
        }
    }
}