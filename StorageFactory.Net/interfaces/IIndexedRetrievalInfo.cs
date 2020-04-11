using System;
using System.Collections.Generic;
using System.Text;

namespace StorageFactory.Net.interfaces {
    public interface IIndexedRetrievalInfo<T> where T : class {

        // TODO A retrieval property with information on success, etc?

        /// <summary>The retrieved class or default(T) class"</summary>
        T StoredObject { get; set; }

        /// <summary>Info on file required save it back to the correct index</summary>
        IIndexedStorageInfo Info { get; set; }


    }
}
