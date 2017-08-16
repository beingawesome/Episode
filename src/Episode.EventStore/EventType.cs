namespace Episode.EventStore
{
    internal class EventType
    {
        public EventType(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
