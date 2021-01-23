using BluetoothLE.Net.Parsers.Characteristics;
using LogUtils.Net;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TestCases.Core.TestToolSet;
using VariousUtils.Net;

namespace TestCases.Core.BLE_CharParsers {

    [TestFixture]
    public class Test11_IOTSensors : TestCaseBase {
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
        #region Data

        ClassLog log = new ClassLog("Test11_IOTSensors");

        #endregion
        #region Test cases

        [Test]
        public void Temperature_3930() {
            // Each value is .01 degrees celcius
            // 3930 * 0.01 == 39.30 Celcius
            this.TestTemperature(3930, this.GetCelciusExpectedReturn(3930));
        }

        [Test]
        public void Temperature_Minus2231() {
            this.TestTemperature(-2231, this.GetCelciusExpectedReturn(-2231));
        }


        #endregion
        #region Helpers
        public void TestTemperature(short value, string expected) {
            TestHelpersNet.CatchUnexpected(() => {
                CharParser_Temperature parser = new CharParser_Temperature();
                byte[] data = new byte[sizeof(short)];
                int pos = 0;
                value.WriteToBuffer(data, ref pos);
                string result = parser.Parse(data);
                LogUtils.Net.Log.Info("TestTemperature", "Test", result);
                Assert.AreEqual(expected, result, "Parse fail");
            });



        }


        private string GetCelciusExpectedReturn(short value) {
            return ((double)(value * 0.01)).ToString("#######0.00", CultureInfo.CurrentCulture);
        }



        #endregion

    }

}
