using AutoMapper;
using Business.Abstract;
using Business.Validations.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.SecuredOperation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Localization;
using Core.Utilities.Messages;
using Core.Utilities.Responses;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.AppUserTypes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AppUserTypeService : IAppUserTypeService
    {
        #region DI

        private readonly IAppUserTypeDal _appUserTypeDal;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;
        public AppUserTypeService(IAppUserTypeDal appUserTypeDal, IMapper mapper, ILocalizationService localizationService)
        {
            _appUserTypeDal = appUserTypeDal;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        #endregion DI

        [CacheAspect(10)]
        [SecuredOperationAspect("AppUserType.List")]
        public async Task<ApiDataResponse<List<AppUserTypeDto>>> GetListAsync()
        {
            var response = await _appUserTypeDal.GetListAsync();
            var userDtos = _mapper.Map<List<AppUserTypeDto>>(response);
            return new SuccessApiDataResponse<List<AppUserTypeDto>>(data: userDtos, message: _localizationService[ResultCodes.HTTP_OK], resultCount: userDtos.Count);

        }

        public async Task<ApiDataResponse<AppUserType>> GetAsync(Expression<Func<AppUserType, bool>> filter)
        {
            var user = await _appUserTypeDal.GetAsync(filter);
            return new SuccessApiDataResponse<AppUserType>(data: user, user == null ? _localizationService[ResultCodes.ERROR_UserNotFound] : _localizationService[ResultCodes.HTTP_OK]);

        }
        [CacheAspect(10)]
        [SecuredOperationAspect("AppUserType.List")]
        public async Task<ApiDataResponse<AppUserTypeDto>> GetByIdAsync(int id)
        {
            var user = await _appUserTypeDal.GetAsync(x => x.Id == id);
            var userDto = _mapper.Map<AppUserTypeDto>(user);
            return new SuccessApiDataResponse<AppUserTypeDto>(data: userDto, userDto == null ? _localizationService[ResultCodes.ERROR_UserNotFound] : _localizationService[ResultCodes.HTTP_OK]);
        }


        //[TransactionScopeAspect]
        [CacheRemoveAspect("IAppUserTypeService.GetListAsync")]
        [ValidationAspect(typeof(AppUserTypeAddDtoValidator))]
        [LogAspect(typeof(FileLogger))]
        [SecuredOperationAspect()]
        public async Task<ApiDataResponse<AppUserTypeDto>> AddAsync(AppUserTypeAddDto userTypeAddDto)
        {
            //Aynı UserTypeName var mı kontrolü yapılıyor
            var getUserExist = await _appUserTypeDal.GetAsync(x => x.UserTypeName == userTypeAddDto.UserTypeName);
            if (!Equals(getUserExist, null))
                return new ErrorApiDataResponse<AppUserTypeDto>(null, message: _localizationService[ResultCodes.HTTP_Conflict], resultCodes: ResultCodes.HTTP_Conflict);
            else
            {
                {
                    var userType = _mapper.Map<AppUserType>(userTypeAddDto);
                    var userTypeAdd = await _appUserTypeDal.AddAsync(userType);
                    var userTypeDto = _mapper.Map<AppUserTypeDto>(userTypeAdd);
                    return new SuccessApiDataResponse<AppUserTypeDto>(userTypeDto, message: _localizationService[ResultCodes.HTTP_OK]);
                }
            }
        }

        //[TransactionScopeAspect]
        [CacheRemoveAspect("IAppUserTypeService.GetListAsync")]
        [ValidationAspect(typeof(AppUserTypeUpdateDtoValidator))]
        [LogAspect(typeof(FileLogger))]
        public async Task<ApiDataResponse<AppUserTypeUpdateDto>> UpdateAsync(AppUserTypeUpdateDto userTypeUpdateDto)
        {
            var getUserType = await _appUserTypeDal.GetAsync(x => x.Id == userTypeUpdateDto.Id);
            var userType = _mapper.Map<AppUserType>(userTypeUpdateDto);
            userType.CreatedDate = getUserType.CreatedDate;
            userType.CreatedUserId = getUserType.CreatedUserId;
            var resultUpdate = await _appUserTypeDal.UpdateAsync(userType);
            if (resultUpdate == null)
                return new ErrorApiDataResponse<AppUserTypeUpdateDto>(null, _localizationService[ResultCodes.ERROR_NotUpdated]);
            var userUpdataMap = _mapper.Map<AppUserTypeUpdateDto>(resultUpdate);
            return new SuccessApiDataResponse<AppUserTypeUpdateDto>(userUpdataMap, _localizationService[ResultCodes.HTTP_OK]);
        }
        [CacheRemoveAspect("IAppUserTypeService.GetListAsync")]
        [LogAspect(typeof(FileLogger))]
        public async Task<ApiDataResponse<bool>> DeleteAsync(int id)
        {
            return new SuccessApiDataResponse<bool>(await _appUserTypeDal.DeleteAsync(id), _localizationService[ResultCodes.HTTP_OK]);
        }


    }
}