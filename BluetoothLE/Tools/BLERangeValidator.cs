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
                result.Status = BLE_DataValidationStatus.StringConversionFailed;
                result.Payload = new byte[bleType.BytesRequired()];
                result.Range = this.GetRange(bleType);
                switch (bleType) {
                    case BLE_DataType.Bool:
                        return ValidateBoolRangeRange(result);
                    case BLE_DataType.UInt_2bit:
                        return ValidateUint02Range(result);
                    case BLE_DataType.UInt_4bit:
                        return ValidateUint04Range(result);
                    case BLE_DataType.UInt_8bit:
                        return ValidateUint08Range(result);
                    case BLE_DataType.UInt_12bit:
                        return ValidateUint12Range(result);
                    case BLE_DataType.UInt_16bit:
                        return ValidateUint16Range(result);
                    case BLE_DataType.UInt_24bit:
                        return ValidateUint24Range(result);
                    case BLE_DataType.UInt_32bit:
                        return ValidateUint32Range(result);
                    case BLE_DataType.UInt_48bit:
                        return ValidateUint48Range(result);
                    case BLE_DataType.UInt_64bit:
                        return ValidateUint64Range(result);
                    case BLE_DataType.UInt_128bit:
                        return RangeNotHandled(result);
                    case BLE_DataType.Int_8bit:
                        return ValidateInt8Range(result);
                    case BLE_DataType.Int_12bit:
                        return ValidateInt12Range(result);
                    case BLE_DataType.Int_16bit:
                        return ValidateInt16Range(result);
                    case BLE_DataType.Int_24bit:
                        return ValidateInt24Range(result);
                    case BLE_DataType.Int_32bit:
                        return ValidateInt32Range(result);
                    case BLE_DataType.Int_48bit:
                        return ValidateInt48Range(result);
                    case BLE_DataType.Int_64bit:
                        return ValidateInt64Range(result);
                    case BLE_DataType.Int_128bit:
                        return RangeNotHandled(result);
                    case BLE_DataType.IEEE_754_32bit_floating_point:
                        return Validateint32Float(result);
                    case BLE_DataType.IEEE_754_64bit_floating_point:
                        return Validateint64Double(result);
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

        private RangeValidationResult ValidateBoolRangeRange(RangeValidationResult result) {
            byte val;
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (Byte.TryParse(result.UserEntryString, out val)) {
                if (val == 0 || val == 1) {
                    result.Status = BLE_DataValidationStatus.Success;
                    val.WriteToBuffer(result.Payload, 0);
                }
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private RangeValidationResult ValidateUint02Range(RangeValidationResult result) {
            Byte val;
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (UInt02.TryParse(result.UserEntryString, out val)) {
                result.Status = BLE_DataValidationStatus.Success;
                val.WriteToBuffer(result.Payload, 0);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private RangeValidationResult ValidateUint04Range(RangeValidationResult result) {
            Byte val;
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (UInt04.TryParse(result.UserEntryString, out val)) {
                result.Status = BLE_DataValidationStatus.Success;
                val.WriteToBuffer(result.Payload, 0);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private RangeValidationResult ValidateUint08Range(RangeValidationResult result) {
            byte val;
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (Byte.TryParse(result.UserEntryString, out val)) {
                result.Status = BLE_DataValidationStatus.Success;
                val.WriteToBuffer(result.Payload, 0);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private RangeValidationResult ValidateUint12Range(RangeValidationResult result) {
            UInt16 val;
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (UInt12.TryParse(result.UserEntryString, out val)) {
                result.Status = BLE_DataValidationStatus.Success;
                val.WriteToBuffer(result.Payload, 0);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private RangeValidationResult ValidateUint16Range(RangeValidationResult result) {
            UInt16 val;
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (UInt16.TryParse(result.UserEntryString, out val)) {
                result.Status = BLE_DataValidationStatus.Success;
                val.WriteToBuffer(result.Payload, 0);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private RangeValidationResult ValidateUint24Range(RangeValidationResult result) {
            UInt32 val;
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (UInt24.TryParse(result.UserEntryString, out val)) {
                result.Status = BLE_DataValidationStatus.Success;
                result.Payload = UInt24.GetBytes(val);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private RangeValidationResult ValidateUint32Range(RangeValidationResult result) {
            UInt32 val;
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (UInt32.TryParse(result.UserEntryString, out val)) {
                result.Status = BLE_DataValidationStatus.Success;
                val.WriteToBuffer(result.Payload, 0);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private RangeValidationResult ValidateUint48Range(RangeValidationResult result) {
            UInt64 val;
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (UInt48.TryParse(result.UserEntryString, out val)) {
                result.Status = BLE_DataValidationStatus.Success;
                result.Payload = UInt48.GetBytes(val);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private RangeValidationResult ValidateUint64Range(RangeValidationResult result) {
            UInt64 val;
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (UInt64.TryParse(result.UserEntryString, out val)) {
                result.Status = BLE_DataValidationStatus.Success;
                val.WriteToBuffer(result.Payload, 0);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private RangeValidationResult ValidateInt8Range(RangeValidationResult result) {
            sbyte val;
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (SByte.TryParse(result.UserEntryString, out val)) {
                result.Status = BLE_DataValidationStatus.Success;
                val.WriteToBuffer(result.Payload, 0);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private RangeValidationResult ValidateInt12Range(RangeValidationResult result) {
            Int16 val;
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (Int12.TryParse(result.UserEntryString, out val)) {
                result.Status = BLE_DataValidationStatus.Success;
                // Call the Int12 to properly set the sign for 12 int
                val = Int12.GetNew(val).Value;
                val.WriteToBuffer(result.Payload, 0);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private RangeValidationResult ValidateInt16Range(RangeValidationResult result) {
            Int16 val;
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (Int16.TryParse(result.UserEntryString, out val)) {
                result.Status = BLE_DataValidationStatus.Success;
                val.WriteToBuffer(result.Payload, 0);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private RangeValidationResult ValidateInt24Range(RangeValidationResult result) {
            Int32 val;
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (Int24.TryParse(result.UserEntryString, out val)) {
                result.Status = BLE_DataValidationStatus.Success;
                result.Payload = Int24.GetBytes(val);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private RangeValidationResult ValidateInt32Range(RangeValidationResult result) {
            Int32 val;
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (Int32.TryParse(result.UserEntryString, out val)) {
                result.Status = BLE_DataValidationStatus.Success;
                val.WriteToBuffer(result.Payload, 0);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private RangeValidationResult ValidateInt48Range(RangeValidationResult result) {
            Int64 val;
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (Int48.TryParse(result.UserEntryString, out val)) {
                result.Status = BLE_DataValidationStatus.Success;
                result.Payload = Int48.GetBytes(val);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private RangeValidationResult ValidateInt64Range(RangeValidationResult result) {
            Int64 val;
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (Int64.TryParse(result.UserEntryString, out val)) {
                result.Status = BLE_DataValidationStatus.Success;
                val.WriteToBuffer(result.Payload, 0);
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private RangeValidationResult Validateint32Float(RangeValidationResult result) {
            Single val;
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (Single.TryParse(result.UserEntryString, out val)) {
                // The float TryParse does not validate range so do it manually
                if (val >= Single.MinValue && val <= Single.MaxValue) {
                    result.Status = BLE_DataValidationStatus.Success;
                    val.WriteToBuffer(result.Payload, 0);
                }
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private RangeValidationResult Validateint64Double(RangeValidationResult result) {
            Double val;
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
            }
            else if (Double.TryParse(result.UserEntryString, out val)) {
                // The double TryParse does not validate range so do it manually
                if (val >= Double.MinValue && val <= Double.MaxValue) {
                    result.Status = BLE_DataValidationStatus.Success;
                    val.WriteToBuffer(result.Payload, 0);
                }
            }
            result.Message = result.Status.ToString().CamelCaseToSpaces();
            return result;
        }


        private RangeValidationResult ValidateIEEE20601(RangeValidationResult result) {
            if (string.IsNullOrWhiteSpace(result.UserEntryString)) {
                result.Status = BLE_DataValidationStatus.Empty;
                result.Message = result.Status.ToString();
                return result;
            }

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
            this.ValidateUint16Range(tmp);
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
                // Is empty valid?
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
                // Is empty valid?
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
