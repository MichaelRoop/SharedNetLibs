﻿using LogUtils.Net;
using NUnit.Framework;
using StorageFactory.Net.interfaces;
using StorageFactory.Net.Serializers;
using StorageFactory.Net.StorageManagers;
using TestCaseSupport.Core;

namespace TestCases.StorageTests {


    [TestFixture]
    public class StorageTestCases : TestCaseBase {
#pragma warning disable CA1822 // Mark members as static

        #region Setup

#pragma warning disable CS8618
        private TstData data;
        private TstData data2;
#pragma warning restore CS8618

        private readonly string subDir = "MR_TestCases/Cases";
        private readonly ClassLog log = new ("StorageTestCases");

        [OneTimeSetUp]
        public void TestSetSetup() {
            this.OneTimeSetup();

            //this.data = new tstData() {
            //    MyInt = 98214,
            //    MyString = "blah blah woof woof and then some",
            //};

            this.data = new TstData("Blah");


            this.data2 = new TstData() {
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
                this.MyPrivateInt = 34;
                this.MyString = str;
                this.MyPrivateString = Guid.NewGuid().ToString();
            }

        }


        [Test]
        public void JSON_ReadWriteTest() {
            TestHelpers.CatchUnexpected(() => {

                #region Data 

                JsonReadWriteSerializer<TstData> serializer = new ();
                IStorageManager<TstData> storage = new SimpleStorageManger<TstData>(serializer);
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
                TstData tmp = storage.ReadObjectFromDefaultFile();
                Assert.AreEqual(data.MyInt, tmp.MyInt);
                Assert.AreEqual(data.MyString, tmp.MyString);

                Assert.AreEqual(data.MyPrivateInt, tmp.MyPrivateInt);
                Assert.AreEqual(data.MyPrivateString, tmp.MyPrivateString);


                storage.WriteObjectToFile(data2, fileName2);
                Assert.True(File.Exists(filePath2), "File not there: {0}", filePath2);
                tmp = storage.ReadObjectFromFile(fileName2);
                Assert.AreEqual(data2.MyInt, tmp.MyInt);
                Assert.AreEqual(data2.MyString, tmp.MyString);

                Assert.AreEqual(data2.MyPrivateInt, tmp.MyPrivateInt);
                Assert.AreEqual(data2.MyPrivateString, tmp.MyPrivateString);


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
            TestHelpers.CatchUnexpected(() => {

                #region Data 

                JsonReadWriteSerializer<TstData> serializer = new JsonReadWriteSerializerIndented<TstData>();
                IStorageManager<TstData> storage = new SimpleStorageManger<TstData>(serializer);
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
                TstData tmp = storage.ReadObjectFromDefaultFile();
                Assert.AreEqual(data.MyInt, tmp.MyInt);
                Assert.AreEqual(data.MyString, tmp.MyString);
                Assert.AreEqual(data.MyPrivateInt, tmp.MyPrivateInt);



                storage.WriteObjectToFile(data2, fileName2);
                Assert.True(File.Exists(filePath2), "File not there: {0}", filePath2);
                tmp = storage.ReadObjectFromFile(fileName2);
                Assert.AreEqual(data2.MyInt, tmp.MyInt);
                Assert.AreEqual(data2.MyString, tmp.MyString);
                Assert.AreEqual(data2.MyPrivateInt, tmp.MyPrivateInt);

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

            JsonReadWriteSerializer<TstData> serializer = new ();
            IStorageManager<TstData> storage = new SimpleStorageManger<TstData>(serializer);
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

            JsonReadWriteSerializer<TstData> serializer = new ();
            IStorageManager<TstData> storage = new SimpleStorageManger<TstData>(serializer);
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
            TestHelpers.CatchUnexpected(() => {

                #region Data 

                IReadWriteSerializer<TstData> serializer = new EncryptingReadWriteSerializer<TstData>();
                IStorageManager<TstData> storage = new SimpleStorageManger<TstData>(serializer);
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
                TstData tmp = storage.ReadObjectFromDefaultFile();
                Assert.AreEqual(this.data.MyInt, tmp.MyInt);
                Assert.AreEqual(this.data.MyString, tmp.MyString);
            });
        }


        [Test]
        public void GetFileListTest() {
            TestHelpers.CatchUnexpected(() => {

                #region Data 

                IReadWriteSerializer<TstData> serializer = new JsonReadWriteSerializer<TstData>();
                IStorageManager<TstData> storage = new SimpleStorageManger<TstData>(serializer);
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
            TestHelpers.CatchUnexpected(() => {

                #region Data 

                IReadWriteSerializer<TstData> serializer = new XmlReadWriteSerializer<TstData>();
                IStorageManager<TstData> storage = new SimpleStorageManger<TstData>(serializer);
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
                TstData tmp = storage.ReadObjectFromDefaultFile();
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
            TestHelpers.CatchUnexpected(() => {

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

                MemoryStream memStream = new ((int)buff.Length);
                memStream.Write(buff, 0, buff.Length);

                // Make sure all are gone
                storage.DeleteAllFiles();
                storage.WriteObjectToDefaultFile(memStream);
                Assert.True(File.Exists(filePath1), "File not there: {0}", filePath1);
                MemoryStream readStream = storage.ReadObjectFromDefaultFile();
                Assert.AreEqual(memStream.GetBuffer(), readStream.GetBuffer());


                byte[] buff2 = new byte[] { 0, 1, 2, 3, 4, 5 };
                MemoryStream memStream2 = new ((int)buff2.Length);
                memStream2.Write(buff2, 0, buff2.Length);
                storage.WriteObjectToFile(memStream2, fileName2);
                Assert.True(File.Exists(filePath2), "File not there: {0}", filePath2);
                readStream.Dispose();
                readStream = storage.ReadObjectFromFile(fileName2);
                Assert.AreEqual(memStream2.GetBuffer(), readStream.GetBuffer());


            });
        }



        private string FilePath(IStorageManager<TstData> storage, string fileName) {
            return Path.Combine(storage.StorageRootDir, storage.StorageSubDir, fileName);
        }

#pragma warning restore CA1822 // Mark members as static

    }
}
