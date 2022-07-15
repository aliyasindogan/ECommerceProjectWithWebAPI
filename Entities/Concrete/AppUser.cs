using Core.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class AppUser : User
    {
        public Guid RefreshToken { get; set; }
    }
}