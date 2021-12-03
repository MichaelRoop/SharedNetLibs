using LogUtils.Net;
using NUnit.Framework;
using StorageFactory.Net.interfaces;
using StorageFactory.Net.Serializers;
using StorageFactory.Net.StorageManagers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestCaseSupport.Core;

namespace TestCases.StorageTests {

    [TestFixture]
    class IndexedStorageTestCases : TestCaseBase {

        #region Test classes

        public class TstData {
            public string UId { get; set; }
            public int MyInt { get; set; } = 23;
            public string MyString { get; set; } = "this is a string";
            public int MyPrivateInt { get; private set; } = 9999;
            public string MyPrivateString { get; set; } = "this is a string";

            public TstData() {
                this.UId = Guid.NewGuid().ToString();
                this.MyPrivateInt = 1234;
                this.MyPrivateString = "blipo";
            }

            public TstData(string str) {
                this.UId = Guid.NewGuid().ToString();
                this.MyInt = 3226;
                this.MyPrivateInt = 1234;
                this.MyString = str;
                this.MyPrivateString = Guid.NewGuid().ToString();
            }


            public TstData(string str, int pub, int priv) {
                this.UId = Guid.NewGuid().ToString();
                this.MyInt = pub;
                this.MyPrivateInt = priv;
                this.MyString = str;
                this.MyPrivateString = Guid.NewGuid().ToString();
            }
        }

        public class TstExtraInfo {
            public string Address { get; set; }
            public int ConnectType { get; set; }
            public TstExtraInfo() {
                this.Address = String.Empty; 
                this.ConnectType = 0;  
            }
            public TstExtraInfo(string address, int connectType) {
                this.Address = address;
                this.ConnectType = connectType;
            }
        }

        public class MyIndexedRetrievalInfo : IIndexedRetrievalInfo<TstData, TstExtraInfo> {
            public bool RetrievedOk { get; set; } = false;
            public TstData StoredObject { get; set; }
            public IIndexItem<TstExtraInfo> Info { get; set; }

            public MyIndexedRetrievalInfo() {
                this.RetrievedOk = false;
                this.StoredObject = new TstData();
                this.Info = new IndexItem<TstExtraInfo>(this.StoredObject.UId);
            }

            ///// <summary>Constructor</summary>
            ///// <remarks>
            ///// https://stackoverflow.com/questions/5780888/casting-interfaces-for-deserialization-in-json-net
            ///// Need a constructor with the concrete class so that Json serialize knows what to do
            ///// </remarks>
            ///// <param name="extraInfo"></param>
            //public MyIndexedRetrievalInfo(IndexedStorageInfo<TstExtraInfo> info
                
            //    /*TstData data, TstExtraInfo extraInfo*/):this() {
            //    // Do not use just 
            //    //this.StoredObject = data;
            //    throw new NotImplementedException();
            //}


        }


        #endregion

        #region Data

#pragma warning disable CS8618
        private TstData data1;
        private TstData data2;
        private TstData data3;
        IIndexedStorageManager<TstData, TstExtraInfo> storage;
#pragma warning restore CS8618

        private string subDir = "MR_TestCases/Cases";
        private ClassLog log = new ClassLog("IndexedStorageTestCases");
        private IReadWriteSerializer<TstData> dataSerializer = 
            new JsonReadWriteSerializerIndented<TstData>();
        private IReadWriteSerializer<IIndexGroup<TstExtraInfo>> indexSerializer =
            new JsonReadWriteSerializerIndented<IIndexGroup<TstExtraInfo>>();

        #endregion

        #region Setup

                [OneTimeSetUp]
        public void TestSetSetup() {
            this.OneTimeSetup();
            this.data1 = new TstData("Blah");
            this.data2 = new TstData("blip", 7777, 2121);
            this.data3 = new TstData("blop", 11, 987654321);
            // setup the indexed storage manager
            this.storage = new
                    IndexedStorageManager<TstData, TstExtraInfo>(
                    this.dataSerializer,
                    this.indexSerializer);
            this.storage.StorageSubDir = this.subDir;
            this.storage.IndexFileName = "Index1.txt";

        }

