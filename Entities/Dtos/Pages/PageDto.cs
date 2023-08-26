using Core.Entities;

namespace Entities.Dtos.Pages
{
    public class PageDto : IDto
    {
        public int Id { get; set; }
        public string PageURL { get; set; }
        public int? ParentPageID { get; set; }
        public int PageTypeID { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
    }
}
