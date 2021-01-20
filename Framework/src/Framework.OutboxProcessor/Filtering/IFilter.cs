using System;
using System.Linq;
using System.Reflection;
using Framework.Core.Events;

namespace Framework.OutboxProcessor.Filtering
{
    public interface IFilter
    {
        bool ShouldPublish(IEvent @event);
    }

    //public class MyCustomFiler : IFilter
    //{
    //    public bool ShouldPublish(IEvent @event)
    //    {
    //        return @event.GetType().GetCustomAttributes<IntegrationEventAttribute>().Any();
    //    }
    //}

    //public class IntegrationEventAttribute : Attribute { }
}