        [OneTimeTearDown]
        public void TestSetTeardown() {
            this.OneTimeTeardown();
        }

        [SetUp]
        public void SetupEachTest() {
            // Clean up the directories I think
            this.storage.DeleteStorageDirectory();
        }

        #endregion

        #region Directory management

        [Test]
        public void A1_DeleteEmptyDirectory() {
            TestHelpers.CatchUnexpected(() => {
                Directory.CreateDirectory(this.storage.StoragePath);
                Assert.True(Directory.Exists(this.storage.StoragePath), "Directory should be there");
                this.storage.DeleteStorageDirectory();
                Assert.False(Directory.Exists(this.storage.StoragePath), "Directory should be gone");
            });
        }


        [Test]
        public void A2_DeleteDirectoryWithFiles() {
            TestHelpers.CatchUnexpected(() => {
                Directory.CreateDirectory(this.storage.StoragePath);
                Assert.True(Directory.Exists(this.storage.StoragePath), "Directory should be there");
                using (FileStream fs = File.Create(Path.Combine(this.storage.StoragePath, "File1.txt"))) { };
                using (FileStream fs = File.Create(Path.Combine(this.storage.StoragePath, "File2.txt"))) { };
                Assert.AreEqual(2, Directory.GetFiles(this.storage.StoragePath).Count(), "Should be 2 files in directory");
                this.storage.DeleteStorageDirectory();
                Assert.False(Directory.Exists(this.storage.StoragePath), "Directory should be gone");
            });
        }



        [Test]
        public void A3_AutoCreateDirectory() {
            TestHelpers.CatchUnexpected(() => {
                this.storage.DeleteStorageDirectory();
                Assert.False(Directory.Exists(this.storage.StoragePath), "Directory should be gone");
                // On next call to IndexedItems it will recreate directory with an empty index
                Assert.AreEqual(0, this.storage.IndexedItems.Count, "should be 0 after directory deleted");
                Assert.True(Directory.Exists(this.storage.StoragePath), "Directory should be gone");
                Assert.True(Directory.GetFiles(this.storage.StoragePath).Count() == 1, "Should only have index file");
            });
        }

        #endregion

        //TestHelpers.CatchUnexpected(() => {
        //    });

        #region Storage Retrieval

        [Test]
        public void A4_TestStoreRetrieveWithRetrivalObj() {
            TestHelpers.CatchUnexpected(() => {
                int count = 10;
                var testData = this.CreateTestData(count);
                for (int i = 0; i < count; i++) {
                    this.storage.Store(testData.Item1[i], testData.Item2[i]);
                }

                var ndxList = this.storage.IndexedItems;
                Assert.AreEqual(count, ndxList.Count, "Mismatch data in number and retrieved number");
                // Confirm that all the input data is in the index
                foreach (var ndx in ndxList) {
                    Assert.NotNull(testData.Item2.First((x) => x.UId_FileName == ndx.UId_FileName), "Did not find in data {0} in storage index", ndx.UId_FileName.ToString());
                }
                for (int i = 0; i < count; i++) {
                    IIndexedRetrievalInfo<TstData, TstExtraInfo> retrieved = new MyIndexedRetrievalInfo();
                    retrieved = this.storage.Retrieve(retrieved, testData.Item2[i]);
                    Assert.True(this.storage.FileExists(testData.Item2[i]), "index list file does not exists ({0})", testData.Item2[i].UId_FileName);
                    this.log.Info("TestStoreRetrieve", () => string.Format("UId:{0}", retrieved.Info.UId_FileName));
                    Assert.True(retrieved.RetrievedOk, "Failure to retrieve");
                    Assert.AreEqual(testData.Item2[i].UId_FileName, retrieved.Info.UId_FileName);

                    TstData outObj = retrieved.StoredObject;
                    TstData inObj = testData.Item1[i];
                    Assert.NotNull(outObj, "Failure to retrieve - null");
                    Assert.AreEqual(inObj.MyInt, outObj.MyInt, "MyInt");
                    Assert.AreEqual(inObj.MyPrivateInt, outObj.MyPrivateInt, "MyPrivateInt");
                    Assert.AreEqual(inObj.MyPrivateString, outObj.MyPrivateString, "private string");
                    Assert.AreEqual(inObj.MyString, outObj.MyString, "MyString");
                }



                foreach (var ndx in ndxList) {
                    Assert.True(this.storage.FileExists(ndx), "index list file not exists ({0})", ndx.UId_FileName);
                    TstData ret = this.storage.Retrieve(ndx);
                    Assert.NotNull(ret, "Failure to retrieve - null");
                    // Test the values against the in data
                }

            });
        }


