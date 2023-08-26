using Core.Entities;

namespace Entities.Dtos.PagePageLanguages
{
    public class PagePageLanguageDto : IDto
    {
        public int Id { get; set; }
        public int PageID { get; set; }
        public string PageName { get; set; }
        public string PageSeoURL { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public int LanguageID { get; set; }
        public string PageURL { get; set; }
        public int? ParentPageID { get; set; }
        public int PageTypeID { get; set; }
        public int DisplayOrder { get; set; }
        public string LanguageName { get; set; }
        public string PageTypeName { get; set; }
        public bool IsActive { get; set; }

    }
}
