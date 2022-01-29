
namespace BluetoothLE.Net.Enumerations {

    /// <summary>Used in the format presenter descriptor</summary>
    /// <remarks>
    /// https://www.bluetooth.com/specifications/assigned-numbers/format-types/
    /// </remarks>
    public enum DataFormatEnum : byte {
        // Do * NOT * change order. Lines up with spec
        Reserved0x00 = 0x00,  // No exponent
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
            return value switch {
                DataFormatEnum.Reserved0x00 or 
                DataFormatEnum.OpaqueStructure or 
                DataFormatEnum.Int_128bit or 
                DataFormatEnum.UInt_128bit or 
                Enumerations.DataFormatEnum.IEEE_11073_16bit_SFLOAT or 
                Enumerations.DataFormatEnum.IEEE_11073_32bit_FLOAT or 
                DataFormatEnum.Unhandled => false,
                _ => true,
            };
        }


        public static bool HasLengthRequirement(this DataFormatEnum value) {
            return value switch {
                DataFormatEnum.Reserved0x00 or 
                DataFormatEnum.UTF8_String or 
                DataFormatEnum.UTF16_String or 
                DataFormatEnum.OpaqueStructure or 
                DataFormatEnum.Unhandled => false,
                _ => true,
            };
        }


        public static int BytesRequired(this DataFormatEnum value) {
            return value switch {
                DataFormatEnum.Boolean or 
                DataFormatEnum.UInt_2bit or 
                DataFormatEnum.UInt_4bit or 
                DataFormatEnum.UInt_8bit or 
                DataFormatEnum.Int_8bit => 1,
                DataFormatEnum.UInt_12bit or 
                DataFormatEnum.Int_12bit or 
                DataFormatEnum.UInt_16bit or 
                DataFormatEnum.Int_16bit or 
                DataFormatEnum.IEEE_11073_16bit_SFLOAT => 2,
                DataFormatEnum.UInt_24bit or 
                DataFormatEnum.Int_24bit => 3,
                DataFormatEnum.UInt_32bit or 
                DataFormatEnum.Int_32bit or 
                DataFormatEnum.IEEE_754_32bit_floating_point or 
                DataFormatEnum.IEEE_11073_32bit_FLOAT or 
                DataFormatEnum.IEEE_20601_format => 4,
                DataFormatEnum.UInt_48bit or 
                DataFormatEnum.Int_48bit => 6,
                DataFormatEnum.UInt_64bit or 
                DataFormatEnum.Int_64bit or 
                DataFormatEnum.IEEE_754_64bit_floating_point => 8,
                DataFormatEnum.UInt_128bit or 
                DataFormatEnum.Int_128bit => 16,
                // You will use the HasLengthRequirement before calling this
                _ => 9999,
            };
        }


        public static bool ExponentAccepted(this DataFormatEnum value) {
            return value switch {
                DataFormatEnum.UInt_12bit or 
                DataFormatEnum.UInt_16bit or 
                DataFormatEnum.UInt_24bit or 
                DataFormatEnum.UInt_32bit or 
                DataFormatEnum.UInt_48bit or 
                DataFormatEnum.UInt_64bit or 
                DataFormatEnum.UInt_128bit or 
                DataFormatEnum.Int_8bit or 
                DataFormatEnum.Int_12bit or 
                DataFormatEnum.Int_16bit or 
                DataFormatEnum.Int_24bit or 
                DataFormatEnum.Int_32bit or 
                DataFormatEnum.Int_48bit or 
                DataFormatEnum.Int_64bit or 
                DataFormatEnum.Int_128bit => true,
                _ => false,
            };
        }


    }

}
