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
using Entities.Dtos.ResourceDetails;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ResourceDetailService : IResourceDetailService
    {
        #region DI

        private readonly IResourceDetailDal _resourceDetailDal;
        private IMapper _mapper;
        private readonly ILocalizationService _localizationService;
        public ResourceDetailService(IResourceDetailDal resourceDetailDal, IMapper mapper, ILocalizationService localizationService)
        {
            _resourceDetailDal = resourceDetailDal;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        #endregion DI

        [CacheAspect(10)]
        [SecuredOperationAspect("ResourceDetail.List")]
        public async Task<ApiDataResponse<List<ResourceDetailDto>>> GetListAsync()
        {
            var response = await _resourceDetailDal.GetListAsync();
            var userDtos = _mapper.Map<List<ResourceDetailDto>>(response);
            return new SuccessApiDataResponse<List<ResourceDetailDto>>(data: userDtos, message: _localizationService[ResultCodes.HTTP_OK], resultCount: userDtos.Count);

        }

        public async Task<ApiDataResponse<ResourceDetail>> GetAsync(Expression<Func<ResourceDetail, bool>> filter)
        {
            var user = await _resourceDetailDal.GetAsync(filter);
            return new SuccessApiDataResponse<ResourceDetail>(data: user, user == null ? _localizationService[ResultCodes.ERROR_UserNotFound] : _localizationService[ResultCodes.HTTP_OK]);

        }
        [CacheAspect(10)]
        [SecuredOperationAspect("ResourceDetail.List")]
        public async Task<ApiDataResponse<ResourceDetailDto>> GetByIdAsync(int id)
        {
            var user = await _resourceDetailDal.GetAsync(x => x.Id == id);
            var userDto = _mapper.Map<ResourceDetailDto>(user);
            return new SuccessApiDataResponse<ResourceDetailDto>(data: userDto, userDto == null ? _localizationService[ResultCodes.ERROR_UserNotFound] : _localizationService[ResultCodes.HTTP_OK]);
        }


        [TransactionScopeAspect]
        [CacheRemoveAspect("IResourceDetailService.GetListAsync")]
        [ValidationAspect(typeof(ResourceDetailAddDtoValidator))]
        [LogAspect(typeof(FileLogger))]
        public async Task<ApiDataResponse<ResourceDetailDto>> AddAsync(ResourceDetailAddDto entity)
        {
            var userType = _mapper.Map<ResourceDetail>(entity);
            var userTypeAdd = await _resourceDetailDal.AddAsync(userType);
            var userTypeDto = _mapper.Map<ResourceDetailDto>(userTypeAdd);
            return new SuccessApiDataResponse<ResourceDetailDto>(userTypeDto, message: _localizationService[ResultCodes.HTTP_OK]);
        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("IResourceDetailService.GetListAsync")]
        [ValidationAspect(typeof(ResourceDetailUpdateDtoValidator))]
        [LogAspect(typeof(FileLogger))]
        public async Task<ApiDataResponse<ResourceDetailUpdateDto>> UpdateAsync(ResourceDetailUpdateDto entity)
        {
            var getUserType = await _resourceDetailDal.GetAsync(x => x.Id == entity.Id);
            var userType = _mapper.Map<ResourceDetail>(entity);
            userType.CreatedDate = getUserType.CreatedDate;
            userType.CreatedUserId = getUserType.CreatedUserId;
            var resultUpdate = await _resourceDetailDal.UpdateAsync(userType);
            if (resultUpdate == null)
                return new ErrorApiDataResponse<ResourceDetailUpdateDto>(null, _localizationService[ResultCodes.ERROR_NotUpdated]);
            var userUpdataMap = _mapper.Map<ResourceDetailUpdateDto>(resultUpdate);
            return new SuccessApiDataResponse<ResourceDetailUpdateDto>(userUpdataMap, _localizationService[ResultCodes.HTTP_OK]);
        }
        [CacheRemoveAspect("IResourceDetailService.GetListAsync")]
        [LogAspect(typeof(FileLogger))]
        public async Task<ApiDataResponse<bool>> DeleteAsync(int id)
        {
            return new SuccessApiDataResponse<bool>(await _resourceDetailDal.DeleteAsync(id), _localizationService[ResultCodes.HTTP_OK]);
        }

        public Task<ApiDataResponse<List<ResourceDetailDto>>> GetListDetailAsync()
        {
            throw new NotImplementedException();
        }
    }
}