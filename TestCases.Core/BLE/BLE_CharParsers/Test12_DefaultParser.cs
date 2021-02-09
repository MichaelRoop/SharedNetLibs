using BluetoothLE.Net.Enumerations;
using BluetoothLE.Net.interfaces;
using BluetoothLE.Net.Parsers.Characteristics;
using BluetoothLE.Net.Parsers.Descriptor;
using BluetoothLE.Net.Parsers.Types;
using LogUtils.Net;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestCases.Core.TestToolSet;
using VariousUtils.Net;

namespace TestCases.Core.BLE.BLE_CharParsers {

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

        [Test]
        public void DiscardedRedundantFormat() {
            TestHelpersNet.CatchUnexpected(() => {
                IDescParser formatParser = new DescParser_PresentationFormat();
                formatParser.Parse(this.GetBlock(DataFormatEnum.UInt_8bit));
                List<IDescParser> descriptors = new List<IDescParser>();
                descriptors.Add(formatParser);
                IDescParser formatParser2 = new DescParser_PresentationFormat();
                formatParser2.Parse(this.GetBlock(DataFormatEnum.UInt_8bit));
                descriptors.Add(formatParser2);
                BLEOperationStatus status = this.defaultCharParser.SetDescriptorParsers(descriptors);
                Assert.AreEqual(BLEOperationStatus.RedundantFormatDescriptorsDiscarded, status, "On set descriptor parsers");
            });
        }


        #region Strings

        [Test]
        public void UTF8String() {
            TestHelpersNet.CatchUnexpected(() => {
                IDescParser parser = new DescParser_PresentationFormat();
                this.SetFormatDesc(this.GetBlock(DataFormatEnum.UTF8_String, UnitsOfMeasurement.Unitless));
                string str = "This is a sample UTF8 string for formating";
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
                string str = "This is a sample UTF16 string for formating";
                string result = this.defaultCharParser.Parse(Encoding.Unicode.GetBytes(str));
                this.log.Info("UTF16String", () => string.Format("UTF16String '{0}'", result));
                Assert.AreEqual(str, result);
            });
        }

        #endregion

        #region UInt

        [Test]
        public void Uint02_FullRange() {
            this.TestByteBits(this.GetByteArray(0), "0", DataFormatEnum.UInt_2bit);
            this.TestByteBits(this.GetByteArray(1), "1", DataFormatEnum.UInt_2bit);
            this.TestByteBits(this.GetByteArray(3), "3", DataFormatEnum.UInt_2bit);
        }


        [Test]
        public void Uint02_BitsMaskedOut() {
            this.TestByteBits(this.GetByteArray(15), "3", DataFormatEnum.UInt_2bit);
        }


        [Test]
        public void Uint04_FullRange() {
            this.TestByteBits(this.GetByteArray(0), "0", DataFormatEnum.UInt_4bit);
            this.TestByteBits(this.GetByteArray(15), "15", DataFormatEnum.UInt_4bit);
        }

        [Test]
        public void Uint04_BitsMaskedOut() {
            this.TestByteBits(this.GetByteArray(255), "15", DataFormatEnum.UInt_4bit);
        }

        [Test]
        public void Uint08_FullRange() {
            this.TestByteBits(this.GetByteArray(Byte.MinValue), Byte.MinValue.ToString(), DataFormatEnum.UInt_8bit);
            this.TestByteBits(this.GetByteArray(Byte.MaxValue), Byte.MaxValue.ToString(), DataFormatEnum.UInt_8bit);
        }

        [Test]
        public void Uint08_Exponent() {
            sbyte value = 112;
            this.TestExp(value, -1);
            this.TestExp(value, -2);
            this.TestExp(value, 1);
            this.TestExp(value, 2);
        }


        [Test]
        public void Uint12_FullRange() {
            this.TestByteBits(this.GetU16ByteArray(0), "0", DataFormatEnum.UInt_16bit);
            this.TestByteBits(this.GetU16ByteArray(4095), "4095", DataFormatEnum.UInt_16bit);
        }

        [Test]
        public void Uint12_Exponent() {
            ushort value = 222;
            this.TestExp12Bit(value, -1);
            this.TestExp12Bit(value, -2);
            this.TestExp12Bit(value, 1);
            this.TestExp12Bit(value, 2);
        }

