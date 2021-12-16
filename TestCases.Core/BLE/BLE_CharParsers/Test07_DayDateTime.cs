using BluetoothLE.Net.Parsers.Types;
using NUnit.Framework;
using TestCaseSupport.Core;
using VariousUtils.Net;

namespace TestCases.Core.BLE.BLE_CharParsers {

    [TestFixture]
    public class Test07_DayDateTime : TestCaseBase {

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
        public void ValidAll() { Test(2021, 1, 1, 20, 15, 32); }

        [Test]
        public void ValidFriday() { Test(2021, 1, 1, 20, 15, 32); }
        [Test]
        public void ValidSaturday() { Test(2021, 1, 2, 20, 15, 32); }
        [Test]
        public void ValidSunday() { Test(2021, 1, 3, 20, 15, 32); }
        [Test]
        public void ValidMonday() { Test(2021, 1, 4, 20, 15, 32); }
        [Test]
        public void ValidTuesday() { Test(2021, 1, 5, 20, 15, 32); }
        [Test]
        public void ValidWednesday() { Test(2021, 1, 6, 20, 15, 32); }
        [Test]
        public void ValidThursday() { Test(2021, 1, 7, 20, 15, 32); }




        private static void Test(ushort year, byte month, byte day, byte hour, byte minutes, byte seconds) {
            DateTime dt = new (year, month, day, hour, minutes, seconds, DateTimeKind.Local);
            string expected = string.Format("{0} {1} {2}", 
                dt.DayOfWeek.GetDayStr(), dt.ToLongDateString(), dt.ToLongTimeString());
            Test(year, month, day, hour, minutes, seconds, expected);
        }


        private static void Test(ushort year, byte month, byte day, byte hour, byte minutes, byte seconds, string expected) {
            TestHelpers.CatchUnexpected(() => {
                DateTime dt = new (year, month, day, hour, minutes, seconds, DateTimeKind.Local);
                TypeParserDayDateTime parser = new ();
                byte[] data = new byte[parser.RequiredBytes];
                int pos = 0;
                year.WriteToBuffer(data, ref pos);
                month.WriteToBuffer(data, ref pos);
                day.WriteToBuffer(data, ref pos);
                hour.WriteToBuffer(data, ref pos);
                minutes.WriteToBuffer(data, ref pos);
                seconds.WriteToBuffer(data, ref pos);
                byte bleDay = dt.DayOfWeek.GetBleDayByte(); //this.GetBleDay(dt.DayOfWeek);
                bleDay.WriteToBuffer(data, ref pos);
                string result = parser.Parse(data);
                Assert.AreEqual(expected, result, "Parse fail");
            });

        }


    }
}
