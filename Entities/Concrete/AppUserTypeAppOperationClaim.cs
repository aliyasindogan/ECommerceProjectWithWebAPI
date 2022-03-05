using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class AppUserTypeAppOperationClaim : UserTypeOperationClaim
    {
        public string Status { get; set; }

        [ForeignKey("OperationClaimId")]
        public virtual AppOperationClaim AppOperationClaim { get; set; }

        [ForeignKey("UserTypeId")]
        public virtual AppUserType AppUserType { get; set; }
    }
}
