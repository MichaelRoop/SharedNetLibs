using BluetoothLE.Net.Enumerations;
using BluetoothLE.Net.interfaces;
using BluetoothLE.Net.Parsers.Descriptor;
using LogUtils.Net;
using NUnit.Framework;
using System;
using VariousUtils.Net;

namespace TestCases.BLE_DescParsers {

    [TestFixture]
    public class Test07_DescFormatParser : TestCaseBase {

        ClassLog log = new ClassLog("DescFormatParserTest");

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
            TestHelpersNet.CatchUnexpected(() => {
                IDescParser parser = new DescParser_PresentationFormat();
                byte[] data = new byte[7];
                byte format = DataFormatEnum.unsigned_32bit_integer.ToByte();
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
                Assert.IsTrue(parser.ImplementationType == typeof(DescParser_PresentationFormat));
                DescParser_PresentationFormat impl = parser as DescParser_PresentationFormat;
                Assert.IsNotNull(impl, "Is null on cast");
                Assert.AreEqual(DataFormatEnum.unsigned_32bit_integer, impl.Format);
                Assert.AreEqual(exponent, impl.Exponent);
                Assert.AreEqual(UnitsOfMeasurement.LengthMetre, impl.MeasurementUnitsEnum);
                Assert.AreEqual(UnitsOfMeasurement.LengthMetre.ToUint16(), impl.MeasurementUnitUShort);
                Assert.AreEqual(nameSpace, impl.Namespace);
                Assert.AreEqual(description, impl.Description);
            });
        }


        byte[] GetBlock() {
            byte[] data = new byte[7];
            byte format = DataFormatEnum.unsigned_32bit_integer.ToByte();
            byte exponent = 33;
            byte nameSpace = 1;
            ushort description = 0x221A;

            int pos = 0;
            format.WriteToBuffer(data, ref pos);
            exponent.WriteToBuffer(data, ref pos);
            UnitsOfMeasurement.LengthMetre.ToUint16().WriteToBuffer(data, ref pos);
            nameSpace.WriteToBuffer(data, ref pos);
            description.WriteToBuffer(data, ref pos);
            return data;
        }


        [Test]
        public void Err13340_FormatParseDataBadFormat() {
            TestHelpersNet.CatchUnexpected(() => {
                IDescParser parser = new DescParser_PresentationFormat();
                byte[] data = this.GetBlock();
                // Bogus format
                data[0] = 245;  // Bogus Format at position 0
                string result = parser.Parse(data);
                this.logReader.Validate(13340,
                    "DescParser_PresentationFormat", "GetFormat", "Format:245 not handled");
            });
        }


        [Test]
        public void Err13341_FormatParseDataBadUnit() {
            TestHelpersNet.CatchUnexpected(() => {
                IDescParser parser = new DescParser_PresentationFormat();
                byte[] data = this.GetBlock();
                int pos = 2;
                ((ushort)0xFFF0).WriteToBuffer(data, ref pos); // Bogus measurement unit at pos 2,3
                string result = parser.Parse(data);
                this.logReader.Validate(13341,
                    "DescParser_PresentationFormat", "GetUnitOfMeasurement", "value 0xFFF0 not found in enums");
            });
        }






        //TestHelpersNet.CatchUnexpected(() => {
        //    });



    }
}
