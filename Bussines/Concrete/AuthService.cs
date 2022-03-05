using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.Validations.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Responses;
using Core.Utilities.Security.Hash.Sha512;
using Core.Utilities.Security.Token;
using Entities.Concrete;
using Entities.Dtos.Auth;
using Entities.Dtos.User;
using System;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthService : IAuthService
    {
        #region DI
        private IAppUserService _appUserService;
        private ITokenService _tokenService;
        private IMapper _mapper;

        public AuthService(IAppUserService appUserService, ITokenService tokenService, IMapper mapper)
        {
            _appUserService = appUserService;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        #endregion

        [ValidationAspect(typeof(LoginDtoValidator))]
        public async Task<ApiDataResponse<AccessToken>> LoginAsync(LoginDto loginDto)
        {
            var user = await _appUserService.GetAsync(x => x.UserName == loginDto.UserName);
            if (user.Data == null)
                return new ErrorApiDataResponse<AccessToken>(null, Messages.UserNotFound);

            if (!Sha512Helper.VerifyPasswordHash(loginDto.Password, user.Data.PasswordHash, user.Data.PasswordSalt))
                return new ErrorApiDataResponse<AccessToken>(null, Messages.UserNotFound);

            var accessToken = await CreateAccessTokenAsync(_mapper.Map<AppUser>(user.Data));
            return new SuccessApiDataResponse<AccessToken>(accessToken, Messages.SystemLoginSuccessful);
        }

        //private async Task<ApiDataResponse<AppUserDto>> UpdateToken(ApiDataResponse<AppUserDto> user)
        //{
        //    var accessToken = _tokenService.CreateToken(user, user.Data.UserName);
        //    var userUpdateDto = _mapper.Map<UserUpdateDto>(user.Data);
        //    userUpdateDto.Token = accessToken.Token;
        //    userUpdateDto.TokenExpireDate = accessToken.Expiration;
        //    userUpdateDto.UpdatedUserId = user.Data.Id;
        //    var resultUserUpdateDto = await _appUserService.UpdateAsync(userUpdateDto);
        //    var userDto = _mapper.Map<AppUserDto>(resultUserUpdateDto.Data);
        //    return new SuccessApiDataResponse<AppUserDto>(userDto, Messages.SystemLoginSuccessful);
        //}
        public async Task<AccessToken> CreateAccessTokenAsync(AppUser appUser)
        {
            var roles = await _appUserService.GetRolesAsync(appUser);
            var accessToken = _tokenService.CreateToken(appUser, roles);
            return accessToken;
        }
    }
}