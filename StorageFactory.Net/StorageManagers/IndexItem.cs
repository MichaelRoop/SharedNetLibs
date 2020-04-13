using Newtonsoft.Json;
using StorageFactory.Net.interfaces;

namespace StorageFactory.Net.StorageManagers {

    public class IndexItem<T> : IIndexItem<T> where T : class {

        #region Properties

        /// <summary>Useful for displaying to the user to identify the item</summary>
        public string Display { get; set; } = "** NA **";


        /// <summary>
        /// Unique file identifier generated on create. Can be deserialized by Newtonsoft JSON
        /// </summary>
        [JsonProperty]
        public string UId_FileName { get; private set; } = "** NA **";


        /// <summary>Unique identifier from the stored object itself</summary>
        [JsonProperty]
        public string UId_Object { get; private set; } = "** NA **";


        /// <summary>Extra information about the stored object to return with index info</summary>
        [JsonProperty]
        public T ExtraInfoObj { get; private set; } = default(T);

        #endregion

        #region Constructors

        /// <summary>Requires default constructor for JSON serialization</summary>
        public IndexItem() {
        }


        public IndexItem(string objUId) {
            this.ExtraInfoObj = default(T);
            this.UId_Object = objUId;
            this.UId_FileName = string.Format("{0}.txt", this.UId_Object);
        }


        public IndexItem(string objUId, T extraInfo) : this(objUId) {
            this.ExtraInfoObj = extraInfo;
        }

        #endregion

    }
}
