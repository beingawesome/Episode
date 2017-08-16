using Episode.Versioning;
using System.Threading.Tasks;

namespace Episode.Commands.Messaging
{
    public sealed class CommandBus
    {
        private readonly IBusAdapter _bus;
        private readonly ICommandMetadataFactory _metadata;

        internal CommandBus(IBusAdapter bus, ICommandMetadataFactory metadata)
        {
            _bus = bus;
            _metadata = metadata;
        }

        public Task<Commit> SendAsync<TCommand>(TCommand command)
            where TCommand : Command
        {
            var meta = _metadata.Create(command);

            return _bus.SendAsync(command, meta);
        }
    }
}
