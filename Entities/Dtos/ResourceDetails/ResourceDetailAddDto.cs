using Core.Entities;

namespace Entities.Dtos.ResourceDetails
{
    public class ResourceDetailAddDto : IDto
    {
        public string ResourceValue { get; set; }
        public int LanguageID { get; set; }
        public int ResourceID { get; set; }
    }
}
