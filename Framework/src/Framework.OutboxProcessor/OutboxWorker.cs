using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Framework.Core.Events;
using Framework.OutboxProcessor.DataStore;
using Framework.OutboxProcessor.EventBus;
using Framework.OutboxProcessor.Types;
using Framework.Persistence;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Framework.OutboxProcessor
{
    public class OutboxWorker : BackgroundService, IDataStoreChangeTracker
    {
        private readonly ILogger<OutboxWorker> _logger;
        private readonly IDataStore _store;
        private readonly ICursorManager _cursorManager;
        private readonly IEventBus _eventBus;
        private readonly IEventTypeResolver _typeResolver;

        public OutboxWorker(ILogger<OutboxWorker> logger,
            IDataStore store,
            ICursorManager cursorManager,
            IEventBus eventBus, 
            IEventTypeResolver typeResolver)
        {
            _logger = logger;
            _store = store;
            _cursorManager = cursorManager;
            _eventBus = eventBus;
            _typeResolver = typeResolver;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _eventBus.Start();
            _logger.LogInformation("Event bus started.");
            _store.SubscribeForChanges(this);
            _logger.LogInformation("Subscribed to data store");
        }

        public void ChangeDetected(OutboxItem item)
        {
            var type = _typeResolver.GetType(item.EventType);
            var eventToPublish = JsonConvert.DeserializeObject(item.EventBody, type) as IEvent;
            //..... Transformation .....
            _eventBus.Publish(eventToPublish);
            _cursorManager.Move(item.Id);
        }
    }
}
