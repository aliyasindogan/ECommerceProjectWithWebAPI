using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Pages
{
    public class PageDeleteDto
    {
        public int Id { get; set; }
        public string PageName { get; set; }
        public string PageURL { get; set; }
        public int? ParentID { get; set; }
        public string PageSeoURL { get; set; }
        public int PageTypeID { get; set; }
        public int DisplayOrder { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
    }
}
