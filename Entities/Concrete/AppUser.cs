using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class AppUser : User
    {

        public virtual AppUserType AppUserType { get; set; }
    }
}
