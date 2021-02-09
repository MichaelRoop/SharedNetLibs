using BluetoothLE.Net.Enumerations;
using BluetoothLE.Net.Parsers.Types;
using LogUtils.Net;
using System;
using System.Linq;
using System.Text;
using VariousUtils.Net;

namespace BluetoothLE.Net.Tools {

    public class BLERangeValidator {

        #region Data

        private ClassLog log = new ClassLog("BLERangeValidator");
        private BLEValidRangeFactory factory = new BLEValidRangeFactory();

        #endregion

        #region Public

        public DataTypeDisplay GetRange(BLE_DataType dataType) {
            return this.factory.GetRange(dataType);
        }



        /// <summary>Validate user entry from UI</summary>
        /// <param name="value">The value as string entered by the user</param>
        /// <param name="bleType">The type this applies to on conversion</param>
        /// <returns></returns>
        public RangeValidationResult Validate(string value, BLE_DataType bleType) {
            try {
                RangeValidationResult result = new RangeValidationResult(value);
                result.Payload = new byte[bleType.BytesRequired()];
                result.Range = this.GetRange(bleType);
                switch (bleType) {
                    case BLE_DataType.Bool:
                        return ValidateByteRange(result, 0, 1);
                    case BLE_DataType.UInt_2bit:
                        return ValidateByteRange(result, 0, 3);
                    case BLE_DataType.UInt_4bit:
                        return ValidateByteRange(result, 0, 15);
                    case BLE_DataType.UInt_8bit:
                        return ValidateByteRange(result, 0, Byte.MaxValue);
                    case BLE_DataType.UInt_12bit:
                        return ValidateUint16Range(result, 0, Uint12.MaxValue);
                    case BLE_DataType.UInt_16bit:
                        return ValidateUint16Range(result, 0, UInt16.MaxValue);
                    case BLE_DataType.UInt_24bit:
                        return ValidateUint24Range(result, 0, Uint24.MaxValue);
                    case BLE_DataType.UInt_32bit:
                        return ValidateUint32Range(result, 0, UInt32.MaxValue);
                    case BLE_DataType.UInt_48bit:
                        return ValidateUint48Range(result, 0, 281474976710655);
                    case BLE_DataType.UInt_64bit:
                        return ValidateUint64Range(result, 0, UInt64.MaxValue);
                    case BLE_DataType.UInt_128bit:
                        return RangeNotHandled(result);
                    case BLE_DataType.Int_8bit:
                        return ValidateInt8Range(result, SByte.MinValue, SByte.MaxValue);
                    case BLE_DataType.Int_12bit:
                        return Validateint16Range(result, -2048, 2047);
                    case BLE_DataType.Int_16bit:
                        return Validateint16Range(result, Int16.MinValue, Int16.MaxValue);
                    case BLE_DataType.Int_24bit:
                        return Validateint32Range(result, -8388608, 8388607);
                    case BLE_DataType.Int_32bit:
                        return Validateint32Range(result, Int32.MinValue, Int32.MaxValue);
                    case BLE_DataType.Int_48bit:
                        return Validateint64Range(result, -140737488355328, 140737488355327);
                    case BLE_DataType.Int_64bit:
                        return Validateint64Range(result, Int64.MinValue, Int64.MaxValue);
                    case BLE_DataType.Int_128bit:
                        return RangeNotHandled(result);
                    case BLE_DataType.IEEE_754_32bit_floating_point:
                        return Validateint32Float(result, Single.MinValue, Single.MaxValue);
                    case BLE_DataType.IEEE_754_64bit_floating_point:
                        return Validateint64Double(result, Double.MinValue, Double.MaxValue);
                    case BLE_DataType.IEEE_11073_16bit_SFLOAT:
                        return RangeNotHandled(result);
                    case BLE_DataType.IEEE_11073_32bit_FLOAT:
                        return RangeNotHandled(result);
                    case BLE_DataType.IEEE_20601_format:
                        return ValidateIEEE20601(result);
                    case BLE_DataType.UTF8_String:
                        return ValidateUTF8String(result);
                    case BLE_DataType.UTF16_String:
                        return ValidateUTF16String(result);
                    case BLE_DataType.OpaqueStructure:
                    case BLE_DataType.Reserved:
                        return RangeNotHandled(result);
                    default:
                        return RangeNotHandled(result);
                }
            }
            catch (Exception e) {
                log.Exception(9999, "RangeValidationResult", "", e);
                return new RangeValidationResult() {
                    UserEntryString = value,
                    Message = BLE_DataValidationStatus.UnhandledError.ToString(),
                    Range = new DataTypeDisplay(BLE_DataType.Reserved, "0", "0"),
                    Payload = new byte[0],
                    Status = BLE_DataValidationStatus.UnhandledError,
                };
            }
        }

