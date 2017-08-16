using Episode.Events;
using Episode.Metadata;
using EventStore.ClientAPI;
using Newtonsoft.Json;
using System;
using System.Text;

namespace Episode.EventStore
{

    internal class EventSerializer
    {
        public EventData Serialize(EventDescriptor e)
        {
            var type = e.Event.GetType();

            e.Metadata.Set(new EventType(type.AssemblyQualifiedName));

            var id = Guid.NewGuid();
            var name = type.Name;
            var data = ToJsonBytes(e.Event);
            var metadata = ToJsonBytes(e.Metadata);

            return new EventData(id, name, true, data, metadata);
        }

        public EventDescriptor Deserialize(ResolvedEvent resolved, bool throwOnError)
        {
            var metadata = FromJsonBytes<IMetadata>(resolved.Event.Metadata);
            var eventType = metadata.Get<EventType>();

            // TODO: Security risk!!! Don't do in production!!!
            var type = Type.GetType(eventType?.Name, throwOnError);

            if (type == null) return default(EventDescriptor);

            if (!typeof(Event).IsAssignableFrom(type))
            {
                return throwOnError
                        ? throw new Exception("Event is not of type Event")
                        : default(EventDescriptor);
            }

            var e = (Event)FromJsonBytes(resolved.Event.Data, type);

            return new EventDescriptor(e, metadata);
        }

        private byte[] ToJsonBytes<T>(T data)
        {
            var json = JsonConvert.SerializeObject(data);

            return Encoding.UTF8.GetBytes(json);
        }

        private T FromJsonBytes<T>(byte[] bytes)
        {
            return (T)FromJsonBytes(bytes, typeof(T));
        }

        private object FromJsonBytes(byte[] bytes, Type type)
        {
            var json = Encoding.UTF8.GetString(bytes);

            return JsonConvert.DeserializeObject(json, type);
        }
    }
}
