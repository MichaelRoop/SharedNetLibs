using BluetoothLE.Net.Parsers.Characteristics;
using LogUtils.Net;
using NUnit.Framework;
using System.Globalization;
using TestCaseSupport.Core;
using VariousUtils.Net;

namespace TestCases.Core.BLE.BLE_CharParsers {

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

        //private readonly ClassLog log = new ("Test11_IOTSensors");

        #endregion
        #region Test cases

        [Test]
        public void Temperature_3930() {
            // Each value is .01 degrees celcius
            // 3930 * 0.01 == 39.30 Celcius
            TestTemperature(3930, 39.30, GetValueFromZeroPointZeroOneUnits(3930));
            TestTemperature(3, 0.03, GetValueFromZeroPointZeroOneUnits(3));
            TestTemperature(0, 0.00, GetValueFromZeroPointZeroOneUnits(0));
        }

        [Test]
        public void Temperature_Minus2231() {
            TestTemperature(-2231, -22.31, GetValueFromZeroPointZeroOneUnits(-2231));
        }


        [Test]
        public void Humidity_3801() {
            TestHumidity(3801, 38.01, GetValueFromZeroPointZeroOneUnits(3801)+"%");
        }


        [Test]
        public void Pressure_111101() {
            TestPressure(111101, 11110.1, GetValueFromZeroPointOneUnits(111101));
        }



        #endregion
        #region Helpers
        public static void TestTemperature(short value, double expectedValue, string expected) {
            TestHelpers.CatchUnexpected(() => {
                CharParser_Temperature parser = new ();
                byte[] data = new byte[sizeof(short)];
                int pos = 0;
                value.WriteToBuffer(data, ref pos);
                string result = parser.Parse(data);
                LogUtils.Net.Log.Info("TestIOTSensors", "TestTemperature", result);
                Assert.AreEqual(expected, result, "Parse fail");
                Assert.AreEqual(expectedValue, parser.Value, "Double value");
            });
        }

        public static void TestHumidity(ushort value, double expectedValue, string expected) {
            TestHelpers.CatchUnexpected(() => {
                CharParser_Humidity parser = new ();
                byte[] data = new byte[sizeof(short)];
                int pos = 0;
                value.WriteToBuffer(data, ref pos);
                string result = parser.Parse(data);
                LogUtils.Net.Log.Info("TestIOTSensors", "TestHumidity", result);
                Assert.AreEqual(expected, result, "Parse fail");
                Assert.AreEqual(expectedValue, parser.Value, "Double value");
            });
        }

        public static void TestPressure(uint value, double expectedValue, string expected) {
            TestHelpers.CatchUnexpected(() => {
                CharParser_Pressure parser = new ();
                byte[] data = new byte[sizeof(uint)];
                int pos = 0;
                value.WriteToBuffer(data, ref pos);
                string result = parser.Parse(data);
                LogUtils.Net.Log.Info("TestIOTSensors", "TestPressure", result);
                Assert.AreEqual(expected, result, "Parse fail");
                Assert.AreEqual(expectedValue, parser.Value, "Double value");
            });
        }



        private static string GetValueFromZeroPointZeroOneUnits(short value) {
            return ((double)(value * 0.01)).ToString("#######0.00", CultureInfo.CurrentCulture);
        }


        private static string GetValueFromZeroPointOneUnits(uint value) {
            return ((double)(value * 0.1)).ToString("#######0.0", CultureInfo.CurrentCulture);
        }


        #endregion

    }

}
