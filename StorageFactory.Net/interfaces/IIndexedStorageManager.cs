namespace StorageFactory.Net.interfaces {


    /// <summary>Manage files with an index object that contains subset of its data</summary>
    /// <remarks>
    /// Most useful for storing a number of large data models. An index file contains 
    /// a list of the index objects that hold display info for the file and its access
    /// information. So you can get a list of information rapidly without having to
    /// open all the larger files
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    public interface IIndexedStorageManager<TData,TExtraInfo> where TData : class where TExtraInfo : class {

        #region Properties

        /// <summary>
        /// By default, implementations will use Environment.SpecialFolder.LocalApplicationData 
        /// so that Xamarin can create cross platform storage directories. ONLY EVER OVERRIDE 
        /// THIS IF YOU ARE WORKING ON A SPECIFIC OS 
        /// </summary>
        string StorageRootDir { get; set; }


        /// <summary>File storage sub diretory off root. Default "DEFAULT_SUB_DIR"</summary>
        /// <remarks>
        /// Back slashes will be converted to '/' for cross platform compatibility. No leading or 
        /// ending front or back slashes
        /// </remarks>
        string StorageSubDir { get; set; }


        /// <summary>The storage path combined root and sub directory</summary>
        string StoragePath { get; }


        string IndexFileName { get; set; }


        /// <summary>Get the list of info on objects currently stored</summary>
        List<IIndexItem<TExtraInfo>> IndexedItems { get; }



        #endregion


        /// <summary>Force a fresh reload of index from file</summary>
        /// <returns>The index list freshly loaded</returns>
        List<IIndexItem<TExtraInfo>> ReloadIndex();


        /// <summary>Does the file exist</summary>
        /// <param name="fileInfo">The info on the file to verify</param>
        /// <returns>true on success, otherwise false</returns>
        bool FileExists(IIndexItem<TExtraInfo> fileInfo);


        /// <summary>Retrieve the stored T object based on its info</summary>
        /// <param name="fileInfo">The info object required to retrieve the object</param>
        /// <returns>
        /// A retrieval info class which contains the stored object and its indexer 
        /// object required for next store
        /// </returns>
        IIndexedRetrievalInfo<TData,TExtraInfo> Retrieve(IIndexedRetrievalInfo<TData, TExtraInfo> outPut, IIndexItem<TExtraInfo> fileInfo);


        /// <summary>Retrieve the object with information from the index item</summary>
        /// <param name="indexItem">The index item with file info</param>
        /// <returns>The object or null if not found</returns>
        TData Retrieve(IIndexItem<TExtraInfo> indexItem);


        /// <summary>Store previously retrieved object with its related indexing</summary>
        /// <param name="retrievedData">Contains the object as well as its indexing info</param>
        /// <returns>true on success, otherwise false</returns>
        bool Store(IIndexedRetrievalInfo<TData, TExtraInfo> retrievedData);


        /// <summary>Store object with its related indexing</summary>
        /// <remarks>See IIndexedStorageInfo for details</remarks>
        /// <param name="info">Contains the indexing info</param>
        /// <returns>true on success, otherwise false</returns>
        bool Store(TData obj, IIndexItem<TExtraInfo> info);


        /// <summary>Delete the sub directory tree and all files that it contains</summary>
        /// <param name="subDirName"></param>
        bool DeleteStorageDirectory();


        /// <summary>Delete file based on the info and remove from index</summary>
        /// <param name="fileInfo">The info on the file to delete</param>
        /// <returns>true on success, otherwise false</returns>
        bool DeleteFile(IIndexItem<TExtraInfo> fileInfo);


        /// <summary>Deletes all files in the directory but leaves the diretory and index in place</summary>
        /// <returns>true on success, otherwise false</returns>
        bool DeleteAllFiles();

    }
}
