using Core.Entities;

namespace Entities.Dtos.AppUserTypes
{
    public class AppUserTypeDto : IDto
    {
        public int Id { get; set; }
        public string AppUserTypeName { get; set; }
    }
}
