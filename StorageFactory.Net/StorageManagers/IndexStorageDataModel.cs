using StorageFactory.Net.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageFactory.Net.StorageManagers {
    class IndexStorageDataModel<TExtraInfo> : IIndexStorageDataModel<TExtraInfo> where TExtraInfo : class {
        
        public List<IIndexedStorageInfo<TExtraInfo>> Items { get; set; } 

        public IndexStorageDataModel() {
            this.Items = new List<IIndexedStorageInfo<TExtraInfo>>();
        }



    }
}
