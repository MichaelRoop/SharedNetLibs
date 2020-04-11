using ChkUtils.Net;
using ChkUtils.Net.ErrObjects;
using LogUtils.Net;
using StorageFactory.Net.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using VariousUtils;

namespace StorageFactory.Net.StorageManagers {

    public class SimpleStorageManger<T> : IStorageManager<T> where T : class {

        #region Data

        private string root = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private string subDir = "DEFAULT_SUB_DIR";
        private string file = "DEFAULT_FILE_NAME.TXT";
        IReadWriteSerializer<T> serializer = null;

        #endregion

        #region IStorageManager Properties

        /// <summary>
        /// By default, implementations will use Environment.SpecialFolder.LocalApplicationData 
        /// so that Xamarin can create cross platform storage directories. ONLY OVERRIDE THIS 
        /// IF YOU ARE WORKING ON A SPECIFIC OS ONLY
        /// </summary>
        public string StorageRootDir {
            get { lock (this) { return this.root; } }
            set { lock (this) { 
                    this.root = FileHelpers.CleanLeadAndTrailingSlashes(FileHelpers.ConvertSlashes(value));
                } 
            }
        }


        /// <summary>File storage sub diretory off root. Default "DEFAULT_SUB_DIR"</summary>
        /// <remarks>
        /// Back slashes will be converted to '/' for cross platform compatibility. No leading or 
        /// ending front or back slashes
        /// </remarks>
        public string StorageSubDir {
            get { lock (this) { return this.subDir; } }
            set { lock (this) {
                    this.subDir = FileHelpers.CleanLeadAndTrailingSlashes(FileHelpers.ConvertSlashes(value));
                } 
            }
        }


        /// <summary>The storage path combined root and sub directory</summary>
        public string StoragePath {
            get { lock (this) { return Path.Combine(this.root, this.subDir); } }
        }


        /// <summary>File name used for Default File methods. Set if required</summary>
        public string DefaultFileName {
            get { lock (this) { return this.file; } }
            set { lock (this) { this.file = value; } }
        }

        #endregion

        #region Constructors

        public SimpleStorageManger(IReadWriteSerializer<T> serializer) {
            this.serializer = serializer;
        }

        #endregion

        #region IStorageManager implementation

        /// <summary>Delete the sub directory tree and all files that it contains</summary>
        /// <param name="subDirName"></param>
        public bool DeleteStorageDirectory() {
            lock (this) {
                return DirectoryHelpers.DeleteDirectory(this.StoragePath);
            }
        }


        /// <summary>Delete the file that was defined DefaultFileName property</summary>
        /// <returns>true on success, otherwise false</returns>
        public bool DeleteDefaultFile() {
            lock (this) {
                return this.DeleteFile(this.DefaultFileName);
            }
        }


        /// <summary>Delete named file in the working directory</summary>
        /// <param name="filename">The file to delete</param>
        /// <returns>true on success, otherwise false</returns>
        public bool DeleteFile(string filename) {
            lock (this) {
                return FileHelpers.DeleteFile(this.StoragePath, filename);
            }
        }


        /// <summary>Delete files in the working directory according to the pattern</summary>
        /// <param name="pattern">The pattern such as '*.txt' to delete</param>
        /// <returns>true on success, otherwise false</returns>
        public bool DeleteFiles(string pattern) {
            lock (this) {
                return FileHelpers.DeleteFiles(this.StoragePath, pattern);
            }
        }


        /// <summary>Delete all files in the working directory</summary>
        /// <returns>true on success, otherwise false</returns>
        public bool DeleteAllFiles() {
            return this.DeleteFiles("*.*");
        }


        /// <summary>Does the file defined in DefaultFileName property exist</summary>
        /// <returns>true on success, otherwise false</returns>
        public bool DefaultFileExists() {
            return this.FileExists(this.DefaultFileName);
        }


        /// <summary>Does the named file exist</summary>
        /// <param name="filename">The file to verify</param>
        /// <returns>true on success, otherwise false</returns>
        public bool FileExists(string filename) {
            lock (this) {
                return File.Exists(FileHelpers.GetFullFileName(this.StoragePath, filename));
            }
        }


        public List<string> GetFileList(bool includePath = false) {
            lock (this) {
                return FileHelpers.GetFileList(this.StoragePath, includePath);
            }
        }


        /// <summary>Load in the file defined DefaultFileName property</summary>
        /// <returns>The T class or null</returns>
        public T ReadObjectFromDefaultFile() {
            lock (this) {
                return this.ReadObjectFromFile(this.DefaultFileName);
            }
        }


        /// <summary>Load in the named file</summary>
        /// <returns>The T class or null</returns>
        public T ReadObjectFromFile(string filename) {
            lock (this) {
                ErrReport report;
                string name = FileHelpers.GetFullFileName(this.StoragePath, filename);
                T ret = WrapErr.ToErrReport(out report, 9999,
                    () => string.Format("Failed to read: {0}", name),
                    () => {
                        DirectoryHelpers.CreateStorageDir(this.StoragePath);
                        if (File.Exists(name)) {
                            using (FileStream fs = File.OpenRead(name)) {
                                return this.serializer.Deserialize(fs);
                            }
                        }
                        return default(T);
                    });
                return report.Code == 0 ? ret : default(T);
            }
        }


        /// <summary>Write the class object to the file defined in DefaultFileName property</summary>
        /// <returns>true on success, otherwise false</returns>
        public bool WriteObjectToDefaultFile(T obj) {
            lock (this) {
                return this.WriteObjectToFile(obj, this.DefaultFileName);
            }
        }


        /// <summary>Write the T class object to the named file</summary>
        /// <returns>true on success, otherwise false</returns>
        public bool WriteObjectToFile(T obj, string filename) {
            lock (this) {
                ErrReport report;
                string name = FileHelpers.GetFullFileName(this.StoragePath, filename);
                bool ret = WrapErr.ToErrReport(out report, 9999,
                    () => string.Format("Failed to write: {0}", name),
                    () => {
                        Log.Info("SimpleStorageManager", "WriteObjectToFile", 
                            () => string.Format("Write File:{0}", name));
                        DirectoryHelpers.CreateStorageDir(this.StoragePath);
                        using (FileStream fs = File.Create(name)) {
                            return this.serializer.Serialize(obj, fs);
                        }
                    });
                return report.Code == 0 ? ret : false;
            }
        }

        #endregion

    }
    // Previously 312 lines
}
