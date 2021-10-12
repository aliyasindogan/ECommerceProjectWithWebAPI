using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Responses;
using Core.Utilities.Security.Token;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.UserDtos;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Concrete

{
    public class UserService : IUserService
    {
        #region DI

        private readonly IUserDal _userDal;
        private readonly AppSettings _appSettings;
        private IMapper _mapper;

        public UserService(IUserDal userDal, IOptions<AppSettings> appSettings, IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        #endregion DI

        public async Task<ApiDataResponse<IEnumerable<UserDetailDto>>> GetListAsync(Expression<Func<User, bool>> filter = null)
        {
            if (filter == null)
            {
                var response = await _userDal.GetListAsync();
                var userDetailDtos = _mapper.Map<IEnumerable<UserDetailDto>>(response);
                return new SuccessApiDataResponse<IEnumerable<UserDetailDto>>(userDetailDtos, Messages.Listed);
            }
            else
            {
                var response = await _userDal.GetListAsync(filter);
                var userDetailDtos = _mapper.Map<IEnumerable<UserDetailDto>>(response);
                return new SuccessApiDataResponse<IEnumerable<UserDetailDto>>(userDetailDtos, Messages.Listed);
            }
        }

        public async Task<ApiDataResponse<UserDto>> GetAsync(Expression<Func<User, bool>> filter)
        {
            var user = await _userDal.GetAsync(filter);
            if (user != null)
            {
                var userDto = _mapper.Map<UserDto>(user);
                return new SuccessApiDataResponse<UserDto>(userDto, Messages.Listed);
            }
            return new ErrorApiDataResponse<UserDto>(null, Messages.NotListed);
        }

        public async Task<ApiDataResponse<UserDto>> GetByIdAsync(int id)
        {
            var user = await _userDal.GetAsync(x => x.Id == id);
            if (user != null)
            {
                var userDto = _mapper.Map<UserDto>(user);
                return new SuccessApiDataResponse<UserDto>(userDto, Messages.Listed);
            }
            return new ErrorApiDataResponse<UserDto>(null, Messages.NotListed);
        }

        public async Task<ApiDataResponse<UserDto>> AddAsync(UserAddDto userAddDto)
        {
            var user = _mapper.Map<User>(userAddDto);
            //Todo:12.10.2021 CreatedDate ve CreatedUserId düzenlenecek.
            user.CreatedDate = DateTime.Now;
            user.CreatedUserId = 1;
            var userAdd = await _userDal.AddAsync(user);
            var userDto = _mapper.Map<UserDto>(userAdd);
            return new SuccessApiDataResponse<UserDto>(userDto, Messages.Added);
        }

        public async Task<ApiDataResponse<UserUpdateDto>> UpdateAsync(UserUpdateDto userUpdateDto)
        {
            var getUser = await _userDal.GetAsync(x => x.Id == userUpdateDto.Id);
            var user = _mapper.Map<User>(userUpdateDto);
            //Todo:12.10.2021 CreatedDate ve CreatedUserId düzenlenecek.
            user.CreatedDate = getUser.CreatedDate;
            user.CreatedUserId = getUser.CreatedUserId;
            user.UpdatedDate = DateTime.Now;
            user.UpdatedUserId = 1;
            user.Token = userUpdateDto.Token;
            user.TokenExpireDate = userUpdateDto.TokenExpireDate;
            var resultUpdate = await _userDal.UpdateAsync(user);
            var userUpdataMap = _mapper.Map<UserUpdateDto>(resultUpdate);

            return new SuccessApiDataResponse<UserUpdateDto>(userUpdataMap, Messages.Updated);
        }

        public async Task<ApiDataResponse<bool>> DeleteAsync(int id)
        {
            return new SuccessApiDataResponse<bool>(await _userDal.DeleteAsync(id), Messages.Deleted);
        }

        //public async Task<ApiDataResponse<AccessToken>> Authenticate(UserForLoginDto userForLoginDto)
        //{
        //    var user = await _userDal.GetAsync(x => x.UserName == userForLoginDto.UserName && x.Password == userForLoginDto.Password);
        //    if (user == null)
        //        return null;
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_appSettings.SecurityKey);
        //    var tokenDescriptor = new SecurityTokenDescriptor()
        //    {
        //        Subject = new ClaimsIdentity(new[]
        //        {
        //            new Claim(ClaimTypes.Name,user.Id.ToString())
        //        }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };

        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    AccessToken accessToken = new AccessToken()
        //    {
        //        Token = tokenHandler.WriteToken(token),
        //        Expiration = (DateTime)tokenDescriptor.Expires,
        //        UserName = user.UserName,
        //        UserID = user.Id
        //    };
        //    return await Task.Run(() => accessToken);
        //}
    }
}