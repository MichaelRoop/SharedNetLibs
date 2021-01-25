using BluetoothLE.Net.Parsers.Characteristics;
using BluetoothLE.Net.Parsers.Types;
using NUnit.Framework;
using System;
using TestCases.Core.TestToolSet;
using VariousUtils.Net;

namespace TestCases.Core.BLE_CharParsers {

    [TestFixture]
    public class Test09_CurrentTime : TestCaseBase {
        public object BitHelpers { get; private set; }

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
        public void AllAdjustEnabled() {
            this.Test(2021, 1, 1, 20, 15, 32, 200, this.SetBits(true, true, true, true)); 
        }

        [Test]
        public void AllAdjustDisabled() {
            this.Test(2021, 1, 1, 20, 15, 32, 200, this.SetBits(false, false, false, false));
        }

        [Test]
        public void AllAdjustZeroThreeEnabled() {
            this.Test(2021, 1, 1, 20, 15, 32, 200, this.SetBits(true, false, false, true));
        }



        private void Test(ushort year, byte month, byte day, byte hour, byte minutes, byte seconds, byte fragment, byte adjustBitmask) {
            DateTime dt = new DateTime(year, month, day, hour, minutes, seconds, DateTimeKind.Local);
            string expected = string.Format("{0} {1} {2}.{3} {4}",
                dt.DayOfWeek.GetDayStr(), dt.ToLongDateString(), dt.ToLongTimeString(), fragment.GetSecond256FragmentAsMs(), adjustBitmask.CurrentTimeAdjustReasonStr());
            this.Test(year, month, day, hour, minutes, seconds, fragment, adjustBitmask, expected);
        }


        private void Test(ushort year, byte month, byte day, byte hour, byte minutes, byte seconds, byte fragment, byte adjustBitmask, string expected) {
            TestHelpersNet.CatchUnexpected(() => {
                DateTime dt = new DateTime(year, month, day, hour, minutes, seconds, DateTimeKind.Local);
                CharParser_CurrentTime parser = new CharParser_CurrentTime();
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
                adjustBitmask.WriteToBuffer(data, ref pos);
                string result = parser.Parse(data);
                Assert.AreEqual(expected, result, "Parse fail");
            });
        }


        private byte SetBits(bool zero, bool one, bool two, bool three) {
            byte adjust = 0;
            BitTools.SetBit(adjust, 0, zero);
            BitTools.SetBit(adjust, 1, one);
            BitTools.SetBit(adjust, 2, two);
            BitTools.SetBit(adjust, 3, three);
            return adjust;
        }




    }
}
