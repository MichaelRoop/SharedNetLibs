﻿using BluetoothLE.Net.Enumerations;
using BluetoothLE.Net.interfaces;
using BluetoothLE.Net.Parsers.Characteristics;
using BluetoothLE.Net.Parsers.Descriptor;
using LogUtils.Net;
using NUnit.Framework;
using System.Text;
using TestCaseSupport.Core;
using VariousUtils.Net;

namespace TestCases.Core.BLE.BLE_CharParsers {

    [TestFixture]
    public class Test13_DefaultParserWithAggregate : TestCaseBase {

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

        class TestData {
            public DataFormatEnum DataType { get; set; } = DataFormatEnum.Reserved0x00;
            public object Value { get; set; } = new object();
            public string Expected { get; set; } = string.Empty;

            public TestData() { }
            public TestData(DataFormatEnum dataType, object value, string expected) {
                this.DataType = dataType;
                this.Value = value;
                this.Expected = expected;
            }
        }


        private readonly ClassLog log = new ("Test13_DefaultParserWithAggregate");
        private readonly ICharParser defaultCharParser = new CharParser_Default();
        private readonly BLE_TestTools tools = new ();

        #endregion



        [Test]
        public void T01_ValidFormatCount() {
            TestHelpers.CatchUnexpected(() => {
                DescParser_CharacteristicAggregateFormat agg = new ();
                List<IDescParser> descriptors = new ();
                // Need to calculate size with all data 
                this.AddFormat(BLE_TestTools.GetBlock(DataFormatEnum.UInt_8bit), descriptors, agg);
                this.AddFormat(BLE_TestTools.GetBlock(DataFormatEnum.UInt_16bit), descriptors, agg);
                this.AddFormat(BLE_TestTools.GetBlock(DataFormatEnum.UInt_32bit), descriptors, agg);
                //int size = 0;
                //foreach (var f in descriptors) {
                //    size += f.RequiredBytes;
                //}
                descriptors.Add(agg);
                var status = this.defaultCharParser.SetDescriptorParsers(descriptors);
                Assert.AreEqual(BLEOperationStatus.Success, status, "On set descriptor parsers");
            });
        }


        [Test]
        public void T02_MissingFormat() {
            TestHelpers.CatchUnexpected(() => {
                DescParser_CharacteristicAggregateFormat agg = new ();
                List<IDescParser> descriptors = new ();
                this.AddFormat(BLE_TestTools.GetBlock(DataFormatEnum.UInt_8bit), descriptors, agg);
                this.AddFormat(BLE_TestTools.GetBlock(DataFormatEnum.UInt_16bit), descriptors, agg);
                agg.AttributeHandles.Add(0xF000);
                descriptors.Add(agg);
                var status = this.defaultCharParser.SetDescriptorParsers(descriptors);
                Assert.AreEqual(BLEOperationStatus.AggregateFormatMissingFormats, status, "On set descriptor parsers");
            });
        }


        [Test]
        public void T03_HandleNotFormat() {
            TestHelpers.CatchUnexpected(() => {
                DescParser_CharacteristicAggregateFormat agg = new ();
                List<IDescParser> descriptors = new ();
                this.AddFormat(BLE_TestTools.GetBlock(DataFormatEnum.UInt_8bit), descriptors, agg);
                this.AddFormat(BLE_TestTools.GetBlock(DataFormatEnum.UInt_16bit), descriptors, agg);
                // this will be number 3
                byte[] data = new byte[] { 1 };
                DescParser_Default def = new () { AttributeHandle = 0x3 };
                def.Parse(data);
                descriptors.Add(def);
                agg.AttributeHandles.Add(def.AttributeHandle);
                descriptors.Add(agg);
                var status = this.defaultCharParser.SetDescriptorParsers(descriptors);
                Assert.AreEqual(BLEOperationStatus.AggregateFormatHandleNotFormatType, status, "On set wrong descriptor type");
            });
        }


