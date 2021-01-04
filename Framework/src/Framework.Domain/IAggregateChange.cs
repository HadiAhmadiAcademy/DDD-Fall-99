using System.Collections.Generic;

namespace Framework.Domain
{
    public interface IAggregateChange: IAggregateRoot
    {
        IReadOnlyList<IDomainEvent> UncommittedEvents { get; }
    }
}