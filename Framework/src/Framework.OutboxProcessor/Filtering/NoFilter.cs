using Framework.Core.Events;

namespace Framework.OutboxProcessor.Filtering
{
    public class NoFilter : IFilter
    {
        public bool ShouldPublish(IEvent @event)
        {
            return true;
        }
    }
}