        [Test]
        public void T04_DuplicateFormat() {
            TestHelpers.CatchUnexpected(() => {
                DescParser_CharacteristicAggregateFormat agg = new ();
                List<IDescParser> descriptors = new ();
                this.AddFormat(BLE_TestTools.GetBlock(DataFormatEnum.UInt_8bit), descriptors, agg);
                this.AddFormat(BLE_TestTools.GetBlock(DataFormatEnum.UInt_16bit), descriptors, agg);
                descriptors[1].AttributeHandle = descriptors[0].AttributeHandle;
                descriptors.Add(agg);
                var status = this.defaultCharParser.SetDescriptorParsers(descriptors);
                Assert.AreEqual(BLEOperationStatus.AggregateFormatDuplicateFormats, status, "Duplicates");
            });
        }


        [Test]
        public void T10_MultiUints() {
            List<TestData> td = new ();
            td.Add(new TestData(DataFormatEnum.UInt_8bit, (byte)25, "25"));
            td.Add(new TestData(DataFormatEnum.UInt_16bit, (UInt16)12555, "12555"));
            td.Add(new TestData(DataFormatEnum.UInt_32bit, (UInt32)3453453425, "3453453425"));
            td.Add(new TestData(DataFormatEnum.UInt_64bit, (UInt64)8905279859573, "8905279859573"));
            this.ProcessMultiple(td);
        }

        [Test]
        public void T11_MultiInts() {
            List<TestData> td = new ();
            td.Add(new TestData(DataFormatEnum.Int_8bit, (sbyte)25, "25"));
            td.Add(new TestData(DataFormatEnum.Int_16bit, (Int16)(12555), "12555"));
            td.Add(new TestData(DataFormatEnum.Int_32bit, (Int32)(34426565), "34426565"));
            td.Add(new TestData(DataFormatEnum.Int_64bit, (Int64)(8905279859573), "8905279859573"));
            td.Add(new TestData(DataFormatEnum.Int_8bit, (sbyte)-25, "-25"));
            td.Add(new TestData(DataFormatEnum.Int_16bit, (Int16)(-12555), "-12555"));
            td.Add(new TestData(DataFormatEnum.Int_32bit, (Int32)(-34426565), "-34426565"));
            td.Add(new TestData(DataFormatEnum.Int_64bit, (Int64)(-8905279859573), "-8905279859573"));
            this.ProcessMultiple(td);
        }


        [Test]
        public void T12_Floats() {
            List<TestData> td = new ();
            td.Add(new TestData(DataFormatEnum.IEEE_754_32bit_floating_point, (float)25.5, "25.5"));
            td.Add(new TestData(DataFormatEnum.IEEE_754_64bit_floating_point, (double)12555.324, "12555.324"));
            this.ProcessMultiple(td);
        }




        [Test]
        public void T15_NumericMinMax() {
            List<TestData> td = new ();
            td.Add(new TestData(DataFormatEnum.UInt_8bit, Byte.MinValue, Byte.MinValue.ToString()));
            td.Add(new TestData(DataFormatEnum.UInt_8bit, Byte.MaxValue, Byte.MaxValue.ToString()));
            td.Add(new TestData(DataFormatEnum.UInt_16bit, UInt16.MinValue, UInt16.MinValue.ToString()));
            td.Add(new TestData(DataFormatEnum.UInt_16bit, UInt16.MaxValue, UInt16.MaxValue.ToString()));
            td.Add(new TestData(DataFormatEnum.UInt_32bit, UInt32.MinValue, UInt32.MinValue.ToString()));
            td.Add(new TestData(DataFormatEnum.UInt_32bit, UInt32.MaxValue, UInt32.MaxValue.ToString()));
            td.Add(new TestData(DataFormatEnum.UInt_64bit, UInt64.MinValue, UInt64.MinValue.ToString()));
            td.Add(new TestData(DataFormatEnum.UInt_64bit, UInt64.MaxValue, UInt64.MaxValue.ToString()));

            td.Add(new TestData(DataFormatEnum.Int_8bit, SByte.MinValue, SByte.MinValue.ToString()));
            td.Add(new TestData(DataFormatEnum.Int_8bit, SByte.MaxValue, SByte.MaxValue.ToString()));
            td.Add(new TestData(DataFormatEnum.Int_16bit, Int16.MinValue, Int16.MinValue.ToString()));
            td.Add(new TestData(DataFormatEnum.Int_16bit, Int16.MaxValue, Int16.MaxValue.ToString()));
            td.Add(new TestData(DataFormatEnum.Int_32bit, Int32.MinValue, Int32.MinValue.ToString()));
            td.Add(new TestData(DataFormatEnum.Int_32bit, Int32.MaxValue, Int32.MaxValue.ToString()));
            td.Add(new TestData(DataFormatEnum.Int_64bit, Int64.MinValue, Int64.MinValue.ToString()));
            td.Add(new TestData(DataFormatEnum.Int_64bit, Int64.MaxValue, Int64.MaxValue.ToString()));
            this.ProcessMultiple(td);
        }





