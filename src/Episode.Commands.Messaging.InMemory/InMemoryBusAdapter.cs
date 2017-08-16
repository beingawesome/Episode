using Episode.Metadata;
using Episode.Versioning;
using System.Threading.Tasks;

namespace Episode.Commands.Messaging.InMemory
{
    internal class InMemoryBusAdapter : IBusAdapter
    {
        private readonly CommandHandlers _handlers;

        public InMemoryBusAdapter(CommandHandlers handlers)
        {
            _handlers = handlers;
        }

        public Task<Commit> SendAsync<TCommand>(TCommand command, IMetadata metadata)
            where TCommand : Command
        {
            var handler = _handlers.Build<TCommand>();

            return handler.HandleAsync(command, metadata);
        }
    }
}
