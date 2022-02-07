using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class AppUserAppRole : UserRole
    {
        public string RoleStatus { get; set; }
        [ForeignKey("RoleId")]
        public virtual AppRole AppRole { get; set; }

        [ForeignKey("UserId")]
        public virtual AppUser AppUser { get; set; }
    }
}
