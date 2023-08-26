namespace Entities.Dtos.Pages
{
    public class PageAddDto
    {
        public string PageURL { get; set; }
        public int? ParentPageID { get; set; }
        public int PageTypeID { get; set; }
        public int DisplayOrder { get; set; }
    }
}
