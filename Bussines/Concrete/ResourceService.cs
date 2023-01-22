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
using Entities.Dtos.Resources;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ResourceService : IResourceService
    {
        #region DI

        private readonly IResourceDal _resourceDal;
        private IMapper _mapper;
        private readonly ILocalizationService _localizationService;
        public ResourceService(IResourceDal resourceDal, IMapper mapper, ILocalizationService localizationService)
        {
            _resourceDal = resourceDal;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        #endregion DI

        [CacheAspect(10)]
        [SecuredOperationAspect("Resource.List")]
        public async Task<ApiDataResponse<List<ResourceDto>>> GetListAsync()
        {
            var response = await _resourceDal.GetListAsync();
            var userDtos = _mapper.Map<List<ResourceDto>>(response);
            return new SuccessApiDataResponse<List<ResourceDto>>(data: userDtos, message: _localizationService[ResultCodes.HTTP_OK], resultCount: userDtos.Count);

        }

        public async Task<ApiDataResponse<Resource>> GetAsync(Expression<Func<Resource, bool>> filter)
        {
            var user = await _resourceDal.GetAsync(filter);
            return new SuccessApiDataResponse<Resource>(data: user, user == null ? _localizationService[ResultCodes.ERROR_UserNotFound] : _localizationService[ResultCodes.HTTP_OK]);

        }
        [CacheAspect(10)]
        [SecuredOperationAspect("Resource.List")]
        public async Task<ApiDataResponse<ResourceDto>> GetByIdAsync(int id)
        {
            var user = await _resourceDal.GetAsync(x => x.Id == id);
            var userDto = _mapper.Map<ResourceDto>(user);
            return new SuccessApiDataResponse<ResourceDto>(data: userDto, userDto == null ? _localizationService[ResultCodes.ERROR_UserNotFound] : _localizationService[ResultCodes.HTTP_OK]);
        }


        [TransactionScopeAspect]
        [CacheRemoveAspect("IResourceService.GetListAsync")]
        [ValidationAspect(typeof(ResourceAddDtoValidator))]
        [LogAspect(typeof(FileLogger))]
        public async Task<ApiDataResponse<ResourceDto>> AddAsync(ResourceAddDto userTypeAddDto)
        {
            var userType = _mapper.Map<Resource>(userTypeAddDto);
            var userTypeAdd = await _resourceDal.AddAsync(userType);
            var userTypeDto = _mapper.Map<ResourceDto>(userTypeAdd);
            return new SuccessApiDataResponse<ResourceDto>(userTypeDto, message: _localizationService[ResultCodes.HTTP_OK]);
        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("IResourceService.GetListAsync")]
        [ValidationAspect(typeof(ResourceUpdateDtoValidator))]
        [LogAspect(typeof(FileLogger))]
        public async Task<ApiDataResponse<ResourceUpdateDto>> UpdateAsync(ResourceUpdateDto userTypeUpdateDto)
        {
            var getUserType = await _resourceDal.GetAsync(x => x.Id == userTypeUpdateDto.Id);
            var userType = _mapper.Map<Resource>(userTypeUpdateDto);
            userType.CreatedDate = getUserType.CreatedDate;
            userType.CreatedUserId = getUserType.CreatedUserId;
            var resultUpdate = await _resourceDal.UpdateAsync(userType);
            if (resultUpdate == null)
                return new ErrorApiDataResponse<ResourceUpdateDto>(null, _localizationService[ResultCodes.ERROR_NotUpdated]);
            var userUpdataMap = _mapper.Map<ResourceUpdateDto>(resultUpdate);
            return new SuccessApiDataResponse<ResourceUpdateDto>(userUpdataMap, _localizationService[ResultCodes.HTTP_OK]);
        }
        [CacheRemoveAspect("IResourceService.GetListAsync")]
        [LogAspect(typeof(FileLogger))]
        public async Task<ApiDataResponse<bool>> DeleteAsync(int id)
        {
            return new SuccessApiDataResponse<bool>(await _resourceDal.DeleteAsync(id), _localizationService[ResultCodes.HTTP_OK]);
        }

        public Task<ApiDataResponse<List<ResourceDto>>> GetListDetailAsync()
        {
            throw new NotImplementedException();
        }
    }
}