using BluetoothLE.Net.Enumerations;
using BluetoothLE.Net.Parsers.Types;
using LogUtils.Net;
using System.Text;
using VariousUtils.Net;

namespace BluetoothLE.Net.Tools {

    public class BLERangeValidator {

        #region Data

        private readonly ClassLog log = new ("BLERangeValidator");
        //private readonly BLEValidRangeFactory factory = new ();

        #endregion

        #region Public

        public static DataTypeDisplay GetRange(BLE_DataType dataType) {
            return BLEValidRangeFactory.GetRange(dataType);
        }



        /// <summary>Validate user entry from UI</summary>
        /// <param name="value">The value as string entered by the user</param>
        /// <param name="bleType">The type this applies to on conversion</param>
        /// <returns></returns>
        public RangeValidationResult Validate(string value, BLE_DataType bleType) {
            try {
                RangeValidationResult result = new (value);
                result.Status = BLE_DataValidationStatus.StringConversionFailed;
                result.Payload = new byte[bleType.BytesRequired()];
                result.Range = GetRange(bleType);
                return bleType switch {
                    BLE_DataType.Bool => ValidateBoolRangeRange(result),
                    BLE_DataType.UInt_2bit => ValidateUint02Range(result),
                    BLE_DataType.UInt_4bit => ValidateUint04Range(result),
                    BLE_DataType.UInt_8bit => ValidateUint08Range(result),
                    BLE_DataType.UInt_12bit => ValidateUint12Range(result),
                    BLE_DataType.UInt_16bit => ValidateUint16Range(result),
                    BLE_DataType.UInt_24bit => ValidateUint24Range(result),
                    BLE_DataType.UInt_32bit => ValidateUint32Range(result),
                    BLE_DataType.UInt_48bit => ValidateUint48Range(result),
                    BLE_DataType.UInt_64bit => ValidateUint64Range(result),
                    BLE_DataType.UInt_128bit => RangeNotHandled(result),
                    BLE_DataType.Int_8bit => ValidateInt8Range(result),
                    BLE_DataType.Int_12bit => ValidateInt12Range(result),
                    BLE_DataType.Int_16bit => ValidateInt16Range(result),
                    BLE_DataType.Int_24bit => ValidateInt24Range(result),
                    BLE_DataType.Int_32bit => ValidateInt32Range(result),
                    BLE_DataType.Int_48bit => ValidateInt48Range(result),
                    BLE_DataType.Int_64bit => ValidateInt64Range(result),
                    BLE_DataType.Int_128bit => RangeNotHandled(result),
                    BLE_DataType.IEEE_754_32bit_floating_point => Validateint32Float(result),
                    BLE_DataType.IEEE_754_64bit_floating_point => Validateint64Double(result),
                    BLE_DataType.IEEE_11073_16bit_SFLOAT => RangeNotHandled(result),
                    BLE_DataType.IEEE_11073_32bit_FLOAT => RangeNotHandled(result),
                    BLE_DataType.IEEE_20601_format => ValidateIEEE20601(result),
                    BLE_DataType.UTF8_String => ValidateUTF8String(result),
                    BLE_DataType.UTF16_String => ValidateUTF16String(result),
                    BLE_DataType.OpaqueStructure or BLE_DataType.Reserved0x00 or BLE_DataType.Unhandled => RangeNotHandled(result),
                    _ => RangeNotHandled(result),
                };
            }
            catch (Exception e) {
                log.Exception(9999, "RangeValidationResult", "", e);
                return new RangeValidationResult() {
                    UserEntryString = value,
                    Message = BLE_DataValidationStatus.UnhandledError.ToString(),
                    Range = new DataTypeDisplay(BLE_DataType.Unhandled, "0", "0"),
                    Payload = Array.Empty<byte>(),
                    Status = BLE_DataValidationStatus.UnhandledError,
                };
            }
        }

        #endregion

        #region Private validate methods

