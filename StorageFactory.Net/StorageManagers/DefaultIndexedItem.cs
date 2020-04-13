
namespace StorageFactory.Net.StorageManagers {

    public class DefaultIndexedItem : IndexedStorageInfo<DefaultFileExtraInfo> {

        public DefaultIndexedItem(string objUid) : base("", new DefaultFileExtraInfo()) {
            // The default extra info is an empty object
        }

    }
}
