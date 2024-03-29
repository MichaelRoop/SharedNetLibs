﻿using NUnit.Framework;
using TestCaseSupport.Core;
using VariousUtils.Net;

namespace TestCases.VariousUtilsTests.Net {

    [TestFixture]
    public class EnumHelpersTests : TestCaseBase {

        #region Data

        [Flags]
        public enum TestEnum {
            None = 0,
            One = 1,
            Two = 2,
            Three = 4,
            Four = 8,
            Five = 16,
            Six = 32,
            Seven = 64,
            Eight = 128,
            Nine = 256,
        }


        public enum TestUintEnum : uint {
            None = 0,
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
        }

        public enum TestByteEnum : byte {
            None = 0,
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
        }



        // Something strange. Works if at least 2. Less and it adds a leading 0 entry
        public enum EmptyEnum : int {
        }



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

        #region Flags

        [Test]
        public void T01_Flags_01_Add() {
            TestHelpers.CatchUnexpected(() => {
                TestEnum t = TestEnum.None;
                Assert.AreEqual(TestEnum.None, t);
                t = t.AddFlag(TestEnum.One);
                t = t.AddFlag(TestEnum.Three);
                t = t.AddFlag(TestEnum.Six);
                Assert.True(t.HasFlag(TestEnum.None));
                Assert.True(t.HasFlag(TestEnum.One));
                Assert.True(t.HasFlag(TestEnum.Three));
                Assert.True(t.HasFlag(TestEnum.Six));


            });
        }


        [Test]
        public void T01_Flags_02_Remove() {
            TestHelpers.CatchUnexpected(() => {
                TestEnum t = TestEnum.Four | TestEnum.Eight | TestEnum.Two;
                Assert.True(t.HasFlag(TestEnum.None));
                Assert.True(t.HasFlag(TestEnum.Four));
                Assert.True(t.HasFlag(TestEnum.Eight));
                Assert.True(t.HasFlag(TestEnum.Two));

                t = t.RemoveFlag(TestEnum.Eight);
                t = t.RemoveFlag(TestEnum.Four);
                Assert.True(t.HasFlag(TestEnum.None));
                Assert.False(t.HasFlag(TestEnum.Four));
                Assert.False(t.HasFlag(TestEnum.Eight));
                Assert.True(t.HasFlag(TestEnum.Two));
                t = t.RemoveFlag(TestEnum.Two);
                Assert.False(t.HasFlag(TestEnum.Two));
                t = t.RemoveFlag(TestEnum.None);
                // None is 0 so it will always be there even if you call remove
                Assert.True(t.HasFlag(TestEnum.None));
            });
        }

        #endregion

        #region ToValues

        [Test]
        public void T02_01_Enum_ToInt() {
            TestHelpers.CatchUnexpected(() => {
                Assert.AreEqual(64, TestEnum.Seven.ToInt());
            });
        }

        [Test]
        public void T02_02_Int_ToEnum_Valid() {
            TestHelpers.CatchUnexpected(() => {
                int value = 64;
                Assert.AreEqual(TestEnum.Seven, value.ToEnum<TestEnum>());
                // Just to make sure it does not throw an exception
                //Assert.AreNotEqual(TestEnum.Seven, 23356.ToEnum<TestEnum>());
            });
        }

        [Test]
        public void T02_03_Int_ToEnum_InvalidNumber() {
            // TODO - just returns a non existing enum of that value
            int value = 3264;
             Assert.AreEqual(3264, (int)value.ToEnum<TestEnum>());
        }

        [Test]
        public void T02_04_ToEnum_Int_InvalidNumberWithDefault() {
            int value = 3264;
            Assert.AreEqual(TestEnum.None, value.ToEnum<TestEnum>(TestEnum.None));
        }




        #endregion

        #region FirstOrDefault

        [Test]
        public void T03_01_FirstOrDefault_byte() {
            byte value = 254;
            TestByteEnum e = value.FirstOrDefault(TestByteEnum.None);
            Assert.AreEqual(TestByteEnum.None, e);

            value = 4;
            e = value.FirstOrDefault(TestByteEnum.None);
            Assert.AreEqual(TestByteEnum.Four, e);
        }



        [Test]
        public void T03_05_FirstOrDefault_uint() {
            TestHelpers.CatchUnexpected(() => {
                uint value = 33333;
                TestUintEnum e = value.FirstOrDefault(TestUintEnum.None);
                Assert.AreEqual(TestUintEnum.None, e);

                value = 4;
                e = value.FirstOrDefault(TestUintEnum.None);
                Assert.AreEqual(TestUintEnum.Four, e);
            });
        }

        #endregion

        #region GetEnumList
        [Test]
        public void T04_01_GetEnumList_Count() {
            Assert.AreEqual(10, EnumHelpers.GetEnumList<TestEnum>().Count);
        }

        [Test]
        public void T04_02_GetEnumList_Empty() {
            Assert.AreEqual(0, EnumHelpers.GetEnumList<EmptyEnum>().Count);
        }

        #endregion

    }

}
