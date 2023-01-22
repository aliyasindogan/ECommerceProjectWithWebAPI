using AutoMapper;
using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.SecuredOperation;
using Core.Utilities.Localization;
using Core.Utilities.Messages;
using Core.Utilities.Responses;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Languages;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LanguageService : ILanguageService
    {
        #region DI

        private readonly ILanguageDal _languageDal;
        private IMapper _mapper;
        private readonly ILocalizationService _localizationService;
        public LanguageService(ILanguageDal languageDal, IMapper mapper, ILocalizationService localizationService)
        {
            _languageDal = languageDal;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        #endregion DI

        [CacheAspect(10)]
        [SecuredOperationAspect("Language.List")]
        public async Task<ApiDataResponse<List<LanguageDto>>> GetListAsync()
        {
            var response = await _languageDal.GetListAsync();
            var userDtos = _mapper.Map<List<LanguageDto>>(response);
            return new SuccessApiDataResponse<List<LanguageDto>>(data: userDtos, message: _localizationService[ResultCodes.HTTP_OK], resultCount: userDtos.Count);

        }

        public async Task<ApiDataResponse<Language>> GetAsync(Expression<Func<Language, bool>> filter)
        {
            var user = await _languageDal.GetAsync(filter);
            return new SuccessApiDataResponse<Language>(data: user, user == null ? _localizationService[ResultCodes.ERROR_UserNotFound] : _localizationService[ResultCodes.HTTP_OK]);

        }
        [CacheAspect(10)]
        [SecuredOperationAspect("Language.List")]
        public async Task<ApiDataResponse<LanguageDto>> GetByIdAsync(int id)
        {
            var user = await _languageDal.GetAsync(x => x.Id == id);
            var userDto = _mapper.Map<LanguageDto>(user);
            return new SuccessApiDataResponse<LanguageDto>(data: userDto, userDto == null ? _localizationService[ResultCodes.ERROR_UserNotFound] : _localizationService[ResultCodes.HTTP_OK]);
        }

        public Task<ApiDataResponse<List<LanguageDto>>> GetListDetailAsync()
        {
            throw new NotImplementedException();
        }
    }
}