        [Test]
        public void Uint12_BitMasked() {
            this.TestByteBits(this.GetU16ByteArray(0xAFFF), "4095", DataFormatEnum.UInt_12bit);
        }

        [Test]
        public void Uint16_FullRange() {
            this.TestByteBits(this.GetU16ByteArray(0), "0", DataFormatEnum.UInt_16bit);
            this.TestByteBits(this.GetU16ByteArray(62022), "62022", DataFormatEnum.UInt_16bit);
            this.TestByteBits(this.GetU16ByteArray(UInt16.MaxValue), UInt16.MaxValue.ToString(), DataFormatEnum.UInt_16bit);
        }

        [Test]
        public void Uint16_Exponent() {
            ushort value = 12192;
            this.TestExp(value, -1);
            this.TestExp(value, -2);
            this.TestExp(value, 1);
            this.TestExp(value, 2);
        }

        [Test]
        public void aaTestUint02() {
            TestHelpersNet.CatchUnexpected(() => {
                UInt02 val = UInt02.GetNew(2);
                Assert.AreEqual(2, val.Value);
                Assert.True(val == 2, "== operator");
                Assert.AreEqual(0, UInt02.MinValue);
                Assert.AreEqual(3, UInt02.MaxValue);
            });
        }


        [Test]
        public void Uint16_NotEnoughBytes() {
            this.TestByteBits(this.GetByteArray(100), "1 byte(s) Data. Requires 2", DataFormatEnum.UInt_16bit);
        }


        [Test]
        public void Uint24_Valid() {
            this.TestByteBits(this.GetU32ByteArray(0xFFFFF1), "16777201", DataFormatEnum.UInt_24bit);
        }

        [Test]
        public void Uint24_Exponent() {
            uint value = 225462;
            this.TestExp24Bit(value, -1);
            this.TestExp24Bit(value, -2);
            this.TestExp24Bit(value, 1);
            this.TestExp24Bit(value, 2);
        }

        [Test]
        public void Uint24_NotEnoughBytes() {
            this.TestByteBits(this.GetByteArray(100), "1 byte(s) Data. Requires 3", DataFormatEnum.UInt_24bit);
        }


        [Test]
        public void Uint24_Masked() {
            this.TestByteBits(this.GetU32ByteArray(0xFFFFFFFF), "16777215", DataFormatEnum.UInt_24bit);
        }

        [Test]
        public void Uint32_FullRange() {
            this.TestByteBits(this.GetU32ByteArray(0), "0", DataFormatEnum.UInt_32bit);
            this.TestByteBits(this.GetU32ByteArray(4294967290), "4294967290", DataFormatEnum.UInt_32bit);
        }


        [Test]
        public void Uint32_Exponent() {
            uint value = 4294967;
            this.TestExp(value, -1);
            this.TestExp(value, -2);
            this.TestExp(value, -3);
            this.TestExp(value, -4);
            this.TestExp(value, 1);
            this.TestExp(value, 2);
            this.TestExp(value, 3);
            this.TestExp(value, 4);
        }


        [Test]
        public void Uint48_Valid() {
            this.TestByteBits(this.GetU64ByteArray(14294967295), "14294967295", DataFormatEnum.UInt_48bit);
        }

        [Test]
        public void Uint48_Exponent() {
            ulong value = 22546987872;
            this.TestExp48(value, -1);
            this.TestExp48(value, -2);
            this.TestExp48(value, 1);
            this.TestExp48(value, 2);
        }



        [Test]
        public void Uint48_Masked() {
            this.TestByteBits(this.GetU64ByteArray(0xFFFFFFFFFFFFFF), "281474976710655", DataFormatEnum.UInt_48bit);
        }


        [Test]
        public void Uint64_Valid() {
            this.TestByteBits(this.GetU64ByteArray(9994294967290), "9994294967290", DataFormatEnum.UInt_64bit);
        }


        // Not supported
        //[Test]
        public void Uint128_Valid() {
            this.TestByteBits(this.GetU64ByteArray(9994294967290), "9994294967290", DataFormatEnum.UInt_128bit);
        }


        [Test]
        public void Uint64_Exponent() {
            ulong value = 987872;
            this.TestExp(value, -1);
            this.TestExp(value, -2);
            this.TestExp(value, 1);
            this.TestExp(value, 2);
        }


        #endregion

        #region Int

