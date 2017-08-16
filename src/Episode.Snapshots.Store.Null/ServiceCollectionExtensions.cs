using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Episode.Snapshots.Store.Null
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNullSnapshotStore(this IServiceCollection services)
        {
            services.TryAddSingleton<ISnapshotStore, NullStore>();

            return services;
        }
    }
}
