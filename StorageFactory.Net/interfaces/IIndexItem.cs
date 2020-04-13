
namespace StorageFactory.Net.interfaces {

    /// <summary>Contains minimal index data that loads quickly and identify files</summary>
    /// <typeparam name="T">
    /// Type containing extra info to retrieve with each index items
    /// WARNING - Keep it small to avoid overhead in loading a list of these
    /// </typeparam>
    public interface IIndexItem<T> where T : class {
        
        /// <summary>Useful for displaying to the user to identify the item</summary>
        string Display { get; set; }


        /// <summary>File unique identifier</summary>
        string UId_FileName { get; }


        /// <summary>Unique identifier from the stored object itself</summary>
        string UId_Object { get; }


        /// <summary>Extra info stored with the index item for the stored object</summary>
        T ExtraInfoObj { get; }


    }
}
