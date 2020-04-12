using System.Collections.Generic;

namespace StorageFactory.Net.interfaces {


    /// <summary>An object to encapsulate the index file</summary>
    /// <typeparam name="TExtraInfo">The ExtraInfo</typeparam>
    public interface IIndexStorageDataModel<TExtraInfo> where TExtraInfo : class {

        List<IIndexedStorageInfo<TExtraInfo>> Items { get; set; }

    }


}
