using Core.Entities;

namespace Entities.Dtos.AppUserTypes
{
    public class AppUserTypeDetailDto : IDto
    {
        public int Id { get; set; }
        public int AppUserTypeName { get; set; }
    }
}
