using Core.Entities.BaseEntities;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Page:BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string PageName { get; set; }

        [Required]
        [StringLength(250)]
        public string PageURL { get; set; }
        public int? ParentID { get; set; }

        [StringLength(250)]
        public string PageSeoURL { get; set; }

        [Required]
        public int PageTypeID { get; set; }

        [Required]
        public int DisplayOrder { get; set; }

        [StringLength(70)]
        public string MetaTitle { get; set; }

        [StringLength(260)]
        public string MetaKeywords { get; set; }

        [StringLength(160)]
        public string MetaDescription { get; set; }
        public PageType PageType { get; set; }
    }
}
