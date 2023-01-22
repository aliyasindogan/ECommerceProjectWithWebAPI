using Core.Entities.BaseEntities;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Language : BaseEntity
    {
        public Language()
        {
            Resources = new HashSet<Resource>();
        }
        //Türkçe
        //English
        public string LanguageName { get; set; }
        //tr-TR
        //en-EN
        public string LanguageCode { get; set; }
        //1,2
        public int DisplayOrder { get; set; }

        public ICollection<Resource> Resources { get; set; }
    }
}
