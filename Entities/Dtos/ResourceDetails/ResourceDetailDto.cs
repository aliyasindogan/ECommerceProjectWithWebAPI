using Core.Entities;

namespace Entities.Dtos.ResourceDetails
{
    public class ResourceDetailDto : IDto
    {
        public int Id { get; set; }
        public string ResourceValue { get; set; }
        public int ResourceID { get; set; }
        public string ResourceName { get; set; }
        public int LanguageID { get; set; }
        public string LanguageName { get; set; }
    }
}
