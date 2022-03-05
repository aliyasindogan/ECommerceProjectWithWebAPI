using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class AppUserAppOperationClaim : UserOperationClaim
    {
        public string Status { get; set; }
        [ForeignKey("OperationClaimId")]
        public virtual AppOperationClaim AppOperationClaim { get; set; }

        [ForeignKey("UserId")]
        public virtual AppUser AppUser { get; set; }
    }
}
