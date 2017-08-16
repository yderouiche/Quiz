using System;

namespace Foundation.Domain.Entity
{
    
    public interface IEntity
    {
        int? Id { get; set; }

        bool IsNew { get; }

    }
}
