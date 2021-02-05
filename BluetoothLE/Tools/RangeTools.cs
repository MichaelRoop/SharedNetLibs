using BluetoothLE.Net.Enumerations;
using LogUtils.Net;
using System;
using System.Linq;
using System.Text;
using VariousUtils.Net;

namespace BluetoothLE.Net.Tools {

    public static class RangeTools {

        #region Data

        private static ClassLog log = new ClassLog("RangetTools");

        // Unsigned integers
        private static RangeMinMax boolRange = new RangeMinMax(BLE_DataType.Bool, "0", "1");
        private static RangeMinMax uint2Range = new RangeMinMax(BLE_DataType.UInt_2bit, "0", "3");
        private static RangeMinMax uint4Range = new RangeMinMax(BLE_DataType.UInt_4bit, "0", "15");
        private static RangeMinMax uint8Range = new RangeMinMax(BLE_DataType.UInt_8bit, Byte.MinValue.ToString(), Byte.MaxValue.ToString());
        private static RangeMinMax uint12Range = new RangeMinMax(BLE_DataType.UInt_12bit, "0", "4095");
        private static RangeMinMax uint16Range = new RangeMinMax(BLE_DataType.UInt_16bit, UInt16.MinValue.ToString(), UInt16.MaxValue.ToString());
        private static RangeMinMax uint24Range = new RangeMinMax(BLE_DataType.UInt_24bit, "0", "16777215");
        private static RangeMinMax uint32Range = new RangeMinMax(BLE_DataType.UInt_32bit, UInt32.MinValue.ToString(), UInt32.MaxValue.ToString());
        private static RangeMinMax uint48Range = new RangeMinMax(BLE_DataType.UInt_48bit, "0", "281474976710655");
        private static RangeMinMax uint64Range = new RangeMinMax(BLE_DataType.UInt_64bit, UInt64.MinValue.ToString(), UInt64.MaxValue.ToString());
        private static RangeMinMax uint128Range = new RangeMinMax(BLE_DataType.UInt_128bit, "0", "340282366920938463463374607431768211455");
        // Signed integers
        private static RangeMinMax int8Range = new RangeMinMax(BLE_DataType.Int_8bit, SByte.MinValue.ToString(), SByte.MaxValue.ToString());
        private static RangeMinMax int12Range = new RangeMinMax(BLE_DataType.Int_12bit, "-2048", "2047");
        private static RangeMinMax int16Range = new RangeMinMax(BLE_DataType.Int_16bit, Int16.MinValue.ToString(), Int16.MaxValue.ToString());
        private static RangeMinMax int24Range = new RangeMinMax(BLE_DataType.Int_24bit, "-8388608", "8388607");
        private static RangeMinMax int32Range = new RangeMinMax(BLE_DataType.Int_32bit, Int32.MinValue.ToString(), Int32.MaxValue.ToString());
        private static RangeMinMax int48Range = new RangeMinMax(BLE_DataType.Int_48bit, "-140737488355328", "140737488355327");
        private static RangeMinMax int64Range = new RangeMinMax(BLE_DataType.Int_64bit, Int64.MinValue.ToString(), Int64.MaxValue.ToString());
        private static RangeMinMax int128Range = new RangeMinMax(BLE_DataType.Int_128bit, "-170141183460469231731687303715884105728", "170141183460469231731687303715884105727");
        // Float and double
        private static RangeMinMax float32 = new RangeMinMax(BLE_DataType.IEEE_754_32bit_floating_point, Single.MinValue.ToString(), Single.MaxValue.ToString());
        private static RangeMinMax float64 = new RangeMinMax(BLE_DataType.IEEE_754_64bit_floating_point, Double.MinValue.ToString(), Double.MaxValue.ToString());
        // These require some bit shifting. TBD
        private static RangeMinMax float16_11073 = new RangeMinMax(BLE_DataType.IEEE_11073_16bit_SFLOAT, "0", "0");
        private static RangeMinMax float32IEE_11073 = new RangeMinMax(BLE_DataType.IEEE_11073_32bit_FLOAT, "0", "0");
        // Strings
        private static RangeMinMax utf8String = new RangeMinMax(BLE_DataType.UTF8_String, "1", "variable");
        private static RangeMinMax utf16String = new RangeMinMax(BLE_DataType.UTF16_String, "1", "variable");
        // this is 2 Uint16 in one block
        // TODO - need to handle both pieces as UINT16
        private static RangeMinMax twoUint16 = new RangeMinMax(
            BLE_DataType.IEEE_20601_format, 
            string.Format("{0}|{0}", UInt16.MinValue),
            string.Format("{0}|{0}", UInt16.MaxValue));

        // Unhandled
        private static RangeMinMax unhandledRange = new RangeMinMax(BLE_DataType.Reserved, "0", "0");

        #endregion

        #region Public

