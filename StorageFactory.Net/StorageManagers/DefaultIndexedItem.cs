
namespace StorageFactory.Net.StorageManagers {

    public class DefaultIndexedItem : IndexItem<DefaultFileExtraInfo> {

        public DefaultIndexedItem(string objUid) : base("", new DefaultFileExtraInfo()) {
            // The default extra info is an empty object
        }

    }
}
