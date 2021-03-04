using BluetoothLE.Net.Parsers.Types;
using NUnit.Framework;
using System;
using TestCaseSupport.Core;
using VariousUtils.Net;

namespace TestCases.Core.BLE.BLE_Types {

    [TestFixture]
    class Test02_Int24 : TestCaseBase {

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

        [Ignore("Very long")]
        [Test]
        public void T00_FullRangeFromBytes() {
            for(int i = Int24.MinValue; i <= Int24.MaxValue; i++) {
                this.TestValidValuesFromBytes(i);
            }
        }


        [Ignore("Very long")]
        [Test]
        public void T00_FullRangeFromInt() {
            for (int i = Int24.MinValue; i <= Int24.MaxValue; i++) {
                this.TestValidValuesFromInt(i);
            }
        }



        [Test]
        public void T01_FromInt32_SignedInt_ValidnRange() {
            this.TestValidValuesFromInt(Int24.MinValue);
            this.TestValidValuesFromInt(0);
            this.TestValidValuesFromInt(Int24.MaxValue);
        }



        [Test]
        public void T02_FromInt32_Signed_OutOfRangeMinus() {
            this.TestOutOfRange(Int24.MinValue - 1);
        }

        [Test]
        public void T03_FromInt32_Signed_OutOfRangePlus() {
            this.TestOutOfRange(Int24.MaxValue + 1);
        }


        public void TestValidValuesFromBytes(Int32 value) {
            TestHelpers.CatchUnexpected(() => {
                byte[] buffer = Int24.GetBytes(value);
                int pos = 0;
                Int24 val = Int24.GetNew(buffer, ref pos);
                Assert.AreEqual(value, val.Value, string.Format("On Set with Int32", buffer.ToHexByteString()));
            });
        }



        public void TestValidValuesFromInt(Int32 value ) {
            TestHelpers.CatchUnexpected(() => {
                Int24 val = Int24.GetNew(value);
                Assert.AreEqual(value, val.Value, string.Format("On Set with Int32:{0}", value));
            });
        }

        public void TestOutOfRange(Int32 value) {
            TestHelpers.CatchUnexpected(() => {
                Assert.Throws<ArgumentOutOfRangeException>(() => {
                    Int24 val = Int24.GetNew(value);
                });
            });
        }




    }

}