        #endregion

        #region Private validate methods

        private RangeValidationResult ValidateByteRange(RangeValidationResult result, byte min, byte max) {
            byte val;
            if (Byte.TryParse(result.UserEntryString, out val)) {
                if (val >= min && val <= max) {
                    result.Status = BLE_DataValidationStatus.Success;
                    val.WriteToBuffer(result.Payload, 0);
                }
                else {
                    result.Status = BLE_DataValidationStatus.OutOfRange;
                }
            }
            else {
                result.Status = BLE_DataValidationStatus.InvalidInput;
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private RangeValidationResult ValidateUint16Range(RangeValidationResult result, UInt16 min, UInt16 max) {
            UInt16 val;
            if (UInt16.TryParse(result.UserEntryString, out val)) {
                if (val >= min && val <= max) {
                    result.Status = BLE_DataValidationStatus.Success;
                    val.WriteToBuffer(result.Payload, 0);
                }
                else {
                    result.Status = BLE_DataValidationStatus.OutOfRange;
                }
            }
            else {
                result.Status = BLE_DataValidationStatus.InvalidInput;
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private RangeValidationResult ValidateUint24Range(RangeValidationResult result, UInt32 min, UInt32 max) {
            UInt32 val;
            if (UInt32.TryParse(result.UserEntryString, out val)) {
                if (val >= min && val <= max) {
                    result.Status = BLE_DataValidationStatus.Success;
                    byte[] tmp = new byte[4];
                    val.WriteToBuffer(tmp, 0);
                    Array.Copy(tmp, result.Payload, 3);
                }
                else {
                    result.Status = BLE_DataValidationStatus.OutOfRange;
                }
            }
            else {
                result.Status = BLE_DataValidationStatus.InvalidInput;
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }



        private RangeValidationResult ValidateUint32Range(RangeValidationResult result, UInt32 min, UInt32 max) {
            UInt32 val;
            if (UInt32.TryParse(result.UserEntryString, out val)) {
                if (val >= min && val <= max) {
                    result.Status = BLE_DataValidationStatus.Success;
                    val.WriteToBuffer(result.Payload, 0);
                }
                else {
                    result.Status = BLE_DataValidationStatus.OutOfRange;
                }
            }
            else {
                result.Status = BLE_DataValidationStatus.InvalidInput;
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private RangeValidationResult ValidateUint48Range(RangeValidationResult result, UInt64 min, UInt64 max) {
            UInt64 val;
            if (UInt64.TryParse(result.UserEntryString, out val)) {
                if (val >= min && val <= max) {
                    result.Status = BLE_DataValidationStatus.Success;
                    byte[] tmp = new byte[8];
                    val.WriteToBuffer(tmp, 0);
                    Array.Copy(tmp, result.Payload, 6);
                }
                else {
                    result.Status = BLE_DataValidationStatus.OutOfRange;
                }
            }
            else {
                result.Status = BLE_DataValidationStatus.InvalidInput;
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }




        private RangeValidationResult ValidateUint64Range(RangeValidationResult result, UInt64 min, UInt64 max) {
            UInt64 val;
            if (UInt64.TryParse(result.UserEntryString, out val)) {
                if (val >= min && val <= max) {
                    result.Status = BLE_DataValidationStatus.Success;
                    val.WriteToBuffer(result.Payload, 0);
                }
                else {
                    result.Status = BLE_DataValidationStatus.OutOfRange;
                }
            }
            else {
                result.Status = BLE_DataValidationStatus.InvalidInput;
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private RangeValidationResult ValidateInt8Range(RangeValidationResult result, sbyte min, sbyte max) {
            sbyte val;
            if (SByte.TryParse(result.UserEntryString, out val)) {
                if (val >= min && val <= max) {
                    result.Status = BLE_DataValidationStatus.Success;
                    val.WriteToBuffer(result.Payload, 0);
                }
                else {
                    result.Status = BLE_DataValidationStatus.OutOfRange;
                }
            }
            else {
                result.Status = BLE_DataValidationStatus.InvalidInput;
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private RangeValidationResult Validateint16Range(RangeValidationResult result, Int16 min, Int16 max) {
            Int16 val;
            if (Int16.TryParse(result.UserEntryString, out val)) {
                if (val >= min && val <= max) {
                    result.Status = BLE_DataValidationStatus.Success;
                    val.WriteToBuffer(result.Payload, 0);
                }
                else {
                    result.Status = BLE_DataValidationStatus.OutOfRange;
                }
            }
            else {
                result.Status = BLE_DataValidationStatus.InvalidInput;
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private RangeValidationResult Validateint32Range(RangeValidationResult result, Int32 min, Int32 max) {
            Int32 val;
            if (Int32.TryParse(result.UserEntryString, out val)) {
                if (val >= min && val <= max) {
                    result.Status = BLE_DataValidationStatus.Success;
                    val.WriteToBuffer(result.Payload, 0);
                }
                else {
                    result.Status = BLE_DataValidationStatus.OutOfRange;
                }
            }
            else {
                result.Status = BLE_DataValidationStatus.InvalidInput;
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private RangeValidationResult Validateint64Range(RangeValidationResult result, Int64 min, Int64 max) {
            Int64 val;
            if (Int64.TryParse(result.UserEntryString, out val)) {
                if (val >= min && val <= max) {
                    result.Status = BLE_DataValidationStatus.Success;
                    val.WriteToBuffer(result.Payload, 0);
                }
                else {
                    result.Status = BLE_DataValidationStatus.OutOfRange;
                }
            }
            else {
                result.Status = BLE_DataValidationStatus.InvalidInput;
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private RangeValidationResult Validateint32Float(RangeValidationResult result, Single min, Single max) {
            Single val;
            if (Single.TryParse(result.UserEntryString, out val)) {
                if (val >= min && val <= max) {
                    result.Status = BLE_DataValidationStatus.Success;
                    val.WriteToBuffer(result.Payload, 0);
                }
                else {
                    result.Status = BLE_DataValidationStatus.OutOfRange;
                }
            }
            else {
                result.Status = BLE_DataValidationStatus.InvalidInput;
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private RangeValidationResult Validateint64Double(RangeValidationResult result, Double min, Double max) {
            Double val;
            if (Double.TryParse(result.UserEntryString, out val)) {
                if (val >= min && val <= max) {
                    result.Status = BLE_DataValidationStatus.Success;
                    val.WriteToBuffer(result.Payload, 0);
                }
                else {
                    result.Status = BLE_DataValidationStatus.OutOfRange;
                }
            }
            else {
                result.Status = BLE_DataValidationStatus.InvalidInput;
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private RangeValidationResult ValidateIEEE20601(RangeValidationResult result) {
            // Input supposed to be delimited as 0xFF|0xFF
            string[] parts = result.UserEntryString.Split('|');
            if (parts.Count() < 2) {
                result.Status = BLE_DataValidationStatus.InvalidInput;
                return result;
            }

            if (this.ValidateIEEE20601Part(result, parts[0]) &&
                this.ValidateIEEE20601Part(result, parts[1])) {
                // Copy over each portion to buffer. 
                // Use Parser - already validated
                UInt16 val1 = UInt16.Parse(parts[0]);
                UInt16 val2 = UInt16.Parse(parts[1]);
                int pos = 0;
                val1.WriteToBuffer(result.Payload, ref pos);
                val2.WriteToBuffer(result.Payload, ref pos);
                result.Status = BLE_DataValidationStatus.Success;
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private bool ValidateIEEE20601Part(RangeValidationResult result, string value) {
            RangeValidationResult tmp = new RangeValidationResult(value);
            this.ValidateUint16Range(tmp, UInt16.MinValue, UInt16.MaxValue);
            if (tmp.Status != BLE_DataValidationStatus.Success) {
                result.Status = tmp.Status;
                return false;
            }
            return true;
        }


        private RangeValidationResult ValidateUTF8String(RangeValidationResult result) {
            if (result.UserEntryString.Length > 0) {
                result.Status = BLE_DataValidationStatus.Success;
                result.Payload = Encoding.UTF8.GetBytes(result.UserEntryString);
            }
            else {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private RangeValidationResult ValidateUTF16String(RangeValidationResult result) {
            if (result.UserEntryString.Length > 0) {
                result.Status = BLE_DataValidationStatus.Success;
                result.Payload = Encoding.Unicode.GetBytes(result.UserEntryString);
            }
            else {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private RangeValidationResult RangeNotHandled(RangeValidationResult result) {
            result.Status = BLE_DataValidationStatus.NotHandled;
            result.Payload = new byte[0];
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }

        #endregion


    }

}
