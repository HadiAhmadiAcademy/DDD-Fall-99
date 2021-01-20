using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Framework.Core.Events;

namespace Framework.OutboxProcessor.EventTransformation
{
    public class EventTransformerLookUp : IEventTransformerLookUp
    {
        private Dictionary<string, Type> _transformers = new Dictionary<string, Type>();
        public void AddTypesFromAssembly(Assembly assembly)
        {
            var events = assembly.GetTypes()
                .Where(IsImplementationOfEventTransformer)
                .ToList();

            events.ForEach(transformer =>
            {
                var typeOfEvent = transformer.BaseType.GetGenericArguments().First();
                _transformers.Add(typeOfEvent.Name, transformer);
            });
        }

        private static bool IsImplementationOfEventTransformer(Type type)
        {
            return type.BaseType != null &&
                   type.BaseType.IsGenericType &&
                   type.BaseType.GetGenericTypeDefinition() == typeof(EventTransformer<>);
        }

        public IEventTransformer LookUpTransformer(IEvent @event)
        {
            var nameOfEvent = @event.GetType().Name;
            if (!_transformers.ContainsKey(nameOfEvent)) return null;
            return Activator.CreateInstance(_transformers[nameOfEvent]) as IEventTransformer;
        }
    }
}