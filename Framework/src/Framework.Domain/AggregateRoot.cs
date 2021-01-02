using System.Collections.Generic;

namespace Framework.Domain
{
    public class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
    {
        private List<IDomainEvent> _uncommittedEvents;
        public IReadOnlyList<IDomainEvent> UncommittedEvents => _uncommittedEvents.AsReadOnly();
        public AggregateRoot()
        {
            _uncommittedEvents = new List<IDomainEvent>();
        }
    }
}