
namespace StorageFactory.Net.StorageManagers {

    public class DefaultIndexedItem : IndexItem<DefaultFileExtraInfo> {

#pragma warning disable IDE0060 // Remove unused parameter
        public DefaultIndexedItem(string objUid) : base("", new DefaultFileExtraInfo()) {
            // The default extra info is an empty object
        }
#pragma warning restore IDE0060 // Remove unused parameter

    }
}
