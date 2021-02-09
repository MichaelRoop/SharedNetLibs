using BluetoothLE.Net.Parsers.Types;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestCases.Core.TestToolSet;
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
        public void T00_FullRange() {
            for(int i = Int24.MinValue; i <= Int24.MaxValue; i++) {
                this.TestValidValuesFromBytes(i);
            }
        }


        [Test]
        public void T01_FromInt32_Signed_ValidnRange() {
            this.TestValidValues(Int24.MinValue);
            this.TestValidValues(0);
            this.TestValidValues(Int24.MaxValue);


            //TestHelpersNet.CatchUnexpected(() => {
            //    Int32 expected = -22416;
            //    Int24 val = Int24.GetNew(expected);
            //    Assert.AreEqual(expected, val.Value, "On Set with Int32");


            //});
        }



        [Test]
        public void T02_FromInt32_Signed_OutOfRangeMinus() {
            this.TestOutOfRange(Int24.MinValue - 1);

            //TestHelpersNet.CatchUnexpected(() => {
            //    Assert.Throws<ArgumentOutOfRangeException>(() => {
            //        Int32 expected = Int24.MinValue - 1;
            //        Int24 val = Int24.GetNew(expected);
            //    });
            //});
        }

        [Test]
        public void T03_FromInt32_Signed_OutOfRangePlus() {
            //this.TestOutOfRange(Int24.MaxValue + 100);

            TestHelpersNet.CatchUnexpected(() => {
                Assert.Throws<ArgumentOutOfRangeException>(() => {
                    Int32 expected = Int24.MaxValue + 1;
                    Int24 val = Int24.GetNew(expected);
                });
            });
        }


        public void TestValidValuesFromBytes(Int32 value) {
            TestHelpersNet.CatchUnexpected(() => {
                byte[] buffer = Int24.GetBytes(value);
                int pos = 0;
                Int24 val = Int24.GetNew(buffer, ref pos);
                //Int24 val = Int24.GetNew(value);
                Assert.AreEqual(value, val.Value, string.Format("On Set with Int32", buffer.ToHexByteString()));
            });
        }



        public void TestValidValues(Int32 value ) {
            TestHelpersNet.CatchUnexpected(() => {
                Int24 val = Int24.GetNew(value);
                Assert.AreEqual(value, val.Value, "On Set with Int32");
            });
        }

        public void TestOutOfRange(Int32 value) {
            TestHelpersNet.CatchUnexpected(() => {
                Assert.Throws<ArgumentOutOfRangeException>(() => {
                    Int24 val = Int24.GetNew(value);
                });
            });
        }




    }

}
