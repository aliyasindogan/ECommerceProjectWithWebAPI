using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.Validations.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Responses;
using Core.Utilities.Security.Hash.Sha512;
using Core.Utilities.Security.Token;
using Entities.Concrete;
using Entities.Dtos.AppUsers;
using Entities.Dtos.Auths;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthService : IAuthService
    {
        #region DI
        private readonly IAppUserService _appUserService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthService(IAppUserService appUserService, ITokenService tokenService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _appUserService = appUserService;
            _tokenService = tokenService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
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

            var accessToken = await CreateAccessTokenAsync(_mapper.Map<User>(user.Data));
            return new SuccessApiDataResponse<AccessToken>(accessToken, Messages.SystemLoginSuccessful);
        }

        public async Task<ApiDataResponse<AccessToken>> RegisterAsync(RegisterDto registerDto, string password)
        {
            var user = await _appUserService.GetAsync(x => x.UserName == registerDto.UserName);
            if (user.Data != null)
                return new ErrorApiDataResponse<AccessToken>(null, Messages.UserNameAlreadyExist);

            byte[] passwordHash, passwordSalt;
            Sha512Helper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var appUser = _mapper.Map<AppUser>(registerDto);
            appUser.PasswordHash = passwordHash;
            appUser.PasswordSalt = passwordSalt;
            appUser.CreatedDate = DateTime.Now;
            appUser.CreatedUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var appUserAddDto = _mapper.Map<AppUserAddDto>(appUser);
            var appUserAdd = _appUserService.AddAsync(appUserAddDto);
            if (appUserAdd == null)
                return new ErrorApiDataResponse<AccessToken>(null, Messages.NotAdded);
            var appUserAccessToken = _mapper.Map<AppUser>(appUserAdd);
            var _userMap = _mapper.Map<User>(appUserAccessToken);
            var newAccessToken = await CreateAccessTokenAsync(_userMap);
            return new SuccessApiDataResponse<AccessToken>(newAccessToken, Messages.UserRegistered);
        }
        public async Task<AccessToken> CreateAccessTokenAsync(User user)
        {
            var appUser = _mapper.Map<AppUser>(user);
            var roles = await _appUserService.GetRolesAsync(appUser);
            var accessToken = _tokenService.CreateToken(user, roles);
            return accessToken;
        }
    }
}