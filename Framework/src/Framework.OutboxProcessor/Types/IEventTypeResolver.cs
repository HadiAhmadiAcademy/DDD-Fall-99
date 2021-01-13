using System;
using System.Reflection;

namespace Framework.OutboxProcessor.Types
{
    public interface IEventTypeResolver
    {
        void AddTypesFromAssembly(Assembly assembly);
        Type GetType(string typeName);
    }
}