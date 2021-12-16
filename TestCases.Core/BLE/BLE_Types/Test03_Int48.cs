using BluetoothLE.Net.Parsers.Types;
using NUnit.Framework;
using TestCaseSupport.Core;
using VariousUtils.Net;

namespace TestCases.Core.BLE.BLE_Types {

    [TestFixture]
    public class Test03_Int48 : TestCaseBase {

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


        [Ignore("Very very long")]
        [Test]
        public void T00_FullRangeFromBytes() {
            for (Int64 i = Int48.MinValue; i <= Int48.MaxValue; i+=100000) {
                TestValidValuesFromBytes(i);
            }
        }


        [Ignore("Very long")]
        [Test]
        public void T00_FullRangeFromInt() {
            for (Int64 i = Int48.MinValue; i <= Int48.MaxValue; i+=100000) {
                TestValidValuesFromInt(i);
            }
        }



        [Test]
        public void T01_FromInt64_SignedInt_ValidnRange() {
            TestValidValuesFromInt(Int48.MinValue);
            TestValidValuesFromInt(0);
            TestValidValuesFromInt(Int48.MaxValue);
        }



        [Test]
        public void T02_FromInt64_Signed_OutOfRangeMinus() {
            TestOutOfRange(Int48.MinValue - 1);
        }

        [Test]
        public void T03_FromInt64_Signed_OutOfRangePlus() {
            TestOutOfRange(Int48.MaxValue + 1);
        }


        [Test]
        public void T04_FromInt64_FromBytes_ValidnRange() {
            TestValidValuesFromBytes(Int48.MinValue);
            TestValidValuesFromBytes(0);
            TestValidValuesFromBytes(Int48.MaxValue);
        }




        public static void TestValidValuesFromBytes(Int64 value) {
            TestHelpers.CatchUnexpected(() => {
                byte[] buffer = Int48.GetBytes(value);
                int pos = 0;
                Int48 val = Int48.GetNew(buffer, ref pos);
                Assert.AreEqual(value, val.Value, string.Format("On Set with Int32:{0}", buffer.ToHexByteString()));
            });
        }



        public static void TestValidValuesFromInt(Int64 value) {
            TestHelpers.CatchUnexpected(() => {
                Int48 val = Int48.GetNew(value);
                Assert.AreEqual(value, val.Value, string.Format("On Set with Int32:{0}", value));
            });
        }

        public static void TestOutOfRange(Int64 value) {
            TestHelpers.CatchUnexpected(() => {
                Assert.Throws<ArgumentOutOfRangeException>(() => {
                    Int48 val = Int48.GetNew(value);
                });
            });
        }



    }

}
