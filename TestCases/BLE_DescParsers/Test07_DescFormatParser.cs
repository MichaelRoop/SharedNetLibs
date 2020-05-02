using BluetoothLE.Net.Enumerations;
using BluetoothLE.Net.interfaces;
using BluetoothLE.Net.Parsers.Descriptor;
using LogUtils.Net;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                data[0] = 8;  // Format  DataFormatEnum.unsigned_32bit_integer
                data[1] = 33; // Exponent
                // TODO - look at how the data comes in from BLE
                data[2] = 0x01; // 0x2701 UnitsOfMeasurement.LengthMetre - least significant byte then most significant
                data[3] = 0x27;
                data[4] = 1;    // Namespace
                data[5] = 0x1A; // Uint16 Description
                data[6] = 0x22;

                string result = parser.Parse(data);
                this.log.Info("FormatValuesChecked", () => string.Format("Display:{0}", result));
                Assert.IsTrue(parser.ImplementationType == typeof(DescParser_PresentationFormat));
                DescParser_PresentationFormat impl = parser as DescParser_PresentationFormat;
                Assert.IsNotNull(impl, "Is null on cast");
                Assert.AreEqual(DataFormatEnum.unsigned_32bit_integer, impl.Format);
                Assert.AreEqual(UnitsOfMeasurement.LengthMetre, impl.MeasurementUnitsEnum);
                Assert.AreEqual(0x2701, impl.MeasurementUnitUShort);
                Assert.AreEqual(1, impl.Namespace);
                Assert.AreEqual(0x221A, impl.Description);
            });
        }


        [Test]
        public void Err13340_FormatParseDataBadFormat() {
            TestHelpersNet.CatchUnexpected(() => {
                IDescParser parser = new DescParser_PresentationFormat();
                byte[] data = new byte[7];
                // Bogus format
                data[0] = 245;  // Bogus
                data[1] = 33; // Exponent
                // TODO - look at how the data comes in from BLE
                data[2] = 0x01; // 0x2701 UnitsOfMeasurement.LengthMetre - least significant byte then most significant
                data[3] = 0x27;
                data[4] = 1;    // Namespace
                data[5] = 0x1A; // Uint16 Description
                data[6] = 0x22;

                string result = parser.Parse(data);
                this.logReader.Validate(13340, 
                    "DescParser_PresentationFormat", "GetFormat", "Format:245 not handled");
            });
        }


        [Test]
        public void Err13341_FormatParseDataBadUnit() {
            TestHelpersNet.CatchUnexpected(() => {
                IDescParser parser = new DescParser_PresentationFormat();
                byte[] data = new byte[7];
                data[0] = 8;  // Format  DataFormatEnum.unsigned_32bit_integer
                data[1] = 33; // Exponent
                // TODO - look at how the data comes in from BLE
                data[2] = 0xF0; // 0x2701 UnitsOfMeasurement.LengthMetre - least significant byte then most significant
                data[3] = 0xFF;
                data[4] = 1;    // Namespace
                data[5] = 0x1A; // Uint16 Description
                data[6] = 0x22;

                string result = parser.Parse(data);
                this.logReader.Validate(13341,
                    "DescParser_PresentationFormat", "GetUnitOfMeasurement", "value 0xFFF0 not found in enums");
            });
        }






        //TestHelpersNet.CatchUnexpected(() => {
        //    });



    }
}
