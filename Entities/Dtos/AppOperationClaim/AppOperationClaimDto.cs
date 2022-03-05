using Core.Entities;

namespace Entities.Dtos.AppOperationClaim
{
    public class AppOperationClaimDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
