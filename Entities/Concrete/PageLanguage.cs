using Core.Entities.BaseEntities;

namespace Entities.Concrete
{
    public class PageLanguage: AuditEntity
    {
        #region Properties
        public int PageID { get; set; }
        public string PageName { get; set; }
        public string PageSeoURL { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public int LanguageID { get; set; }
        #endregion

        #region Relations
        public Page Page { get; set; }
        public Language Language { get; set; } 
        #endregion

    }
}
