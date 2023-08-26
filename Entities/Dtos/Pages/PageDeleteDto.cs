using Core.Entities;

namespace Entities.Dtos.Pages
{
    public class PageDeleteDto:IDto
    {
        public int Id { get; set; }
        public string PageURL { get; set; }
        public int? ParentPageID { get; set; }
        public int PageTypeID { get; set; }
        public int DisplayOrder { get; set; }

    }
}
