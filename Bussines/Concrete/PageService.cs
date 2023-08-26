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
using Entities.Dtos.PagePageLanguages;
using Entities.Dtos.Pages;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PageService : IPageService
    {
        #region DI

        private readonly IPageDal _pageDal;
        private IMapper _mapper;
        private readonly ILocalizationService _localizationService;
        public PageService(IPageDal pageDal, IMapper mapper, ILocalizationService localizationService)
        {
            _pageDal = pageDal;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        #endregion DI

        [CacheAspect(10)]
        [SecuredOperationAspect("Page.List")]
        public async Task<ApiDataResponse<List<PageDto>>> GetListAsync()
        {
            var response = await _pageDal.GetListAsync();
            var pageDtos = _mapper.Map<List<PageDto>>(response);
            return new SuccessApiDataResponse<List<PageDto>>(data: pageDtos, message: _localizationService[ResultCodes.HTTP_OK], resultCount: pageDtos.Count);

        }
        [CacheAspect(10)]
        [SecuredOperationAspect("Page.List")]
        public async Task<ApiDataResponse<List<PageDto>>> GetListDetailAsync()
        {
            var response = await _pageDal.GetListDetailAsync();
            var pageDtos = _mapper.Map<List<PageDto>>(response);
            return new SuccessApiDataResponse<List<PageDto>>(pageDtos, message: _localizationService[ResultCodes.HTTP_OK], resultCount: pageDtos.Count);
        }
        public async Task<ApiDataResponse<Page>> GetAsync(Expression<Func<Page, bool>> filter)
        {
            var page = await _pageDal.GetAsync(filter);
            return new SuccessApiDataResponse<Page>(data: page, page == null ? _localizationService[ResultCodes.ERROR_UserNotFound] : _localizationService[ResultCodes.HTTP_OK]);

        }
        [CacheAspect(10)]
        [SecuredOperationAspect("Page.List")]
        public async Task<ApiDataResponse<PageDto>> GetByIdAsync(int id)
        {
            var page = await _pageDal.GetAsync(x => x.Id == id);
            var pageDto = _mapper.Map<PageDto>(page);
            return new SuccessApiDataResponse<PageDto>(data: pageDto, pageDto == null ? _localizationService[ResultCodes.ERROR_UserNotFound] : _localizationService[ResultCodes.HTTP_OK]);
        }


        //[TransactionScopeAspect]
        [CacheRemoveAspect("IPageService.GetListAsync,IPageService.GetListAdminPanelLeftMenuAsync")]
        [ValidationAspect(typeof(PageAddDtoValidator))]
        [LogAspect(typeof(FileLogger))]
        public async Task<ApiDataResponse<PageDto>> AddAsync(PageAddDto pageAddDto)
        {
            var page = _mapper.Map<Page>(pageAddDto);
            var pageAdd = await _pageDal.AddAsync(page);
            var pageDto = _mapper.Map<PageDto>(pageAdd);
            return new SuccessApiDataResponse<PageDto>(pageDto, message: _localizationService[ResultCodes.HTTP_OK]);
        }

        //[TransactionScopeAspect]
        [CacheRemoveAspect("IPageService.GetListAsync,IPageService.GetListAdminPanelLeftMenuAsync")]
        [ValidationAspect(typeof(PageUpdateDtoValidator))]
        [LogAspect(typeof(FileLogger))]
        public async Task<ApiDataResponse<PageUpdateDto>> UpdateAsync(PageUpdateDto pageUpdateDto)
        {
            var getPage = await _pageDal.GetAsync(x => x.Id == pageUpdateDto.Id);
            var page = _mapper.Map<Page>(pageUpdateDto);
            var resultUpdate = await _pageDal.UpdateAsync(page);
            if (resultUpdate == null)
                return new ErrorApiDataResponse<PageUpdateDto>(null, _localizationService[ResultCodes.ERROR_NotUpdated]);
            var pageUpdataMap = _mapper.Map<PageUpdateDto>(resultUpdate);
            return new SuccessApiDataResponse<PageUpdateDto>(pageUpdataMap, _localizationService[ResultCodes.HTTP_OK]);
        }
        [CacheRemoveAspect("IPageService.GetListAsync,IPageService.GetListAdminPanelLeftMenuAsync")]
        [LogAspect(typeof(FileLogger))]
        public async Task<ApiDataResponse<bool>> DeleteAsync(int id)
        {
            return new SuccessApiDataResponse<bool>(await _pageDal.DeleteAsync(id), _localizationService[ResultCodes.HTTP_OK]);
        }

        [CacheAspect(10)]
        [SecuredOperationAspect("Page.List")]
        public async Task<ApiDataResponse<List<PagePageLanguageDto>>> GetListAdminPanelLeftMenuAsync()
        {
            var pageDtos = await _pageDal.GetListAdminPanelLeftMenuAsync();
            return new SuccessApiDataResponse<List<PagePageLanguageDto>>(pageDtos, message: _localizationService[ResultCodes.HTTP_OK], resultCount: pageDtos.Count);
        }
    }
}


