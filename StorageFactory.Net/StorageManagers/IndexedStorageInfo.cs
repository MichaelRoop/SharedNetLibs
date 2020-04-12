using Newtonsoft.Json;
using StorageFactory.Net.interfaces;
using System;

namespace StorageFactory.Net.StorageManagers {

    public class IndexedStorageInfo<T> : IIndexedStorageInfo<T> where T : class {

        /// <summary>Useful for displaying to the user to identify the item</summary>
        public string Display { get; set; }


        /// <summary>
        /// Unique file identifier generated on create. Can be deserialized by Newtonsoft JSON
        /// </summary>
        [JsonProperty]
        public string UId { get; private set; }


        /// <summary>Extra information about the stored object to return with index info</summary>
        [JsonProperty]
        public T ExtraInfoObj { get; private set; } 


        public IndexedStorageInfo() {
            this.ExtraInfoObj = default(T);
            this.UId = string.Format("{0}.txt", Guid.NewGuid().ToString());
        }


        public IndexedStorageInfo(T extraInfo) : this() {
            this.ExtraInfoObj = extraInfo;
        }


    }
}
