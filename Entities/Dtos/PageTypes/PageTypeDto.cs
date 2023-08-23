using Core.Entities;

namespace Entities.Dtos.PageTypes
{
    public class PageTypeDto:IDto
    {
        public int Id { get; set; }
        public string PageTypeName { get; set; }
    }
}
