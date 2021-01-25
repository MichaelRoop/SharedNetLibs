using BluetoothLE.Net.interfaces;
using BluetoothLE.Net.Parsers.Descriptor;
using LogUtils.Net;
using NUnit.Framework;
using System;
using TestCases.Core.TestToolSet;

namespace TestCases.BLE_DescParsers {

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
            protected override Type GetDerivedType() { throw new NotImplementedException(); }
            protected override void ResetMembers() {
                throw new NotImplementedException();
            }
        }

        public class BlowOnDoParse : DescParser_Base {
            protected override void DoParse(byte[] data) { throw new NotImplementedException(); }
            protected override Type GetDerivedType() { return this.GetType(); }
            protected override void ResetMembers() { }
        }



        #endregion

        [Test]
        public void Err13305_DataZeroLength() {
            TestHelpersNet.CatchUnexpected(() => {
                IDescParser parser = new DescParser_PresentationFormat();
                byte[] data = new byte[0];
                parser.Parse(data);
                this.logReader.Validate(13305, "DescParser_Base", "CopyToRawData", "byte[] is zero length");
            });
        }


        [Test]
        public void Err13306_DataNull() {
            TestHelpersNet.CatchUnexpected(() => {
                IDescParser parser = new DescParser_PresentationFormat();
                parser.Parse(null);
                this.logReader.Validate(13316, "DescParser_Base", "CopyToRawData", "Raw byte[] is null");
            });
        }


        [Test]
        public void Err13307_ExceptionOnDoParse() {
            TestHelpersNet.CatchUnexpected(() => {
                try {
                    IDescParser parser = new BlowOnDoParse();
                    parser.Parse(new byte[12]);
                }
                catch { }
                this.logReader.Validate(13307, "DescParser_Base", "Parse",
                    "Failure on Parse");
            });
        }


        [Test]
        public void Err13315_DataTooShort() {
            TestHelpersNet.CatchUnexpected(() => {
                IDescParser parser = new DescParser_PresentationFormat();
                byte[] data = new byte[1];
                parser.Parse(data);
                this.logReader.Validate(13315, 
                    "DescParser_Base", 
                    "CopyToRawData",
                    "Data length:1 smaller than requested:7 Data '0x00'");
            });
        }


        [Test]
        public void Err13325_ExceptionOnConstruction() {
            TestHelpersNet.CatchUnexpected(() => {
                try {
                    IDescParser parser = new BlowOnSetMembers();
                }
                catch { }
                this.logReader.Validate(13325, "DescParser_Base", ".ctor", "Failed on construction");
            });
        }

    }
}
