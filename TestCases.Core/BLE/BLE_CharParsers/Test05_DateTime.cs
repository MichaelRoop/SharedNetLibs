using BluetoothLE.Net.Enumerations;
using BluetoothLE.Net.Parsers.Characteristics;
using BluetoothLE.Net.Parsers.Types;
using NUnit.Framework;
using TestCaseSupport.Core;
using VariousUtils.Net;

namespace TestCases.Core.BLE.BLE_CharParsers {

    [TestFixture]
    public class Test05_DateTime : TestCaseBase {

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
        public void InvalidYear() { Test(1021, 1, 1, 20, 15, 32, ((ushort)0).GetYearStr()); }
        [Test]
        public void InvalidMonth() { Test(2021, 13, 1, 20, 15, 32, "Invalid Date Time - 2021 13 1 20:15:32"); }
        [Test]
        public void InvalidDay() { Test(2021, 1, 41, 20, 15, 32, "Invalid Date Time - 2021 1 41 20:15:32"); }
        [Test]
        public void InvalidHour() { Test(2021, 1, 1, 29, 15, 32, "Invalid Date Time - 2021 1 1 29:15:32"); }
        [Test]
        public void InvalidMinutes() { Test(2021, 1, 1, 20, 75, 32, "Invalid Date Time - 2021 1 1 20:75:32"); }
        [Test]
        public void InvalidSeconds() { Test(2021, 1, 1, 20, 15, 132, "Invalid Date Time - 2021 1 1 20:15:132"); }

        [Test]
        public void InvalidFebruary() { Test(2021, 2, 31, 20, 15, 13, "Invalid Date Time - 2021 2 31 20:15:13"); }

        [Test]
          public void InsufficientBytes() {
            TestHelpers.CatchUnexpected(() => {
                TypeParserDateTime parser = new ();
                byte[] data = new byte[4];
                string result = parser.Parse(data);
                Assert.AreEqual("", result, "Parse fail");
            });
        }

        [Test]
        public void BirthDayValid() {
            TestDateOfBirth(2020, MonthOfYear.Feb, DayOfWeek.Monday);
        }

        [Test]
        public void BirthDayInValidYear() {
            TestDateOfBirth(120, MonthOfYear.Feb, DayOfWeek.Monday);
        }



        private static void Test(ushort year, byte month, byte day, byte hour, byte minutes, byte seconds) {
            DateTime dt = new (year, month, day, hour, minutes, seconds, DateTimeKind.Local);
            string expected = string.Format("{0} {1}", dt.ToLongDateString(), dt.ToLongTimeString());
            Test(year, month, day, hour, minutes, seconds, expected);
        }


        private static void Test(ushort year, byte month, byte day, byte hour, byte minutes, byte seconds, string expected) {
            TestHelpers.CatchUnexpected(() => {
                TypeParserDateTime parser = new ();
                byte[] data = new byte[parser.RequiredBytes];
                int pos = 0;
                year.WriteToBuffer(data, ref pos);
                month.WriteToBuffer(data, ref pos);
                day.WriteToBuffer(data, ref pos);
                hour.WriteToBuffer(data, ref pos);
                minutes.WriteToBuffer(data, ref pos);
                seconds.WriteToBuffer(data, ref pos);
                string result = parser.Parse(data);
                Assert.AreEqual(expected, result, "Parse fail");
            });
        }


        private static void TestDateOfBirth(ushort year, MonthOfYear month, DayOfWeek day) {
            TestHelpers.CatchUnexpected(() => {
                string expected = string.Format("{0}, {1}, {2}",
                year.GetYearStr(), MonthOfYear.Feb.GetMonthStr(),
                day.GetDayStr());

                CharParser_DateOfBirth parser = new ();
                byte[] data = new byte[parser.RequiredBytes];
                int pos = 0;
                year.WriteToBuffer(data, ref pos);
                ((byte)month).WriteToBuffer(data, ref pos);
                day.GetBleDayByte().WriteToBuffer(data, ref pos);
                string result = parser.Parse(data);
                Assert.AreEqual(expected, result, "Parse fail");
                Assert.AreEqual(year.IsYearValid() ? year : 0, parser.Year);
                Assert.AreEqual(month, parser.Month);
                Assert.AreEqual(day, parser.Day);
            });

        }


    }
}
