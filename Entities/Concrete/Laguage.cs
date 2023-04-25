using Core.Entities.BaseEntities;

namespace Entities.Concrete
{
    public class Language : BaseEntity
    {
        //Türkçe
        //English
        public string LanguageName { get; set; }
        //tr-TR
        //en-EN
        public string LanguageCode { get; set; }
        //1,2
        public int DisplayOrder { get; set; }

    }
}
