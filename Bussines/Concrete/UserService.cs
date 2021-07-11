using System;
using Bussines.Abstarct;
using DataAccess.Abstract;
using Entities.Dtos.UserDtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Bussines.Concrete

{
    public class UserService : IUserService
    {
        private readonly IUserDal _userDal;

        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<IEnumerable<UserDetailDto>> GetListAsync()
        {
            List<UserDetailDto> userDetailDtos = new List<UserDetailDto>();
            var response = await _userDal.GetListAsync();
            foreach (var item in response.ToList())
            {
                userDetailDtos.Add(new UserDetailDto()
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Gender = item.Gender == true ? "Erkek" : "Kadın",
                    DateOfBirth = item.DateOfBirth,
                    UserName = item.UserName,
                    Address = item.Address,
                    Email = item.Email,
                    Id = item.Id,
                });
            }
            return userDetailDtos;
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await _userDal.GetAsync(x => x.Id == id);
            UserDto userDto = new UserDto()
            {
                Address = user.Address,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                FirstName = user.FirstName,
                Gender = user.Gender,
                Id = user.Id,
                LastName = user.LastName,
                UserName = user.UserName
            };
            return userDto;
        }

        public async Task<UserDto> AddAsync(UserAddDto userAddDto)
        {
            User user = new User()
            {
                LastName = userAddDto.LastName,
                Address = userAddDto.Address,

                //Todo:CreatedDate ve CreatedUserId düzenlenecek.
                CreatedDate = DateTime.Now,
                CreatedUserId = 1,
                DateOfBirth = userAddDto.DateOfBirth,
                Email = userAddDto.Email,
                FirstName = userAddDto.FirstName,
                Gender = userAddDto.Gender,
                Password = userAddDto.Password,
                UserName = userAddDto.UserName,
            };

            var userAdd = await _userDal.AddAsync(user);

            UserDto userDto = new UserDto()
            {
                LastName = userAdd.LastName,
                Address = userAdd.Address,
                DateOfBirth = userAdd.DateOfBirth,
                Email = userAdd.Email,
                FirstName = userAdd.FirstName,
                Gender = userAdd.Gender,
                UserName = userAdd.UserName,
                Id = userAdd.Id,
            };
            return userDto;
        }

        public async Task<UserUpdateDto> UpdateAsync(UserUpdateDto userUpdateDto)
        {
            var getUser = await _userDal.GetAsync(x => x.Id == userUpdateDto.Id);
            User user = new User()
            {
                LastName = userUpdateDto.LastName,
                Address = userUpdateDto.Address,
                DateOfBirth = userUpdateDto.DateOfBirth,
                Email = userUpdateDto.Email,
                FirstName = userUpdateDto.FirstName,
                Gender = userUpdateDto.Gender,
                UserName = userUpdateDto.UserName,
                Id = userUpdateDto.Id,
                CreatedDate = getUser.CreatedDate,
                CreatedUserId = getUser.CreatedUserId,
                Password = userUpdateDto.Password,
                UpdatedDate = DateTime.Now,
                UpdatedUserId = 1,
            };
            var userUpdate = await _userDal.UpdateAsync(user);
            UserUpdateDto newUserUpdateDto = new UserUpdateDto()
            {
                LastName = userUpdate.LastName,
                Address = userUpdate.Address,
                DateOfBirth = userUpdate.DateOfBirth,
                Email = userUpdate.Email,
                FirstName = userUpdate.FirstName,
                Gender = userUpdate.Gender,
                UserName = userUpdate.UserName,
                Id = userUpdate.Id,
                Password = userUpdate.Password,
            };
            return newUserUpdateDto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userDal.DeleteAsync(id);
        }
    }
}