using Core.Entities.Concrete;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class AppUser : User
    {
        [ForeignKey("UserTypeID")]
        public virtual AppUserType AppUserType { get; set; }
    }
}
