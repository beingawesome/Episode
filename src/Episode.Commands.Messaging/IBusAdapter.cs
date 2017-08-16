using Episode.Metadata;
using Episode.Versioning;
using System.Threading.Tasks;

namespace Episode.Commands.Messaging
{
    public interface IBusAdapter
    {
        Task<Commit> SendAsync<TCommand>(TCommand command, IMetadata metadata)
            where TCommand : Command;
    }
}
