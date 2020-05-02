using BluetoothLE.Net.interfaces;
using BluetoothLE.Net.Parsers.Descriptor;
using LogUtils.Net;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [Test]
        public void Err13305_DataZeroLength() {
            TestHelpersNet.CatchUnexpected(() => {
                IDescParser parser = new DescParser_PresentationFormat();
                byte[] data = new byte[0];
                parser.Parse(data);
                this.logReader.Validate(13305, "DescParser_Base", "Parse", "byte[] is zero length");
            });
        }


        [Test]
        public void Err13306_DataNull() {
            TestHelpersNet.CatchUnexpected(() => {
                IDescParser parser = new DescParser_PresentationFormat();
                parser.Parse(null);
                this.logReader.Validate(13306, "DescParser_Base", "Parse", "Raw byte[] is null");
            });
        }


        [Test]
        public void Err13315_DataTooShort() {
            TestHelpersNet.CatchUnexpected(() => {
                IDescParser parser = new DescParser_PresentationFormat();
                byte[] data = new byte[1];
                parser.Parse(data);
                this.logReader.Validate(13315, "DescParser_Base", "CopyToRawData");
            });
        }



    }
}
