using BluetoothLE.Net.Enumerations;
using BluetoothLE.Net.Tools;
using NUnit.Framework;
using TestCaseSupport.Core;
using VariousUtils.Net;

namespace TestCases.Core.BLE.BLE_DataInput {

    [TestFixture]
    public class T001_RangeMinMax : TestCaseBase {

        //private readonly ClassLog log = new ("DescParserBaseTests");
        private readonly BLERangeValidator validator = new ();

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

        #region Bool

        [Test]
        public void BoolValidateValid() {
            this.ValidateByte("0", BLE_DataValidationStatus.Success, 0, BLE_DataType.Bool);
            this.ValidateByte("1", BLE_DataValidationStatus.Success, 1, BLE_DataType.Bool);
        }

        [Test]
        public void BoolValidateInvalidRange() {
            this.ValidateByte("3", BLE_DataValidationStatus.StringConversionFailed, 0, BLE_DataType.Bool);
        }

        [Test]
        public void BoolValidateInvalidFormat() {
            this.ValidateByte("3dd", BLE_DataValidationStatus.StringConversionFailed, 0, BLE_DataType.Bool);
        }

        #endregion

        #region Uint8
        [Test]
        public void UInt08_ValidateValid() {
            this.ValidateByte("0", BLE_DataValidationStatus.Success, 0, BLE_DataType.UInt_8bit);
            this.ValidateByte("27", BLE_DataValidationStatus.Success, 27, BLE_DataType.UInt_8bit);
            this.ValidateByte(Byte.MaxValue.ToString(), BLE_DataValidationStatus.Success, Byte.MaxValue, BLE_DataType.UInt_8bit);
        }

        [Test]
        public void UInt08_ValidateInValidMin() {
            this.ValidateByte("-1", BLE_DataValidationStatus.StringConversionFailed, 0, BLE_DataType.UInt_8bit);
        }


        [Test]
        public void UInt08_ValidateInValidMax() {
            this.ValidateByte("300", BLE_DataValidationStatus.StringConversionFailed, 0, BLE_DataType.UInt_8bit);
        }

        [Test]
        public void UInt08_ValidateInValidFormat() {
            this.ValidateByte("xx300", BLE_DataValidationStatus.StringConversionFailed, 0, BLE_DataType.UInt_8bit);
        }

        [Test]
        public void UInt02_ValidateValid() {
            this.ValidateByte("0", BLE_DataValidationStatus.Success, 0, BLE_DataType.UInt_2bit);
            this.ValidateByte("3", BLE_DataValidationStatus.Success, 3, BLE_DataType.UInt_2bit);
        }

        public void UInt02_ValidateInvalidPlus() {
            this.ValidateByte("5", BLE_DataValidationStatus.OutOfRange, 0, BLE_DataType.UInt_2bit);
        }

        public void UInt02_ValidateInvalidMinus() {
            this.ValidateByte("-5", BLE_DataValidationStatus.InvalidInput, 0, BLE_DataType.UInt_2bit);
        }
        [Test]
        public void UInt04_ValidateValid() {
            this.ValidateByte("0", BLE_DataValidationStatus.Success, 0, BLE_DataType.UInt_4bit);
            this.ValidateByte("15", BLE_DataValidationStatus.Success, 15, BLE_DataType.UInt_4bit);
        }

        public void UInt04_ValidateInvalidPlus() {
            this.ValidateByte("18", BLE_DataValidationStatus.OutOfRange, 0, BLE_DataType.UInt_4bit);
        }

        public void UInt04_ValidateInvalidMinus() {
            this.ValidateByte("-5", BLE_DataValidationStatus.InvalidInput, 0, BLE_DataType.UInt_4bit);
        }

        #endregion

        #region Uint16

        [Test]
        public void UInt12_ValidateValid() {
            this.ValidateUint16("0", BLE_DataValidationStatus.Success, 0, BLE_DataType.UInt_12bit);
            this.ValidateUint16("4095", BLE_DataValidationStatus.Success, 4095, BLE_DataType.UInt_12bit);
        }

