using Entities.Dtos.UserDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bussines.Abstarct
{
    public interface IUserService
    {
        Task<IEnumerable<UserDetailDto>> GetListAsync();

        Task<UserDto> GetByIdAsync(int id);

        Task<UserDto> AddAsync(UserAddDto userAddDto);

        Task<UserUpdateDto> UpdateAsync(UserUpdateDto userUpdateDto);

        Task<bool> DeleteAsync(int id);
    }
}