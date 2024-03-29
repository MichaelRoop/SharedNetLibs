﻿using BluetoothLE.Net.Enumerations;
using BluetoothLE.Net.interfaces;
using BluetoothLE.Net.Parsers.Descriptor;
using LogUtils.Net;
using NUnit.Framework;
using TestCaseSupport.Core;
using VariousUtils.Net;

namespace TestCases.Core.BLE.BLE_DescParsers {

    [TestFixture]
    public class Test07_DescFormatParser : TestCaseBase {

        private readonly ClassLog log = new ("DescFormatParserTest");

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
        public void FormatParseValuesChecked() {
            TestHelpers.CatchUnexpected(() => {
                IDescParser parser = new DescParser_PresentationFormat();
                byte[] data = new byte[7];
                byte format = DataFormatEnum.UInt_32bit.ToByte();
                byte exponent = 33;
                byte nameSpace = 1;
                ushort description = 0x221A;
                int pos = 0;
                format.WriteToBuffer(data, ref pos);
                exponent.WriteToBuffer(data, ref pos);
                UnitsOfMeasurement.LengthMetre.ToUint16().WriteToBuffer(data, ref pos);
                nameSpace.WriteToBuffer(data, ref pos);
                description.WriteToBuffer(data, ref pos);

                string result = parser.Parse(data);
                this.log.Info("FormatValuesChecked", () => string.Format("Display:{0}", result));
                Assert.IsTrue(parser is DescParser_PresentationFormat);
                DescParser_PresentationFormat? impl = parser as DescParser_PresentationFormat;
                Assert.IsNotNull(impl, "Is null on cast");
                if (impl == null) { return; }// for compiler
                Assert.AreEqual(DataFormatEnum.UInt_32bit, impl.Format);
                Assert.AreEqual(exponent, impl.Exponent);
                Assert.AreEqual(UnitsOfMeasurement.LengthMetre, impl.MeasurementUnitsEnum);
                Assert.AreEqual(UnitsOfMeasurement.LengthMetre.ToUint16(), impl.MeasurementUnitUShort);
                Assert.AreEqual(nameSpace, impl.Namespace);
                Assert.AreEqual(description, impl.Description);
            });
        }




        [Test]
        public void Err13340_FormatParseDataBadFormat() {
            TestHelpers.CatchUnexpected(() => {
                IDescParser parser = new DescParser_PresentationFormat();
                byte[] data = GetBlock();
                // Bogus format
                data[0] = 245;  // Bogus Format at position 0
                string result = parser.Parse(data);
                this.logReader.Validate(13340,
                    "DescParser_PresentationFormat", "GetFormat", "Format:245 not handled");
            });
        }


        [Test]
        public void Err13341_FormatParseDataBadUnit() {
            TestHelpers.CatchUnexpected(() => {
                IDescParser parser = new DescParser_PresentationFormat();
                byte[] data = GetBlock();
                int pos = 2;
                ((ushort)0xFFF0).WriteToBuffer(data, ref pos); // Bogus measurement unit at pos 2,3
                string result = parser.Parse(data);
                this.logReader.Validate(13341,
                    "DescParser_PresentationFormat", "GetUnitOfMeasurement", "value 0xFFF0 not found in enums");
            });
        }



        #region GetBlock

        private static byte[] GetBlock() {
            return GetBlock(DataFormatEnum.UInt_32bit, UnitsOfMeasurement.LengthMetre);
        }


        //private static byte[] GetBlock(DataFormatEnum formatEnum) {
        //    return GetBlock(formatEnum, UnitsOfMeasurement.LengthMetre, 0);
        //}


        private static byte[] GetBlock(DataFormatEnum formatEnum, UnitsOfMeasurement units) {
            return GetBlock(formatEnum, units, 0);
        }


        private static byte[] GetBlock(DataFormatEnum formatEnum, UnitsOfMeasurement units, byte exponent) {
            return GetBlock(formatEnum, units, exponent, 1, 0x221A);
        }


        //private static byte[] GetBlock(DataFormatEnum formatEnum, UnitsOfMeasurement units, byte exponent, byte nameSpace) {
        //    return GetBlock(formatEnum, units, exponent, nameSpace, 0x221A);
        //}

        private static byte[] GetBlock(DataFormatEnum formatEnum, UnitsOfMeasurement units, byte exponent, byte nameSpace, ushort description) {
            byte[] data = new byte[7];
            //ushort description = 0x221A;

            int pos = 0;
            formatEnum.ToByte().WriteToBuffer(data, ref pos);
            exponent.WriteToBuffer(data, ref pos);
            units.ToUint16().WriteToBuffer(data, ref pos);
            nameSpace.WriteToBuffer(data, ref pos); // namespace
            description.WriteToBuffer(data, ref pos);
            return data;
        }

        #endregion
    }
}