        [Test]
        public void UInt12_ValidateInvalidMinus() {
            this.ValidateUint16("-2", BLE_DataValidationStatus.StringConversionFailed, 0, BLE_DataType.UInt_12bit);
        }

        [Test]
        public void UInt12_ValidateInvalidPlus() {
            this.ValidateUint16("5000", BLE_DataValidationStatus.StringConversionFailed, 0, BLE_DataType.UInt_12bit);
        }


        [Test]
        public void UInt16_ValidateValid() {
            this.ValidateUint16(UInt16.MinValue.ToString(), BLE_DataValidationStatus.Success, UInt16.MinValue, BLE_DataType.UInt_16bit);
            this.ValidateUint16(UInt16.MaxValue.ToString(), BLE_DataValidationStatus.Success, UInt16.MaxValue, BLE_DataType.UInt_16bit);
        }

        [Test]
        public void UInt16_ValidateInvalidMinus() {
            this.ValidateUint16("-2", BLE_DataValidationStatus.StringConversionFailed, 0, BLE_DataType.UInt_16bit);
        }

        [Test]
        public void UInt16_ValidateInvalidPlus() {
            this.ValidateUint16((UInt16.MaxValue + 1000).ToString(), BLE_DataValidationStatus.StringConversionFailed, 0, BLE_DataType.UInt_16bit);
        }
        #endregion

        #region Uint32

        [Test]
        public void UInt24_ValidateValid() {
            this.ValidateUint32("0", BLE_DataValidationStatus.Success, 0, BLE_DataType.UInt_24bit);
            this.ValidateUint32("16777215", BLE_DataValidationStatus.Success, 16777215, BLE_DataType.UInt_24bit);
        }

        [Test]
        public void UInt24_ValidateInvalidMinus() {
            this.ValidateUint32("-1", BLE_DataValidationStatus.StringConversionFailed, 0, BLE_DataType.UInt_24bit);
        }


        [Test]
        public void UInt24_ValidateInvalidPlus() {
            this.ValidateUint32("16779000", BLE_DataValidationStatus.StringConversionFailed, 0, BLE_DataType.UInt_24bit);
        }

        [Test]
        public void UInt32_ValidateValid() {
            this.ValidateUint32(UInt32.MinValue.ToString(), BLE_DataValidationStatus.Success, UInt32.MinValue, BLE_DataType.UInt_32bit);
            this.ValidateUint32(UInt32.MaxValue.ToString(), BLE_DataValidationStatus.Success, UInt32.MaxValue, BLE_DataType.UInt_32bit);
        }

        [Test]
        public void UInt32_ValidateInvalidMinus() {
            this.ValidateUint32("-1", BLE_DataValidationStatus.StringConversionFailed, 0, BLE_DataType.UInt_32bit);
        }


        [Test]
        public void UInt32_ValidateInvalidPlus() {
            ulong val = UInt32.MaxValue;
            val += 100;
            this.ValidateUint32(val.ToString(), BLE_DataValidationStatus.StringConversionFailed, 0, BLE_DataType.UInt_32bit);
        }

        #endregion

        #region Uint64

        [Test]
        public void UInt48_ValidateValid() {
            this.ValidateUint64("0", BLE_DataValidationStatus.Success, 0, BLE_DataType.UInt_48bit);
            this.ValidateUint64("281474976710655", BLE_DataValidationStatus.Success, 281474976710655, BLE_DataType.UInt_48bit);
        }

        [Test]
        public void UInt48_ValidateInvalidMinus() {
            this.ValidateUint64("-1", BLE_DataValidationStatus.StringConversionFailed, 0, BLE_DataType.UInt_48bit);
        }


        [Test]
        public void UInt48_ValidateInvalidPlus() {
            this.ValidateUint64("281474976710777", BLE_DataValidationStatus.StringConversionFailed, 0, BLE_DataType.UInt_48bit);
        }

