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
using Entities.Dtos.PageLanguages;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PageLanguageService : IPageLanguageService
    {
        #region DI

        private readonly IPageLanguageDal _pageLanguageDal;
        private IMapper _mapper;
        private readonly ILocalizationService _localizationService;
        public PageLanguageService(IPageLanguageDal pageLanguageDal, IMapper mapper, ILocalizationService localizationService)
        {
            _pageLanguageDal = pageLanguageDal;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        #endregion DI

        [CacheAspect(10)]
        [SecuredOperationAspect("PageLanguage.List")]
        public async Task<ApiDataResponse<List<PageLanguageDto>>> GetListAsync()
        {
            var response = await _pageLanguageDal.GetListAsync();
            var pageLanguageDtos = _mapper.Map<List<PageLanguageDto>>(response);
            return new SuccessApiDataResponse<List<PageLanguageDto>>(data: pageLanguageDtos, message: _localizationService[ResultCodes.HTTP_OK], resultCount: pageLanguageDtos.Count);

        }
        [CacheAspect(10)]
        [SecuredOperationAspect("PageLanguage.List")]
        public async Task<ApiDataResponse<List<PageLanguageDto>>> GetListDetailAsync()
        {
            var response = await _pageLanguageDal.GetListDetailAsync();
            var pageLanguageDtos = _mapper.Map<List<PageLanguageDto>>(response);
            return new SuccessApiDataResponse<List<PageLanguageDto>>(pageLanguageDtos, message: _localizationService[ResultCodes.HTTP_OK], resultCount: pageLanguageDtos.Count);
        }
        public async Task<ApiDataResponse<PageLanguage>> GetAsync(Expression<Func<PageLanguage, bool>> filter)
        {
            var pageLanguage = await _pageLanguageDal.GetAsync(filter);
            return new SuccessApiDataResponse<PageLanguage>(data: pageLanguage, pageLanguage == null ? _localizationService[ResultCodes.ERROR_UserNotFound] : _localizationService[ResultCodes.HTTP_OK]);

        }
        [CacheAspect(10)]
        [SecuredOperationAspect("PageLanguage.List")]
        public async Task<ApiDataResponse<PageLanguageDto>> GetByIdAsync(int id)
        {
            var page = await _pageLanguageDal.GetAsync(x => x.Id == id);
            var pageLanguageDto = _mapper.Map<PageLanguageDto>(page);
            return new SuccessApiDataResponse<PageLanguageDto>(data: pageLanguageDto, pageLanguageDto == null ? _localizationService[ResultCodes.ERROR_UserNotFound] : _localizationService[ResultCodes.HTTP_OK]);
        }


        //[TransactionScopeAspect]
        [CacheRemoveAspect("IPageLanguageService.GetListAsync")]
        [ValidationAspect(typeof(PageAddDtoValidator))]
        [LogAspect(typeof(FileLogger))]
        [SecuredOperationAspect()]
        public async Task<ApiDataResponse<PageLanguageDto>> AddAsync(PageLanguageAddDto pageLanguageAddDto)
        {
            var pageLanguage = _mapper.Map<PageLanguage>(pageLanguageAddDto);
            var pageLanguageAdd = await _pageLanguageDal.AddAsync(pageLanguage);
            var pageLanguageDto = _mapper.Map<PageLanguageDto>(pageLanguageAdd);
            return new SuccessApiDataResponse<PageLanguageDto>(pageLanguageDto, message: _localizationService[ResultCodes.HTTP_OK]);
        }

        //[TransactionScopeAspect]
        [CacheRemoveAspect("IPageLanguageService.GetListAsync")]
        [ValidationAspect(typeof(PageUpdateDtoValidator))]
        [LogAspect(typeof(FileLogger))]
        [SecuredOperationAspect()]
        public async Task<ApiDataResponse<PageLanguageUpdateDto>> UpdateAsync(PageLanguageUpdateDto pageLanguageUpdateDto)
        {
            var getPageLanguage = await _pageLanguageDal.GetAsync(x => x.Id == pageLanguageUpdateDto.Id);
            var pageLanguage = _mapper.Map<PageLanguage>(pageLanguageUpdateDto);
            var resultUpdate = await _pageLanguageDal.UpdateAsync(pageLanguage);
            if (resultUpdate == null)
                return new ErrorApiDataResponse<PageLanguageUpdateDto>(null, _localizationService[ResultCodes.ERROR_NotUpdated]);
            var pageUpdataMap = _mapper.Map<PageLanguageUpdateDto>(resultUpdate);
            return new SuccessApiDataResponse<PageLanguageUpdateDto>(pageUpdataMap, _localizationService[ResultCodes.HTTP_OK]);
        }
        [CacheRemoveAspect("IPageLanguageService.GetListAsync")]
        [LogAspect(typeof(FileLogger))]
        [SecuredOperationAspect()]
        public async Task<ApiDataResponse<bool>> DeleteAsync(int id)
        {
            return new SuccessApiDataResponse<bool>(await _pageLanguageDal.DeleteAsync(id), _localizationService[ResultCodes.HTTP_OK]);
        }


    }
}