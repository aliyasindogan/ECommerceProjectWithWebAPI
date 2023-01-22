﻿using Core.Entities;
using System;

namespace Entities.Dtos.Resources
{
    public class ResourceDto : IDto
    {
        public int Id { get; set; }
        public Guid ResourceName { get; set; }
        public string ResourceValue { get; set; }
        public string ResourceGroupName { get; set; }
        public int LanguageID { get; set; }
        public string LaguageName { get; set; }
    }
}