        //--
        [Test]
        public void UInt64_ValidateValid() {
            this.ValidateUint64(UInt64.MinValue.ToString(), BLE_DataValidationStatus.Success, UInt64.MinValue, BLE_DataType.UInt_64bit);
            this.ValidateUint64(UInt64.MaxValue.ToString(), BLE_DataValidationStatus.Success, UInt64.MaxValue, BLE_DataType.UInt_64bit);
        }

        [Test]
        public void UInt64_ValidateInvalidMinus() {
            this.ValidateUint64("-1", BLE_DataValidationStatus.StringConversionFailed, 0, BLE_DataType.UInt_64bit);
        }


        [Test]
        public void UInt64_ValidateInvalidPlus() {
            decimal val = UInt64.MaxValue;
            val += 100;
            this.ValidateUint64(val.ToString(), BLE_DataValidationStatus.StringConversionFailed, 0, BLE_DataType.UInt_64bit);
        }

        #endregion

        #region Int8

        [Test]
        public void Int08_ValidateValid() {
            this.ValidateSByte(SByte.MinValue.ToString(), BLE_DataValidationStatus.Success, SByte.MinValue);
            this.ValidateSByte("0", BLE_DataValidationStatus.Success, 0);
            this.ValidateSByte(SByte.MaxValue.ToString(), BLE_DataValidationStatus.Success, SByte.MaxValue);
        }

        [Test]
        public void Int08_ValidateInValidMin() {
            this.ValidateSByte("-150", BLE_DataValidationStatus.StringConversionFailed, 0);
        }

        [Test]
        public void Int08_ValidateInValidMax() {
            this.ValidateSByte("300", BLE_DataValidationStatus.StringConversionFailed, 0);
        }

        #endregion

        #region Int16

        [Test]
        public void Int16_ValidateValid() {
            this.ValidateInt16(Int16.MinValue.ToString(), BLE_DataValidationStatus.Success, Int16.MinValue, BLE_DataType.Int_16bit);
            this.ValidateInt16("0", BLE_DataValidationStatus.Success, 0, BLE_DataType.Int_16bit);
            this.ValidateInt16(Int16.MaxValue.ToString(), BLE_DataValidationStatus.Success, Int16.MaxValue, BLE_DataType.Int_16bit);
        }

        [Test]
        public void Int16_ValidateInValidMin() {
            this.ValidateInt16(Int32.MinValue.ToString(), BLE_DataValidationStatus.StringConversionFailed, 0, BLE_DataType.Int_16bit);
        }

        [Test]
        public void Int16_ValidateInValidMax() {
            this.ValidateInt16(Int32.MaxValue.ToString(), BLE_DataValidationStatus.StringConversionFailed, 0, BLE_DataType.Int_16bit);
        }

        #endregion

        #region Int32

        [Test]
        public void Int32_ValidateValid() {
            this.ValidateInt32(Int32.MinValue.ToString(), BLE_DataValidationStatus.Success, Int32.MinValue, BLE_DataType.Int_32bit);
            this.ValidateInt32("0", BLE_DataValidationStatus.Success, 0, BLE_DataType.Int_32bit);
            this.ValidateInt32(Int32.MaxValue.ToString(), BLE_DataValidationStatus.Success, Int32.MaxValue, BLE_DataType.Int_32bit);
        }

        [Test]
        public void Int32_ValidateInValidMin() {
            this.ValidateInt32(Int64.MinValue.ToString(), BLE_DataValidationStatus.StringConversionFailed, 0, BLE_DataType.Int_32bit);
        }

        [Test]
        public void Int32_ValidateInValidMax() {
            this.ValidateInt32(Int64.MaxValue.ToString(), BLE_DataValidationStatus.StringConversionFailed, 0, BLE_DataType.Int_32bit);
        }

        #endregion

        #region Int64

