using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Domain
{
    public class AggregateChange<TKey> : Entity<TKey>, IAggregateChange
    {
        private readonly List<IDomainEvent> _uncommittedEvents;
        public IReadOnlyList<IDomainEvent> UncommittedEvents => _uncommittedEvents.AsReadOnly();
        public AggregateChange()
        {
            _uncommittedEvents = new List<IDomainEvent>();
        }
    }
}
