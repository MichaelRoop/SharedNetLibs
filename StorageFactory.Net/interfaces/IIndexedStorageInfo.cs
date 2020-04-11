
namespace StorageFactory.Net.interfaces {

    /// <summary>Contains required data to maintain file in the index</summary>
    /// <remarks>
    /// If user adds other fields in implementation you will have to cast it
    /// to that type on retrieval. Other fields would be extra information 
    /// required in a list without having to retrieve entire files. 
    /// WARNING - Keep it small to avoid overhead in loading a list of these
    /// </remarks>
    public interface IIndexedStorageInfo {
        
        /// <summary>Useful for displaying to the user to identify the item</summary>
        string Display { get; set; }

        /// <summary>Actual physical file name, usually generated</summary>
        /// <remarks>
        /// - Do NOT change IIndexedStorageInfo.FileName after initial store. 
        /// - If you want to store to new location, delete old object in 
        ///   storage after retrieval before storing same object with new name 
        ///   to clean up the index
        /// - If no FileName is specified it is presumed a new file and a GUID will be 
        ///   generated for the file name. This is the prefered method because it avoids 
        ///   duplicate file names 
        /// </remarks>
        string FileName { get; set; }


        /// <summary>Extension for file name. This extension is added to the GUID</summary>
        string FileExtName { get; set; }


    }
}
