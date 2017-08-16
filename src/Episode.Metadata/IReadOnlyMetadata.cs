namespace Episode.Metadata
{
    public interface IReadOnlyMetadata
    {
        TFeature Get<TFeature>();
    }
}
