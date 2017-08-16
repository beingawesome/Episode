using Episode.Metadata;

namespace Episode.Commands.Messaging
{
    public interface ICommandMetadataFactory
    {
        IMetadata Create<TCommand>(TCommand command)
            where TCommand : Command;
    }
}
