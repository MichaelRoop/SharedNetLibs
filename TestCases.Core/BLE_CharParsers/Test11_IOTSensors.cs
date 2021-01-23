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
            this.TestTemperature(3930, this.GetValueFromZeroPointZeroOneUnits(3930));
        }

        [Test]
        public void Temperature_Minus2231() {
            this.TestTemperature(-2231, this.GetValueFromZeroPointZeroOneUnits(-2231));
        }


        [Test]
        public void Humidity_3801() {
            this.TestHumidity(3801, this.GetValueFromZeroPointZeroOneUnits(3801)+"%");
        }


        [Test]
        public void Pressure_111101() {
            this.TestPressure(111101, this.GetValueFromZeroPointOneUnits(111101));
        }



        #endregion
        #region Helpers
        public void TestTemperature(short value, string expected) {
            TestHelpersNet.CatchUnexpected(() => {
                CharParser_TemperatureCelcius parser = new CharParser_TemperatureCelcius();
                byte[] data = new byte[sizeof(short)];
                int pos = 0;
                value.WriteToBuffer(data, ref pos);
                string result = parser.Parse(data);
                LogUtils.Net.Log.Info("TestIOTSensors", "TestTemperature", result);
                Assert.AreEqual(expected, result, "Parse fail");
            });
        }

        public void TestHumidity(ushort value, string expected) {
            TestHelpersNet.CatchUnexpected(() => {
                CharParser_Humidity parser = new CharParser_Humidity();
                byte[] data = new byte[sizeof(short)];
                int pos = 0;
                value.WriteToBuffer(data, ref pos);
                string result = parser.Parse(data);
                LogUtils.Net.Log.Info("TestIOTSensors", "TestHumidity", result);
                Assert.AreEqual(expected, result, "Parse fail");
            });
        }

        public void TestPressure(uint value, string expected) {
            TestHelpersNet.CatchUnexpected(() => {
                CharParser_Pressure parser = new CharParser_Pressure();
                byte[] data = new byte[sizeof(uint)];
                int pos = 0;
                value.WriteToBuffer(data, ref pos);
                string result = parser.Parse(data);
                LogUtils.Net.Log.Info("TestIOTSensors", "TestPressure", result);
                Assert.AreEqual(expected, result, "Parse fail");
            });
        }



        private string GetValueFromZeroPointZeroOneUnits(short value) {
            return ((double)(value * 0.01)).ToString("#######0.00", CultureInfo.CurrentCulture);
        }


        private string GetValueFromZeroPointOneUnits(uint value) {
            return ((double)(value * 0.1)).ToString("#######0.0", CultureInfo.CurrentCulture);
        }


        #endregion

    }

}