        [Test]
        public void Iint08_FullRange() {
            this.TestByteBits(this.GetSByteArray(sbyte.MinValue), sbyte.MinValue.ToString(), DataFormatEnum.Int_8bit);
            this.TestByteBits(this.GetSByteArray(0), "0", DataFormatEnum.Int_8bit);
            this.TestByteBits(this.GetSByteArray(sbyte.MaxValue), sbyte.MaxValue.ToString(), DataFormatEnum.Int_8bit);
        }


        [Test]
        public void Int08_Exponent() {
            byte value = 222;
            this.TestExp(value, -1);
            this.TestExp(value, -2);
            this.TestExp(value, 1);
            this.TestExp(value, 2);
        }


        [Test]
        public void Int12_FullRange() {
            this.TestByteBits(this.GetI16ByteArray(Int12.MinValue), Int12.MinValue.ToString(), DataFormatEnum.Int_12bit);
            this.TestByteBits(this.GetI16ByteArray(0), "0", DataFormatEnum.Int_12bit);
            this.TestByteBits(this.GetI16ByteArray(Int12.MaxValue), Int12.MaxValue.ToString(), DataFormatEnum.Int_12bit);
        }


        [Test]
        public void Int12_Masked() {
            this.TestByteBits(this.GetI16ByteArray(0xFFF), "4095", DataFormatEnum.Int_12bit);
        }



        [Test]
        public void Iint16_FullRange() {
            this.TestByteBits(this.GetI16ByteArray(31022), "31022", DataFormatEnum.Int_16bit);
            this.TestByteBits(this.GetI16ByteArray(0), "0", DataFormatEnum.Int_16bit);
            this.TestByteBits(this.GetI16ByteArray(-31022), "-31022", DataFormatEnum.Int_16bit);
        }


        [Test]
        public void Int16_NotEnoughBytes() {
            this.TestByteBits(this.GetByteArray(100), "1 byte(s) Data. Requires 2", DataFormatEnum.Int_16bit);
        }


        [Test]
        public void Int24_FullRange() {
            this.TestByteBits(this.Get24BitByteArray(Int24.MaxValue), Int24.MaxValue.ToString(), DataFormatEnum.Int_24bit);
            this.TestByteBits(this.Get24BitByteArray(3320), "3320", DataFormatEnum.Int_24bit);
            this.TestByteBits(this.Get24BitByteArray(0), "0", DataFormatEnum.Int_24bit);
            this.TestByteBits(this.Get24BitByteArray(-3320), "-3320", DataFormatEnum.Int_24bit);
            this.TestByteBits(this.Get24BitByteArray(Int24.MinValue), Int24.MinValue.ToString(), DataFormatEnum.Int_24bit);
        }

        // Signed 24 bit not supported
        //[Test]
        //public void Int24Exponent() {
        //    int value = 225411;
        //    this.TestExp24Bit(value, -1);
        //    this.TestExp24Bit(value, -2);
        //    this.TestExp24Bit(value, 1);
        //    this.TestExp24Bit(value, 2);
        //}

        [Test]
        public void Int24_NotEnoughBytes() {
            this.TestByteBits(this.GetByteArray(100), "1 byte(s) Data. Requires 3", DataFormatEnum.Int_24bit);
        }


        [Test]
        public void Int32_FullRange() {
            //-2,147,483,648 to 2,147,483,647
            this.TestByteBits(this.GetI32ByteArray(0), "0", DataFormatEnum.Int_32bit);
            this.TestByteBits(this.GetI32ByteArray(2147483645), "2147483645", DataFormatEnum.Int_32bit);
            this.TestByteBits(this.GetI32ByteArray(-2147483642), "-2147483642", DataFormatEnum.Int_32bit);
        }


        [Test]
        public void Int32_Exponent() {
            int value = 222;
            this.TestExp(value, -1);
            this.TestExp(value, -2);
            this.TestExp(value, 1);
            this.TestExp(value, 2);
        }

        [Test]
        public void Int48_FullRange() {
            this.TestByteBits(this.GetI64ByteArray(0), "Unhandled - Int 48bit:0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00", DataFormatEnum.Int_48bit);
            this.TestByteBits(this.GetI64ByteArray(14294967295), "Unhandled - Int 48bit:0xFF,0xE3,0x0B,0x54,0x03,0x00,0x00,0x00", DataFormatEnum.Int_48bit);
            this.TestByteBits(this.GetI64ByteArray(-14294967295), "Unhandled - Int 48bit:0x01,0x1C,0xF4,0xAB,0xFC,0xFF,0xFF,0xFF", DataFormatEnum.Int_48bit);
        }


