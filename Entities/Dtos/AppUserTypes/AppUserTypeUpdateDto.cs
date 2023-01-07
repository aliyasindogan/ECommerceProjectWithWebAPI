using Core.Entities;

namespace Entities.Dtos.AppUserTypes
{
    public class AppUserTypeUpdateDto:IDto
    {
        public int Id { get; set; }
        public string UserTypeName { get; set; }
    }
}
