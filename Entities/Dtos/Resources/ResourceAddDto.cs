using Core.Entities;
using System;

namespace Entities.Dtos.Resources
{
    public class ResourceAddDto : IDto
    {
        public string ResourceName { get; set; }
    }
}
