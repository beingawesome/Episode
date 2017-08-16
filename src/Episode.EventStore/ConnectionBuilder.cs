using System;

namespace Episode.EventStore
{
    public class ConnectionBuilder : IDisposable
    {
        private readonly ConnectionPool _pool;

        internal ConnectionBuilder()
        {
            _pool = new ConnectionPool();
        }

        public EventStoreFacade Build(Uri uri)
        {
            return new EventStoreFacade(_pool, uri);
        }

        public void Dispose()
        {
            _pool?.Dispose();
        }
    }
}
