namespace StorageFactory.Net.interfaces {

    public interface IStorageManager<T> where T :class {

        #region Properties

        /// <summary>
        /// By default, implementations will use Environment.SpecialFolder.LocalApplicationData 
        /// so that Xamarin can create cross platform storage directories. ONLY OVERRIDE THIS 
        /// IF YOU ARE WORKING ON A SPECIFIC OS ONLY 
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


        /// <summary>File name used for Default File methods. Set if required</summary>
        string DefaultFileName { get; set; }

        #endregion


        /// <summary>Delete the sub directory tree and all files that it contains</summary>
        /// <param name="subDirName"></param>
        bool DeleteStorageDirectory();


        /// <summary>Delete the file defined DefaultFileName property</summary>
        /// <returns>true on success, otherwise false</returns>
        bool DeleteDefaultFile();


        /// <summary>Delete named file in the working directory</summary>
        /// <param name="filename">The file to delete</param>
        /// <returns>true on success, otherwise false</returns>
        bool DeleteFile(string filename);


        /// <summary>Delete files in the working directory according to the pattern</summary>
        /// <param name="pattern">The pattern such as '*.txt' to delete</param>
        /// <returns>true on success, otherwise false</returns>
        bool DeleteFiles(string pattern);


        /// <summary>Delete all files in the working directory</summary>
        /// <returns>true on success, otherwise false</returns>
        bool DeleteAllFiles();


        /// <summary>Does the file defined in DefaultFileName property exist</summary>
        /// <returns>true on success, otherwise false</returns>
        bool DefaultFileExists();


        /// <summary>Does the named file exist</summary>
        /// <param name="filename">The file to verify</param>
        /// <returns>true on success, otherwise false</returns>
        bool FileExists(string filename);


        List<string> GetFileList(bool includePath = false);


        /// <summary>Load in the file defined DefaultFileName property</summary>
        /// <returns>The T class or null</returns>
        T ReadObjectFromDefaultFile();


        /// <summary>Load in the named file</summary>
        /// <returns>The T class or null</returns>
        T ReadObjectFromFile(string filename);


        /// <summary>Write the class object to the file defined in DefaultFileName property</summary>
        /// <returns>true on success, otherwise false</returns>
        bool WriteObjectToDefaultFile(T obj);


        /// <summary>Write the T class object to the named file</summary>
        /// <returns>true on success, otherwise false</returns>
        bool WriteObjectToFile(T obj, string filename);

    }
}
