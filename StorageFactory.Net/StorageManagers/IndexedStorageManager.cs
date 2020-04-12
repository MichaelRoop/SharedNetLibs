using ChkUtils.Net;
using ChkUtils.Net.ErrObjects;
using LogUtils.Net;
using StorageFactory.Net.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using VariousUtils;

namespace StorageFactory.Net.StorageManagers {

    public class IndexedStorageManager<TData, TExtraInfo> 
        : IIndexedStorageManager<TData, TExtraInfo> where TData : class where TExtraInfo : class {

        #region Data

        private string root = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private string subDir = "DEFAULT_SUB_DIR";
        private string fileName = "DEFAULT_FILE_NAME.TXT";
        private string indexName = "DEFAULT_INDEX_FILE_NAME.TXT";
        private IReadWriteSerializer<TData> dataSerializer = null;
        private IReadWriteSerializer<IIndexStorageDataModel<TExtraInfo>> indexSerializer = null;

        private IIndexStorageDataModel<TExtraInfo> indexItems = new IndexStorageDataModel<TExtraInfo>();
        private ClassLog log = new ClassLog("IndexedStorageManager");

        #endregion

        #region IIndexedStorageManger Properties

        public string StorageRootDir {
            get { lock (this) { return this.root; } }
            set {
                lock (this) {
                    this.root = FileHelpers.CleanLeadAndTrailingSlashes(FileHelpers.ConvertSlashes(value));
                }
            }
        }


        public string StorageSubDir {
            get { lock (this) { return this.subDir; } }
            set {
                lock (this) {
                    this.subDir = FileHelpers.CleanLeadAndTrailingSlashes(FileHelpers.ConvertSlashes(value));
                }
            }
        }


        /// <summary>The storage path combined root and sub directory</summary>
        public string StoragePath {
            get { lock (this) { return Path.Combine(this.root, this.subDir); } }
        }


        public List<IIndexedStorageInfo<TExtraInfo>> IndexedItems {
            get {
                lock (this) {
                    return this.GetIndex().Items;
                }
            }
        }

        #endregion

        #region Constructors

        public IndexedStorageManager(
            IReadWriteSerializer<TData> dataSerializer,
            IReadWriteSerializer<IIndexStorageDataModel<TExtraInfo>> indexSerializer) {
         
            this.dataSerializer = dataSerializer;
            this.indexSerializer = indexSerializer;
        }

        #endregion

        #region IIndexedStorageManger Methods

        public bool DeleteFile(IIndexedStorageInfo<TExtraInfo> fileInfo) {
            lock (this) {
                ErrReport report;
                bool result = WrapErr.ToErrReport(out report, 9999, "", () => {
                    // sync file and index changes
                    // TODO May want to load new copy of index here
                    if (this.IsInIndex(fileInfo)) {
                        if (!this.RemoveFromIndex(fileInfo)) { 
                            return false;
                        }

                        // At this point index is changed but not saved
                        if (!FileHelpers.DeleteFile(this.FullFileName(fileInfo))) {
                            // Restore index item to this copy of index
                            this.indexItems.Items.Add(fileInfo);
                            return false;
                        }
                        return this.WriteIndexToFile(this.indexItems);
                    }
                    else {
                        this.log.Error(9999, () => string.Format("'{0}' ({1}) not found in index", fileInfo.Display, fileInfo.UId));
                        // Still try to delete the file in case orphaned from index
                        return FileHelpers.DeleteFile(this.FullFileName(fileInfo));
                    }
                });
                return report.Code == 0 ? result : false;
            }
        }


        public bool DeleteStorageDirectory() {
            lock (this) {
                if (DirectoryHelpers.DeleteDirectory(this.StoragePath)) {
                    this.indexItems.Items.Clear();
                }
                return false;
            }
        }

        public bool FileExists(IIndexedStorageInfo<TExtraInfo> indexItem) {
            lock (this) {
                return File.Exists(FileHelpers.GetFullFileName(this.StoragePath, indexItem.UId));
            }
        }

        public IIndexedRetrievalInfo<TData, TExtraInfo> Retrieve(
            IIndexedRetrievalInfo<TData, TExtraInfo> outPut, 
            IIndexedStorageInfo<TExtraInfo> fileInfo) {




            return outPut;
        }


        public bool Store(IIndexedRetrievalInfo<TData, TExtraInfo> retrievedData) {
            return this.Store(retrievedData.StoredObject, retrievedData.Info);
        }


        /// <summary>Write the file
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="indexItem"></param>
        /// <returns></returns>
        public bool Store(TData obj, IIndexedStorageInfo<TExtraInfo> indexItem) {
            lock (this) {
                // check if exists in index
                bool inIndex = this.IsInIndex(indexItem);
                if (this.WriteDataToFile(obj, indexItem)) {
                    // Remove from index so it can have new index entry in case it has changed
                    // TODO - what happens if remove is false?
                    this.RemoveFromIndex(indexItem);
                    // Call the copy directly to prevent loading from file if we removed last item localy
                    this.indexItems.Items.Add(indexItem);
                    return this.WriteIndexToFile(this.indexItems);
                }
                return true;
            }
        }

        #endregion


        private bool WriteDataToFile(TData obj, IIndexedStorageInfo<TExtraInfo> info) {
            ErrReport report;
            string name = FileHelpers.GetFullFileName(this.StoragePath, info.UId);
            bool ret = WrapErr.ToErrReport(out report, 9999,
                () => string.Format("Failed to write file '{0}'", name),
                () => {
                    this.log.Info("Store", () => string.Format("Write file:{0}", name));
                    DirectoryHelpers.CreateStorageDir(this.StoragePath);
                    using (FileStream fs = File.Create(name)) {
                        return this.dataSerializer.Serialize(obj, fs);
                    }
                });
            return report.Code == 0 ? ret : false;
        }



        /// <summary>Write the index to the named file</summary>
        /// <param name="index">The index object</param>
        /// <returns>true on success, otherwise false</returns>
        private bool WriteIndexToFile(IIndexStorageDataModel<TExtraInfo> index) {
            ErrReport report;
            string name = FileHelpers.GetFullFileName(this.StoragePath, this.indexName);
            bool ret = WrapErr.ToErrReport(out report, 9999,
                () => string.Format("Failed to write index '{0}'", name),
                () => {
                    this.log.Info("WriteIndexToFile", () => string.Format("Write Index:{0}", name));
                    DirectoryHelpers.CreateStorageDir(this.StoragePath);
                    using (FileStream fs = File.Create(name)) {
                        return this.indexSerializer.Serialize(index, fs);
                    }
                });
            return report.Code == 0 ? ret : false;
        }


        private IIndexStorageDataModel<TExtraInfo> ReadIndexFromFile() {
            lock (this) {
                ErrReport report;
                string name = FileHelpers.GetFullFileName(this.StoragePath, this.indexName);
                IIndexStorageDataModel<TExtraInfo> ret = WrapErr.ToErrReport(out report, 9999,
                    () => string.Format("Failed to read index '{0}'", name),
                    () => {
                        DirectoryHelpers.CreateStorageDir(this.StoragePath);
                        if (File.Exists(name)) {
                            using (FileStream fs = File.OpenRead(name)) {
                                return this.indexSerializer.Deserialize(fs);
                            }
                        }
                        return default(IIndexStorageDataModel<TExtraInfo>);
                    });
                return report.Code == 0 ? ret : default(IIndexStorageDataModel<TExtraInfo>);
            }
        }


        /// <summary>Get the index copy or load from file if empty</summary>
        /// <returns>The index copy</returns>
        private IIndexStorageDataModel<TExtraInfo> GetIndex() {
            if (this.indexItems.Items.Count > 0) {
                this.indexItems = this.ReadIndexFromFile();
            }
            return this.indexItems;
        }





        private string FullFileName(IIndexedStorageInfo<TExtraInfo> fileInfo) {
            return FileHelpers.GetFullFileName(this.StoragePath, fileInfo.UId);
        }


        private bool IsInIndex(IIndexedStorageInfo<TExtraInfo> fileInfo) {
            return this.GetIndex().Items.Find((x) => x == fileInfo) != null;
        }


        private bool RemoveFromIndex(IIndexedStorageInfo<TExtraInfo> indexItem) {
            if (this.IsInIndex(indexItem)) {
                if (this.indexItems.Items.Remove(indexItem)) {
                    return true;
                }
                this.log.Error(9999, () => string.Format("Failed to remove '{0}' ({1}) from index", indexItem.Display, indexItem.UId));
                return false;
            }
            return true;
        }


    }
}