        [Test]
        public void A5_TestStoreRetrieveObj() {
            TestHelpers.CatchUnexpected(() => {
                int count = 10;
                var results = this.CreateTestData(count);
                for (int i = 0; i < count; i++) {
                    this.storage.Store(results.Item1[i], results.Item2[i]);
                }

                var ndxList = this.storage.IndexedItems;
                Assert.AreEqual(count, ndxList.Count, "Mismatch data in number and retrieved number");
                // Confirm that all the input data is in the index
                foreach (var ndx in ndxList) {
                    Assert.NotNull(results.Item2.First((x) => x.UId_FileName == ndx.UId_FileName), "Did not find in data {0} in storage index", ndx.UId_FileName.ToString());
                }
                for (int i = 0; i < count; i++) {
                    var ndx = results.Item2[i];
                    Assert.True(this.storage.FileExists(ndx), "index list file does not exists ({0})", ndx.UId_FileName);
                    TstData outObj = this.storage.Retrieve(ndx);
                    TstData inObj = results.Item1[i];
                    Assert.NotNull(outObj, "Failure to retrieve - null");
                    Assert.AreEqual(inObj.MyInt, outObj.MyInt, "MyInt");
                    Assert.AreEqual(inObj.MyPrivateInt, outObj.MyPrivateInt, "MyPrivateInt");
                    Assert.AreEqual(inObj.MyPrivateString, outObj.MyPrivateString, "private string");
                    Assert.AreEqual(inObj.MyString, outObj.MyString, "MyString");
                    // UID between the object and index item
                    Assert.AreEqual(inObj.UId, ndx.UId_Object, "Object ID not in sync with ndx ID");
                }

                foreach (var ndx in ndxList) {
                    Assert.True(this.storage.FileExists(ndx), "index list file not exists ({0})", ndx.UId_FileName);
                    TstData ret = this.storage.Retrieve(ndx);
                    Assert.NotNull(ret, "Failure to retrieve - null");
                    // Test the values against the in data
                }
            });
        }


        [Test]
        public void A6_TestStoreRetrieveObjAfterIndexReload() {
            TestHelpers.CatchUnexpected(() => {
                int count = 10;
                var results = this.CreateTestData(count);
                for (int i = 0; i < count; i++) {
                    this.storage.Store(results.Item1[i], results.Item2[i]);
                }

                //var ndxList = this.storage.IndexedItems;
                var ndxList = this.storage.ReloadIndex();

                Assert.AreEqual(count, ndxList.Count, "Mismatch data in number and retrieved number");
                // Confirm that all the input data is in the index
                foreach (var ndx in ndxList) {
                    Assert.NotNull(results.Item2.First((x) => x.UId_FileName == ndx.UId_FileName), "Did not find in data {0} in storage index", ndx.UId_FileName.ToString());
                }
                for (int i = 0; i < count; i++) {
                    var ndx = results.Item2[i];
                    Assert.True(this.storage.FileExists(ndx), "index list file does not exists ({0})", ndx.UId_FileName);
                    TstData outObj = this.storage.Retrieve(ndx);
                    TstData inObj = results.Item1[i];
                    Assert.NotNull(outObj, "Failure to retrieve - null");
                    Assert.AreEqual(inObj.MyInt, outObj.MyInt, "MyInt");
                    Assert.AreEqual(inObj.MyPrivateInt, outObj.MyPrivateInt, "MyPrivateInt");
                    Assert.AreEqual(inObj.MyPrivateString, outObj.MyPrivateString, "private string");
                    Assert.AreEqual(inObj.MyString, outObj.MyString, "MyString");
                }

                foreach (var ndx in ndxList) {
                    Assert.True(this.storage.FileExists(ndx), "index list file not exists ({0})", ndx.UId_FileName);
                    TstData ret = this.storage.Retrieve(ndx);
                    Assert.NotNull(ret, "Failure to retrieve - null");
                    // Test the values against the in data
                }
            });
        }