        private static RangeValidationResult ValidateBoolRangeRange(RangeValidationResult result) {
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (Byte.TryParse(result.UserEntryString, out byte val)) {
                if (val == 0 || val == 1) {
                    result.Status = BLE_DataValidationStatus.Success;
                    val.WriteToBuffer(result.Payload, 0);
                }
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private static RangeValidationResult ValidateUint02Range(RangeValidationResult result) {
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (UInt02.TryParse(result.UserEntryString, out byte val)) {
                result.Status = BLE_DataValidationStatus.Success;
                val.WriteToBuffer(result.Payload, 0);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private static RangeValidationResult ValidateUint04Range(RangeValidationResult result) {
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (UInt04.TryParse(result.UserEntryString, out byte val)) {
                result.Status = BLE_DataValidationStatus.Success;
                val.WriteToBuffer(result.Payload, 0);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private static RangeValidationResult ValidateUint08Range(RangeValidationResult result) {
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (Byte.TryParse(result.UserEntryString, out byte val)) {
                result.Status = BLE_DataValidationStatus.Success;
                val.WriteToBuffer(result.Payload, 0);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private static RangeValidationResult ValidateUint12Range(RangeValidationResult result) {
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (UInt12.TryParse(result.UserEntryString, out UInt16 val)) {
                result.Status = BLE_DataValidationStatus.Success;
                val.WriteToBuffer(result.Payload, 0);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private static RangeValidationResult ValidateUint16Range(RangeValidationResult result) {
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (UInt16.TryParse(result.UserEntryString, out UInt16 val)) {
                result.Status = BLE_DataValidationStatus.Success;
                val.WriteToBuffer(result.Payload, 0);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private static RangeValidationResult ValidateUint24Range(RangeValidationResult result) {
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (UInt24.TryParse(result.UserEntryString, out UInt32 val)) {
                result.Status = BLE_DataValidationStatus.Success;
                result.Payload = UInt24.GetBytes(val);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private static RangeValidationResult ValidateUint32Range(RangeValidationResult result) {
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (UInt32.TryParse(result.UserEntryString, out UInt32 val)) {
                result.Status = BLE_DataValidationStatus.Success;
                val.WriteToBuffer(result.Payload, 0);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private static RangeValidationResult ValidateUint48Range(RangeValidationResult result) {
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (UInt48.TryParse(result.UserEntryString, out UInt64 val)) {
                result.Status = BLE_DataValidationStatus.Success;
                result.Payload = UInt48.GetBytes(val);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private static RangeValidationResult ValidateUint64Range(RangeValidationResult result) {
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (UInt64.TryParse(result.UserEntryString, out UInt64 val)) {
                result.Status = BLE_DataValidationStatus.Success;
                val.WriteToBuffer(result.Payload, 0);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private static RangeValidationResult ValidateInt8Range(RangeValidationResult result) {
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (SByte.TryParse(result.UserEntryString, out sbyte val)) {
                result.Status = BLE_DataValidationStatus.Success;
                val.WriteToBuffer(result.Payload, 0);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private static RangeValidationResult ValidateInt12Range(RangeValidationResult result) {
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (Int12.TryParse(result.UserEntryString, out Int16 val)) {
                result.Status = BLE_DataValidationStatus.Success;
                // Call the Int12 to properly set the sign for 12 int
                val = Int12.GetNew(val).Value;
                val.WriteToBuffer(result.Payload, 0);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private static RangeValidationResult ValidateInt16Range(RangeValidationResult result) {
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (Int16.TryParse(result.UserEntryString, out Int16 val)) {
                result.Status = BLE_DataValidationStatus.Success;
                val.WriteToBuffer(result.Payload, 0);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private static RangeValidationResult ValidateInt24Range(RangeValidationResult result) {
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (Int24.TryParse(result.UserEntryString, out Int32 val)) {
                result.Status = BLE_DataValidationStatus.Success;
                result.Payload = Int24.GetBytes(val);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private static RangeValidationResult ValidateInt32Range(RangeValidationResult result) {
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (Int32.TryParse(result.UserEntryString, out Int32 val)) {
                result.Status = BLE_DataValidationStatus.Success;
                val.WriteToBuffer(result.Payload, 0);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private static RangeValidationResult ValidateInt48Range(RangeValidationResult result) {
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (Int48.TryParse(result.UserEntryString, out Int64 val)) {
                result.Status = BLE_DataValidationStatus.Success;
                result.Payload = Int48.GetBytes(val);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private static RangeValidationResult ValidateInt64Range(RangeValidationResult result) {
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (Int64.TryParse(result.UserEntryString, out Int64 val)) {
                result.Status = BLE_DataValidationStatus.Success;
                val.WriteToBuffer(result.Payload, 0);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private static RangeValidationResult Validateint32Float(RangeValidationResult result) {
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (Single.TryParse(result.UserEntryString, out Single val)) {
                // The float TryParse does not validate range so do it manually
                if (val >= Single.MinValue && val <= Single.MaxValue) {
                    result.Status = BLE_DataValidationStatus.Success;
                    val.WriteToBuffer(result.Payload, 0);
                }
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private static RangeValidationResult Validateint64Double(RangeValidationResult result) {
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (Double.TryParse(result.UserEntryString, out Double val)) {
                // The double TryParse does not validate range so do it manually
                if (val >= Double.MinValue && val <= Double.MaxValue) {
                    result.Status = BLE_DataValidationStatus.Success;
                    val.WriteToBuffer(result.Payload, 0);
                }
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private static RangeValidationResult ValidateIEEE20601(RangeValidationResult result) {
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
                result.Message = result.Status.ToString();
                return result;
            }

            // Input supposed to be delimited as 0xFF|0xFF
            string[] parts = result.UserEntryString.Split('|');
            if (parts.Length < 2) {
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
            RangeValidationResult tmp = new (value);
            ValidateUint16Range(tmp);
            if (tmp.Status != BLE_DataValidationStatus.Success) {
                result.Status = tmp.Status;
                return false;
            }
            return true;
        }


        private static RangeValidationResult ValidateUTF8String(RangeValidationResult result) {
            if (result.UserEntryString.Length > 0) {
                result.Status = BLE_DataValidationStatus.Success;
                result.Payload = Encoding.UTF8.GetBytes(result.UserEntryString);
            }
            else {
                // Is empty valid?
                result.Status = BLE_DataValidationStatus.Empty;
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private static RangeValidationResult ValidateUTF16String(RangeValidationResult result) {
            if (result.UserEntryString.Length > 0) {
                result.Status = BLE_DataValidationStatus.Success;
                result.Payload = Encoding.Unicode.GetBytes(result.UserEntryString);
            }
            else {
                // Is empty valid?
                result.Status = BLE_DataValidationStatus.Empty;
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private static RangeValidationResult RangeNotHandled(RangeValidationResult result) {
            result.Status = BLE_DataValidationStatus.NotHandled;
            result.Payload = Array.Empty<byte>();
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }

        #endregion


    }

}
