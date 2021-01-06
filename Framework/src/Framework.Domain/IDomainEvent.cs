using System;
using Framework.Core;
using Framework.Core.Events;

namespace Framework.Domain
{
    public interface IDomainEvent : IEvent
    {
        Guid EventId { get; }
        DateTime PublishDateTime { get; }
    }
}