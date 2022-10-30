using Core.Entities;

namespace Entities.Dtos.AppOperationClaims
{
    public class AppOperationClaimDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
