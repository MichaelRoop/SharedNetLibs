using BluetoothLE.Net.Parsers.Characteristics.DataTypes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TestCases.Core.TestToolSet;
using VariousUtils.Net;

namespace TestCases.Core.BLE_CharParsers {

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
        public void ValidAll() { this.Test(2021, 1, 1, 20, 15, 32); }

        [Test]
        public void ValidFriday() { this.Test(2021, 1, 1, 20, 15, 32); }
        [Test]
        public void ValidSaturday() { this.Test(2021, 1, 2, 20, 15, 32); }
        [Test]
        public void ValidSunday() { this.Test(2021, 1, 3, 20, 15, 32); }
        [Test]
        public void ValidMonday() { this.Test(2021, 1, 4, 20, 15, 32); }
        [Test]
        public void ValidTuesday() { this.Test(2021, 1, 5, 20, 15, 32); }
        [Test]
        public void ValidWednesday() { this.Test(2021, 1, 6, 20, 15, 32); }
        [Test]
        public void ValidThursday() { this.Test(2021, 1, 7, 20, 15, 32); }




        private void Test(ushort year, byte month, byte day, byte hour, byte minutes, byte seconds) {
            DateTime dt = new DateTime(year, month, day, hour, minutes, seconds, DateTimeKind.Local);
            string expected = string.Format("{0} {1} {2}", 
                dt.DayOfWeek.GetDayStr(), dt.ToLongDateString(), dt.ToLongTimeString());
            this.Test(year, month, day, hour, minutes, seconds, expected);
        }


        private void Test(ushort year, byte month, byte day, byte hour, byte minutes, byte seconds, string expected) {
            TestHelpersNet.CatchUnexpected(() => {
                DateTime dt = new DateTime(year, month, day, hour, minutes, seconds, DateTimeKind.Local);
                TypeParser_DayDateTime parser = new TypeParser_DayDateTime();
                byte[] data = new byte[parser.RequiredBytes()];
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
