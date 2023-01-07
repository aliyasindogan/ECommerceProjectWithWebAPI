using Core.Entities;
using System;

namespace Entities.Dtos.AppUsers
{
    public class AppUserAddDto : IDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ProfileImageUrl { get; set; }
        public string GsmNumber { get; set; }
        public int UserTypeID { get; set; }
        public Guid RefreshToken { get; set; }
    }
}