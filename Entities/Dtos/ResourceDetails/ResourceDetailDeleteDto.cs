using Core.Entities;
using System;

namespace Entities.Dtos.ResourceDetails
{
    public class ResourceDetailDeleteDto : IDto
    {
        public int Id { get; set; }
        public string ResourceValue { get; set; }
        public int ResourceID { get; set; }
        public int LanguageID { get; set; }
     
    }
}
