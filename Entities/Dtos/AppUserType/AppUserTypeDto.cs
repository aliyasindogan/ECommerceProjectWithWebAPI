using Core.Entities;

namespace Entities.Dtos.AppUserType
{
    public class AppUserTypeDto : IDto
    {
        public int Id { get; set; }
        public int UserTypeName { get; set; }
    }
}
