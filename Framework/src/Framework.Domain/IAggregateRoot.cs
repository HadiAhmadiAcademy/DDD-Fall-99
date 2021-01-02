using System.Collections.Generic;

namespace Framework.Domain
{
    public interface IAggregateRoot
    {
        IReadOnlyList<IDomainEvent> UncommittedEvents { get; }
    }
}