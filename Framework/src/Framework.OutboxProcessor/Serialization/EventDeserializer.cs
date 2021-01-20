using System;
using Framework.Core.Events;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Framework.OutboxProcessor.Serialization
{
    public static class EventDeserializer
    {
        private static JsonSerializerSettings settings;
        static EventDeserializer()
        {
            settings = new JsonSerializerSettings
            {
                ContractResolver = new PrivateSetterContractResolver(),
            };
        }
        public static IEvent Deserialize(Type type, string body)
        {
            return JsonConvert.DeserializeObject(body, type, settings) as IEvent;
        }
    }
}