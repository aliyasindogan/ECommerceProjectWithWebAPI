using Core.Entities;

namespace Entities.Dtos.Languages
{
    public class LanguageDetailDto : IDto
    {
        public int Id { get; set; }
        public string LanguageName { get; set; }
        public string LaguageCode { get; set; }
        public int DisplayOrder { get; set; }
    }
}
