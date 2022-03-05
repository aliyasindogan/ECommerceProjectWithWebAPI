using Core.Entities;

namespace Entities.Dtos
{
    public class AppUserTypeDto : IDto
    {
        public int Id { get; set; }
        public int UserTypeName { get; set; }
    }
}
