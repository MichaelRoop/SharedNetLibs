using BluetoothLE.Net.Enumerations;
using BluetoothLE.Net.Parsers.Characteristics;
using BluetoothLE.Net.Parsers.Types;
using NUnit.Framework;
using System;
using TestCases.Core.TestToolSet;
using VariousUtils.Net;

namespace TestCases.Core.BLE_CharParsers {

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
        public void ValidAll() { this.Test(2021, 1, 1, 20, 15, 32); }

        [Test]
        public void InvalidYear() { this.Test(1021, 1, 1, 20, 15, 32, ((ushort)0).GetYearStr()); }
        [Test]
        public void InvalidMonth() { this.Test(2021, 13, 1, 20, 15, 32, "Invalid Date Time - 2021 13 1 20:15:32"); }
        [Test]
        public void InvalidDay() { this.Test(2021, 1, 41, 20, 15, 32, "Invalid Date Time - 2021 1 41 20:15:32"); }
        [Test]
        public void InvalidHour() { this.Test(2021, 1, 1, 29, 15, 32, "Invalid Date Time - 2021 1 1 29:15:32"); }
        [Test]
        public void InvalidMinutes() { this.Test(2021, 1, 1, 20, 75, 32, "Invalid Date Time - 2021 1 1 20:75:32"); }
        [Test]
        public void InvalidSeconds() { this.Test(2021, 1, 1, 20, 15, 132, "Invalid Date Time - 2021 1 1 20:15:132"); }

        [Test]
        public void InvalidFebruary() { this.Test(2021, 2, 31, 20, 15, 13, "Invalid Date Time - 2021 2 31 20:15:13"); }

        [Test]
          public void InsufficientBytes() {
            TestHelpersNet.CatchUnexpected(() => {
                TypeParserDateTime parser = new TypeParserDateTime();
                byte[] data = new byte[4];
                string result = parser.Parse(data);
                Assert.AreEqual("", result, "Parse fail");
            });
        }

        [Test]
        public void BirthDayValid() {
            this.TestDateOfBirth(2020, MonthOfYear.Feb, DayOfWeek.Monday);
        }

        [Test]
        public void BirthDayInValidYear() {
            this.TestDateOfBirth(120, MonthOfYear.Feb, DayOfWeek.Monday);
        }



        private void Test(ushort year, byte month, byte day, byte hour, byte minutes, byte seconds) {
            DateTime dt = new DateTime(year, month, day, hour, minutes, seconds, DateTimeKind.Local);
            string expected = string.Format("{0} {1}", dt.ToLongDateString(), dt.ToLongTimeString());
            this.Test(year, month, day, hour, minutes, seconds, expected);
        }


        private void Test(ushort year, byte month, byte day, byte hour, byte minutes, byte seconds, string expected) {
            TestHelpersNet.CatchUnexpected(() => {
                TypeParserDateTime parser = new TypeParserDateTime();
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


        private void TestDateOfBirth(ushort year, MonthOfYear month, DayOfWeek day) {
            TestHelpersNet.CatchUnexpected(() => {
                string expected = string.Format("{0}, {1}, {2}",
                year.GetYearStr(), MonthOfYear.Feb.GetMonthStr(),
                day.GetDayStr());

                CharParser_DateOfBirth parser = new CharParser_DateOfBirth();
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
