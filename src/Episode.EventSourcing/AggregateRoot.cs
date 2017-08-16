using Episode.Events;

namespace Episode.EventSourcing
{
    public abstract class AggregateRoot
    {
        internal static readonly long InitialVersion = -1;

        protected AggregateRoot(string id)
        {
            Id = id;
            Proxy = new AggregateProxy(this);
        }

        public string Id { get; }

        internal AggregateProxy Proxy { get; }

        protected void Emit(Event @event)
        {
            Proxy.Push(@event);
        }
    }
}
