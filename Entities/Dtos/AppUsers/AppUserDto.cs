using Core.Entities;

namespace Entities.Dtos.AppUsers
{
    public class AppUserDto : IDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ProfileImageUrl { get; set; }
        public string GsmNumber { get; set; }
        public string UserTypeName { get; set; }
        public int UserTypeID { get; set; }
    }
}