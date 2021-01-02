using System;
using Framework.Core;

namespace Framework.Domain
{
    public interface IDomainEvent : IEvent
    {
        Guid EventId { get; }
        DateTime PublishDateTime { get; }
    }
}