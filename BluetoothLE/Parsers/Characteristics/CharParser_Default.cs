using BluetoothLE.Net.Parsers.Descriptor;
using LogUtils.Net;
using System;
using System.Text;
using VariousUtils.Net;
using System.Linq;

namespace BluetoothLE.Net.Parsers.Characteristics {

    /// <summary>For Characteristics not yet implemented to return byte string</summary>
    public class CharParser_Default : CharParser_Base {

        private readonly ClassLog log = new ClassLog("CharParser_Default");

        protected override bool IsDataVariableLength { get; set; } = true;


        protected override void DoParse(byte[] data) {
            DescParser_PresentationFormat format = null;

            foreach (var desc in this.DescriptorParsers) {
                if (desc is DescParser_PresentationFormat){
                    format = desc as DescParser_PresentationFormat;
                }
            }

            // Use the format descriptor for data display format.Format
            if (format == null) {
                this.DisplayString = data.ToFormatedByteString();
                this.log.Info("DoParse", () => string.Format("NOT IMPLEMENTED Display:{0}", this.DisplayString));
            }
            else {
                this.DisplayString = Process(format, data);
            }
        }


        private string Process(DescParser_PresentationFormat desc, byte[] data) {
            
            // TODO - use the exponent on numerics
            // TODO - user unit
            byte[] tmp = null;
            switch (desc.Format) {
                case Enumerations.DataFormatEnum.Boolean:
                    return ((bool)(data.ToByte(0) >  0)).ToString();
                case Enumerations.DataFormatEnum.Unsigned_2bit_integer:
                    return ((byte)(((int)data.ToByte(0)) & 0x3)).ToString();
                case Enumerations.DataFormatEnum.unsigned_4bit_integer:
                    return ((byte)(((int)data.ToByte(0)) & 0xF)).ToString();
                case Enumerations.DataFormatEnum.unsigned_8bit_integer:
                    return data.ToByte(0).ToString();
                case Enumerations.DataFormatEnum.unsigned_12bit_integer:
                    return ((ushort)(((int)data.ToUint16(0)) & 0xFFF)).ToString();
                case Enumerations.DataFormatEnum.unsigned_16bit_integer:
                    return data.ToUint16(0).ToString();
                case Enumerations.DataFormatEnum.unsigned_24bit_integer:
                    tmp = new byte[4];
                    Array.Copy(data, 0, tmp, 0, 3);
                    return ((uint)(((int)tmp.ToUint32(0)) & 0xFFFFFF)).ToString();
                case Enumerations.DataFormatEnum.unsigned_32bit_integer:
                    return data.ToUint32(0).ToString();
                case Enumerations.DataFormatEnum.unsigned_48bit_integer:
                    tmp = new byte[8];
                    Array.Copy(data, 0, tmp, 0, 6);
                    return ((UInt64)((tmp.ToUint64(0)) & 0xFFFFFFFF)).ToString();
                case Enumerations.DataFormatEnum.unsigned_64bit_integer:
                    return data.ToUint64(0).ToString();
                case Enumerations.DataFormatEnum.unsigned_128bit_integer:
                    // 16 bytes
                    return data.ToFormatedByteString(); // TODO ****
                case Enumerations.DataFormatEnum.signed_8bit_integer:
                    return data.ToSByte(0).ToString();
                case Enumerations.DataFormatEnum.signed_12bit_integer:
                    return data.ToFormatedByteString(); // TODO ****
                case Enumerations.DataFormatEnum.signed_16bit_integer:
                    return data.ToInt16(0).ToString();
                case Enumerations.DataFormatEnum.signed_24bit_integer:
                    return data.ToFormatedByteString(); // TODO ****
                case Enumerations.DataFormatEnum.signed_32bit_integer:
                    return data.ToInt32(0).ToString();
                case Enumerations.DataFormatEnum.signed_48bit_integer:
                    return data.ToFormatedByteString(); // TODO ****
                case Enumerations.DataFormatEnum.signed_64bit_integer:
                    return data.ToInt64(0).ToString();
                case Enumerations.DataFormatEnum.signed_128bit_integer:
                    return data.ToFormatedByteString(); // TODO ****
                case Enumerations.DataFormatEnum.IEEE_754_32bit_floating_point:
                    return data.ToFloat32(0).ToString(); // ****** NOT SURE OR IEEE
                case Enumerations.DataFormatEnum.IEEE_754_64bit_floating_point:
                    return data.ToFormatedByteString(); // TODO ****
                case Enumerations.DataFormatEnum.IEEE_11073_16bit_SFLOAT:
                    tmp = new byte[4];
                    Array.Copy(data, 0, tmp, 0, 2);
                    return ((float)(((int)tmp.ToFloat32(0)) & 0xFFFFFF)).ToString();
                case Enumerations.DataFormatEnum.IEEE_11073_32bit_FLOAT:
                    return data.ToFloat32(0).ToString(); // ****** NOT SURE OR IEEE
                case Enumerations.DataFormatEnum.IEEE_20601_format:
                    return data.ToFormatedByteString(); // TODO ****
                case Enumerations.DataFormatEnum.UTF8_String:
                    return Encoding.UTF8.GetString(data);
                case Enumerations.DataFormatEnum.UTF16_String:
                    return Encoding.Unicode.GetString(data);

                case Enumerations.DataFormatEnum.OpaqueStructure:
                case Enumerations.DataFormatEnum.Unhandled:
                case Enumerations.DataFormatEnum.Reserved:
                default:
                    return data.ToFormatedByteString();
            }

        }


    }

}
