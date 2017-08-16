using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Episode.EventSourcing
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEventSourcing(this IServiceCollection services, Uri uri)
        {
            services.AddTransient<AggregateRepository>();

            return services;
        }
    }
}
