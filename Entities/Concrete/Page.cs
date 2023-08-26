using Core.Entities.BaseEntities;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Page:BaseEntity
    {
        public Page()
        {
            PagePermissons = new HashSet<PagePermisson>();
            PageLanguages = new HashSet<PageLanguage>();
        }
        public string PageURL { get; set; }
        public int? ParentPageID { get; set; }
        public int PageTypeID { get; set; }
        public int DisplayOrder { get; set; }
    
        public PageType PageType { get; set; }
        public ICollection<PagePermisson> PagePermissons { get; set; }
        public ICollection<PageLanguage> PageLanguages { get; set; }

    }
}
