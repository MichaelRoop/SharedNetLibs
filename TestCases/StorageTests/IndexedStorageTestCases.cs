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


        #endregion

        #region Setup

        [OneTimeSetUp]
        public void TestSetSetup() {
            this.OneTimeSetup();
            this.data1 = new TstData("Blah");
            this.data2 = new TstData("blip", 7777, 2121);
            this.data3 = new TstData("blop", 11, 987654321);
        }

        [OneTimeTearDown]
        public void TestSetTeardown() {
            this.OneTimeTeardown();
        }

        [SetUp]
        public void SetupEachTest() {
            // Clean up the directories I think
        }

        #endregion

        [Test]
        public void TestStoreRetrieve() {
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


                //for (int i = 0; i < ndxList.Count; i++) {
                //    var x = ndxList[i];
                //    //x.UId

                //}





                //for (int i = 0; i < 10; i++) {
                //    IIndexedStorageInfo<TstExtraInfo> idx =
                //        new IndexedStorageInfo<TstExtraInfo>(new TstExtraInfo());

                //    idx.Display = string.Format("Display:{0}", i);
                //    idx.ExtraInfoObj.Address = string.Format("Address:{0}", i);
                //    idx.ExtraInfoObj.ConnectType = i;

                //    manager.Store(
                //        new TstData(string.Format("Mine{0}", i), (321 + i), (333356 + i)),
                //        idx);
                //}






            });
        }



        //TestHelpersNet.CatchUnexpected(() => {
        //    });


    }
}
