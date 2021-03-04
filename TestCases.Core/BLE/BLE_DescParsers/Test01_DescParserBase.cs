using BluetoothLE.Net.interfaces;
using BluetoothLE.Net.Parsers.Descriptor;
using LogUtils.Net;
using NUnit.Framework;
using System;
using TestCaseSupport.Core;

namespace TestCases.Core.BLE.BLE_DescParsers {

    [TestFixture]
    public class Test01_DescParserBase : TestCaseBase {

        ClassLog log = new ClassLog("DescParserBaseTests");

        #region Setup

        [OneTimeSetUp]
        public void TestSetSetup() {
            this.OneTimeSetup();
        }

        [OneTimeTearDown]
        public void TestSetTeardown() {
            this.OneTimeTeardown();
        }

        [SetUp]
        public void SetupEachTest() {
        }

        #endregion

        #region Bogus Test Classes To Provoke exceptions

        public class BlowOnSetMembers : DescParser_Base {
            protected override void DoParse(byte[] data) { }
            protected override void ResetMembers() {
                throw new NotImplementedException();
            }
        }

        public class BlowOnDoParse : DescParser_Base {
            protected override void DoParse(byte[] data) { throw new NotImplementedException(); }
            protected override void ResetMembers() {
                base.ResetMembers();
            }
        }



        #endregion


        //BlowOnDoParse

        [Test]
        public void DerivedTypeTest() {
            TestHelpers.CatchUnexpected(() => {
                IDescParser p = new BlowOnDoParse();
                //Assert.AreEqual(typeof(BlowOnDoParse).Name, p.ImplementationType.Name, "ImplementationType");

                // p.GetType() returns <TestCases.BLE_DescParsers.Test01_DescParserBase+BlowOnDoParse>
                //Assert.AreEqual(typeof(BlowOnDoParse).Name, p.GetType(), "GetType");
                // Works
                Assert.True(p is BlowOnDoParse, "p is BlowOnDoParse");

            });


        }



        [Test]
        public void Err13618_DataZeroLength() {
            TestHelpers.CatchUnexpected(() => {
                IDescParser parser = new DescParser_PresentationFormat();
                byte[] data = new byte[0];
                parser.Parse(data);
                this.logReader.Validate(13618, "BLEParserBase", "CopyToRawData", "byte[] is zero length");
            });
        }


        [Test]
        public void Err13616_DataNull() {
            TestHelpers.CatchUnexpected(() => {
                IDescParser parser = new DescParser_PresentationFormat();
                parser.Parse(null);
                this.logReader.Validate(13616, "BLEParserBase", "CopyToRawData", "Raw byte[] is null");
            });
        }


        [Test]
        public void Err13607_ExceptionOnDoParse() {
            TestHelpers.CatchUnexpected(() => {
                try {
                    IDescParser parser = new BlowOnDoParse();
                    parser.Parse(new byte[12]);
                }
                catch { }
                this.logReader.Validate(13607, "BLEParserBase", "Parse",
                    "Failure on Parse");
            });
        }


        [Test]
        public void Err13615_DataTooShort() {
            TestHelpers.CatchUnexpected(() => {
                IDescParser parser = new DescParser_PresentationFormat();
                byte[] data = new byte[1];
                parser.Parse(data);
                this.logReader.Validate(13615, 
                    "BLEParserBase", 
                    "CopyToRawData",
                    "Data length:1 smaller than requested:7 Data '0x00'");
            });
        }


        [Test]
        public void Err13325_ExceptionOnConstruction() {
            TestHelpers.CatchUnexpected(() => {
                try {
                    IDescParser parser = new BlowOnSetMembers();
                }
                catch { }
                this.logReader.Validate(13325, "BLEParserBase", ".ctor", "Failed on construction");
            });
        }

    }
}
