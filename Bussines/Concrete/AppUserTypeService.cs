using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.Validations.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.SecuredOperation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Entities.Dtos;
using Core.Entities.Enums;
using Core.Utilities.Localization;
using Core.Utilities.Messages;
using Core.Utilities.Responses;
using Core.Utilities.Security.Hash.Sha512;
using Core.Utilities.Security.Token;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos.AppUsers;
using Entities.Dtos.AppUserTypes;
using Entities.Dtos.Resources;
using Microsoft.Extensions.Options;
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
        private readonly IResourceService _resourceService;
        private readonly IResourceDetailService _resourceDetailService;
        public AppUserTypeService(IAppUserTypeDal appUserTypeDal, IMapper mapper, ILocalizationService localizationService, IResourceService resourceService, IResourceDetailService resourceDetailService)
        {
            _appUserTypeDal = appUserTypeDal;
            _mapper = mapper;
            _localizationService = localizationService;
            _resourceService = resourceService;
            _resourceDetailService = resourceDetailService;
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


        [TransactionScopeAspect]
        [CacheRemoveAspect("IAppUserTypeService.GetListAsync")]
        [ValidationAspect(typeof(AppUserTypeAddDtoValidator))]
        [LogAspect(typeof(FileLogger))]
        public async Task<ApiDataResponse<AppUserTypeDto>> AddAsync(AppUserTypeAddDto userTypeAddDto)
        {
            string resourceName = Core.Utilities.Messages.Constants.AppUserType + "_" + userTypeAddDto.UserTypeName.Replace(" ", "");
            var getResource = await _resourceService.GetAsync(x => x.ResourceName == resourceName);
            if (getResource.Success)
                return new ErrorApiDataResponse<AppUserTypeDto>(null, message: _localizationService[ResultCodes.VALIDATION_ThisRecordAlreadyExists], resultCodes: ResultCodes.HTTP_Conflict);

            ResourceAddDto resourceAddDto = new ResourceAddDto { ResourceName = resourceName };
            var resource = await _resourceService.AddAsync(resourceAddDto);
            var userType = _mapper.Map<AppUserType>(userTypeAddDto);
            userType.ResourceID = resource.Data.Id;
            var userTypeAdd = await _appUserTypeDal.AddAsync(userType);
            var userTypeDto = _mapper.Map<AppUserTypeDto>(userTypeAdd);
            return new SuccessApiDataResponse<AppUserTypeDto>(userTypeDto, message: _localizationService[ResultCodes.HTTP_OK]);
        }

        [TransactionScopeAspect]
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