using BluetoothLE.Net.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;
using VariousUtils.Net;

namespace BluetoothLE.Net.Tools {

    public static class RangeTools {

        #region Range objects
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
        private static RangeMinMax twoUint16 = new RangeMinMax(BLE_DataType.IEEE_20601_format, "0", UInt32.MaxValue.ToString());

        // Unhandled
        private static RangeMinMax unhandledRange = new RangeMinMax(BLE_DataType.Reserved, "0", "0");



        #endregion


        public static RangeValidationResult Validate(string value1, string value2, BLE_DataType dataType) {
            RangeValidationResult result = new RangeValidationResult();
            result.IsValid = false;
            result.UserEntryString = string.Format("{0}|{1}", value1, value2);
            if (dataType == BLE_DataType.IEEE_20601_format) {
                // Same value for each 
                RangeMinMax minMax = GetMinMaxDisplay(BLE_DataType.UInt_16bit);
                minMax.DataType = dataType.ToStr();
                minMax.Min = string.Format("{0}|{0}", minMax.Min);
                minMax.Max = string.Format("{0}|{0}", minMax.Max);
                ushort val;
                if (UInt16.TryParse(value1, out val)) {
                    if (val >= UInt16.MinValue && val <= UInt16.MaxValue) {
                        if (UInt16.TryParse(value2, out val)) {
                            if (val >= UInt16.MinValue && val <= UInt16.MaxValue) {
                                result.IsValid = true;
                            }
                        }
                    }
                }
            }
            return result;
        }


        private static bool ValidateByteRange(RangeValidationResult result, byte min, byte max) {
            byte val;
            if (Byte.TryParse(result.UserEntryString, out val)) {
                if (val >= min && val <= max) {
                    result.IsValid = true;
                    val.WriteToBuffer(result.Payload, 0);
                    return true;
                }
            }
            return false;
        }


        private static bool ValidateUint16Range(RangeValidationResult result, UInt16 min, UInt16 max) {
            UInt16 val;
            if (UInt16.TryParse(result.UserEntryString, out val)) {
                if (val >= min && val <= max) {
                    result.IsValid = true;
                    val.WriteToBuffer(result.Payload, 0);
                    return true;
                }
            }
            return false;
        }


        private static bool ValidateUint32Range(RangeValidationResult result, UInt32 min, UInt32 max) {
            UInt32 val;
            if (UInt32.TryParse(result.UserEntryString, out val)) {
                if (val >= min && val <= max) {
                    result.IsValid = true;
                    val.WriteToBuffer(result.Payload, 0);
                    return true;
                }
            }
            return false;
        }


        private static bool ValidateUint64Range(RangeValidationResult result, UInt64 min, UInt64 max) {
            UInt64 val;
            if (UInt64.TryParse(result.UserEntryString, out val)) {
                if (val >= min && val <= max) {
                    result.IsValid = true;
                    val.WriteToBuffer(result.Payload, 0);
                    return true;
                }
            }
            return false;
        }


        //////////////////
        ///

        private static bool Validateint16Range(RangeValidationResult result, Int16 min, Int16 max) {
            Int16 val;
            if (Int16.TryParse(result.UserEntryString, out val)) {
                if (val >= min && val <= max) {
                    result.IsValid = true;
                    val.WriteToBuffer(result.Payload, 0);
                    return true;
                }
            }
            return false;
        }


        private static bool Validateint32Range(RangeValidationResult result, Int32 min, Int32 max) {
            Int32 val;
            if (Int32.TryParse(result.UserEntryString, out val)) {
                if (val >= min && val <= max) {
                    result.IsValid = true;
                    val.WriteToBuffer(result.Payload, 0);
                    return true;
                }
            }
            return false;
        }


        private static bool Validateint64Range(RangeValidationResult result, Int64 min, Int64 max) {
            Int64 val;
            if (Int64.TryParse(result.UserEntryString, out val)) {
                if (val >= min && val <= max) {
                    result.IsValid = true;
                    val.WriteToBuffer(result.Payload, 0);
                    return true;
                }
            }
            return false;
        }



        ////////////////////////////




