
namespace StorageFactory.Net.interfaces {

    /// <summary>Contains required data to maintain file in the index</summary>
    /// <remarks>
    /// If user adds other fields in implementation you will have to cast it
    /// to that type on retrieval. Other fields would be extra information 
    /// required in a list without having to retrieve entire files. 
    /// WARNING - Keep it small to avoid overhead in loading a list of these
    /// </remarks>
    public interface IIndexedStorageInfo<T> where T : class {
        
        /// <summary>Useful for displaying to the user to identify the item</summary>
        string Display { get; set; }


        /// <summary>File unique identifier</summary>
        string UIdFileName { get; }


        /// <summary>Unique identifier from the stored object itself</summary>
        string ObjUId { get; }


        /// <summary>Extra info stored with the index item for the stored object</summary>
        T ExtraInfoObj { get; }


    }
}
