﻿using BluetoothLE.Net.Parsers.Characteristics;
using NUnit.Framework;
using System.Text;
using TestCaseSupport.Core;

namespace TestCases.Core.BLE.BLE_CharParsers {

    [TestFixture]
    public class Test02_CharParsersMisc : TestCaseBase {

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
        public void BatteryParseValue() {
            TestHelpers.CatchUnexpected(() => {
                byte[] data = new byte[1];
                data[0] = 89;
                CharParser_BatteryLevel b = new ();
                string result = b.Parse(data);
                Assert.AreEqual("89", result, "Parse fail");
            });
        }


        [Test]
        public void PPnPICParseValue() {
            TestHelpers.CatchUnexpected(() => {
                byte[] data = new byte[] { 0x02, 0x5E, 0x04, 0x17, 0x08, 0x31, 0x01 };
                CharParser_PPnPID b = new ();
                string result = b.Parse(data);
                string expected = "Vendor ID:2, Vendor Namespace:1118, Manufacturer ID:2071, Manufacturer Namespace:305";
                Assert.AreEqual(expected, result, "Parse fail");
            });
        }


        [Test]
        public void StringParseValue() {
            TestHelpers.CatchUnexpected(() => {
                string value = "Blah blah woof woof";
                byte[] data = Encoding.UTF8.GetBytes(value);
                CharParser_String b = new ();
                string result = b.Parse(data);
                Assert.AreEqual(value, result, "Parse fail");
            });
        }




    }
}
