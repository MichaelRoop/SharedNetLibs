
namespace BluetoothLE.Net.Enumerations {

    /// <summary>Used in the format presenter descriptor</summary>
    /// <remarks>
    /// https://www.bluetooth.com/specifications/assigned-numbers/format-types/
    /// </remarks>
    public enum DataFormatEnum : byte {
        // Do * NOT * change order. Lines up with spec
        Reserved = 0x00,  // No exponent
        Boolean = 0x01,   // No exponent
        UInt_2bit = 0x02, // No exponent
        UInt_4bit = 0x03, // No exponent
        UInt_8bit = 0x04, // No exponent
        UInt_12bit = 0x05,
        UInt_16bit = 0x06,
        UInt_24bit = 0x07,
        UInt_32bit = 0x08, // Used for IPv4 addresses
        UInt_48bit = 0x09, // Used for BT BD_ADDR address
        UInt_64bit = 0x0A,
        UInt_128bit = 0x0B,
        Int_8bit = 0x0C,
        Int_12bit = 0x0D,
        Int_16bit = 0x0E,
        Int_24bit = 0x0F,
        Int_32bit = 0x10,
        Int_48bit = 0x11,
        Int_64bit = 0x12,
        Int_128bit = 0x13, // Used for IPv6 addresses
        // 754 is the currently supported in MS
        IEEE_754_32bit_floating_point = 0x14,// No exponent
        IEEE_754_64bit_floating_point = 0x15,// No exponent
        IEEE_11073_16bit_SFLOAT = 0x16,     // No exponent
        IEEE_11073_32bit_FLOAT = 0x17,      // No exponent
        IEEE_20601_format = 0x18,           // No exponent - dunit. 2 Uint16 values concatenated
        UTF8_String = 0x19,                 // No exponent
        UTF16_String = 0x1A,                // No exponent
        OpaqueStructure = 0x1B,             // No exponent
        // BLE 0x1C to 0xFF reserved


        // My own enum to 
        Unhandled = 255,
    }


    public static class DataFormatEnumExtensions {
        public static byte ToByte(this DataFormatEnum value) {
            return (byte)value;
        }



        public static bool IsHandled(this DataFormatEnum value) {
            switch (value) {
                case DataFormatEnum.Reserved:
                case DataFormatEnum.OpaqueStructure:
                case DataFormatEnum.Int_128bit:
                case DataFormatEnum.UInt_128bit:
                // IEEE 11073 float is used in medical
                // https://stackoverflow.com/questions/60841331/dart-convert-ieee-11073-32-bit-float-to-a-simple-double
                case Enumerations.DataFormatEnum.IEEE_11073_16bit_SFLOAT:
                case Enumerations.DataFormatEnum.IEEE_11073_32bit_FLOAT:
                case DataFormatEnum.Unhandled:
                    return false;
                default:
                    return true;
            }
        }


        public static bool HasLengthRequirement(this DataFormatEnum value) {
            switch (value) {
                case DataFormatEnum.Reserved:
                case DataFormatEnum.UTF8_String:
                case DataFormatEnum.UTF16_String:
                case DataFormatEnum.OpaqueStructure:
                case DataFormatEnum.Unhandled:
                    return false;
                default:
                    return true;
            }
        }


        public static int BytesRequired(this DataFormatEnum value) {
            switch (value) {
                case DataFormatEnum.Boolean:
                case DataFormatEnum.UInt_2bit:
                case DataFormatEnum.UInt_4bit:
                case DataFormatEnum.UInt_8bit:
                case DataFormatEnum.Int_8bit:
                    return 1;
                case DataFormatEnum.UInt_12bit:
                case DataFormatEnum.Int_12bit:
                case DataFormatEnum.UInt_16bit:
                case DataFormatEnum.Int_16bit:
                case DataFormatEnum.IEEE_11073_16bit_SFLOAT:
                    return 2;
                case DataFormatEnum.UInt_24bit:
                case DataFormatEnum.Int_24bit:
                    return 3;
                case DataFormatEnum.UInt_32bit:
                case DataFormatEnum.Int_32bit:
                case DataFormatEnum.IEEE_754_32bit_floating_point:
                case DataFormatEnum.IEEE_11073_32bit_FLOAT:
                case DataFormatEnum.IEEE_20601_format:
                    return 4;
                case DataFormatEnum.UInt_48bit:
                case DataFormatEnum.Int_48bit:
                    return 6;
                case DataFormatEnum.UInt_64bit:
                case DataFormatEnum.Int_64bit:
                case DataFormatEnum.IEEE_754_64bit_floating_point:
                    return 8;
                case DataFormatEnum.UInt_128bit:
                case DataFormatEnum.Int_128bit:
                    return 16;

                // You will use the HasLengthRequirement before calling this
                case DataFormatEnum.UTF8_String:
                case DataFormatEnum.UTF16_String:

                case DataFormatEnum.OpaqueStructure:
                case DataFormatEnum.Reserved:
                case DataFormatEnum.Unhandled:
                default:
                    return 9999;
            }
        }



    }

}
