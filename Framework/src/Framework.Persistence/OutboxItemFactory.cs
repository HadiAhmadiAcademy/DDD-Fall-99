using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Framework.Domain;
using Newtonsoft.Json;

namespace Framework.Persistence
{
    public static class OutboxItemFactory
    {
        public static List<OutboxItem> CreateFromEventsOfAggregate(List<IDomainEvent> events)
        {
            return events.Select(CreateOutboxItem).ToList();
        }
        public static OutboxItem CreateOutboxItem(IDomainEvent a)
        {
            return new OutboxItem()
            {
                EventId = a.EventId,
                EventType = a.GetType().Name,
                PublishDateTime = a.PublishDateTime,
                EventBody = JsonConvert.SerializeObject(a),
            };
        }
    }
}