        /// <summary>Validate user entry from UI</summary>
        /// <param name="value">The value as string entered by the user</param>
        /// <param name="bleType">The type this applies to on conversion</param>
        /// <returns></returns>
        public static RangeValidationResult Validate(string value, BLE_DataType bleType) {
            try {
                RangeValidationResult result = new RangeValidationResult(value);
                result.Payload = new byte[bleType.BytesRequired()];
                result.Range = GetMinMaxDisplay(bleType);
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
                        return ValidateUint16Range(result, 0, 4095);
                    case BLE_DataType.UInt_16bit:
                        return ValidateUint16Range(result, 0, UInt16.MaxValue);
                    case BLE_DataType.UInt_24bit:
                        return ValidateUint24Range(result, 0, 16777215);
                    case BLE_DataType.UInt_32bit:
                        return ValidateUint32Range(result, 0, UInt32.MaxValue);
                    case BLE_DataType.UInt_48bit:
                        return ValidateUint64Range(result, 0, 281474976710655);
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
            catch(Exception e) {
                log.Exception(9999, "RangeValidationResult", "", e);
                return new RangeValidationResult() {
                    UserEntryString = value,
                    Message = BLE_DataValidationStatus.UnhandledError.ToString(),
                    Range = new RangeMinMax(BLE_DataType.Reserved, "0", "0"),
                    Payload = new byte[0],
                    Status = BLE_DataValidationStatus.UnhandledError,
                };
            }
        }


        /// <summary>Get the min and max value for the data type</summary>
        /// <param name="dataType">The BLE data type</param>
        /// <returns>A min max range object</returns>
        public static RangeMinMax GetMinMaxDisplay(BLE_DataType dataType) {
            switch (dataType) {
                case BLE_DataType.Bool:
                    return boolRange;
                case BLE_DataType.UInt_2bit:
                    return uint2Range;
                case BLE_DataType.UInt_4bit:
                    return uint4Range;
                case BLE_DataType.UInt_8bit:
                    return uint8Range;
                case BLE_DataType.UInt_12bit:
                    return uint12Range;
                case BLE_DataType.UInt_16bit:
                    return uint16Range;
                case BLE_DataType.UInt_24bit:
                    return uint24Range;
                case BLE_DataType.UInt_32bit:
                    return uint32Range;
                case BLE_DataType.UInt_48bit:
                    return uint48Range;
                case BLE_DataType.UInt_64bit:
                    return uint64Range;
                case BLE_DataType.UInt_128bit:
                    return uint128Range;
                case BLE_DataType.Int_8bit:
                    return int8Range;
                case BLE_DataType.Int_12bit:
                    return int12Range;
                case BLE_DataType.Int_16bit:
                    return int16Range;
                case BLE_DataType.Int_24bit:
                    return int24Range;
                case BLE_DataType.Int_32bit:
                    return int32Range;
                case BLE_DataType.Int_48bit:
                    return int48Range;
                case BLE_DataType.Int_64bit:
                    return int64Range;
                case BLE_DataType.Int_128bit:
                    return int128Range;
                case BLE_DataType.IEEE_754_32bit_floating_point:
                    return float32;
                case BLE_DataType.IEEE_754_64bit_floating_point:
                    return float64;
                case BLE_DataType.IEEE_11073_16bit_SFLOAT:
                    return float16_11073;
                case BLE_DataType.IEEE_11073_32bit_FLOAT:
                    return float32IEE_11073;
                case BLE_DataType.IEEE_20601_format:
                    return twoUint16;
                case BLE_DataType.UTF8_String:
                    return utf8String;
                case BLE_DataType.UTF16_String:
                    return utf16String;
                case BLE_DataType.OpaqueStructure:
                case BLE_DataType.Reserved:
                default:
                    return unhandledRange;
            }
        }

        #endregion

        #region Private validate methods

        private static RangeValidationResult ValidateByteRange(RangeValidationResult result, byte min, byte max) {
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


        private static RangeValidationResult ValidateUint16Range(RangeValidationResult result, UInt16 min, UInt16 max) {
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


        private static RangeValidationResult ValidateUint24Range(RangeValidationResult result, UInt32 min, UInt32 max) {
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



        private static RangeValidationResult ValidateUint32Range(RangeValidationResult result, UInt32 min, UInt32 max) {
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


        private static RangeValidationResult ValidateUint64Range(RangeValidationResult result, UInt64 min, UInt64 max) {
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


        private static RangeValidationResult ValidateInt8Range(RangeValidationResult result, sbyte min, sbyte max) {
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


        private static RangeValidationResult Validateint16Range(RangeValidationResult result, Int16 min, Int16 max) {
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


        private static RangeValidationResult Validateint32Range(RangeValidationResult result, Int32 min, Int32 max) {
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


        private static RangeValidationResult Validateint64Range(RangeValidationResult result, Int64 min, Int64 max) {
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


        private static RangeValidationResult Validateint32Float(RangeValidationResult result, Single min, Single max) {
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


        private static RangeValidationResult Validateint64Double(RangeValidationResult result, Double min, Double max) {
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


        private static RangeValidationResult ValidateIEEE20601(RangeValidationResult result) {
            // Input supposed to be delimited as 0xFF|0xFF
            string[] parts = result.UserEntryString.Split('|');
            if (parts.Count() < 2) {
                result.Status = BLE_DataValidationStatus.InvalidInput;
                return result;
            }

            if (ValidateIEEE20601Part(result, parts[0]) &&
                ValidateIEEE20601Part(result, parts[1])) { 
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


        private static bool ValidateIEEE20601Part(RangeValidationResult result, string value) {
            RangeValidationResult tmp = new RangeValidationResult(value);
            ValidateUint16Range(tmp, UInt16.MinValue, UInt16.MaxValue);
            if (tmp.Status != BLE_DataValidationStatus.Success) {
                result.Status = tmp.Status;
                return false;
            }
            return true;
        }


        public static RangeValidationResult ValidateUTF8String(RangeValidationResult result) {
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


        public static RangeValidationResult ValidateUTF16String(RangeValidationResult result) {
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


        public static RangeValidationResult RangeNotHandled(RangeValidationResult result) {
            result.Status = BLE_DataValidationStatus.NotHandled;
            result.Payload = new byte[0];
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }

        #endregion

    }

}
