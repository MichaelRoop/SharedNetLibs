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
                this.GetDayStr(dt.DayOfWeek), dt.ToLongDateString(), dt.ToLongTimeString());
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
                byte bleDay = this.GetBleDay(dt.DayOfWeek);
                bleDay.WriteToBuffer(data, ref pos);
                string result = parser.Parse(data);
                Assert.AreEqual(expected, result, "Parse fail");
            });

        }



        private string GetDayStr(DayOfWeek day) {
            return DateTimeFormatInfo.CurrentInfo.GetDayName(day);
        }


        private byte GetBleDay(DayOfWeek day) {
            switch (day) {
                case DayOfWeek.Sunday:
                    return 7;
                case DayOfWeek.Monday:
                    return 1;
                case DayOfWeek.Tuesday:
                    return 2;
                case DayOfWeek.Wednesday:
                    return 3;
                case DayOfWeek.Thursday:
                    return 4;
                case DayOfWeek.Friday:
                    return 5;
                case DayOfWeek.Saturday:
                    return 6;
                default:
                    return 0;
            }


            //int bleDay = (day == 1) ? 7 : (day);
            //return (byte)bleDay;
        }




    }
}
