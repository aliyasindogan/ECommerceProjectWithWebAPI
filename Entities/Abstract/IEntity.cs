using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Abstract
{
    /// <summary>
    /// Veritabanında karşılık gelen tablolarda olacak
    /// </summary>
    public interface IEntity
    {
        int Id { get; set; }
    }
}