using BluetoothLE.Net.Parsers.Types;
using NUnit.Framework;
using System.Globalization;
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
                TestValidValuesFromBytes(i);
            }
        }


        [Ignore("Very long")]
        [Test]
        public void T00_FullRangeFromInt() {
            for (int i = Int24.MinValue; i <= Int24.MaxValue; i++) {
                TestValidValuesFromInt(i);
            }
        }



        [Test]
        public void T01_FromInt32_SignedInt_ValidnRange() {
            TestValidValuesFromInt(Int24.MinValue);
            TestValidValuesFromInt(0);
            TestValidValuesFromInt(Int24.MaxValue);
        }



        [Test]
        public void T02_FromInt32_Signed_OutOfRangeMinus() {
            TestOutOfRange(Int24.MinValue - 1);
        }

        [Test]
        public void T03_FromInt32_Signed_OutOfRangePlus() {
            TestOutOfRange(Int24.MaxValue + 1);
        }


        [Test]
        public void T04_Int24_Equals_NOT_Int48_WithSameValue() {
            TestHelpers.CatchUnexpected(() => {
                Assert.False(new Int24(48).Equals(new Int48(48)));
            });
        }


        [Test]
        public void T04_Int24_EqualsInt24() {
            TestHelpers.CatchUnexpected(() => {
                Assert.True(new Int24(43).Equals(new Int24(43)));
            });
        }

        [Test]
        public void T04_Int24_NotEqualsInt24() {
            TestHelpers.CatchUnexpected(() => {
                Assert.False(new Int24(43).Equals(new Int24(4)));
            });
        }


        [Test]
        public void T05_Int24_CompareToInt24_Same() {
            TestHelpers.CatchUnexpected(() => {
                Assert.AreEqual(0, new Int24(43).CompareTo(new Int24(43)));
            });
        }

        [Test]
        public void T06_Int24_CompareTo_SmallerValue() {
            TestHelpers.CatchUnexpected(() => {
                Assert.AreEqual(1, new Int24(43).CompareTo(new Int24(3)));
            });
        }

        [Test]
        public void T07_Int24_CompareTo_LargerValue() {
            TestHelpers.CatchUnexpected(() => {
                Assert.AreEqual(-1, new Int24(4).CompareTo(new Int24(43)));
            });
        }

        [Test]
        public void T08_Int24_CompareTo_EqualValue() {
            TestHelpers.CatchUnexpected(() => {
                Assert.AreEqual(0, new Int24(43).CompareTo(new Int24(43)));
            });
        }



        [Test]
        public void T09_Int24_CompareTo_Sorted() {
            Int24[] array = new Int24[6] {
                    new Int24(25),
                    new Int24(4),
                    new Int24(-400),
                    new Int24(3222),
                    new Int24(0),
                    new Int24(25)
                };

            Assert.AreEqual(25, array[0].Value);
            Assert.AreEqual(4, array[1].Value);
            Assert.AreEqual(-400, array[2].Value);
            Assert.AreEqual(3222, array[3].Value);
            Assert.AreEqual(0, array[4].Value);
            Assert.AreEqual(25, array[5].Value);

            Array.Sort(array);

            Assert.AreEqual(-400, array[0].Value);
            Assert.AreEqual(0, array[1].Value);
            Assert.AreEqual(4, array[2].Value);
            Assert.AreEqual(25, array[3].Value);
            Assert.AreEqual(25, array[4].Value);
            Assert.AreEqual(3222, array[5].Value);
        }


        [Test]
        public void T10_Int24_Equitable_Equals_NOT() {
            TestHelpers.CatchUnexpected(() => {
                Assert.False(new Int24(48).Equals(new Int24(8)));
            });
        }

        [Test]
        public void T11_Int24_Equitable_Equals_OK() {
            TestHelpers.CatchUnexpected(() => {
                Assert.True(new Int24(8).Equals(new Int24(8)));
            });
        }

        [Test]
        public void T12_Int24_Formatable_OK() {
            TestHelpers.CatchUnexpected(() => {
                Assert.AreEqual("398",  new Int24(398).ToString());
            });
        }

        [Test]
        public void T13_Int24_Formatable_NOT() {
            TestHelpers.CatchUnexpected(() => {
                Assert.AreNotEqual("398", new Int24(96).ToString());
            });
        }


        [Test]
        public void T14_Int24_ConvertibleAll() {
            CultureInfo info = new ("en-US");
            Assert.True(new Int24(6).ToBoolean(info), "Bool 6");
            Assert.False(new Int24(0).ToBoolean(info), "Bool 0");
            Assert.AreEqual(122, new Int24(122).ToByte(info), "byte 122");

            Assert.AreEqual(122, new Int24(122).ToChar(info), "Char 122");
            Assert.AreEqual(12222, new Int24(12222).ToDecimal(info), "Decimal 12222");
            Assert.AreEqual(122, new Int24(122).ToDouble(info), "Double 122");

            Assert.AreEqual(123, new Int24(123).ToInt16(info), "Int16 123");
            Assert.AreEqual(3456, new Int24(3456).ToInt32(info), "Int32 3456");
            Assert.AreEqual(122, new Int24(122).ToInt64(info), "Int64 122");


            Assert.AreEqual(123, new Int24(123).ToUInt16(info), "UInt16 123");
            Assert.AreEqual(3456, new Int24(3456).ToUInt32(info), "UInt32 3456");
            Assert.AreEqual(122, new Int24(122).ToUInt64(info), "UInt64 122");



            Assert.Throws<InvalidCastException>(() => {
                new Int24(2011).ToDateTime(info);
            }, "Cast to date time should throw exception");


            //Assert.AreEqual(122, new Int24(122).ToInt16(info), "Int16 ");
            //Assert.AreEqual(122, new Int24(122).ToDouble(info), "Bool 6");
            //Assert.AreEqual(122, new Int24(122).ToDouble(info), "Bool 6");



            //new Int24().ToBoolean(CultureInfo.CreateSpecificCulture().CurrentCulture)


        }




        public static void TestValidValuesFromBytes(Int32 value) {
            TestHelpers.CatchUnexpected(() => {
                byte[] buffer = Int24.GetBytes(value);
                int pos = 0;
                Int24 val = Int24.GetNew(buffer, ref pos);
                Assert.AreEqual(value, val.Value, string.Format("On Set with Int32:{0}", buffer.ToHexByteString()));
            });
        }



        public static void TestValidValuesFromInt(Int32 value ) {
            TestHelpers.CatchUnexpected(() => {
                Int24 val = Int24.GetNew(value);
                Assert.AreEqual(value, val.Value, string.Format("On Set with Int32:{0}", value));
            });
        }

        public static void TestOutOfRange(Int32 value) {
            TestHelpers.CatchUnexpected(() => {
                Assert.Throws<ArgumentOutOfRangeException>(() => {
                    Int24 val = Int24.GetNew(value);
                });
            });
        }




    }

}