        private void AddFormat(byte[] data, List<IDescParser> descriptors, DescParser_CharacteristicAggregateFormat agg) {
            UInt16 handle = 1;
            if (agg.AttributeHandles.Count > 0) {
                handle = (UInt16)(agg.AttributeHandles[^1] + 1);
            }
            IDescParser formatParser = new DescParser_PresentationFormat() {
                AttributeHandle = handle,
            };
            string result = formatParser.Parse(data);
            this.log.Info("AddFormat", () => string.Format("Format Desc Display:{0}", result));
            descriptors.Add(formatParser);
            agg.AttributeHandles.Add(handle);
        }



        private void ProcessMultiple(List<TestData> testData) {
            UInt16 handle = 1;
            List<IDescParser> descriptors = new ();
            DescParser_CharacteristicAggregateFormat agg = 
                new ();

            int bytesRequired = 0;
            foreach (TestData td in testData) {
                descriptors.Add(this.AddDescriptor(handle, td.DataType, agg));
                handle++;
                bytesRequired += td.DataType.BytesRequired();
            }
            descriptors.Add(agg);
            var status = this.defaultCharParser.SetDescriptorParsers(descriptors);
            Assert.AreEqual(BLEOperationStatus.Success, status, "Process multiple");

            // Create block for Descriptor to parse
            byte[] data = new byte[bytesRequired];
            string expected = BuildResults(data, testData);
            string result = this.defaultCharParser.Parse(data);
            Assert.AreEqual(expected, result);
        }


        private IDescParser AddDescriptor(UInt16 handle, DataFormatEnum dataType, DescParser_CharacteristicAggregateFormat agg) {
            IDescParser p = new DescParser_PresentationFormat() {
                AttributeHandle = handle,
            };
            p.Parse(BLE_TestTools.GetBlock(dataType));
            agg.AttributeHandles.Add(p.AttributeHandle);
            return p;
        }


        private static string BuildResults(byte[] data, List<TestData> testData) {
            int pos = 0;
            StringBuilder sb = new ();
            foreach(var td in testData) {
                if (pos > 0) {
                    sb.Append("  |  ");
                }
                sb.Append(td.Expected);
                Write(td, data, ref pos);
            }
            return sb.ToString();
        }

        #region PopulateByteArray

        static void Write(TestData testData, byte[] data, ref int pos) {
            switch (testData.DataType) {
                #region Uint
                case DataFormatEnum.Boolean:
                    break;
                case DataFormatEnum.UInt_2bit:
                    break;
                case DataFormatEnum.UInt_4bit:
                    break;
                case DataFormatEnum.UInt_8bit:
                    Write((byte)testData.Value, data, ref pos);
                    break;
                case DataFormatEnum.UInt_12bit:
                    break;
                case DataFormatEnum.UInt_16bit:
                    Write((UInt16)testData.Value, data, ref pos);
                    break;
                case DataFormatEnum.UInt_24bit:
                    break;
                case DataFormatEnum.UInt_32bit:
                    Write((UInt32)testData.Value, data, ref pos);
                    break;
                case DataFormatEnum.UInt_48bit:
                    break;
                case DataFormatEnum.UInt_64bit:
                    Write((UInt64)(testData.Value), data, ref pos);
                    break;
                case DataFormatEnum.UInt_128bit:
                    break;
                #endregion
                #region Int
                case DataFormatEnum.Int_8bit:
                    Write((sbyte)testData.Value, data, ref pos);
                    break;
                case DataFormatEnum.Int_12bit:
                    break;
                case DataFormatEnum.Int_16bit:
                    Write((Int16)testData.Value, data, ref pos);
                    break;
                case DataFormatEnum.Int_24bit:
                    break;
                case DataFormatEnum.Int_32bit:
                    Write((Int32)testData.Value, data, ref pos);
                    break;
                case DataFormatEnum.Int_48bit:
                    break;
                case DataFormatEnum.Int_64bit:
                    Write((Int64)testData.Value, data, ref pos);
                    break;
                case DataFormatEnum.Int_128bit:
                    break;
                #endregion
                #region Float
                case DataFormatEnum.IEEE_754_32bit_floating_point:
                    Write((float)testData.Value, data, ref pos);
                    break;
                case DataFormatEnum.IEEE_754_64bit_floating_point:
                    Write((double)testData.Value, data, ref pos);
                    break;
                case DataFormatEnum.IEEE_11073_16bit_SFLOAT:
                    break;
                case DataFormatEnum.IEEE_11073_32bit_FLOAT:
                    break;
                #endregion
                #region Strings
                case DataFormatEnum.IEEE_20601_format:
                    break;
                case DataFormatEnum.UTF8_String:
                    break;
                case DataFormatEnum.UTF16_String:
                    break;
                #endregion
                #region Not handled
                case DataFormatEnum.Reserved0x00:
                case DataFormatEnum.OpaqueStructure:
                case DataFormatEnum.Unhandled:
                    break;
                #endregion

            }
        }

