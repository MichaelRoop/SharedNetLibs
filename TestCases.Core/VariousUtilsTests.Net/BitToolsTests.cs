using NUnit.Framework;
using TestCaseSupport.Core;
using VariousUtils.Net;

namespace TestCases.Core.VariousUtilsTests.Net {


    [TestFixture]
    public class BitToolsTests : TestCaseBase {
#pragma warning disable CA1822 // Mark members as static

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


        #region Bit mask create tests

        [Test]
        public void CreateBitMask01__uint8_01StartBitsOff() {
            TestHelpers.CatchUnexpected(() => {
                byte mask = 0;
                byte[] bits = new byte[] { 1, 0, 0, 0, 0, 1, 1, 1 };
                bool result = this.FromVisualArray(bits).CreateBitMask(ref mask);
                Assert.True(result, "Creating bit mask");
                Assert.AreEqual("1000 0111", mask.ToBitString());
                Assert.AreEqual(135, mask);
                //ByteHelpers
            });
        }

        [Test]
        public void CreateBitMask01__uint8_02StartBitsOn() {
            TestHelpers.CatchUnexpected(() => {
                byte mask = 0xFF;
                byte[] bits = new byte[] { 1, 0, 0, 0, 0, 1, 1, 1 };
                bool result = this.FromVisualArray(bits).CreateBitMask(ref mask);
                Assert.True(result, "Creating bit mask");
                Assert.AreEqual("1000 0111", mask.ToBitString());
                Assert.AreEqual(135, mask);
                //ByteHelpers
            });
        }



        [Test]
        public void CreateBitMask02_uint16_01StartBitsOff() {
            TestHelpers.CatchUnexpected(() => {
                UInt16 mask = 0;
                //0, 0, 0, 0, 1, 0, 0, 1
                byte[] bits = new byte[] { 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1 };
                bool result = this.FromVisualArray(bits).CreateBitMask(ref mask);
                Assert.True(result, "Creating bit mask");
                Assert.AreEqual("1000 0111 0000 1001", mask.ToBitString());
                Assert.AreEqual(34569, mask);
                //ByteHelpers

            });
        }

        [Test]
        public void CreateBitMask02_uint16_02StartBitsOn() {
            TestHelpers.CatchUnexpected(() => {
                UInt16 mask = 0xFFFF;
                //0, 0, 0, 0, 1, 0, 0, 1
                byte[] bits = new byte[] { 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1 };
                bool result = this.FromVisualArray(bits).CreateBitMask(ref mask);
                Assert.True(result, "Creating bit mask");
                Assert.AreEqual("1000 0111 0000 1001", mask.ToBitString());
                Assert.AreEqual(34569, mask);
                //ByteHelpers

            });
        }


        [Test]
        public void CreateBitMask03_uint32_01StartBitsOff() {
            TestHelpers.CatchUnexpected(() => {
                UInt32 mask = 0;
                //0, 0, 0, 0, 1, 0, 0, 1
                byte[] bits = new byte[] { 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1 };
                bool result = this.FromVisualArray(bits).CreateBitMask(ref mask);
                Assert.True(result, "Creating bit mask");
                Assert.AreEqual("1000 0111 0000 1001 1000 0111 0000 1001", mask.ToBitString());
                Assert.AreEqual(2265548553, mask);
                //ByteHelpers
            });
        }


        [Test]
        public void CreateBitMask03_uint32_02StartBitsOn() {
            TestHelpers.CatchUnexpected(() => {
                UInt32 mask = 0xFFFFFFFF;
                //0, 0, 0, 0, 1, 0, 0, 1
                byte[] bits = new byte[] { 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1 };
                bool result = this.FromVisualArray(bits).CreateBitMask(ref mask);
                Assert.True(result, "Creating bit mask");
                Assert.AreEqual("1000 0111 0000 1001 1000 0111 0000 1001", mask.ToBitString());
                Assert.AreEqual(2265548553, mask);
                //ByteHelpers
            });
        }


        [Test]
        public void CreateBitMask04_uint64_01StartBitsOff() {
            TestHelpers.CatchUnexpected(() => {
                UInt64 mask = 0;
                //0, 0, 0, 0, 1, 0, 0, 1
                byte[] bits = new byte[] { 
                    1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1,
                    1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1
                };
                bool result = this.FromVisualArray(bits).CreateBitMask(ref mask);
                Assert.True(result, "Creating bit mask");
                Assert.AreEqual("1000 0111 0000 1001 1000 0111 0000 1001 1000 0111 0000 1001 1000 0111 0000 1001", mask.GetBitString());
                Assert.AreEqual(9730456944900671241, mask);
                //ByteHelpers

            });
        }


        [Test]
        public void CreateBitMask04_uint64_01StartBitsOn() {
            TestHelpers.CatchUnexpected(() => {
                UInt64 mask = 0xFFFFFFFFFFFFFFFF;
                //0, 0, 0, 0, 1, 0, 0, 1
                byte[] bits = new byte[] {
                    1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1,
                    1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1
                };
                bool result = this.FromVisualArray(bits).CreateBitMask(ref mask);
                Assert.True(result, "Creating bit mask");
                Assert.AreEqual("1000 0111 0000 1001 1000 0111 0000 1001 1000 0111 0000 1001 1000 0111 0000 1001", mask.GetBitString());
                Assert.AreEqual(9730456944900671241, mask);
                //ByteHelpers

            });
        }


        #endregion



        /// <summary>Reverses order of values so visual last is least significant</summary>
        /// <param name="values">Byte array to translate</param>
        /// <returns>List of bools least significant first</returns>
        private List<bool> FromVisualArray(byte[] values) {
                              // need to reverse to process the last entered linear as least significant
            List<bool> arr = new (values.Length);
            for (int i = values.Length - 1; i >= 0; i--) {
                arr.Add(values[i] != 0);
            }
            return arr;
        }

#pragma warning restore CA1822 // Mark members as static

    }

}
