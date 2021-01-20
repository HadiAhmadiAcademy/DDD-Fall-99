using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Framework.Core.Events;
using Framework.Domain;

namespace Framework.OutboxProcessor.Types
{
    public class EventTypeResolver : IEventTypeResolver
    {
        private Dictionary<string, Type> _types = new Dictionary<string, Type>();
        public void AddTypesFromAssembly(Assembly assembly)
        {
            var events = assembly.GetTypes().Where(type => typeof(IEvent).IsAssignableFrom(type)).ToList();
            events.ForEach(a =>
            {
                _types.Add(a.Name, a);
            });
        }

        public Type GetType(string typeName)
        {
            if (_types.ContainsKey(typeName))
                return _types[typeName];
            return null;
        }
    }
}