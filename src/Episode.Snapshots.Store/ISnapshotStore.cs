using System.Threading.Tasks;

namespace Episode.Snapshots.Store
{
    public interface ISnapshotStore
    {
        Task<SnapshotDescriptor> GetLatestSnapshot(string type, string id);
        Task SaveAsync(string type, string id, SnapshotDescriptor snapshot);
    }
}
