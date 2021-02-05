using BluetoothLE.Net.Parsers.Characteristics;
using NUnit.Framework;
using TestCases.Core.TestToolSet;

namespace TestCases.Core.BLE.BLE_CharParsers {

    [TestFixture]
    public class Test04_TimeInfo : TestCaseBase {

        #region Data

        // time zone is multiplied by 4 to give the BLE 15 minute chunks
        const int TIME_ZONE_UNKNOWN_HR = -32; // -128 15 minute chunks


        const byte STANDARD_TIME = 0;
        const byte DST_05 = 2;
        const byte DST_1 = 4;
        const byte DST_2 = 8;
        const byte DST_UNKNOWN = 255;


        #endregion

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
        public void TimeZoneUnknown() { this.Test(TIME_ZONE_UNKNOWN_HR, STANDARD_TIME, "UTC[?] Standard Time"); }

        [Test]
        public void TimeZoneZero() { this.Test(0, STANDARD_TIME, "UTC[0] Standard Time"); }

        [Test]
        public void TimeZonePlus4() { this.Test(4, STANDARD_TIME, "UTC[4] Standard Time"); }

        [Test]
        public void TimeZonePlus14() { this.Test(14, STANDARD_TIME, "UTC[14] Standard Time"); }
        [Test]
        public void TimeZoneMinus12() { this.Test(-12, STANDARD_TIME, "UTC[-12] Standard Time"); }
        [Test]
        public void TimeZoneErr() { this.Test(99, STANDARD_TIME, "UTC[ERR] Standard Time"); }


        [Test]
        public void DaylightSavingsUnknown() { this.Test(4, DST_UNKNOWN, "UTC[4] Daylight savings (Unknown)"); }

        [Test]
        public void StandardTime() { this.Test(4, STANDARD_TIME, "UTC[4] Standard Time"); }

        [Test]
        public void DaylightSavings05() { this.Test(4, DST_05, "UTC[4] Daylight savings (+0.5h)"); }
        [Test]
        public void DaylightSavings1() { this.Test(4, DST_1, "UTC[4] Daylight savings (+1h)"); }
        [Test]
        public void DaylightSavings2() { this.Test(4, DST_2, "UTC[4] Daylight savings (+2h)"); }
        [Test]
        public void DaylightSavingsErr() { this.Test(4, 16, "UTC[4] Daylight savings (ERR)"); }





        private void Test(int zone, byte st, string expected) {
            TestHelpersNet.CatchUnexpected(() => {
                byte[] data = new byte[2];
                data[0] = (byte)(zone * 4);
                data[1] = st;
                CharParser_LocalTimeInformation parser = new CharParser_LocalTimeInformation();
                string result = parser.Parse(data);
                Assert.AreEqual(expected, result, "Parse fail");
            });

        }


    }
}
