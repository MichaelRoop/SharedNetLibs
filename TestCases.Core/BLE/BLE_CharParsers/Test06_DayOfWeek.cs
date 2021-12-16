using BluetoothLE.Net.Parsers.Types;
using NUnit.Framework;
using System.Globalization;
using TestCaseSupport.Core;

namespace TestCases.Core.BLE.BLE_CharParsers {

    [TestFixture]
    public class Test06_DayOfWeek : TestCaseBase {

        #region Data

        // BLE reports Monday as first day of the week
        //const byte BLE_UNKNOWN = 0;
        const byte BLE_MON = 1;
        const byte BLE_TUE = 2;
        const byte BLE_WED = 3;
        const byte BLE_THUR = 4;
        const byte BLE_FRI = 5;
        const byte BLE_SAT = 6;
        const byte BLE_SUN = 7;

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
        public void Sunday() { Test(BLE_SUN, 1); }
        [Test]
        public void Monday() { Test(BLE_MON, 2); }
        [Test]
        public void Tuesday() { Test(BLE_TUE, 3); }
        [Test]
        public void Wednesday() { Test(BLE_WED, 4); }
        [Test]
        public void Thursday() { Test(BLE_THUR, 5); }
        [Test]
        public void Friday() { Test(BLE_FRI, 6); }
        [Test]
        public void Saturday() { Test(BLE_SAT, 7); }





        private static void Test(byte bleDay, int day) {
            TestHelpers.CatchUnexpected(() => {
                TypeParserDayOfWeek parser = new ();
                byte[] data = new byte[parser.RequiredBytes];
                data[0] = bleDay;
                string result = parser.Parse(data);
                Assert.AreEqual(GetDay(day - 1), result, "Parse fail");
            });
        }


        private static string GetDay(int day) {
            return DateTimeFormatInfo.CurrentInfo.GetDayName((DayOfWeek)day);
        }






    }
}
