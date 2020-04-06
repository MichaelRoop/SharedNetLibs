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
    public class StorageTestCases : TestCaseBase {

        #region Setup

        private tstData data = null;
        private tstData data2 = null;
        private string subDir = "MR_TestCases/Cases";

        [OneTimeSetUp]
        public void TestSetSetup() {
            this.OneTimeSetup();

            this.data = new tstData() {
                MyInt = 98214,
                MyString = "blah blah woof woof and then some",
            };

            this.data2 = new tstData() {
                MyInt = 111,
                MyString = "second object to secondary file, same directory",
            };
        }


        [OneTimeTearDown]
        public void TestSetTeardown() {
            this.OneTimeTeardown();
        }

        [SetUp]
        public void SetupEachTest() {
        }

        #endregion


        public class tstData {
            public int MyInt { get; set; } = 23;
            public string MyString { get; set; } = "this is a string";
        }


        [Test]
        public void JSON_ReadWriteTest() {
            TestHelpersNet.CatchUnexpected(() => {

                #region Data 

                IReadWriteSerializer<tstData> serializer = new JsonReadWriteSerializer<tstData>();
                IStorageManager<tstData> storage = new SimpleStorageManger<tstData>(serializer);
                string fileName1 = "MyTestFile.txt";
                string fileName2 = "secondaryFile.txt";

                storage.StorageSubDir = "MR_TestCases/Cases";
                storage.DefaultFileName = fileName1;

                string filePath1 = this.FilePath(storage, fileName1);
                string filePath2 = this.FilePath(storage, fileName2);


                #endregion

                // Make sure all are gone
                storage.DeleteAllFiles();
                Assert.False(File.Exists(filePath1), "File should not be there: {0}", filePath1);
                Assert.False(File.Exists(filePath2), "File should not be there: {0}", filePath2);

                storage.WriteObjectToDefaultFile(data);
                Assert.True(File.Exists(filePath1), "File not there: {0}", filePath1);
                tstData tmp = storage.ReadObjectFromDefaultFile();
                Assert.AreEqual(data.MyInt, tmp.MyInt);
                Assert.AreEqual(data.MyString, tmp.MyString);


                storage.WriteObjectToFile(data2, fileName2);
                Assert.True(File.Exists(filePath2), "File not there: {0}", filePath2);
                tmp = storage.ReadObjectFromFile(fileName2);
                Assert.AreEqual(data2.MyInt, tmp.MyInt);
                Assert.AreEqual(data2.MyString, tmp.MyString);

                //string secFilePath = Path.Combine(storage.StorageRootDir, storage.StorageSubDir, fileName2);
                //string secFilePath = this.FilePath(storage, fileName2);

                //storage.DeleteFile(fileName1);
                storage.DeleteDefaultFile();
                Assert.False(File.Exists(filePath1), "File should not be there: {0}", filePath1);

                storage.DeleteFile(fileName2);
                Assert.False(File.Exists(filePath2), "File should not be there: {0}", filePath2);

                storage.WriteObjectToDefaultFile(data);
                storage.WriteObjectToFile(data2, fileName2);
                Assert.True(File.Exists(filePath1), "File not there: {0}", filePath1);
                Assert.True(File.Exists(filePath2), "File not there: {0}", filePath2);


                storage.DeleteFiles("*.txt");
                Assert.False(File.Exists(filePath1), "File should not be there: {0}", filePath1);
                Assert.False(File.Exists(filePath2), "File should not be there: {0}", filePath2);



                //Assert.AreEqual("开始", msg);
            });
        }


        [Test]
        public void Encrypted_ReadWriteTest() {
            TestHelpersNet.CatchUnexpected(() => {

                #region Data 

                IReadWriteSerializer<tstData> serializer = new EncryptingDataSerializer<tstData>();
                IStorageManager<tstData> storage = new SimpleStorageManger<tstData>(serializer);
                string fileName1 = "EcryptedFile1.txt";
                storage.StorageSubDir = this.subDir;
                storage.DefaultFileName = fileName1;
                string filePath1 = this.FilePath(storage, fileName1);

                #endregion

                // Make sure all are gone
                storage.DeleteAllFiles();
                Assert.False(File.Exists(filePath1), "File should not be there: {0}", filePath1);

                storage.WriteObjectToDefaultFile(this.data);
                Assert.True(File.Exists(filePath1), "File not there: {0}", filePath1);
                tstData tmp = storage.ReadObjectFromDefaultFile();
                Assert.AreEqual(this.data.MyInt, tmp.MyInt);
                Assert.AreEqual(this.data.MyString, tmp.MyString);
            });
        }





        private string FilePath(IStorageManager<tstData> storage, string fileName) {
            return Path.Combine(storage.StorageRootDir, storage.StorageSubDir, fileName);
        }


    }
}
