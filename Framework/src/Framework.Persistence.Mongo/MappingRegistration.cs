using System;
using System.Linq;
using System.Reflection;

namespace Framework.Persistence.Mongo
{
    public static class MappingRegistration
    {
        public static void RegisterAll(Assembly assembly)
        {
            var mappings = assembly.GetExportedTypes()
                .Where(a => typeof(IBsonMapping).IsAssignableFrom(a) && a.IsInterface == false)
                .Select(Activator.CreateInstance)
                .OfType<IBsonMapping>()
                .ToList();

            mappings.ForEach(a => a.Register());
        }
    }
}