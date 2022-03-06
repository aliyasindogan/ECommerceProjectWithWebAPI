using Core.Entities;
using Entities.Dtos.AppUserType;

namespace Entities.Dtos.AppUser
{
    public class AppUserDto : IDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Email { get; set; }
        public string ProfileImageUrl { get; set; }
        public string GsmNumber { get; set; }
        public AppUserTypeDto AppUserTypeDto { get; set; }
    }
}