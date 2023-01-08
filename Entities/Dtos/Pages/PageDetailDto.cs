﻿namespace Entities.Dtos.Pages
{
    public class PageDetailDto
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
