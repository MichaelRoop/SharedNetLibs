using BluetoothLE.Net.Parsers.Characteristics;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestCases.Core.TestToolSet;
using VariousUtils.Net;

namespace TestCases.Core.BLE_CharParsers {

    [TestFixture]
    public class Test10_Alerts : TestCaseBase {

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
        public void OneByteAllFirstByteOff() {
            byte[] data = new byte[1];
            data.SetMaskAllOff(0);
            string expected = "Simple Alert:Not supported, Email:Not supported, " +
                "News:Not supported, Incoming Call:Not supported, " +
                "Missed Call:Not supported, SMS/MMS arrives:Not supported, " +
                "Voice Mail:Not supported, Schedule:Not supported, " +
                "High Prioritized Alert:Not supported, Instant Message:Not supported";
            this.Test(data, expected);
        }



        [Test]
        public void OneByteAllOn() {
            byte[] data = new byte[1];
            data.SetMaskAllOn(0);
            string expected = "Simple Alert:Supported, Email:Supported, " +
                "News:Supported, Incoming Call:Supported, " +
                "Missed Call:Supported, SMS/MMS arrives:Supported, " +
                "Voice Mail:Supported, Schedule:Supported, " +
                "High Prioritized Alert:Not supported, Instant Message:Not supported";
            this.Test(data, expected);
        }

        [Test]
        public void TwoByteAllOn() {
            byte[] data = new byte[2];
            data.SetMaskAllOn(0);
            data.SetMaskAllOn(1);
            string expected = "Simple Alert:Supported, Email:Supported, " +
                "News:Supported, Incoming Call:Supported, " +
                "Missed Call:Supported, SMS/MMS arrives:Supported, " +
                "Voice Mail:Supported, Schedule:Supported, " +
                "High Prioritized Alert:Supported, Instant Message:Supported";
            this.Test(data, expected);
        }


        [Test]
        public void TwoByteSomeOff() {
            byte[] data = new byte[2];
            data.SetMaskAllOn(0);
            data.SetMaskAllOn(1);
            data[0] = BitTools.SetBit(data[0], 1, false);
            data[0] = BitTools.SetBit(data[0], 3, false);
            data[1] = BitTools.SetBit(data[1], 0, false);


            string expected = "Simple Alert:Supported, Email:Not supported, " +
                "News:Supported, Incoming Call:Not supported, " +
                "Missed Call:Supported, SMS/MMS arrives:Supported, " +
                "Voice Mail:Supported, Schedule:Supported, " +
                "High Prioritized Alert:Not supported, Instant Message:Supported";
            this.Test(data, expected);
        }



        private void Test(byte[] data, string expected) {
            TestHelpersNet.CatchUnexpected(() => {
                CharParser_AlertCategoryIDBitmask parser = new CharParser_AlertCategoryIDBitmask();
                string result = parser.Parse(data);
                LogUtils.Net.Log.Info("Test10_Alerts", "Test", result);
                Assert.AreEqual(expected, result, "Parse fail");
            });
        }


    }
}
