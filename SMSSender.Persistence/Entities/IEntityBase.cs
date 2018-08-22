using System;

namespace SMSSender.Persistence.Entities
{
    public interface IEntityBase
    {
        long Id { get; set; }

        DateTime CreatedUtc { get; set; }
    }
}