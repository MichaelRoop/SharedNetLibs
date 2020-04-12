using LogUtils.Net;
using NUnit.Framework;
using StorageFactory.Net.interfaces;
using StorageFactory.Net.Serializers;
using StorageFactory.Net.StorageManagers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases.StorageTests {

    [TestFixture]
    class IndexedStorageTestCases : TestCaseBase {

        #region Test classes

        public class TstData {
            public int MyInt { get; set; } = 23;
            public string MyString { get; set; } = "this is a string";
            public int MyPrivateInt { get; private set; } = 9999;
            public string MyPrivateString { get; set; } = "this is a string";

            public TstData() {
                this.MyPrivateInt = 1234;
                this.MyPrivateString = "blipo";
            }

            public TstData(string str) {
                this.MyInt = 3226;
                this.MyPrivateInt = 1234;
                this.MyString = str;
                this.MyPrivateString = Guid.NewGuid().ToString();
            }


            public TstData(string str, int pub, int priv) {
                this.MyInt = pub;
                this.MyPrivateInt = priv;
                this.MyString = str;
                this.MyPrivateString = Guid.NewGuid().ToString();
            }
        }

        public class TstExtraInfo {
            public string Address { get; set; }
            public int ConnectType { get; set; }
        }

        public class MyIndexedRetrievalInfo : IIndexedRetrievalInfo<TstData, TstExtraInfo> {
            public bool RetrievedOk { get; set; } = false;
            public TstData StoredObject { get; set; }
            public IIndexedStorageInfo<TstExtraInfo> Info { get; set; }

            public MyIndexedRetrievalInfo() {
                this.RetrievedOk = false;
                this.StoredObject = new TstData();
                this.Info = new IndexedStorageInfo<TstExtraInfo>();
            }
        }


        #endregion

        #region Data

        private TstData data1 = null;
        private TstData data2 = null;
        private TstData data3 = null;
        private string subDir = "MR_TestCases/Cases";
        private ClassLog log = new ClassLog("IndexedStorageTestCases");
        private IReadWriteSerializer<TstData> dataSerializer = 
            new JsonReadWriteSerializerIndented<TstData>();
        private IReadWriteSerializer<IIndexStorageDataModel<TstExtraInfo>> indexSerializer =
            new JsonReadWriteSerializerIndented<IIndexStorageDataModel<TstExtraInfo>>();
        IIndexedStorageManager<TstData, TstExtraInfo> storage = null;

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

        [Test]
        public void TestStoreRetrieveWithRetrivalObj() {
            TestHelpersNet.CatchUnexpected(() => {
                IIndexedStorageManager<TstData, TstExtraInfo> manager = new
                    IndexedStorageManager<TstData, TstExtraInfo>(
                    this.dataSerializer,
                    this.indexSerializer);

                manager.StorageSubDir = this.subDir;
                manager.IndexFileName = "Index1.txt";

                manager.DeleteStorageDirectory();
                // On next call to IndexedItems it will recreate directory with an empty index
                Assert.False(Directory.Exists(manager.StoragePath), "Directory should be gone");
                Assert.AreEqual(0, manager.IndexedItems.Count, "should be 0 after directory deleted");
                Assert.True(Directory.Exists(manager.StoragePath), "Directory should be gone");
                Assert.True(Directory.GetFiles(manager.StoragePath).Count() == 1, "Should only have index file");

                int count = 10;
                List<IIndexedStorageInfo<TstExtraInfo>> info = new List<IIndexedStorageInfo<TstExtraInfo>>();
                List<TstData> data = new List<TstData>();
                for (int i = 0; i < count; i++) {
                    // Create data data model
                    data.Add(new TstData(string.Format("Mine{0}", i), (321 + i), (333356 + i)));

                    // create the storage info for the data model
                    IIndexedStorageInfo<TstExtraInfo> item =
                        new IndexedStorageInfo<TstExtraInfo>(new TstExtraInfo());
                    item.Display = string.Format("Display:{0}", i);
                    item.ExtraInfoObj.Address = string.Format("Address:{0}", i);
                    item.ExtraInfoObj.ConnectType = i;
                    info.Add(item);
                }


                for (int i = 0; i < count; i++) {
                    manager.Store(data[i], info[i]);
                }

                var ndxList = manager.IndexedItems;
                Assert.AreEqual(data.Count, ndxList.Count, "Data count vs retrieve ndx items");

                foreach (var ndx in manager.IndexedItems) {
                    Assert.True(manager.FileExists(ndx), "index list file not exists ({0})", ndx.UId);

                    IIndexedRetrievalInfo<TstData, TstExtraInfo> ret = new MyIndexedRetrievalInfo();
                    ret = manager.Retrieve(ret, ndx);
                    this.log.Info("TestStoreRetrieve", () => string.Format("UId:{0}", ret.Info.UId));
                    Assert.True(ret.RetrievedOk, "Failure to retrieve");
                    Assert.AreEqual(ret.Info.UId, ndx.UId);


                }
            });
        }


        private Tuple<List<TstData>, List<IIndexedStorageInfo<TstExtraInfo>>> CreateTestData(int count) {
            List<IIndexedStorageInfo<TstExtraInfo>> info = new List<IIndexedStorageInfo<TstExtraInfo>>();
            List<TstData> data = new List<TstData>();

            for (int i = 0; i < count; i++) {
                // Create data data model
                data.Add(new TstData(string.Format("Mine{0}", i), (321 + i), (333356 + i)));

                // create the storage index 
                info.Add(new IndexedStorageInfo<TstExtraInfo>(
                        new TstExtraInfo() {
                            Address = string.Format("Address:{0}", i),
                            ConnectType = i
                        }) {
                    Display = string.Format("Display:{0}", i)
                });
                Assert.AreEqual(data.Count, info.Count, "Data count vs ndx items");
            }
            return new Tuple<List<TstData>, List<IIndexedStorageInfo<TstExtraInfo>>>(data, info);
        }


        [Test]
        public void TestStoreRetrieveObj() {
            TestHelpersNet.CatchUnexpected(() => {
                int count = 10;
                var results = this.CreateTestData(count);
                for (int i = 0; i < count; i++) {
                    this.storage.Store(results.Item1[i], results.Item2[i]);
                }

                var ndxList = this.storage.IndexedItems;
                Assert.AreEqual(count, ndxList.Count, "Mismatch data in number and retrieved number");
                // Confirm that all the input data is in the index
                foreach (var ndx in ndxList) {
                    Assert.NotNull(results.Item2.First((x) => x.UId == ndx.UId), "Did not find in data {0} in storage index", ndx.UId.ToString());
                }
                for (int i = 0; i < count; i++) {
                    var ndx = results.Item2[i];
                    Assert.True(this.storage.FileExists(ndx), "index list file does not exists ({0})", ndx.UId);
                    TstData outObj = this.storage.Retrieve(ndx);
                    TstData inObj = results.Item1[i];
                    Assert.NotNull(outObj, "Failure to retrieve - null");
                    Assert.AreEqual(inObj.MyInt, outObj.MyInt, "MyInt");
                    Assert.AreEqual(inObj.MyPrivateInt, outObj.MyPrivateInt, "MyPrivateInt");
                    Assert.AreEqual(inObj.MyPrivateString, outObj.MyPrivateString, "private string");
                    Assert.AreEqual(inObj.MyString, outObj.MyString, "MyString");
                }



                foreach (var ndx in ndxList) {
                    Assert.True(this.storage.FileExists(ndx), "index list file not exists ({0})", ndx.UId);
                    TstData ret = this.storage.Retrieve(ndx);
                    Assert.NotNull(ret, "Failure to retrieve - null");
                    // Test the values against the in data
                }
            });
        }



        //TestHelpersNet.CatchUnexpected(() => {
        //    });


    }
}
