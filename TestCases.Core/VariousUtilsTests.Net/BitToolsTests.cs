using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCaseSupport.Core;
using VariousUtils.Net;

namespace TestCases.Core.VariousUtilsTests.Net {


    [TestFixture]
    public class BitToolsTests : TestCaseBase {

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
        public void CreateBitMask01__uint8() {
            TestHelpers.CatchUnexpected(() => {
                byte mask = 0;
                byte[] bits = new byte[] { 1, 0, 0, 0, 0, 1, 1, 1 };
                bool result = this.FromVisualArray(bits).CreateBitMask(ref mask);
                Assert.True(result, "Creating bit mask");
                Assert.AreEqual(135, mask);
                Assert.AreEqual("1000 0111", mask.GetBitString());
                //ByteHelpers

            });
        }


        [Test]
        public void CreateBitMask02_uint16() {
            TestHelpers.CatchUnexpected(() => {
                UInt16 mask = 0;
                //0, 0, 0, 0, 1, 0, 0, 1
                byte[] bits = new byte[] { 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1 };
                bool result = this.FromVisualArray(bits).CreateBitMask(ref mask);
                Assert.True(result, "Creating bit mask");
                Assert.AreEqual(34569, mask);
                Assert.AreEqual("1000 0111 0000 1001", mask.GetBitString());
                //ByteHelpers

            });
        }


        [Test]
        public void CreateBitMask03_uint32() {
            TestHelpers.CatchUnexpected(() => {
                UInt32 mask = 0;
                //0, 0, 0, 0, 1, 0, 0, 1
                byte[] bits = new byte[] { 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1 };
                bool result = this.FromVisualArray(bits).CreateBitMask(ref mask);
                Assert.True(result, "Creating bit mask");
                Assert.AreEqual(2265548553, mask);
                Assert.AreEqual("1000 0111 0000 1001 1000 0111 0000 1001", mask.GetBitString());
                //ByteHelpers
            });
        }



        [Test]
        public void CreateBitMask04_uint64() {
            TestHelpers.CatchUnexpected(() => {
                UInt64 mask = 0;
                //0, 0, 0, 0, 1, 0, 0, 1
                byte[] bits = new byte[] { 
                    1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1,
                    1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1
                };
                bool result = this.FromVisualArray(bits).CreateBitMask(ref mask);
                Assert.True(result, "Creating bit mask");
                Assert.AreEqual(9730456944900671241, mask);
                Assert.AreEqual("1000 0111 0000 1001 1000 0111 0000 1001 1000 0111 0000 1001 1000 0111 0000 1001", mask.GetBitString());
                //ByteHelpers

            });
        }

        #endregion



        /// <summary>Reverses order of values so visual last is least significant</summary>
        /// <param name="values">Byte array to translate</param>
        /// <returns>List of bools least significant first</returns>
        private List<bool> FromVisualArray(byte[] values) {
            // need to reverse to process the last entered linear as least significant
            List<bool> arr = new List<bool>(values.Length);
            for (int i = values.Count() - 1; i >= 0; i--) {
                arr.Add(values[i] == 0 ? false : true);
            }
            return arr;
        }






    }

}