        [Test]
        public void Int48_Masked() {
            this.TestByteBits(this.GetI64ByteArray(0xFFFFFFFFFFFFFF), "Unhandled - Int 48bit:0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00", DataFormatEnum.Int_48bit);
        }


        [Test]
        public void Int64_FullRange() {
            this.TestByteBits(this.GetI64ByteArray(0), "0", DataFormatEnum.Int_64bit);
            this.TestByteBits(this.GetI64ByteArray(9994294), "9994294", DataFormatEnum.Int_64bit);
            this.TestByteBits(this.GetI64ByteArray(-9994294), "-9994294", DataFormatEnum.Int_64bit);
        }

        [Test]
        public void Int64_Exponent() {
            long value = 99999;
            this.TestExp(value, -1);
            this.TestExp(value, -2);
            this.TestExp(value, 1);
            this.TestExp(value, 2);
        }


        [Test]
        public void Int128_Valid() {
            this.TestByteBits(this.GetI64ByteArray(9994294967290), "Unhandled - Int 128bit:0xFA,0xBB,0x66,0xFA,0x16,0x09,0x00,0x00", DataFormatEnum.Int_128bit);
        }

        #endregion

        #region Float Double

        [Test]
        public void Float32_FullRange() {
            this.TestByteBits(this.GetFloat32ByteArray(float.MinValue), float.MinValue.ToString(), DataFormatEnum.IEEE_754_32bit_floating_point);
            this.TestByteBits(this.GetFloat32ByteArray(0), "0", DataFormatEnum.IEEE_754_32bit_floating_point);
            this.TestByteBits(this.GetFloat32ByteArray(float.MaxValue), float.MaxValue.ToString(), DataFormatEnum.IEEE_754_32bit_floating_point);
        }


        [Test]
        public void Float64_FullRange() {
            this.TestByteBits(this.GetDouble64ByteArray(double.MinValue), double.MinValue.ToString(), DataFormatEnum.IEEE_754_64bit_floating_point);
            this.TestByteBits(this.GetDouble64ByteArray(0), "0", DataFormatEnum.IEEE_754_64bit_floating_point);
            this.TestByteBits(this.GetDouble64ByteArray(double.MaxValue), double.MaxValue.ToString(), DataFormatEnum.IEEE_754_64bit_floating_point);
        }


        [Test]
        public void Float32_IEEE_11073() {
            this.TestByteBits(this.GetFloat32ByteArray(0), "Unhandled - IEEE 11073 32bit FLOAT:0x00,0x00,0x00,0x00", DataFormatEnum.IEEE_11073_32bit_FLOAT);
        }


        [Test]
        public void Float16_IEEE_11073() {
            this.TestByteBits(this.GetU16ByteArray(0), "Unhandled - IEEE 11073 16bit SFLOAT:0x00,0x00", DataFormatEnum.IEEE_11073_16bit_SFLOAT);
        }


        [Test]
        public void IEE20601_FullRange() {
            // Two 16 bit uints in one 32 bit uint package
            this.TestByteBits(GetIEE60201ByteArray(UInt16.MinValue, UInt16.MinValue), "0|0", DataFormatEnum.IEEE_20601_format);
            this.TestByteBits(GetIEE60201ByteArray(UInt16.MaxValue, UInt16.MaxValue), 
                string.Format("{0}|{1}", UInt16.MaxValue, UInt16.MaxValue), DataFormatEnum.IEEE_20601_format);
            this.TestByteBits(GetIEE60201ByteArray(30021, 16201), "30021|16201", DataFormatEnum.IEEE_20601_format);
        }

        #endregion

        #region Actual NUnit tests

        public void TestByteBits(byte[] data, string expected, DataFormatEnum format) {
            TestHelpersNet.CatchUnexpected(() => {
                IDescParser parser = new DescParser_PresentationFormat();
                this.SetFormatDesc(this.GetBlock(format, UnitsOfMeasurement.Unitless));
                string result = this.defaultCharParser.Parse(data);
                this.log.Info("TestByteBits", () => string.Format("Value:'{0}'", result));
                Assert.AreEqual(expected, result);
            });
        }


