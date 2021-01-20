using BluetoothLE.Net.Parsers.Characteristics;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestCases.Core.TestToolSet;

namespace TestCases.Core.BLE_CharParsers {

    [TestFixture]
    public class Test03_CharParserAppearance : TestCaseBase {

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
        public void AppearanceParseKeyboardValue() {
            this.ParseAppearance(961, "960,1", "Parse keyboard (961) fail");
        }

        [Test]
        public void AppearanceParseHeartRateSensorValue() {
            this.ParseAppearance(833, "832,1", "Parse Heart Sensor (833) fail");
        }


        #region Private

        private void ParseAppearance(ushort value, string expected, string err) {
            TestHelpersNet.CatchUnexpected(() => {
                CharParser_Appearance b = new CharParser_Appearance();
                byte[] data = BitConverter.GetBytes((ushort)value);
                string result = b.Parse(data);
                Assert.AreEqual(expected, result, err);
            });
        }

        #endregion




    }
}
