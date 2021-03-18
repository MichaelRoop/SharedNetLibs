
namespace BluetoothLE.Net.Enumerations {

    /// <summary>Duplicates the DataFormatEnum and allows extensions</summary>
    public enum BLE_DataType : uint {

        // First entries are taken from the descriptor data type. Do not change
        // -----  No Exponents  -----
        Reserved = DataFormatEnum.Reserved,
        Bool = DataFormatEnum.Boolean,
        UInt_2bit = DataFormatEnum.UInt_2bit,
        UInt_4bit = DataFormatEnum.UInt_4bit,
        UInt_8bit = DataFormatEnum.UInt_8bit,
        // --------------------------

        UInt_12bit = DataFormatEnum.UInt_12bit,
        UInt_16bit = DataFormatEnum.UInt_16bit,
        UInt_24bit = DataFormatEnum.UInt_24bit,
        UInt_32bit = DataFormatEnum.UInt_32bit,
        UInt_48bit = DataFormatEnum.UInt_48bit,
        UInt_64bit = DataFormatEnum.UInt_64bit,
        UInt_128bit = DataFormatEnum.UInt_128bit,
        Int_8bit = DataFormatEnum.Int_8bit,
        Int_12bit = DataFormatEnum.Int_12bit,
        Int_16bit = DataFormatEnum.Int_16bit,
        Int_24bit = DataFormatEnum.Int_24bit,
        Int_32bit = DataFormatEnum.Int_32bit,
        Int_48bit = DataFormatEnum.Int_48bit,
        Int_64bit = DataFormatEnum.Int_64bit,
        Int_128bit = DataFormatEnum.Int_128bit,

        // -----  No Exponents  -----
        // 754 is the currently supported in MS
        IEEE_754_32bit_floating_point = DataFormatEnum.IEEE_754_32bit_floating_point,
        IEEE_754_64bit_floating_point = DataFormatEnum.IEEE_754_64bit_floating_point,
        IEEE_11073_16bit_SFLOAT = DataFormatEnum.IEEE_11073_16bit_SFLOAT,
        IEEE_11073_32bit_FLOAT = DataFormatEnum.IEEE_11073_32bit_FLOAT,
        IEEE_20601_format = DataFormatEnum.IEEE_20601_format,
        UTF8_String = DataFormatEnum.UTF8_String,
        UTF16_String = DataFormatEnum.UTF16_String,
        OpaqueStructure = DataFormatEnum.OpaqueStructure,
        // --------------------------

        // End of Descriptor format type indicators
        // Last one was 0x1B - their max is 0xFF because it is a byte
        // Start the higher level series at 0x100 (256)
        // Can add different structure types



        // End of Descriptor Format data type


    }


    public static class BLE_DataTypeExtensions {

        public static string ToStr(this BLE_DataType dataType) {
            switch (dataType) {
                case BLE_DataType.Bool:
                    return "Bool";
                case BLE_DataType.UInt_2bit:
                    return "UInt2";
                case BLE_DataType.UInt_4bit:
                    return "UInt4";
                case BLE_DataType.UInt_8bit:
                    return "UInt8";
                case BLE_DataType.UInt_12bit:
                    return "UInt12";
                case BLE_DataType.UInt_16bit:
                    return "UInt16";
                case BLE_DataType.UInt_24bit:
                    return "UInt24";
                case BLE_DataType.UInt_32bit:
                    return "UInt32";
                case BLE_DataType.UInt_48bit:
                    return "UInt48";
                case BLE_DataType.UInt_64bit:
                    return "UInt64";
                case BLE_DataType.UInt_128bit:
                    return "UInt128";
                case BLE_DataType.Int_8bit:
                    return "Int8";
                case BLE_DataType.Int_12bit:
                    return "Int12";
                case BLE_DataType.Int_16bit:
                    return "Int16";
                case BLE_DataType.Int_24bit:
                    return "Int24";
                case BLE_DataType.Int_32bit:
                    return "Int32";
                case BLE_DataType.Int_48bit:
                    return "Int48";
                case BLE_DataType.Int_64bit:
                    return "Int64";
                case BLE_DataType.Int_128bit:
                    return "Int128";
                case BLE_DataType.IEEE_754_32bit_floating_point:
                    return "Float32";
                case BLE_DataType.IEEE_754_64bit_floating_point:
                    return "Float64";
                case BLE_DataType.IEEE_11073_16bit_SFLOAT:
                    return "Float16";
                case BLE_DataType.IEEE_11073_32bit_FLOAT:
                    return "Float32";
                case BLE_DataType.IEEE_20601_format:
                    return "TwoUInt16";
                case BLE_DataType.UTF8_String:
                    return "UTF8 String";
                case BLE_DataType.UTF16_String:
                    return "UTF 16 String (Unicode)";
                case BLE_DataType.OpaqueStructure:
                case BLE_DataType.Reserved:
                default:
                    return "Not handled";

                    // TODO add as needed
            }
        }


