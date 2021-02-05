using BluetoothLE.Net.Enumerations;
using BluetoothLE.Net.Tools;
using LogUtils.Net;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TestCases.Core.TestToolSet;
using VariousUtils.Net;

namespace TestCases.Core.BLE_DataInput {

    [TestFixture]
    public class T001_RangeMinMax : TestCaseBase {

        ClassLog log = new ClassLog("DescParserBaseTests");

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
            this.ValidateByte("3", BLE_DataValidationStatus.OutOfRange, 0, BLE_DataType.Bool);
        }

        [Test]
        public void BoolValidateInvalidFormat() {
            this.ValidateByte("3dd", BLE_DataValidationStatus.InvalidInput, 0, BLE_DataType.Bool);
        }

        #endregion

        #region Uint8
        [Test]
        public void Byte8bitValidateValid() {
            this.ValidateByte("0", BLE_DataValidationStatus.Success, 0, BLE_DataType.UInt_8bit);
            this.ValidateByte("27", BLE_DataValidationStatus.Success, 27, BLE_DataType.UInt_8bit);
            this.ValidateByte(Byte.MaxValue.ToString(), BLE_DataValidationStatus.Success, Byte.MaxValue, BLE_DataType.UInt_8bit);
        }

        [Test]
        public void Byte8bitValidateInValidMin() {
            this.ValidateByte("-1", BLE_DataValidationStatus.InvalidInput, 0, BLE_DataType.UInt_8bit);
        }


        [Test]
        public void Byte8bitValidateInValidMax() {
            this.ValidateByte("300", BLE_DataValidationStatus.InvalidInput, 0, BLE_DataType.UInt_8bit);
        }

        [Test]
        public void Byte8bitValidateInValidFormat() {
            this.ValidateByte("xx300", BLE_DataValidationStatus.InvalidInput, 0, BLE_DataType.UInt_8bit);
        }

        [Test]
        public void Byte2bitValidateValid() {
            this.ValidateByte("0", BLE_DataValidationStatus.Success, 0, BLE_DataType.UInt_2bit);
            this.ValidateByte("3", BLE_DataValidationStatus.Success, 3, BLE_DataType.UInt_2bit);
        }

        public void Byte2bitValidateInvalidPlus() {
            this.ValidateByte("5", BLE_DataValidationStatus.OutOfRange, 0, BLE_DataType.UInt_2bit);
        }

        public void Byte2bitValidateInvalidMinus() {
            this.ValidateByte("-5", BLE_DataValidationStatus.InvalidInput, 0, BLE_DataType.UInt_2bit);
        }
        [Test]
        public void Byte4bitValidateValid() {
            this.ValidateByte("0", BLE_DataValidationStatus.Success, 0, BLE_DataType.UInt_4bit);
            this.ValidateByte("15", BLE_DataValidationStatus.Success, 15, BLE_DataType.UInt_4bit);
        }

        public void Byte4bitValidateInvalidPlus() {
            this.ValidateByte("18", BLE_DataValidationStatus.OutOfRange, 0, BLE_DataType.UInt_4bit);
        }

        public void Byte4bitValidateInvalidMinus() {
            this.ValidateByte("-5", BLE_DataValidationStatus.InvalidInput, 0, BLE_DataType.UInt_4bit);
        }

        #endregion

        #region Uint16
        [Test]
        public void Ushort12bitValidateValid() {
            this.ValidateUint16("0", BLE_DataValidationStatus.Success, 0, BLE_DataType.UInt_12bit);
            this.ValidateUint16("4095", BLE_DataValidationStatus.Success, 4095, BLE_DataType.UInt_12bit);
        }

        [Test]
        public void Ushort12bitValidateInvalidMinus() {
            this.ValidateUint16("-2", BLE_DataValidationStatus.InvalidInput, 0, BLE_DataType.UInt_12bit);
        }

        [Test]
        public void Ushort12bitValidateInvalidPlus() {
            this.ValidateUint16("5000", BLE_DataValidationStatus.OutOfRange, 0, BLE_DataType.UInt_12bit);
        }


        [Test]
        public void Ushort16bitValidateValid() {
            this.ValidateUint16(UInt16.MinValue.ToString(), BLE_DataValidationStatus.Success, UInt16.MinValue, BLE_DataType.UInt_16bit);
            this.ValidateUint16(UInt16.MaxValue.ToString(), BLE_DataValidationStatus.Success, UInt16.MaxValue, BLE_DataType.UInt_16bit);
        }

        [Test]
        public void Ushort16bitValidateInvalidMinus() {
            this.ValidateUint16("-2", BLE_DataValidationStatus.InvalidInput, 0, BLE_DataType.UInt_16bit);
        }

        [Test]
        public void Ushort16bitValidateInvalidPlus() {
            this.ValidateUint16((UInt16.MaxValue + 1000).ToString(), BLE_DataValidationStatus.InvalidInput, 0, BLE_DataType.UInt_16bit);
        }
        #endregion


        #region Helpers

        public void ValidateByte(string sVal, BLE_DataValidationStatus status, byte bVal, BLE_DataType dataType) {
            TestHelpersNet.CatchUnexpected(() => {
                RangeValidationResult result = RangeTools.Validate(sVal, dataType);
                Assert.AreEqual(status, result.Status);
                Assert.AreEqual(bVal, result.Payload[0]);
            });
        }


        public void ValidateUint16(string sVal, BLE_DataValidationStatus status, UInt16 val, BLE_DataType dataType) {
            TestHelpersNet.CatchUnexpected(() => {
                RangeValidationResult result = RangeTools.Validate(sVal, dataType);
                Assert.AreEqual(status, result.Status);
                Assert.AreEqual(val, result.Payload.ToUint16(0));
            });
        }

        #endregion

    }
}
