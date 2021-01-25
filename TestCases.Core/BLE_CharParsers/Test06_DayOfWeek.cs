using BluetoothLE.Net.Parsers.Types;
using NUnit.Framework;
using System;
using System.Globalization;
using TestCases.Core.TestToolSet;

namespace TestCases.Core.BLE_CharParsers {

    [TestFixture]
    public class Test06_DayOfWeek : TestCaseBase {

        #region Data

        // BLE reports Monday as first day of the week
        const byte BLE_UNKNOWN = 0;
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
        public void Sunday() { this.Test(BLE_SUN, 1); }
        [Test]
        public void Monday() { this.Test(BLE_MON, 2); }
        [Test]
        public void Tuesday() { this.Test(BLE_TUE, 3); }
        [Test]
        public void Wednesday() { this.Test(BLE_WED, 4); }
        [Test]
        public void Thursday() { this.Test(BLE_THUR, 5); }
        [Test]
        public void Friday() { this.Test(BLE_FRI, 6); }
        [Test]
        public void Saturday() { this.Test(BLE_SAT, 7); }





        private void Test(byte bleDay, int day) {
            TestHelpersNet.CatchUnexpected(() => {
                TypeParserDayOfWeek parser = new TypeParserDayOfWeek();
                byte[] data = new byte[parser.RequiredBytes];
                data[0] = bleDay;
                string result = parser.Parse(data);
                Assert.AreEqual(this.GetDay(day - 1), result, "Parse fail");
            });
        }


        private string GetDay(int day) {
            return DateTimeFormatInfo.CurrentInfo.GetDayName((DayOfWeek)day);
        }






    }
}