        public static int BytesRequired(this BLE_DataType value) {
            switch (value) {
                case BLE_DataType.Bool:
                case BLE_DataType.UInt_2bit:
                case BLE_DataType.UInt_4bit:
                case BLE_DataType.UInt_8bit:
                case BLE_DataType.Int_8bit:
                    return 1;
                case BLE_DataType.UInt_12bit:
                case BLE_DataType.Int_12bit:
                case BLE_DataType.UInt_16bit:
                case BLE_DataType.Int_16bit:
                case BLE_DataType.IEEE_11073_16bit_SFLOAT:
                    return 2;
                case BLE_DataType.UInt_24bit:
                case BLE_DataType.Int_24bit:
                    return 3;
                case BLE_DataType.UInt_32bit:
                case BLE_DataType.Int_32bit:
                case BLE_DataType.IEEE_754_32bit_floating_point:
                case BLE_DataType.IEEE_11073_32bit_FLOAT:
                case BLE_DataType.IEEE_20601_format:
                    return 4;
                case BLE_DataType.UInt_48bit:
                case BLE_DataType.Int_48bit:
                    return 6;
                case BLE_DataType.UInt_64bit:
                case BLE_DataType.Int_64bit:
                case BLE_DataType.IEEE_754_64bit_floating_point:
                    return 8;
                case BLE_DataType.UInt_128bit:
                case BLE_DataType.Int_128bit:
                    return 16;

                case BLE_DataType.UTF8_String:
                case BLE_DataType.UTF16_String:
                case BLE_DataType.OpaqueStructure:
                case BLE_DataType.Reserved:
                default:
                    return 9999;
            }
        }




        //public static uint Size(this BLE_DataType dataType) {
        //    switch (dataType) {
        //        case BLE_DataType.Reserved:
        //            break;
        //        case BLE_DataType.Bool:
        //            break;
        //        case BLE_DataType.UInt_2bit:
        //            break;
        //        case BLE_DataType.UInt_4bit:
        //            break;
        //        case BLE_DataType.UInt_8bit:
        //            break;
        //        case BLE_DataType.UInt_12bit:
        //            break;
        //        case BLE_DataType.UInt_16bit:
        //            break;
        //        case BLE_DataType.UInt_24bit:
        //            break;
        //        case BLE_DataType.UInt_32bit:
        //            break;
        //        case BLE_DataType.UInt_48bit:
        //            break;
        //        case BLE_DataType.UInt_64bit:
        //            break;
        //        case BLE_DataType.UInt_128bit:
        //            break;
        //        case BLE_DataType.Int_8bit:
        //            break;
        //        case BLE_DataType.Int_12bit:
        //            break;
        //        case BLE_DataType.Int_16bit:
        //            break;
        //        case BLE_DataType.Int_24bit:
        //            break;
        //        case BLE_DataType.Int_32bit:
        //            break;
        //        case BLE_DataType.Int_48bit:
        //            break;
        //        case BLE_DataType.Int_64bit:
        //            break;
        //        case BLE_DataType.Int_128bit:
        //            break;
        //        case BLE_DataType.IEEE_754_32bit_floating_point:
        //            break;
        //        case BLE_DataType.IEEE_754_64bit_floating_point:
        //            break;
        //        case BLE_DataType.IEEE_11073_16bit_SFLOAT:
        //            break;
        //        case BLE_DataType.IEEE_11073_32bit_FLOAT:
        //            break;
        //        case BLE_DataType.IEEE_20601_format:
        //            break;
        //        case BLE_DataType.UTF8_String:
        //            break;
        //        case BLE_DataType.UTF16_String:
        //            break;
        //        case BLE_DataType.OpaqueStructure:
        //            break;
        //    }







        //}



    }

}
