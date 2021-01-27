using BluetoothLE.Net.Enumerations;
using BluetoothLE.Net.Parsers.Descriptor;
using LogUtils.Net;
using System;
using System.Text;
using VariousUtils.Net;

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
            if (!desc.Format.IsHandled()) {
                if (desc.Format == DataFormatEnum.Unhandled) {
                    return string.Format("Unhandled:{0}", data.ToFormatedByteString());
                }
                return string.Format("Unhandled - {0}:{1}", 
                    desc.Format.ToString().UnderlineToSpaces(), data.ToFormatedByteString());
            }

            int required = desc.Format.BytesRequired();
            if (desc.Format.HasLengthRequirement() && required > data.Length) {
                return string.Format("{0} byte(s) Data. Requires {1}", data.Length, required);
            }

            // TODO - use the exponent on numerics
            // TODO - user unit
            byte[] tmp = null;
            switch (desc.Format) {
                case Enumerations.DataFormatEnum.Boolean:
                    return ((bool)(data.ToByte(0) >  0)).ToString();
                //------------------------------------------------------
                // Unsigned
                case Enumerations.DataFormatEnum.UInt_2bit:
                    return ((byte)(((int)data.ToByte(0)) & 0x3)).ToString();
                case Enumerations.DataFormatEnum.UInt_4bit:
                    return ((byte)(((int)data.ToByte(0)) & 0xF)).ToString();
                case Enumerations.DataFormatEnum.UInt_8bit:
                    return data.ToByte(0).ToString();
                case Enumerations.DataFormatEnum.UInt_12bit:
                    return ((ushort)(((int)data.ToUint16(0)) & 0xFFF)).ToString();
                case Enumerations.DataFormatEnum.UInt_16bit:
                    return data.ToUint16(0).ToString();
                case Enumerations.DataFormatEnum.UInt_24bit:
                    tmp = new byte[4];
                    Array.Copy(data, 0, tmp, 0, 3);
                    return ((uint)(((int)tmp.ToUint32(0)) & 0xFFFFFF)).ToString();
                case Enumerations.DataFormatEnum.UInt_32bit:
                    return data.ToUint32(0).ToString();
                case Enumerations.DataFormatEnum.UInt_48bit:
                    tmp = new byte[8];
                    Array.Copy(data, 0, tmp, 0, 6);
                    return ((UInt64)((tmp.ToUint64(0)) & 0xFFFFFFFFFFFF)).ToString();
                case Enumerations.DataFormatEnum.UInt_64bit:
                    return data.ToUint64(0).ToString();
                case Enumerations.DataFormatEnum.UInt_128bit:
                    // Will not support this
                    return data.ToFormatedByteString();

                //------------------------------------------------------
                // Signed values
                case Enumerations.DataFormatEnum.Int_8bit:
                    return data.ToSByte(0).ToString();
                case Enumerations.DataFormatEnum.Int_12bit:
                    tmp = new byte[2];
                    Array.Copy(data, 0, tmp, 0, 2);
                    return tmp.ToInt16(0).ToString();
                case Enumerations.DataFormatEnum.Int_16bit:
                    return data.ToInt16(0).ToString();
                case Enumerations.DataFormatEnum.Int_24bit:
                    //tmp = new byte[4];
                    //Array.Copy(data, 0, tmp, 0, 3);
                    //if (data[2] == 0xFF) {
                    //    tmp[3] = 0xFF;
                    //}
                    //return tmp.ToInt32(0).ToString();
                    return data.ToFormatedByteString();

                //return ((int)(((int)tmp.ToInt32(0)) & 0xFFFFFF)).ToString();

                case Enumerations.DataFormatEnum.Int_32bit:
                    return data.ToInt32(0).ToString();
                case Enumerations.DataFormatEnum.Int_48bit:
                    //tmp = new byte[8];
                    //Array.Copy(data, 0, tmp, 0, 6);
                    ////if (tmp[5] == 0xFF) {
                    ////    tmp[6] = 0xFF;
                    ////    tmp[7] = 0xFF;
                    ////}

                    //long val = tmp.ToInt64(0);
                    ////long val2 = (val & 0xFFFFFFFFFFFF);
                    //string r = val.ToString();
                    //return r;
                    return data.ToFormatedByteString();

                //return (tmp.ToInt64(0) & 0xFFFFFFFFFFFF).ToString();
                //return ((long)(tmp.ToInt64(0) & 0xFFFFFFFFFFFF)).ToString();
                case Enumerations.DataFormatEnum.Int_64bit:
                    return data.ToInt64(0).ToString();
                case Enumerations.DataFormatEnum.Int_128bit:
                    // Will not support this
                    return data.ToFormatedByteString();

                //------------------------------------------------------
                // Floats 754 is current MS
                case Enumerations.DataFormatEnum.IEEE_754_32bit_floating_point:
                    return data.ToFloat32(0).ToString();
                case Enumerations.DataFormatEnum.IEEE_754_64bit_floating_point:
                    return data.ToDouble64(0).ToString();

                // Not supporting for now
                case Enumerations.DataFormatEnum.IEEE_11073_16bit_SFLOAT:
                    tmp = new byte[4];
                    Array.Copy(data, 0, tmp, 0, 2);
                    return ((float)(((int)tmp.ToFloat32(0)) & 0xFFFFFF)).ToString();
                case Enumerations.DataFormatEnum.IEEE_11073_32bit_FLOAT:
                    return data.ToFloat32(0).ToString(); // ****** NOT SURE OR IEEE

                //------------------------------------------------------
                // Strings
                case Enumerations.DataFormatEnum.UTF8_String:
                    return Encoding.UTF8.GetString(data);
                case Enumerations.DataFormatEnum.UTF16_String:
                    return Encoding.Unicode.GetString(data);

                //------------------------------------------------------
                // Not handled
                case Enumerations.DataFormatEnum.IEEE_20601_format: // Non defined data
                case Enumerations.DataFormatEnum.OpaqueStructure:
                case Enumerations.DataFormatEnum.Unhandled:
                case Enumerations.DataFormatEnum.Reserved:
                default:
                    return data.ToFormatedByteString();
            }

        }


    }

}