        static void Write(byte value, byte[] data, ref int pos) {
            value.WriteToBuffer(data, ref pos);
        }

        static void Write(sbyte value, byte[] data, ref int pos) {
            value.WriteToBuffer(data, ref pos);
        }

        static void Write(ushort value, byte[] data, ref int pos) {
            value.WriteToBuffer(data, ref pos);
        }

        static void Write(short value, byte[] data, ref int pos) {
            value.WriteToBuffer(data, ref pos);
        }

        static void Write(uint value, byte[] data, ref int pos) {
            value.WriteToBuffer(data, ref pos);
        }

        static void Write(int value, byte[] data, ref int pos) {
            value.WriteToBuffer(data, ref pos);
        }


        //byte[] GetIEE60201ByteArray(UInt16 value1, UInt16 value2) {
        //    int pos = 0;
        //    byte[] data = new byte[4];
        //    value1.WriteToBuffer(data, ref pos);
        //    value2.WriteToBuffer(data, ref pos);
        //    return data;
        //}



        //byte[] Get24BitByteArray(int value) {
        //    byte[] tmp = new byte[4];
        //    //////https://stackoverflow.com/questions/12549197/are-there-any-int24-implementations-in-c
        //    ////// only works for unsigned   
        //    //data[0] = (byte)((value) & 0xFF);
        //    //data[1] = (byte)((value >> 8) & 0xFF);
        //    //data[2] = (byte)((value >> 16) & 0xFF);

        //    byte[] data = new byte[3];


        //    int pos = 0;
        //    value.WriteToBuffer(tmp, ref pos);
        //    Array.Copy(tmp, 0, data, 0, 3);

        //    //----------------------------------
        //    //int four = tmp.ToInt32(0);
        //    ////int three = 

        //    //byte[] otherEnd = new byte[4];
        //    //Array.Copy(data, 0, otherEnd, 0, 3);
        //    //if (data[2] == 0xFF) {
        //    //    otherEnd[3] = 0xFF;
        //    //}
        //    //pos = 0;
        //    //// works!!
        //    //int reconvert = otherEnd.ToInt32(ref pos);
        //    //----------------------------------




        //    //−8,388,608 to 8,388,607

        //    //int tmp = value;
        //    //if (value < 0) {
        //    //    tmp = (value << 12);
        //    //}

        //    //(value & 0xFFFFFF).WriteToBuffer(data, ref pos);
        //    return data;
        //}


        static void Write(ulong value, byte[] data, ref int pos) {
            value.WriteToBuffer(data, ref pos);
        }

        static void Write(long value, byte[] data, ref int pos) {
            value.WriteToBuffer(data, ref pos);
        }

        static void Write(float value, byte[] data, ref int pos) {
            value.WriteToBuffer(data, ref pos);
        }

        static void Write(double value, byte[] data, ref int pos) {
            value.WriteToBuffer(data, ref pos);
        }

        #endregion







    }
}
