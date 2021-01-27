
namespace BluetoothLE.Net.Enumerations {

    /// <summary>Used in the format presenter descriptor</summary>
    public enum DataFormatEnum : byte {
        // Do * NOT * change order. Lines up with spec
        Reserved = 0,
        Boolean = 1,
        UInt_2bit = 2,
        UInt_4bit = 3,
        UInt_8bit = 4,
        UInt_12bit = 5,
        UInt_16bit = 6,
        UInt_24bit = 7,
        UInt_32bit = 8,
        UInt_48bit = 9,
        UInt_64bit = 10,
        UInt_128bit = 11,
        Int_8bit = 12,
        Int_12bit = 13,
        Int_16bit = 14,
        Int_24bit = 15,
        Int_32bit = 16,
        Int_48bit = 17,
        Int_64bit = 18,
        Int_128bit = 19,
        // 754 is the currently supported in MS
        IEEE_754_32bit_floating_point = 20,
        IEEE_754_64bit_floating_point = 21,
        IEEE_11073_16bit_SFLOAT = 22,
        IEEE_11073_32bit_FLOAT = 23,
        IEEE_20601_format = 24,
        UTF8_String = 25,
        UTF16_String = 26,
        OpaqueStructure = 27,

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
                // This is generic data type - no size specified
                case DataFormatEnum.IEEE_20601_format:
                case DataFormatEnum.OpaqueStructure:
                case DataFormatEnum.Int_24bit:
                case DataFormatEnum.Int_48bit:
                case DataFormatEnum.Int_128bit:
                case DataFormatEnum.UInt_128bit:
                // Not sure what the IEEE float is. 754 is the current MS
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
                // This is generic data type - no size specified
                case DataFormatEnum.IEEE_20601_format:
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

                // This is generic data type - no size specified
                case DataFormatEnum.IEEE_20601_format:
                case DataFormatEnum.OpaqueStructure:
                case DataFormatEnum.Reserved:
                case DataFormatEnum.Unhandled:
                default:
                    return 9999;
            }
        }



    }

}
