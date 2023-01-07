using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class AppUserTypeAppOperationClaim : UserTypeOperationClaim
    {
        public AppUserType AppUserType { get; set; }
        public AppOperationClaim AppOperationClaim { get; set; }
    }
}
