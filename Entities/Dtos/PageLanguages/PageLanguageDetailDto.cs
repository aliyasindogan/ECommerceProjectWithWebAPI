namespace Entities.Dtos.PageLanguages
{
    public class PageLanguageDetailDto
    {
        public int Id { get; set; }
        public int PageID { get; set; }
        public string PageName { get; set; }
        public string PageSeoURL { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public int LanguageID { get; set; }

    }
}
