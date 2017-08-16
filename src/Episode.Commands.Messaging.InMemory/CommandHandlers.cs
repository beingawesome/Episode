using Episode.Commands.Handlers;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Episode.Commands.Messaging.InMemory
{

    internal class CommandHandlers
    {
        private readonly IServiceProvider _services;

        public CommandHandlers(IServiceProvider services)
        {
            _services = services;
        }

        public ICommandHandler<TCommand> Build<TCommand>()
            where TCommand : Command
        {
            return _services.GetService<ICommandHandler<TCommand>>();
        }
    }
}
