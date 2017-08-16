using Episode.Events;
using Episode.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace Episode.EventStore
{
    public class EventDescriptor
    {
        public EventDescriptor(Event e, IMetadata metadata)
        {
            Event = e;
            Metadata = metadata;
        }

        public Event Event { get; }
        public IMetadata Metadata { get; }
    }
}
