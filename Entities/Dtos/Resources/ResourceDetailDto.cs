using Core.Entities;
using System;

namespace Entities.Dtos.Resources
{
    public class ResourceDetailDto : IDto
    {
        public int Id { get; set; }
        public string ResourceName { get; set; }
        
    }
}
