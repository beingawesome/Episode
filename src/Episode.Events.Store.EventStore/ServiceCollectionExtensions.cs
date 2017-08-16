using Episode.EventStore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Episode.Events.Store.EventStore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEventStoreEventStore(this IServiceCollection services, Uri uri)
        {
            services.AddEventStore();
            services.TryAddSingleton(s => GetEventStore(s, uri));

            return services;
        }

        private static IEventStore GetEventStore(IServiceProvider services, Uri uri)
        {
            var metadata = services.GetRequiredService<IEventMetadataFactory>();
            var builder = services.GetRequiredService<ConnectionBuilder>();
            var connection = builder.Build(uri);

            return new EventStoreEventStore(connection, metadata);
        }
    }
}
