using System;
using Core.Entities;

namespace Entities.Dtos.AppUser
{
    public class AppUserUpdateDto : IDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ProfileImageUrl { get; set; }
        public string GsmNumber { get; set; }
        public int UserTypeId { get; set; }
        public int UpdatedUserId { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}