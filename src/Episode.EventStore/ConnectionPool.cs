using EventStore.ClientAPI;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Episode.EventStore
{
    internal class ConnectionPool : IDisposable
    {
        private readonly ConcurrentDictionary<Uri, Task<IEventStoreConnection>> _pool = new ConcurrentDictionary<Uri, Task<IEventStoreConnection>>();

        public Task<IEventStoreConnection> Get(Uri uri)
        {
            return _pool.GetOrAdd(uri, CreateAndConnect);
        }

        private async Task<IEventStoreConnection> CreateAndConnect(Uri uri)
        {
            var connection = EventStoreConnection.Create(uri);

            await connection.ConnectAsync();

            return connection;
        }

        public void Dispose()
        {
            var connections = _pool.Values.ToArray();

            Task.WaitAll(connections);

            foreach (var connection in connections)
            {
                try
                {
                    connection.Result?.Close();
                    connection.Result?.Dispose();
                }
                catch
                {
                }
            }
        }
    }
}
