namespace Episode.Metadata
{
    public interface IMetadata : IReadOnlyMetadata
    {
        void Set<TFeature>(TFeature feature);
    }
}
