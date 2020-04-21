namespace StorageFactory.Net.interfaces {

    /// <summary>
    /// Interface to allow the creation of singleton storage mangers based
    /// on the type of class to be stored and retrieved. 
    /// </summary>
    /// <remarks>
    /// This has to be implemented by the user. More notes in function
    /// </remarks>
    public interface IStorageManagerFactory {

        /// <summary>Retrieved the storage manager for a class T object</summary>
        /// <typeparam name="T">The type to store and retrieve</typeparam>
        /// <remarks>   
        /// A sample implementation could be as follows
        /// 
        /// if (typeof(T).Name == typeof(UserDataClass1)) {
        ///     return new SimpleStorageManager<T>(new JsonReadWriteSerializer<T>());
        /// }
        /// else {
        ///     .....
        /// 
        /// You can return and instance of the same type of storage manager/serializer 
        /// combination to manage storage of different classes
        /// 
        /// </remarks>
        /// <returns>The storage manager for the type T class</returns>
        IStorageManager<T> GetManager<T>() where T : class;


        /// <summary>Retrieved the storage manager for a class T object</summary>
        /// <typeparam name="T">The type to store and retrieve</typeparam>
        /// <param name="subDirectory">The subdirectory off the root</param>
        /// <returns>The storage manager for the type T class</returns>
        IStorageManager<T> GetManager<T>(string subDirectory) where T : class;


        /// <summary>Retrieved the storage manager for a class T object</summary>
        /// <typeparam name="T">The type to store and retrieve</typeparam>
        /// <param name="subDirectory">The subdirectory off the root</param>
        /// <param name="defaultFileName">The file name for store and retrieve</param>
        /// <returns>The storage manager for the type T class</returns>
        IStorageManager<T> GetManager<T>(string subDirectory, string defaultFileName) where T : class;


        /// <summary>
        /// Retrieved the storage manager for a class TData object which has an 
        /// index that contains a TIndexExtraInfo in the index object 
        /// </summary>
        /// <typeparam name="TData">The type to store and retrieve</typeparam>
        /// <typeparam name="TIndexExtraInfo">The extra info in the index</typeparam>
        /// <remarks>   
        /// A sample implementation could be as follows
        /// 
        /// if (typeof(TData).Name == typeof(UserDataClass1)) {
        ///     // You can be more specific if you want to also determine which indexed manager
        ///     return new IndexedStorageManager<TData,TIndexedExtraInfo>(new JsonReadWriteSerializer<T>());
        /// }
        /// else {
        ///     .....
        /// 
        /// You can return and instance of the same type of storage manager/serializer 
        /// combination to manage storage of different classes
        /// 
        /// </remarks>
        /// <returns>The indexed storage manager for the type TData class with TIndexExtraInfo index extra info</returns>
        IIndexedStorageManager<TData, TIndexExtraInfo> GetIndexedManager<TData, TIndexExtraInfo>() where TData : class where TIndexExtraInfo : class;


        /// <summary>
        /// Retrieved the storage manager for a class TData object which has an 
        /// index that contains a TIndexExtraInfo in the index object 
        /// </summary>
        /// <typeparam name="TData">The type to store and retrieve</typeparam>
        /// <typeparam name="TIndexExtraInfo">The extra info in the index</typeparam>
        /// <param name="subDirectory">The subdirectory off the root</param>
        /// <returns>The indexed storage manager for the type TData class with TIndexExtraInfo index extra info</returns>
        IIndexedStorageManager<TData, TIndexExtraInfo> GetIndexedManager<TData, TIndexExtraInfo>(string subDirectory)
            where TData : class where TIndexExtraInfo : class;



        /// <summary>
        /// Retrieved the storage manager for a class TData object which has an 
        /// index that contains a TIndexExtraInfo in the index object 
        /// </summary>
        /// <typeparam name="TData">The type to store and retrieve</typeparam>
        /// <typeparam name="TIndexExtraInfo">The extra info in the index</typeparam>
        /// <param name="subDirectory">The subdirectory off the root</param>
        /// <param name="indexName">Name of the index file</param>
        /// <returns>The indexed storage manager for the type TData class with TIndexExtraInfo index extra info</returns>
        IIndexedStorageManager<TData, TIndexExtraInfo> GetIndexedManager<TData, TIndexExtraInfo>(string subDirectory, string indexName)
            where TData : class where TIndexExtraInfo : class;


    }
}
