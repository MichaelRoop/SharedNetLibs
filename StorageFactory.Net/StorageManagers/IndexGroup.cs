using StorageFactory.Net.interfaces;
using System.Collections.Generic;

namespace StorageFactory.Net.StorageManagers {

    /// <summary>Holds group of index items and common data</summary>
    /// <typeparam name="TExtraInfo">ExtraInfo type contained in the index items</typeparam>
    public class IndexGroup<TExtraInfo> : IIndexGroup<TExtraInfo> where TExtraInfo : class {
        
        public List<IIndexItem<TExtraInfo>> Items { get; set; } 

        public IndexGroup() {
            this.Items = new List<IIndexItem<TExtraInfo>>();
        }

    }
}
