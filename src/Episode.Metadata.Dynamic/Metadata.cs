using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Episode.Metadata.Dynamic
{

    public class Metadata : Dictionary<string, JObject>, IMetadata
    {
        public TFeature Get<TFeature>()
        {
            var key = typeof(TFeature).Name;

            return TryGetValue(key, out var value)
                        ? value.ToObject<TFeature>()
                        : default(TFeature);
        }

        public void Set<TFeature>(TFeature feature)
        {
            var key = typeof(TFeature).Name;

            this[key] = JObject.FromObject(feature);
        }
    }
}
