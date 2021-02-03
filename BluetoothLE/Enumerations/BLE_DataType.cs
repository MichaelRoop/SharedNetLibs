
namespace BluetoothLE.Net.Enumerations {

    public enum BLE_DataType : uint {

        // First entries are taken from the descriptor data type. Do not change
        Reserved = DataFormatEnum.Reserved,
        Bool = DataFormatEnum.Boolean,
        UInt_2bit = DataFormatEnum.UInt_2bit,
        UInt_4bit = DataFormatEnum.UInt_4bit,
        UInt_8bit = DataFormatEnum.UInt_8bit,
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
        // 754 is the currently supported in MS
        IEEE_754_32bit_floating_point = DataFormatEnum.IEEE_754_32bit_floating_point,
        IEEE_754_64bit_floating_point = DataFormatEnum.IEEE_754_64bit_floating_point,
        IEEE_11073_16bit_SFLOAT = DataFormatEnum.IEEE_11073_16bit_SFLOAT,
        IEEE_11073_32bit_FLOAT = DataFormatEnum.IEEE_11073_32bit_FLOAT,
        IEEE_20601_format = DataFormatEnum.IEEE_20601_format,
        UTF8_String = DataFormatEnum.UTF8_String,
        UTF16_String = DataFormatEnum.UTF16_String,
        OpaqueStructure = DataFormatEnum.OpaqueStructure,

        // End of Descriptor format type indicators
        // Last one was 0x1B - their max is 0xFF because it is a byte
        // Start the higher level series at 0x100 (256)
        // Can add different structure types



        // End of Descriptor Format data type


    }
}
