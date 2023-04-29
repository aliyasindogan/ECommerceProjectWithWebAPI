namespace Entities.Dtos.Pages
{
    public class PageAddDto
    {
        public string PageURL { get; set; }
        public int? ParentID { get; set; }
        public int PageTypeID { get; set; }
        public int DisplayOrder { get; set; }
    }
}