        public void TestByteBits(byte[] data, string expected, DataFormatEnum format, sbyte exponent) {
            TestHelpersNet.CatchUnexpected(() => {
                IDescParser parser = new DescParser_PresentationFormat();
                byte[] descBlock = this.GetBlock(format, UnitsOfMeasurement.Unitless);
                this.SetExponent(descBlock, exponent);
                this.SetFormatDesc(descBlock);
                string result = this.defaultCharParser.Parse(data);
                this.log.Info("TestByteBits", () => string.Format("Value:'{0}'", result));
                Assert.AreEqual(expected, result);
            });
        }


        #endregion

        #region Helpers

        private void SetFormatDesc(byte[] data) {
            IDescParser formatParser = new DescParser_PresentationFormat();
            string result = formatParser.Parse(data);
            this.log.Info("SetFormatDesc", () => string.Format("Format Desc Display:{0}", result));
            List<IDescParser> descriptors = new List<IDescParser>();
            descriptors.Add(formatParser);
            BLEOperationStatus status = this.defaultCharParser.SetDescriptorParsers(descriptors);
            Assert.AreEqual(BLEOperationStatus.Success, status, "On set descriptor parsers");
        }

        #region Exponent tester

        private void TestExp(byte value, sbyte exponent) {
            string expected = value.Calculate(exponent, exponent).ToStr(exponent);
            this.TestByteBits(this.GetByteArray(value), expected, DataFormatEnum.UInt_8bit, exponent);
        }

        private void TestExp(sbyte value, sbyte exponent) {
            string expected = value.Calculate(exponent, exponent).ToStr(exponent);
            this.TestByteBits(this.GetSByteArray(value), expected, DataFormatEnum.Int_8bit, exponent);
        }

        // 12 bits
        private void TestExp12Bit(ushort value, sbyte exponent) {
            string expected = value.Calculate(exponent, exponent).ToStr(exponent);
            this.TestByteBits(this.GetU16ByteArray(value), expected, DataFormatEnum.UInt_12bit, exponent);
        }

        private void TestExp12Bit(short value, sbyte exponent) {
            string expected = value.Calculate(exponent, exponent).ToStr(exponent);
            this.TestByteBits(this.GetI16ByteArray(value), expected, DataFormatEnum.Int_12bit, exponent);
        }

        private void TestExp(ushort value, sbyte exponent) {
            string expected = value.Calculate(exponent, exponent).ToStr(exponent);
            this.TestByteBits(this.GetU16ByteArray(value), expected, DataFormatEnum.UInt_16bit, exponent);
        }

        private void TestExp(short value, sbyte exponent) {
            string expected = value.Calculate(exponent, exponent).ToStr(exponent);
            this.TestByteBits(this.GetI16ByteArray(value), expected, DataFormatEnum.Int_16bit, exponent);
        }

        // 24 bits
        private void TestExp24Bit(uint value, sbyte exponent) {
            string expected = value.Calculate(exponent, exponent).ToStr(exponent);
            this.TestByteBits(this.GetU32ByteArray(value), expected, DataFormatEnum.UInt_24bit, exponent);
        }

        private void TestExp24Bit(int value, sbyte exponent) {
            string expected = value.Calculate(exponent, exponent).ToStr(exponent);
            this.TestByteBits(this.GetI32ByteArray(value), expected, DataFormatEnum.Int_24bit, exponent);
        }

        private void TestExp(uint value, sbyte exponent) {
            string expected = value.Calculate(exponent, exponent).ToStr(exponent);
            this.TestByteBits(this.GetU32ByteArray(value), expected, DataFormatEnum.UInt_32bit, exponent);
        }

        private void TestExp(int value, sbyte exponent) {
            string expected = value.Calculate(exponent, exponent).ToStr(exponent);
            this.TestByteBits(this.GetI32ByteArray(value), expected, DataFormatEnum.Int_32bit, exponent);
        }

        // 48 bits

        private void TestExp48(ulong value, sbyte exponent) {
            string expected = value.Calculate(exponent, exponent).ToStr(exponent);
            this.TestByteBits(this.GetU64ByteArray(value), expected, DataFormatEnum.UInt_48bit, exponent);
        }

        private void TestExp48(long value, sbyte exponent) {
            string expected = value.Calculate(exponent, exponent).ToStr(exponent);
            this.TestByteBits(this.GetI64ByteArray(value), expected, DataFormatEnum.Int_48bit, exponent);
        }


