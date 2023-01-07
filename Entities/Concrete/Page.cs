using Core.Entities.BaseEntities;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Page:BaseEntity
    {
        public Page()
        {
            PagePermissons = new HashSet<PagePermisson>();
        }
        public string PageName { get; set; }
        public string PageURL { get; set; }
        public int? ParentID { get; set; }
        public string PageSeoURL { get; set; }
        public int PageTypeID { get; set; }
        public int DisplayOrder { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public PageType PageType { get; set; }
        public ICollection<PagePermisson> PagePermissons { get; set; }
        
    }
}
