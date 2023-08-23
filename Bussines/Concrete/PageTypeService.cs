using AutoMapper;
using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.SecuredOperation;
using Core.Utilities.Localization;
using Core.Utilities.Messages;
using Core.Utilities.Responses;
using DataAccess.Abstract;
using Entities.Dtos.PageTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PageTypeService : IPageTypeService
    {
        #region DI

        private readonly IPageTypeDal _pageTypeDal;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;
        public PageTypeService(IPageTypeDal pageTypeDal, IMapper mapper, ILocalizationService localizationService)
        {
            _pageTypeDal = pageTypeDal;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        #endregion DI

        //[CacheAspect(10)]
        [SecuredOperationAspect("PageType.List")]
        public async Task<ApiDataResponse<List<PageTypeDto>>> GetListAsync()
        {
            var response = await _pageTypeDal.GetListAsync();
            var pageDtos = _mapper.Map<List<PageTypeDto>>(response);
            return new SuccessApiDataResponse<List<PageTypeDto>>(data: pageDtos, message: _localizationService[ResultCodes.HTTP_OK], resultCount: pageDtos.Count);

        }
    }
}