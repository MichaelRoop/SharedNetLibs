using LogUtils;
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
    public class StorageTestCases : TestCaseBase {

        #region Setup

        private tstData data = null;
        private tstData data2 = null;
        private string subDir = "MR_TestCases/Cases";
        private ClassLog log = new ClassLog("StorageTestCases");

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

                JsonReadWriteSerializer<tstData> serializer = new JsonReadWriteSerializer<tstData>();
                IStorageManager<tstData> storage = new SimpleStorageManger<tstData>(serializer);
                string fileName1 = "MyTestJsonFile.txt";
                string fileName2 = "secondaryJsonFile.txt";

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


                //storage.DeleteFiles("*.txt");
                //Assert.False(File.Exists(filePath1), "File should not be there: {0}", filePath1);
                //Assert.False(File.Exists(filePath2), "File should not be there: {0}", filePath2);



                //Assert.AreEqual("开始", msg);
            });
        }


        [Test]
        public void JSON_ReadWriteTestFormatted() {
            TestHelpersNet.CatchUnexpected(() => {

                #region Data 

                JsonReadWriteSerializer<tstData> serializer = new JsonReadWriteSerializerIndented<tstData>();
                IStorageManager<tstData> storage = new SimpleStorageManger<tstData>(serializer);
                string fileName1 = "MyTestJsonFileIndented.txt";
                string fileName2 = "secondaryJsonFileIndented.txt";

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

                storage.DeleteDefaultFile();
                Assert.False(File.Exists(filePath1), "File should not be there: {0}", filePath1);

                storage.DeleteFile(fileName2);
                Assert.False(File.Exists(filePath2), "File should not be there: {0}", filePath2);

                storage.WriteObjectToDefaultFile(data);
                storage.WriteObjectToFile(data2, fileName2);
                Assert.True(File.Exists(filePath1), "File not there: {0}", filePath1);
                Assert.True(File.Exists(filePath2), "File not there: {0}", filePath2);
            });
        }


        [Test]
        public void DeleteAllFilesPattern() {
            #region Data 

            JsonReadWriteSerializer<tstData> serializer = new JsonReadWriteSerializer<tstData>();
            IStorageManager<tstData> storage = new SimpleStorageManger<tstData>(serializer);
            string fileName1 = "MyTestJsonFile.txt";
            string fileName2 = "secondaryJsonFile.txt";
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
            storage.WriteObjectToFile(data2, fileName2);
            Assert.True(File.Exists(filePath2), "File not there: {0}", filePath2);

            storage.DeleteFiles("*.txt");
            Assert.False(File.Exists(filePath1), "File should not be there: {0}", filePath1);
            Assert.False(File.Exists(filePath2), "File should not be there: {0}", filePath2);
        }

        [Test]
        public void DeleteAllFiles() {
            #region Data 

            JsonReadWriteSerializer<tstData> serializer = new JsonReadWriteSerializer<tstData>();
            IStorageManager<tstData> storage = new SimpleStorageManger<tstData>(serializer);
            string fileName1 = "MyTestJsonFile.txt";
            string fileName2 = "secondaryJsonFile.txt";
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
            storage.WriteObjectToFile(data2, fileName2);
            Assert.True(File.Exists(filePath2), "File not there: {0}", filePath2);

            storage.DeleteAllFiles();
            Assert.False(File.Exists(filePath1), "File should not be there: {0}", filePath1);
            Assert.False(File.Exists(filePath2), "File should not be there: {0}", filePath2);
        }



        [Test]
        public void Encrypted_ReadWriteTest() {
            TestHelpersNet.CatchUnexpected(() => {

                #region Data 

                IReadWriteSerializer<tstData> serializer = new EncryptingReadWriteSerializer<tstData>();
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


        [Test]
        public void GetFileListTest() {
            TestHelpersNet.CatchUnexpected(() => {

                #region Data 

                IReadWriteSerializer<tstData> serializer = new JsonReadWriteSerializer<tstData>();
                IStorageManager<tstData> storage = new SimpleStorageManger<tstData>(serializer);
                string fileName1 = "JsonFile1.txt";
                string fileName2 = "JsonFile2.txt";

                storage.StorageSubDir = this.subDir;
                storage.DefaultFileName = fileName1;

                #endregion

                // Make sure all are gone and create 2 files
                storage.DeleteAllFiles();
                storage.WriteObjectToDefaultFile(data);
                storage.WriteObjectToFile(data2, fileName2);

                List<string> files = storage.GetFileList();
                files.Sort();
                Assert.AreEqual(2, files.Count);
                foreach(string name in files) {
                    this.log.Info("GetFileListTest", () => string.Format("File name: {0}", name));
                }
                Assert.AreEqual(fileName1, files[0]);
                Assert.AreEqual(fileName2, files[1]);

                files = storage.GetFileList(true);
                foreach (string name in files) {
                    this.log.Info("GetFileListTest", () => string.Format("File name: {0}", name));
                }


            });
        }


        [Test]
        public void XML_ReadWriteTest() {
            TestHelpersNet.CatchUnexpected(() => {

                #region Data 

                IReadWriteSerializer<tstData> serializer = new XmlReadWriteSerializer<tstData>();
                IStorageManager<tstData> storage = new SimpleStorageManger<tstData>(serializer);
                string fileName1 = "MyTestFileXML.txt";
                string fileName2 = "secondaryXMLFile.txt";

                storage.StorageSubDir = "MR_TestCases/Cases";
                storage.DefaultFileName = fileName1;

                string filePath1 = this.FilePath(storage, fileName1);
                string filePath2 = this.FilePath(storage, fileName2);

                #endregion

                // Make sure all are gone
                storage.DeleteAllFiles();
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
            });
        }


        [Test]
        public void MemoryStream_ReadWriteTest() {
            TestHelpersNet.CatchUnexpected(() => {

                #region Data 

                IReadWriteSerializer<MemoryStream> serializer = new MemoryStreamReadWriteSerializer();
                IStorageManager<MemoryStream> storage = new SimpleStorageManger<MemoryStream>(serializer);
                string fileName1 = "MyTestFileMemoryManager.txt";
                string fileName2 = "secondaryMemoryManager.txt";
                storage.StorageSubDir = "MR_TestCases/Cases";
                storage.DefaultFileName = fileName1;
                string filePath1 = Path.Combine(storage.StorageRootDir, storage.StorageSubDir, fileName1);
                string filePath2 = Path.Combine(storage.StorageRootDir, storage.StorageSubDir, fileName2);


                #endregion

                //byte[] buff = new byte[] { 0, 1, 2, 3, 4, 5 };
                double[] dBuff = new double[] { 32.445, 12121213443.44234234, 33.45, 1.3465, 234234.45345345435};
                byte[] buff = dBuff.SelectMany(x => BitConverter.GetBytes(x)).ToArray();

                MemoryStream memStream = new MemoryStream((int)buff.Length);
                memStream.Write(buff, 0, buff.Count());

                // Make sure all are gone
                storage.DeleteAllFiles();
                storage.WriteObjectToDefaultFile(memStream);
                Assert.True(File.Exists(filePath1), "File not there: {0}", filePath1);
                MemoryStream readStream = storage.ReadObjectFromDefaultFile();
                Assert.AreEqual(memStream.GetBuffer(), readStream.GetBuffer());


                byte[] buff2 = new byte[] { 0, 1, 2, 3, 4, 5 };
                MemoryStream memStream2 = new MemoryStream((int)buff2.Length);
                memStream2.Write(buff2, 0, buff2.Count());
                storage.WriteObjectToFile(memStream2, fileName2);
                Assert.True(File.Exists(filePath2), "File not there: {0}", filePath2);
                readStream.Dispose();
                readStream = storage.ReadObjectFromFile(fileName2);
                Assert.AreEqual(memStream2.GetBuffer(), readStream.GetBuffer());


            });
        }



        private string FilePath(IStorageManager<tstData> storage, string fileName) {
            return Path.Combine(storage.StorageRootDir, storage.StorageSubDir, fileName);
        }


    }
}
