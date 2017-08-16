using Episode.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace Episode.Events.Store.EventStore
{
    public interface IEventMetadataFactory
    {
        IMetadata Create(Event e);
    }
}
