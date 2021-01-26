using BluetoothLE.Net.Enumerations;
using BluetoothLE.Net.interfaces;
using BluetoothLE.Net.Parsers.Characteristics;
using BluetoothLE.Net.Parsers.Descriptor;
using LogUtils.Net;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestCases.Core.TestToolSet;
using VariousUtils.Net;

namespace TestCases.Core.BLE_CharParsers {

    [TestFixture]
    class Test12_DefaultParser : TestCaseBase {

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

        #region Data

        private ClassLog log = new ClassLog("DescFormatParserTest");
        private ICharParser defaultCharParser = new CharParser_Default();

        #endregion

        #region Test helpers

        [Test]
        public void UTF8String() {
            TestHelpersNet.CatchUnexpected(() => {
                IDescParser parser = new DescParser_PresentationFormat();
                this.SetFormatDesc(this.GetBlock(DataFormatEnum.UTF8_String, UnitsOfMeasurement.Unitless));
                string str = "This is a sample string for formating";
                string result = this.defaultCharParser.Parse(Encoding.UTF8.GetBytes(str));
                this.log.Info("UTF16String", () => string.Format("UTF8String '{0}'", result));
                Assert.AreEqual(str, result);
            });
        }

        [Test]
        public void UTF16String() {
            TestHelpersNet.CatchUnexpected(() => {
                IDescParser parser = new DescParser_PresentationFormat();
                this.SetFormatDesc(this.GetBlock(DataFormatEnum.UTF16_String, UnitsOfMeasurement.Unitless));
                string str = "This is a sample string for formating";
                string result = this.defaultCharParser.Parse(Encoding.Unicode.GetBytes(str));
                this.log.Info("UTF16String", () => string.Format("UTF16String '{0}'", result));
                Assert.AreEqual(str, result);
            });
        }

        [Test]
        public void Uint2Bit() {
            this.TestByteBits(this.GetByteArray(3), "3", DataFormatEnum.Unsigned_2bit_integer);
        }


        [Test]
        public void Uint2BitBitsMaskedOut() {
            this.TestByteBits(this.GetByteArray(15), "3", DataFormatEnum.Unsigned_2bit_integer);
        }


        [Test]
        public void Uint4Bit() {
            this.TestByteBits(this.GetByteArray(14), "14", DataFormatEnum.unsigned_4bit_integer);
        }

        [Test]
        public void Uint4BitBitsMaskedOut() {
            this.TestByteBits(this.GetByteArray(255), "15", DataFormatEnum.unsigned_4bit_integer);
        }

        [Test]
        public void Uint24BitNotEnoughBytes() {
            this.TestByteBits(this.GetByteArray(100), "ERR", DataFormatEnum.unsigned_24bit_integer);
        }



        // Not yet implemented
        //[Test]
        //public void Int12Bit() {
        //    this.TestByteBits(this.GetSByteArray(-53), "-53", DataFormatEnum.signed_12bit_integer);
        //}



        public void TestByteBits(byte[] data, string expected, DataFormatEnum format) {
            TestHelpersNet.CatchUnexpected(() => {
                IDescParser parser = new DescParser_PresentationFormat();
                this.SetFormatDesc(this.GetBlock(format, UnitsOfMeasurement.Unitless));
                string result = this.defaultCharParser.Parse(data);
                this.log.Info("TestByteBits", () => string.Format("Value:'{0}'", result));
                Assert.AreEqual(expected, result);
            });
        }



        #endregion


        private void SetFormatDesc(byte[] data) {
            IDescParser formatParser = new DescParser_PresentationFormat();
            string result = formatParser.Parse(data);
            this.log.Info("SetFormatDesc", () => string.Format("Format Desc Display:{0}", result));
            List<IDescParser> descriptors = new List<IDescParser>();
            descriptors.Add(formatParser);
            this.defaultCharParser.SetDescriptorParsers(descriptors);
        }



        #region GetBlock

        private byte[] GetBlock() {
            return this.GetBlock(DataFormatEnum.unsigned_32bit_integer, UnitsOfMeasurement.LengthMetre);
        }


        private byte[] GetBlock(DataFormatEnum formatEnum) {
            return this.GetBlock(formatEnum, UnitsOfMeasurement.LengthMetre, 0);
        }


        private byte[] GetBlock(DataFormatEnum formatEnum, UnitsOfMeasurement units) {
            return this.GetBlock(formatEnum, units, 0);
        }


        private byte[] GetBlock(DataFormatEnum formatEnum, UnitsOfMeasurement units, byte exponent) {
            return this.GetBlock(formatEnum, units, exponent, 1, 0x221A);
        }


        private byte[] GetBlock(DataFormatEnum formatEnum, UnitsOfMeasurement units, byte exponent, byte nameSpace) {
            return this.GetBlock(formatEnum, units, exponent, nameSpace, 0x221A);
        }

        private byte[] GetBlock(DataFormatEnum formatEnum, UnitsOfMeasurement units, byte exponent, byte nameSpace, ushort description) {
            byte[] data = new byte[7];
            //ushort description = 0x221A;
            int pos = 0;
            formatEnum.ToByte().WriteToBuffer(data, ref pos);
            exponent.WriteToBuffer(data, ref pos);
            UnitsOfMeasurement.LengthMetre.ToUint16().WriteToBuffer(data, ref pos);
            nameSpace.WriteToBuffer(data, ref pos); // namespace
            description.WriteToBuffer(data, ref pos);
            return data;
        }


        byte[] GetByteArray(byte value) {
            int pos = 0;
            byte[] data = new byte[1];
            value.WriteToBuffer(data, ref pos);
            return data;
        }

        byte[] GetSByteArray(sbyte value) {
            int pos = 0;
            byte[] data = new byte[1];
            value.WriteToBuffer(data, ref pos);
            return data;
        }


        #endregion



    }

}
