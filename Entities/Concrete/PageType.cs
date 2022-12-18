using Core.Entities.BaseEntities;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class PageType : BaseEntity
    {
        public PageType()
        {
            Pages = new HashSet<Page>();
        }
        public string PageTypeName { get; set; }


        public ICollection<Page> Pages { get; set; }

    }
}
