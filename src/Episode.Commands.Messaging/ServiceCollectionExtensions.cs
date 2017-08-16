using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Episode.Commands.Messaging
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCommandBus(this IServiceCollection services)
        {
            services.TryAddSingleton<CommandBus>(s => new CommandBus(s.GetRequiredService<IBusAdapter>(), s.GetRequiredService<ICommandMetadataFactory>()));

            return services;
        }
    }
}