        [Test]
        public void Int64_ValidateValid() {
            this.ValidateInt64(Int64.MinValue.ToString(), BLE_DataValidationStatus.Success, Int64.MinValue, BLE_DataType.Int_64bit);
            this.ValidateInt64("0", BLE_DataValidationStatus.Success, 0, BLE_DataType.Int_64bit);
            this.ValidateInt64(Int64.MaxValue.ToString(), BLE_DataValidationStatus.Success, Int64.MaxValue, BLE_DataType.Int_64bit);
        }

        [Test]
        public void Int64_ValidateInValidMin() {
            this.ValidateInt64(Decimal.MinValue.ToString(), BLE_DataValidationStatus.StringConversionFailed, 0, BLE_DataType.Int_64bit);
        }

        [Test]
        public void Int64_ValidateInValidMax() {
            this.ValidateInt64(Decimal.MaxValue.ToString(), BLE_DataValidationStatus.StringConversionFailed, 0, BLE_DataType.Int_64bit);
        }

        #endregion

        #region Float 32

        [Test]
        public void Float32_ValidateValid() {
            this.ValidateFloat32(Single.MinValue.ToString(), BLE_DataValidationStatus.Success, Single.MinValue);
            this.ValidateFloat32("0", BLE_DataValidationStatus.Success, 0);
            this.ValidateFloat32(Single.MaxValue.ToString(), BLE_DataValidationStatus.Success, Single.MaxValue);
        }

        [Test]
        public void Float32_ValidateInValidMin() {
            this.ValidateFloat32(Double.MinValue.ToString(), BLE_DataValidationStatus.StringConversionFailed, 0);
        }

        [Test]
        public void Float32_ValidateInValidMax() {
            this.ValidateFloat32(Double.MaxValue.ToString(), BLE_DataValidationStatus.StringConversionFailed, 0);
        }

        #endregion

        #region Float 64

        [Test]
        public void Float64_ValidateValid() {
            this.ValidateFloat64(Double.MinValue.ToString(), BLE_DataValidationStatus.Success, Double.MinValue);
            this.ValidateFloat64("0", BLE_DataValidationStatus.Success, 0);
            this.ValidateFloat64(Double.MaxValue.ToString(), BLE_DataValidationStatus.Success, Double.MaxValue);
        }

        [Test]
        public void Float64_ValidateInValidMin() {
            // Double Min
            // -1.7976931348623157E+308
            string underflow = "-2.7976931348623157E+308";
            this.ValidateFloat64(underflow, BLE_DataValidationStatus.StringConversionFailed, 0);
        }

        [Test]
        public void Float64_ValidateInValidMax() {
            // Double Max
            //1.79769e+308
            string overflow = "1.79769e+309";
            this.ValidateFloat64(overflow, BLE_DataValidationStatus.StringConversionFailed, 0);
        }

        #endregion

        #region Helpers

        public void ValidateFloat32(string sVal, BLE_DataValidationStatus status, Single val) {
            TestHelpers.CatchUnexpected(() => {
                RangeValidationResult result = this.validator.Validate(sVal, BLE_DataType.IEEE_754_32bit_floating_point);
                Assert.AreEqual(status, result.Status);
                Single r = result.Payload.ToFloat32(0);
                Assert.AreEqual(val, r);
            });
        }

        public void ValidateFloat64(string sVal, BLE_DataValidationStatus status, double val) {
            TestHelpers.CatchUnexpected(() => {
                RangeValidationResult result = this.validator.Validate(sVal, BLE_DataType.IEEE_754_64bit_floating_point);
                Assert.AreEqual(status, result.Status);
                double r = result.Payload.ToDouble64(0);
                Assert.AreEqual(val, r);
            });
        }

        public void ValidateSByte(string sVal, BLE_DataValidationStatus status, sbyte val) {
            TestHelpers.CatchUnexpected(() => {
                RangeValidationResult result = this.validator.Validate(sVal, BLE_DataType.Int_8bit );
                Assert.AreEqual(status, result.Status);
                sbyte data = result.Payload.ToSByte(0);
                Assert.AreEqual(val, data);
            });
        }


