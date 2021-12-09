
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
            return dataType switch {
                BLE_DataType.Bool => "Bool",
                BLE_DataType.UInt_2bit => "UInt2",
                BLE_DataType.UInt_4bit => "UInt4",
                BLE_DataType.UInt_8bit => "UInt8",
                BLE_DataType.UInt_12bit => "UInt12",
                BLE_DataType.UInt_16bit => "UInt16",
                BLE_DataType.UInt_24bit => "UInt24",
                BLE_DataType.UInt_32bit => "UInt32",
                BLE_DataType.UInt_48bit => "UInt48",
                BLE_DataType.UInt_64bit => "UInt64",
                BLE_DataType.UInt_128bit => "UInt128",
                BLE_DataType.Int_8bit => "Int8",
                BLE_DataType.Int_12bit => "Int12",
                BLE_DataType.Int_16bit => "Int16",
                BLE_DataType.Int_24bit => "Int24",
                BLE_DataType.Int_32bit => "Int32",
                BLE_DataType.Int_48bit => "Int48",
                BLE_DataType.Int_64bit => "Int64",
                BLE_DataType.Int_128bit => "Int128",
                BLE_DataType.IEEE_754_32bit_floating_point => "Float32",
                BLE_DataType.IEEE_754_64bit_floating_point => "Float64",
                BLE_DataType.IEEE_11073_16bit_SFLOAT => "Float16",
                BLE_DataType.IEEE_11073_32bit_FLOAT => "Float32",
                BLE_DataType.IEEE_20601_format => "TwoUInt16",
                BLE_DataType.UTF8_String => "UTF8 String",
                BLE_DataType.UTF16_String => "UTF 16 String (Unicode)",
                _ => "Not handled",
            };
        }


        public static int BytesRequired(this BLE_DataType value) {
            return value switch {
                BLE_DataType.Bool or BLE_DataType.UInt_2bit or BLE_DataType.UInt_4bit or BLE_DataType.UInt_8bit or BLE_DataType.Int_8bit => 1,
                BLE_DataType.UInt_12bit or 
                BLE_DataType.Int_12bit or 
                BLE_DataType.UInt_16bit or 
                BLE_DataType.Int_16bit or 
                BLE_DataType.IEEE_11073_16bit_SFLOAT => 2,
                BLE_DataType.UInt_24bit or 
                BLE_DataType.Int_24bit => 3,
                BLE_DataType.UInt_32bit or 
                BLE_DataType.Int_32bit or 
                BLE_DataType.IEEE_754_32bit_floating_point or 
                BLE_DataType.IEEE_11073_32bit_FLOAT or 
                BLE_DataType.IEEE_20601_format => 4,
                BLE_DataType.UInt_48bit or 
                BLE_DataType.Int_48bit => 6,
                BLE_DataType.UInt_64bit or 
                BLE_DataType.Int_64bit or 
                BLE_DataType.IEEE_754_64bit_floating_point => 8,
                BLE_DataType.UInt_128bit or 
                BLE_DataType.Int_128bit => 16,
                _ => 9999,
            };
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
