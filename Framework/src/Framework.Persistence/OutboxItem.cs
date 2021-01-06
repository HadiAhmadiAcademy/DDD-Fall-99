using System;

namespace Framework.Persistence
{
    public class OutboxItem
    {
        public long Id { get; set; }
        public Guid EventId { get; set; }
        public string EventType { get; set; }
        public string EventBody { get; set; }
        public DateTime PublishDateTime { get; set; }
    }
}