        private void TestExp(ulong value, sbyte exponent) {
            string expected = value.Calculate(exponent, exponent).ToStr(exponent);
            this.TestByteBits(this.GetU64ByteArray(value), expected, DataFormatEnum.UInt_64bit, exponent);
        }

        private void TestExp(long value, sbyte exponent) {
            string expected = value.Calculate(exponent, exponent).ToStr(exponent);
            this.TestByteBits(this.GetI64ByteArray(value), expected, DataFormatEnum.Int_64bit, exponent);
        }


        #endregion

        #region GetBlock

        public byte[] GetBlock() {
            return this.GetBlock(DataFormatEnum.UInt_32bit, UnitsOfMeasurement.Unitless);
        }


        public byte[] GetBlock(DataFormatEnum formatEnum) {
            return this.GetBlock(formatEnum, UnitsOfMeasurement.Unitless);
        }


        public byte[] GetBlock(DataFormatEnum formatEnum, UnitsOfMeasurement units) {
            return this.GetBlock(formatEnum, units, 0);
        }


        public byte[] GetBlock(DataFormatEnum formatEnum, UnitsOfMeasurement units, sbyte exponent) {
            return this.GetBlock(formatEnum, units, exponent, 1, 0x221A);
        }


        public byte[] GetBlock(DataFormatEnum formatEnum, UnitsOfMeasurement units, sbyte exponent, byte nameSpace) {
            return this.GetBlock(formatEnum, units, exponent, nameSpace, 0x221A);
        }

        public byte[] GetBlock(DataFormatEnum formatEnum, UnitsOfMeasurement units, sbyte exponent, byte nameSpace, ushort description) {
            byte[] data = new byte[7];
            int pos = 0;
            formatEnum.ToByte().WriteToBuffer(data, ref pos);   // 0
            exponent.WriteToBuffer(data, ref pos);              // 1
            units.ToUint16().WriteToBuffer(data, ref pos);      // 2
            nameSpace.WriteToBuffer(data, ref pos);// namespace    4
            description.WriteToBuffer(data, ref pos);           // 5
            return data;
        }

        private void SetExponent(byte[] data, sbyte exp) {
            exp.WriteToBuffer(data, 1);
        }

        private void SetUnits(byte[] data, UnitsOfMeasurement units) {
            units.ToUint16().WriteToBuffer(data, 2);
        }



        #endregion

        #region GetByteArray

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


        byte[] GetU16ByteArray(ushort value) {
            int pos = 0;
            byte[] data = new byte[2];
            value.WriteToBuffer(data, ref pos);
            return data;
        }

        byte[] GetI16ByteArray(short value) {
            int pos = 0;
            byte[] data = new byte[2];
            value.WriteToBuffer(data, ref pos);
            return data;
        }

        byte[] GetU32ByteArray(uint value) {
            int pos = 0;
            byte[] data = new byte[4];
            value.WriteToBuffer(data, ref pos);
            return data;
        }

        byte[] GetI32ByteArray(int value) {
            int pos = 0;
            byte[] data = new byte[4];
            value.WriteToBuffer(data, ref pos);
            return data;
        }


        byte[] GetIEE60201ByteArray(UInt16 value1, UInt16 value2) {
            int pos = 0;
            byte[] data = new byte[4];
            value1.WriteToBuffer(data, ref pos);
            value2.WriteToBuffer(data, ref pos);
            return data;
        }



        byte[] Get24BitByteArray(int value) {
            return Int24.GetBytes(value);
        }



        byte[] GetU64ByteArray(ulong value) {
            int pos = 0;
            byte[] data = new byte[8];
            value.WriteToBuffer(data, ref pos);
            return data;
        }

        byte[] GetI64ByteArray(long value) {
            int pos = 0;
            byte[] data = new byte[8];
            value.WriteToBuffer(data, ref pos);
            return data;
        }


        byte[] GetFloat32ByteArray(float value) {
            int pos = 0;
            byte[] data = new byte[4];
            value.WriteToBuffer(data, ref pos);
            return data;
        }

        byte[] GetDouble64ByteArray(double value) {
            int pos = 0;
            byte[] data = new byte[8];
            value.WriteToBuffer(data, ref pos);
            return data;
        }

        #endregion

        #endregion
    }

}