        public void ValidateInt16(string sVal, BLE_DataValidationStatus status, Int16 val, BLE_DataType dataType) {
            TestHelpers.CatchUnexpected(() => {
                RangeValidationResult result = this.validator.Validate(sVal, dataType);
                Assert.AreEqual(status, result.Status);
                // This will be different on 12bit integer. Not yet supported
                if (dataType == BLE_DataType.Int_12bit) {
                    Assert.True(false, "12 bit integer not supported");
                }
                else {
                    Int16 r = result.Payload.ToInt16(0);
                    Assert.AreEqual(val, r);
                }
            });
        }


        public void ValidateInt32(string sVal, BLE_DataValidationStatus status, Int32 val, BLE_DataType dataType) {
            TestHelpers.CatchUnexpected(() => {
                RangeValidationResult result = this.validator.Validate(sVal, dataType);
                Assert.AreEqual(status, result.Status);
                if (dataType == BLE_DataType.Int_24bit) {
                    Assert.True(false, "24 bit integer not supported");
                }
                else {
                    Int32 r = result.Payload.ToInt32(0);
                    Assert.AreEqual(val, r);
                }
            });
        }

        public void ValidateInt64(string sVal, BLE_DataValidationStatus status, Int64 val, BLE_DataType dataType) {
            TestHelpers.CatchUnexpected(() => {
                RangeValidationResult result = this.validator.Validate(sVal, dataType);
                Assert.AreEqual(status, result.Status);
                if (dataType == BLE_DataType.Int_48bit) {
                    Assert.True(false, "48 bit integer not supported");
                }
                else {
                    Int64 r = result.Payload.ToInt64(0);
                    Assert.AreEqual(val, r);
                }
            });
        }


        public void ValidateByte(string sVal, BLE_DataValidationStatus status, byte bVal, BLE_DataType dataType) {
            TestHelpers.CatchUnexpected(() => {
                RangeValidationResult result = this.validator.Validate(sVal, dataType);
                Assert.AreEqual(status, result.Status);
                Assert.AreEqual(bVal, result.Payload[0]);
            });
        }


        public void ValidateUint16(string sVal, BLE_DataValidationStatus status, UInt16 val, BLE_DataType dataType) {
            TestHelpers.CatchUnexpected(() => {
                RangeValidationResult result = this.validator.Validate(sVal, dataType);
                Assert.AreEqual(status, result.Status);
                Assert.AreEqual(val, result.Payload.ToUint16(0));
            });
        }


        public void ValidateUint32(string sVal, BLE_DataValidationStatus status, UInt32 val, BLE_DataType dataType) {
            TestHelpers.CatchUnexpected(() => {
                RangeValidationResult result = this.validator.Validate(sVal, dataType);
                Assert.AreEqual(status, result.Status);
                if (dataType == BLE_DataType.UInt_24bit) {
                    byte[] data = new byte[4];
                    Array.Copy(result.Payload, data, 3);
                    Assert.AreEqual(val, data.ToUint32(0));
                }
                else {
                    Assert.AreEqual(val, result.Payload.ToUint32(0));
                }
            });
        }



        public void ValidateUint64(string sVal, BLE_DataValidationStatus status, UInt64 val, BLE_DataType dataType) {
            TestHelpers.CatchUnexpected(() => {
                RangeValidationResult result = this.validator.Validate(sVal, dataType);
                Assert.AreEqual(status, result.Status);
                if (dataType == BLE_DataType.UInt_48bit) {
                    byte[] data = new byte[8];
                    Array.Copy(result.Payload, data, 6);
                    Assert.AreEqual(6, result.Payload.Length, "Payload size");
                    Assert.AreEqual(val, data.ToUint64(0));
                }
                else {
                    Assert.AreEqual(8, result.Payload.Length, "Payload size");
                    Assert.AreEqual(val, result.Payload.ToUint64(0));
                }
            });
        }



        #endregion

    }
}
