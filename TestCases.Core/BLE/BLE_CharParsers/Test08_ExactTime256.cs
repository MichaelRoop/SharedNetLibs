﻿using BluetoothLE.Net.Parsers.Types;
using NUnit.Framework;
using System;
using TestCaseSupport.Core;
using VariousUtils.Net;

namespace TestCases.Core.BLE.BLE_CharParsers {

    [TestFixture]
    public class Test08_ExactTime256 : TestCaseBase {

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
        public void ValidAll0() { this.Test(2021, 1, 1, 20, 15, 32, 0); }
        [Test]
        public void ValidAll200() { this.Test(2021, 1, 1, 20, 15, 32, 200); }
        [Test]
        public void ValidAll255() { this.Test(2021, 1, 1, 20, 15, 32, 255); }




        private void Test(ushort year, byte month, byte day, byte hour, byte minutes, byte seconds, byte fragment) {
            DateTime dt = new DateTime(year, month, day, hour, minutes, seconds, DateTimeKind.Local);
            string expected = string.Format("{0} {1} {2}.{3}",
                dt.DayOfWeek.GetDayStr(), dt.ToLongDateString(), dt.ToLongTimeString(), fragment.GetSecond256FragmentAsMs());
            this.Test(year, month, day, hour, minutes, seconds, fragment, expected);
        }


        private void Test(ushort year, byte month, byte day, byte hour, byte minutes, byte seconds, byte fragment, string expected) {
            TestHelpers.CatchUnexpected(() => {
                DateTime dt = new DateTime(year, month, day, hour, minutes, seconds, DateTimeKind.Local);
                TypeParserExactTime256 parser = new TypeParserExactTime256();
                byte[] data = new byte[parser.RequiredBytes];
                int pos = 0;
                year.WriteToBuffer(data, ref pos);
                month.WriteToBuffer(data, ref pos);
                day.WriteToBuffer(data, ref pos);
                hour.WriteToBuffer(data, ref pos);
                minutes.WriteToBuffer(data, ref pos);
                seconds.WriteToBuffer(data, ref pos);
                byte bleDay = dt.DayOfWeek.GetBleDayByte();
                bleDay.WriteToBuffer(data, ref pos);
                fragment.WriteToBuffer(data, ref pos);
                string result = parser.Parse(data);
                Assert.AreEqual(expected, result, "Parse fail");
            });

        }



    }

}
