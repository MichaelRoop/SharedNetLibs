using NUnit.Framework;
using System;
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
        public void TestAdd() {
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
        public void TestRemove() {
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


        [Test]
        public void GetEnumListTest() {
            TestHelpers.CatchUnexpected(() => {
                int count = 0;
                foreach (TestEnum te in EnumHelpers.GetEnumList<TestEnum>()) {
                    count++;
                }
                Assert.AreEqual(10, count);


            });
        }


        [Test]
        public void ToIntTest() {
            TestHelpers.CatchUnexpected(() => {
                Assert.AreEqual(64, TestEnum.Seven.ToInt());
            });
        }


        [Test]
        public void ToEnumTest() {
            TestHelpers.CatchUnexpected(() => {
                Assert.AreEqual(TestEnum.Seven, 64.ToEnum<TestEnum>());
                // Just to make sure it does not throw an exception
                Assert.AreNotEqual(TestEnum.Seven, 23356.ToEnum<TestEnum>());
            });
        }


        [Test]
        public void FirstOrDefaultTest() {
            TestHelpers.CatchUnexpected(() => {
                uint value = 33333;

                TestUintEnum e = value.FirstOrDefault(TestUintEnum.None);
                Assert.AreEqual(TestUintEnum.None, e);

                value = 4;
                e = value.FirstOrDefault(TestUintEnum.None);
                Assert.AreEqual(TestUintEnum.Four, e);



                //Assert.AreEqual(TestEnum.Seven, 64.ToEnum<TestEnum>());
                //// Just to make sure it does not throw an exception
                //Assert.AreNotEqual(TestEnum.Seven, 23356.ToEnum<TestEnum>());
            });
        }




    }

}
