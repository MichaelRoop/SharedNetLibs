﻿using BluetoothLE.Net.Enumerations;
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
        public void Uint2Bit() {
            this.TestByteBits(this.GetByteArray(3), "3", DataFormatEnum.UInt_2bit);
        }


        [Test]
        public void Uint2BitBitsMaskedOut() {
            this.TestByteBits(this.GetByteArray(15), "3", DataFormatEnum.UInt_2bit);
        }


        [Test]
        public void Uint4Bit() {
            this.TestByteBits(this.GetByteArray(14), "14", DataFormatEnum.UInt_4bit);
        }

        [Test]
        public void Uint4BitBitsMaskedOut() {
            this.TestByteBits(this.GetByteArray(255), "15", DataFormatEnum.UInt_4bit);
        }

        [Test]
        public void Uint8Bit() {
            this.TestByteBits(this.GetByteArray(222), "222", DataFormatEnum.UInt_8bit);
        }


        [Test]
        public void Uint12Bit() {
            this.TestByteBits(this.GetU16ByteArray(4094), "4094", DataFormatEnum.UInt_16bit);
        }


        [Test]
        public void Uint12BitMasked() {
            this.TestByteBits(this.GetU16ByteArray(0xAFFF), "4095", DataFormatEnum.UInt_12bit);
        }



        [Test]
        public void Uint16Bit() {
            this.TestByteBits(this.GetU16ByteArray(62022), "62022", DataFormatEnum.UInt_16bit);
        }

        [Test]
        public void Uint16BitNotEnoughBytes() {
            this.TestByteBits(this.GetByteArray(100), "1 byte(s) Data. Requires 2", DataFormatEnum.UInt_16bit);
        }


        [Test]
        public void Uint24Bit() {
            this.TestByteBits(this.GetU32ByteArray(0xFFFFF1), "16777201", DataFormatEnum.UInt_24bit);
        }


        [Test]
        public void Uint24BitNotEnoughBytes() {
            this.TestByteBits(this.GetByteArray(100), "1 byte(s) Data. Requires 3", DataFormatEnum.UInt_24bit);
        }


        [Test]
        public void Uint24BitMasked() {
            this.TestByteBits(this.GetU32ByteArray(0xFFFFFFFF), "16777215", DataFormatEnum.UInt_24bit);
        }

        [Test]
        public void Uint32() {
            this.TestByteBits(this.GetU32ByteArray(4294967290), "4294967290", DataFormatEnum.UInt_32bit);
        }

        [Test]
        public void Uint48() {
            this.TestByteBits(this.GetU64ByteArray(14294967295), "14294967295", DataFormatEnum.UInt_48bit);
        }

        [Test]
        public void Uint48Masked() {
            this.TestByteBits(this.GetU64ByteArray(0xFFFFFFFFFFFFFF), "281474976710655", DataFormatEnum.UInt_48bit);
        }


        [Test]
        public void Uint64() {
            this.TestByteBits(this.GetU64ByteArray(9994294967290), "9994294967290", DataFormatEnum.UInt_64bit);
        }


        // Not supported
        //[Test]
        public void Uint128() {
            this.TestByteBits(this.GetU64ByteArray(9994294967290), "9994294967290", DataFormatEnum.UInt_128bit);
        }

        #endregion

        #region Int

        [Test]
        public void Iint8BitFullRange() {
            this.TestByteBits(this.GetSByteArray(sbyte.MinValue), sbyte.MinValue.ToString(), DataFormatEnum.Int_8bit);
            this.TestByteBits(this.GetSByteArray(0), "0", DataFormatEnum.Int_8bit);
            this.TestByteBits(this.GetSByteArray(sbyte.MaxValue), sbyte.MaxValue.ToString(), DataFormatEnum.Int_8bit);
        }


        [Test]
        public void Int12BitFullRange() {
            this.TestByteBits(this.GetI16ByteArray(-4096), "-4096", DataFormatEnum.Int_12bit);
            this.TestByteBits(this.GetI16ByteArray(0), "0", DataFormatEnum.Int_12bit);
            this.TestByteBits(this.GetI16ByteArray(4095), "4095", DataFormatEnum.Int_12bit);
        }


        [Test]
        public void Int12BitMasked() {
            this.TestByteBits(this.GetI16ByteArray(0xFFF), "4095", DataFormatEnum.Int_12bit);
        }



        [Test]
        public void Iint16BitFullRange() {
            this.TestByteBits(this.GetI16ByteArray(31022), "31022", DataFormatEnum.Int_16bit);
            this.TestByteBits(this.GetI16ByteArray(0), "0", DataFormatEnum.Int_16bit);
            this.TestByteBits(this.GetI16ByteArray(-31022), "-31022", DataFormatEnum.Int_16bit);
        }


        [Test]
        public void Int16BitNotEnoughBytes() {
            this.TestByteBits(this.GetByteArray(100), "1 byte(s) Data. Requires 2", DataFormatEnum.Int_16bit);
        }


        [Test]
        public void Int24BitFullRange() {
            // −8,388,608 to 8,388,607
            this.TestByteBits(this.Get24BitByteArray(0), "Unhandled - Int 24bit:0x00,0x00,0x00", DataFormatEnum.Int_24bit);
            this.TestByteBits(this.Get24BitByteArray(8388607), "Unhandled - Int 24bit:0xFF,0xFF,0x7F", DataFormatEnum.Int_24bit);
            this.TestByteBits(this.Get24BitByteArray(-8388605), "Unhandled - Int 24bit:0x03,0x00,0x80", DataFormatEnum.Int_24bit);
        }

        [Test]
        public void Int24BitNotEnoughBytes() {
            this.TestByteBits(this.GetByteArray(100), "Unhandled - Int 24bit:0x64", DataFormatEnum.Int_24bit);
        }

        [Test]
        public void Int24BitMasked() {
            this.TestByteBits(this.GetI32ByteArray(0xFFFFFFF), "Unhandled - Int 24bit:0xFF,0xFF,0xFF,0x0F", DataFormatEnum.Int_24bit);
        }

        [Test]
        public void Int32FullRange() {
            //-2,147,483,648 to 2,147,483,647
            this.TestByteBits(this.GetI32ByteArray(0), "0", DataFormatEnum.Int_32bit);
            this.TestByteBits(this.GetI32ByteArray(2147483645), "2147483645", DataFormatEnum.Int_32bit);
            this.TestByteBits(this.GetI32ByteArray(-2147483642), "-2147483642", DataFormatEnum.Int_32bit);
        }


        [Test]
        public void Int48FullRange() {
            this.TestByteBits(this.GetI64ByteArray(0), "Unhandled - Int 48bit:0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00", DataFormatEnum.Int_48bit);
            this.TestByteBits(this.GetI64ByteArray(14294967295), "Unhandled - Int 48bit:0xFF,0xE3,0x0B,0x54,0x03,0x00,0x00,0x00", DataFormatEnum.Int_48bit);
            this.TestByteBits(this.GetI64ByteArray(-14294967295), "Unhandled - Int 48bit:0x01,0x1C,0xF4,0xAB,0xFC,0xFF,0xFF,0xFF", DataFormatEnum.Int_48bit);
        }


        [Test]
        public void Int48Masked() {
            this.TestByteBits(this.GetI64ByteArray(0xFFFFFFFFFFFFFF), "Unhandled - Int 48bit:0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0xFF,0x00", DataFormatEnum.Int_48bit);
        }


        [Test]
        public void Int64FullRange() {
            this.TestByteBits(this.GetI64ByteArray(0), "0", DataFormatEnum.Int_64bit);
            this.TestByteBits(this.GetI64ByteArray(9994294), "9994294", DataFormatEnum.Int_64bit);
            this.TestByteBits(this.GetI64ByteArray(-9994294), "-9994294", DataFormatEnum.Int_64bit);
        }


        [Test]
        public void Int128() {
            this.TestByteBits(this.GetI64ByteArray(9994294967290), "Unhandled - Int 128bit:0xFA,0xBB,0x66,0xFA,0x16,0x09,0x00,0x00", DataFormatEnum.Int_128bit);
        }

        #endregion

        #region Float Double

        [Test]
        public void Float32BitFullRange() {
            this.TestByteBits(this.GetFloat32ByteArray(float.MinValue), float.MinValue.ToString(), DataFormatEnum.IEEE_754_32bit_floating_point);
            this.TestByteBits(this.GetFloat32ByteArray(0), "0", DataFormatEnum.IEEE_754_32bit_floating_point);
            this.TestByteBits(this.GetFloat32ByteArray(float.MaxValue), float.MaxValue.ToString(), DataFormatEnum.IEEE_754_32bit_floating_point);
        }


        [Test]
        public void Double64BitFullRange() {
            this.TestByteBits(this.GetDouble64ByteArray(double.MinValue), double.MinValue.ToString(), DataFormatEnum.IEEE_754_64bit_floating_point);
            this.TestByteBits(this.GetDouble64ByteArray(0), "0", DataFormatEnum.IEEE_754_64bit_floating_point);
            this.TestByteBits(this.GetDouble64ByteArray(double.MaxValue), double.MaxValue.ToString(), DataFormatEnum.IEEE_754_64bit_floating_point);
        }


        [Test]
        public void Float32Bit_IEEE_11073() {
            this.TestByteBits(this.GetFloat32ByteArray(0), "Unhandled - IEEE 11073 32bit FLOAT:0x00,0x00,0x00,0x00", DataFormatEnum.IEEE_11073_32bit_FLOAT);
        }


        [Test]
        public void Float16Bit_IEEE_11073() {
            this.TestByteBits(this.GetU16ByteArray(0), "Unhandled - IEEE 11073 16bit SFLOAT:0x00,0x00", DataFormatEnum.IEEE_11073_16bit_SFLOAT);
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


        #endregion

        #region Helpers

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
            return this.GetBlock(DataFormatEnum.UInt_32bit, UnitsOfMeasurement.LengthMetre);
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

        byte[] Get24BitByteArray(int value) {
            byte[] tmp = new byte[4];
            //////https://stackoverflow.com/questions/12549197/are-there-any-int24-implementations-in-c
            ////// only works for unsigned   
            //data[0] = (byte)((value) & 0xFF);
            //data[1] = (byte)((value >> 8) & 0xFF);
            //data[2] = (byte)((value >> 16) & 0xFF);

            byte[] data = new byte[3];


            int pos = 0;
            value.WriteToBuffer(tmp, ref pos);
            Array.Copy(tmp, 0, data, 0, 3);

            //----------------------------------
            //int four = tmp.ToInt32(0);
            ////int three = 

            //byte[] otherEnd = new byte[4];
            //Array.Copy(data, 0, otherEnd, 0, 3);
            //if (data[2] == 0xFF) {
            //    otherEnd[3] = 0xFF;
            //}
            //pos = 0;
            //// works!!
            //int reconvert = otherEnd.ToInt32(ref pos);
            //----------------------------------




            //−8,388,608 to 8,388,607

            //int tmp = value;
            //if (value < 0) {
            //    tmp = (value << 12);
            //}

            //(value & 0xFFFFFF).WriteToBuffer(data, ref pos);
            return data;
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