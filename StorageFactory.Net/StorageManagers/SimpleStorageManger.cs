using ChkUtils.Net;
using ChkUtils.Net.ErrObjects;
using LogUtils.Net;
using StorageFactory.Net.interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace StorageFactory.Net.StorageManagers {

    public class SimpleStorageManger<T> : IStorageManager<T> where T : class {

        #region Data

        private bool rebuildPath = true;
        private string fullPath = "";
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
                    this.root = this.CleanPathStr(value); 
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
                    this.subDir = this.CleanPathStr(value);
                } 
            }
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
                ErrReport report;
                WrapErr.ToErrReport(out report, 9999, "Failed to delete directory", () => {
                    string dir = this.GetStoragePath();
                    if (Directory.Exists(dir)) {
                        Directory.Delete(dir);
                    }
                });
                return report.Code == 0;
            }
        }


        /// <summary>Delete the file that was defined DefaultFileName property</summary>
        /// <returns>true on success, otherwise false</returns>
        public bool DeleteDefaultFile() {
            return this.DeleteFile(this.DefaultFileName);
        }


        /// <summary>Delete named file in the working directory</summary>
        /// <param name="filename">The file to delete</param>
        /// <returns>true on success, otherwise false</returns>
        public bool DeleteFile(string filename) {
            lock (this) {
                string name = this.FullFileName(filename);
                ErrReport report;
                WrapErr.ToErrReport(out report, 9999,
                    () => string.Format("Failed to delete: {0}", name),
                    () => {
                        if (File.Exists(name)) {
                            File.Delete(name);
                        }
                    });
                return report.Code == 0;
            }
        }


        /// <summary>Delete files in the working directory according to the pattern</summary>
        /// <param name="pattern">The pattern such as '*.txt' to delete</param>
        /// <returns>true on success, otherwise false</returns>
        public bool DeleteFiles(string pattern) {
            lock (this) {
                string dir = this.GetStoragePath();
                ErrReport report;
                WrapErr.ToErrReport(out report, 9999,
                    () => string.Format("Failed to delete files in {0} with pattern '{1}'", dir, pattern),
                    () => {
                        if (Directory.Exists(dir)) {
                            foreach (string file in Directory.GetFiles(dir, pattern)) {
                                File.Delete(Path.Combine(dir, file));
                            }
                        }
                    });
                return report.Code == 0;
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
            string name = this.FullFileName(filename);
            return File.Exists(name);
        }


        public List<string> GetFileList(bool includePath = false) {
            lock (this) {
                List<string> results = new List<string>();
                string dir = this.GetStoragePath();
                ErrReport report;
                WrapErr.ToErrReport(out report, 9999, "Failed to get file list", () => {
                    if (Directory.Exists(dir)) {
                        foreach (string file in Directory.GetFiles(dir)) {
                            if (includePath) {
                                results.Add(file);
                            }
                            else {
                                results.Add(Path.GetFileName(file));
                            }
                        }
                    }
                });
                return results;
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
                string name = this.FullFileName(filename);
                T ret = WrapErr.ToErrReport(out report, 9999,
                    () => string.Format("Failed to read: {0}", name),
                    () => {
                        this.CreateStorageDir();
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
            return this.WriteObjectToFile(obj, this.DefaultFileName);
        }


        /// <summary>Write the T class object to the named file</summary>
        /// <returns>true on success, otherwise false</returns>
        public bool WriteObjectToFile(T obj, string filename) {
            lock (this) {
                ErrReport report;
                string name = this.FullFileName(filename);
                bool ret = WrapErr.ToErrReport(out report, 9999,
                    () => string.Format("Failed to write: {0}", name),
                    () => {
                        Log.Info("SimpleStorageManager", "WriteObjectToFile", 
                            () => string.Format("Write File:{0}", name));
                        this.CreateStorageDir();
                        using (FileStream fs = File.Create(name)) {
                            return this.serializer.Serialize(obj, fs);
                        }
                    });
                return report.Code == 0 ? ret : false;
            }
        }

        #endregion

        #region Private

        /// <summary>Combine full path and file name</summary>
        /// <param name="fileName">The file name to add</param>
        /// <returns>The full file name including path</returns>
        private string FullFileName(string fileName) {
            return Path.Combine(this.GetStoragePath(), fileName);
        }


        /// <summary>Flip back slashes to forward slashes for cross-platform compatibility</summary>
        /// <param name="pathString">The path string to convert</param>
        /// <returns>The converted string</returns>
        private string ConvertBackSlashes(string pathString) {
            return WrapErr.ToErrorReportException(9999, "Failed to flip backslashes", () => {
                // Cover all the bases by converting either slashes to OS specific
                //Log.Error(9999, () => string.Format("Path.PathSeparator '{0}'", Path.DirectorySeparatorChar));
                string tmp = pathString.Replace('\\', Path.DirectorySeparatorChar);
                return tmp.Replace('/', Path.DirectorySeparatorChar);
            });
        }


        private string CleanPathStr(string pathStr) {
            WrapErr.ChkTrue(pathStr.Length > 0, 9999, "Empty sub directory string not allowed");
            string tmp = this.ConvertBackSlashes(pathStr);
            if (tmp.StartsWith(Path.PathSeparator.ToString())) {
                tmp = tmp.Remove(0, 1);
                WrapErr.ChkTrue(pathStr.Length > 0, 9999, "Empty sub directory string not allowed");
            }
            if (tmp.EndsWith(Path.PathSeparator.ToString())) {
                tmp = tmp.Remove(tmp.Length - 1, 1);
                WrapErr.ChkTrue(pathStr.Length > 0, 9999, "Empty sub directory string not allowed");
            }

            // Flag to indicate that a full path string must be rebuit if any part changed
            this.rebuildPath = true;
            return tmp;
        }


        private bool CreateStorageDir() {
            lock (this) {
                ErrReport report;
                WrapErr.ToErrReport(out report, 9999,
                    () => string.Format("Failed to create directory "),
                    () => {
                        string dir = this.GetStoragePath();
                        Log.Info("SimpleStorageManager", "CreateStorageDir",
                            () => string.Format("Checking to create:{0}", dir));


                        if (!Directory.Exists(dir)) {
                            Directory.CreateDirectory(dir);
                        }
                    });
                return report.Code == 0;
            }
        }


        private string GetStoragePath() {
            if (this.rebuildPath) {
                this.fullPath = Path.Combine(this.root, this.subDir);
            }
            return this.fullPath;
        }

        #endregion

    }
}
