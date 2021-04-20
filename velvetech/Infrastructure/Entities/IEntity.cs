using System;

namespace velvetech.Infrastructure
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime CreateDate { get; set; }
        DateTime? LastModifyDate { get; set; }
        DateTime? Removed { get; set; }
    }
}
