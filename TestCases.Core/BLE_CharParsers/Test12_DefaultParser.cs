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

        ClassLog log = new ClassLog("DescFormatParserTest");


        #endregion

        #region Test helpers

        [Test]
        public void WithDefaultChar_FormatString() {
            TestHelpersNet.CatchUnexpected(() => {
                IDescParser parser = new DescParser_PresentationFormat();
                byte[] data = this.GetBlock(DataFormatEnum.UTF8_String, UnitsOfMeasurement.Unitless);
                string result = parser.Parse(data);
                this.log.Info("WithDefaultChar_FormatString",
                    () => string.Format("Format Desc Display:{0}", result));

                List<IDescParser> descriptors = new List<IDescParser>();
                descriptors.Add(parser);

                ICharParser charParser = new CharParser_Default();
                charParser.SetDescriptorParsers(descriptors);

                string str = "This is a sample string for formating";
                result = charParser.Parse(Encoding.UTF8.GetBytes(str));
                this.log.Info("WithDefaultChar_FormatString",
                    () => string.Format("Default Char Display '{0}'", result));
                Assert.AreEqual(str, result);

            });
        }



        #endregion

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

        #endregion



    }

}
