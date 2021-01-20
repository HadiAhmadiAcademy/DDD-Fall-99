using System;

namespace Framework.Core.Events
{
    public interface IEvent
    {
        Guid EventId { get; }
        //Guid CorrelationId  { get; }
        DateTime PublishDateTime { get; }
    }
}