        #endregion

        #region File Delete

        [Test]
        public void A7_DeleteFilesLocalIndex() {
            TestHelpers.CatchUnexpected(() => {
                this.DoDelete(false);
            });
        }

        [Test]
        public void A8_DeleteFilesReloadedIndex() {
            TestHelpers.CatchUnexpected(() => {
                this.DoDelete(true);
            });
        }

        #endregion


        //TestHelpers.CatchUnexpected(() => {
        //    });


        #region Private

        private Tuple<List<TstData>, List<IIndexItem<TstExtraInfo>>> CreateTestData(int count) {
            List<IIndexItem<TstExtraInfo>> info = new List<IIndexItem<TstExtraInfo>>();
            List<TstData> data = new List<TstData>();

            for (int i = 0; i < count; i++) {
                TstData obj = new TstData(string.Format("Mine{0}", i), (321 + i), (333356 + i));
                TstExtraInfo extra = new TstExtraInfo(string.Format("Address:{0}", i), i);
                IndexItem<TstExtraInfo> ndx =
                    new IndexItem<TstExtraInfo>(obj.UId, extra) {
                        Display = string.Format("Display:{0}", i)
                    };
                data.Add(obj);
                info.Add(ndx);
                Assert.AreEqual(data.Count, info.Count, "Data count vs ndx items");
            }
            return new Tuple<List<TstData>, List<IIndexItem<TstExtraInfo>>>(data, info);
        }


        private void DoDelete(bool forceReload) {
            int count = 10;
            var results = this.CreateTestData(count);
            for (int i = 0; i < count; i++) {
                this.storage.Store(results.Item1[i], results.Item2[i]);
            }
            var ndxList = this.storage.IndexedItems;
            Assert.AreEqual(count, ndxList.Count, "Mismatch data in number and retrieved number");

            int remaining = 9;
            for (int i = 0; i < count; i++, remaining--) {

                this.log.Info("\n+++++++++++++", "-------------------------------------------------");
                this.log.Info("+++++++++++++",
                    () => string.Format("Iteration:{0} Expected:{1}", i, remaining));


                this.log.Info("+++++++++++++",
                    () => string.Format("Deleting:{0} - {1}", results.Item2[i].Display, results.Item2[i].UId_FileName));

                bool ok = this.storage.DeleteFile(results.Item2[i]);
                if (forceReload) {
                    int beforeReload = this.storage.IndexedItems.Count;
                    int actual = this.storage.ReloadIndex().Count;

                    this.log.Info("+++++++++++++", 
                        () => string.Format("success:{0} Actual Count:{1} BEFORE RELOAD:{2}",  ok, actual, beforeReload));




                    Assert.AreEqual(remaining, actual, "Wrong reloaded index count");
                    //Assert.AreEqual(remaining, this.storage.ReloadIndex().Count, "Wrong reloaded index count");
                }
                else {
                    Assert.AreEqual(remaining, this.storage.IndexedItems.Count, "Wrong local index count");
                }
                Assert.False(this.storage.FileExists(results.Item2[i]), "File should be gone ({0})", results.Item2[i].UId_FileName);
            }
        }


        #endregion


    }
}
