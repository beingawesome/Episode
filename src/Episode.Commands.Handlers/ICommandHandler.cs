using Episode.Metadata;
using Episode.Versioning;
using System.Threading.Tasks;

namespace Episode.Commands.Handlers
{
    public interface ICommandHandler<TCommand>
        where TCommand : Command
    {
        Task<Commit> HandleAsync(TCommand command, IReadOnlyMetadata metadata);
    }
}
