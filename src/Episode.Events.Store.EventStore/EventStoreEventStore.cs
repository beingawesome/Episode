using Episode.EventStore;
using Episode.Versioning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Episode.Events.Store.EventStore
{
    internal class EventStoreEventStore : IEventStore, IDisposable
    {
        private readonly IEventMetadataFactory _metadata;
        private readonly EventStoreFacade _connection;

        public EventStoreEventStore(EventStoreFacade connection, IEventMetadataFactory metadata)
        {
            _connection = connection;
            _metadata = metadata;
        }

        // TODO: should i to list?
        public async Task<IEnumerable<Event>> GetEventsAsync(string aggregate, string id, long start)
        {
            return (await _connection.Read(aggregate, id, start)).Select(x => x.Event);
        }

        public Task<Commit> SaveAsync(string aggregate, string id, long expectedVersion, IEnumerable<Event> events)
        {
            var descriptors = events.Select(x => new EventDescriptor(x, _metadata.Create(x)));

            return _connection.Save(aggregate, id, expectedVersion, descriptors);
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }

        Task<IEnumerable<Event>> IEventStore.GetEventsAsync(string aggregate, string id, long start)
        {
            throw new NotImplementedException();
        }        
    }
}