        /// <summary>Validate user entry from UI</summary>
        /// <param name="value">The value as string entered by the user</param>
        /// <param name="bleType">The type this applies to on conversion</param>
        /// <returns></returns>
        public static RangeValidationResult Validate(string value, BLE_DataType bleType) {
            // check for range
            // check for valid string for type
            RangeValidationResult result = new RangeValidationResult();
            result.UserEntryString = value;
            result.IsValid = false;
            result.Payload = new byte[bleType.BytesRequired()];
            result.Range = GetMinMaxDisplay(bleType);
            switch (bleType) {
                case BLE_DataType.Bool:
                    if (!ValidateByteRange(result, 0, 1)) {
                        bool bVal;
                        if (Boolean.TryParse(value, out bVal)) {
                            result.IsValid = true;
                            result.Payload[0] = (bVal == true) ? (byte)1 : (byte)0;
                        }
                    }
                    break;
                case BLE_DataType.UInt_2bit:
                    ValidateByteRange(result, 0, 3);
                    break;
                case BLE_DataType.UInt_4bit:
                    ValidateByteRange(result, 0, 15);
                    break;
                case BLE_DataType.UInt_8bit:
                    ValidateByteRange(result, 0, Byte.MaxValue);
                    break;
                case BLE_DataType.UInt_12bit:
                    ValidateUint16Range(result, 0, 4095);
                    break;
                case BLE_DataType.UInt_16bit:
                    ValidateUint16Range(result, 0, UInt16.MaxValue);
                    break;
                case BLE_DataType.UInt_24bit:
                    ValidateUint32Range(result, 0, 16777215);
                    break;
                case BLE_DataType.UInt_32bit:
                    ValidateUint32Range(result, 0, UInt32.MaxValue);
                    break;
                case BLE_DataType.UInt_48bit:
                    ValidateUint64Range(result, 0, 281474976710655);
                    break;
                case BLE_DataType.UInt_64bit:
                    ValidateUint64Range(result, 0, UInt64.MaxValue);
                    break;
                case BLE_DataType.UInt_128bit:
                    // TODO - not currently handled
                    break;
                case BLE_DataType.Int_8bit:
                    sbyte val;
                    if (SByte.TryParse(result.UserEntryString, out val)) {
                        if (val >= SByte.MinValue && val <= SByte.MaxValue) {
                            result.IsValid = true;
                            val.WriteToBuffer(result.Payload, 0);
                        }
                    }
                    break;
                case BLE_DataType.Int_12bit:
                    Validateint16Range(result, -2048, 2047);
                    break;
                case BLE_DataType.Int_16bit:
                    Validateint16Range(result, Int16.MinValue, Int16.MaxValue);
                    break;
                case BLE_DataType.Int_24bit:
                    Validateint32Range(result, -8388608, 8388607);
                    break;
                case BLE_DataType.Int_32bit:
                    Validateint32Range(result, Int32.MinValue, Int32.MaxValue);
                    break;
                case BLE_DataType.Int_48bit:
                    break;
                case BLE_DataType.Int_64bit:
                    break;
                case BLE_DataType.Int_128bit:
                    break;
                case BLE_DataType.IEEE_754_32bit_floating_point:
                    break;
                case BLE_DataType.IEEE_754_64bit_floating_point:
                    break;
                case BLE_DataType.IEEE_11073_16bit_SFLOAT:
                    break;
                case BLE_DataType.IEEE_11073_32bit_FLOAT:
                    break;
                case BLE_DataType.IEEE_20601_format:
                    break;
                case BLE_DataType.UTF8_String:
                    if (value.Length > 0) {
                        result.IsValid = true;
                        result.Payload = Encoding.UTF8.GetBytes(value);
                    }
                    break;
                case BLE_DataType.UTF16_String:
                    if (value.Length > 0) {
                        result.IsValid = true;
                        result.Payload = Encoding.Unicode.GetBytes(value);
                    }
                    break;
                case BLE_DataType.OpaqueStructure:
                case BLE_DataType.Reserved:
                    result.Payload = new byte[0];
                    break;
            }


            return result;
        }





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



    }

}
