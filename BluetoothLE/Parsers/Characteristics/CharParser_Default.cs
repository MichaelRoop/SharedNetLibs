using BluetoothLE.Net.Enumerations;
using BluetoothLE.Net.Parsers.Descriptor;
using LogUtils.Net;
using System;
using System.Collections.Generic;
using System.Text;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics {

    /// <summary>For Characteristics not yet implemented to return byte string</summary>
    public class CharParser_Default : CharParser_Base {

        private readonly ClassLog log = new ClassLog("CharParser_Default");

        // This becomes list
        private List<DescParser_PresentationFormat> formats = new List<DescParser_PresentationFormat>();

        protected override bool IsDataVariableLength { get; set; } = true;

        // TODO - if we have an Aggreagate Format Descriptor, then there should be
        // multiple Presentation Format Descriptor (found by handle) in the order
        // that the byte data comes in.


        protected override void OnDescriptorsAdded() {
            this.formats.Clear();
            bool isAggregate = false;
            foreach (var desc in this.DescriptorParsers) {
                if (desc is DescParser_CharacteristicAggregateFormat) {
                    isAggregate = true;
                    break;
                }
            }

            if (isAggregate) {
                // TODO - Get the handles from the Agregate and use this to find the format descriptors
                foreach (var desc in this.DescriptorParsers) {
                    if (desc is DescParser_PresentationFormat) {
                        this.formats.Add(desc as DescParser_PresentationFormat);
                    }
                }
                switch (this.formats.Count) {
                    case 0:
                        this.DataType = BLE_DataType.Reserved;
                        break;
                    case 1:
                        this.DataType = this.formats[0].DataType;
                        break;
                    default:
                        this.DataType = BLE_DataType.OpaqueStructure;
                        break;
                }
            }
            else {
                foreach (var desc in this.DescriptorParsers) {
                    if (desc is DescParser_PresentationFormat) {
                        DescParser_PresentationFormat f = desc as DescParser_PresentationFormat;
                        // Not handling multiple presentation format descriptors and aggregage formating
                        this.DataType = f.DataType;
                        this.formats.Add(f);
                        break;
                    }
                }
            }
        }


        protected override void DoParse(byte[] data) {
            // Use the format descriptor for data display format.Format
            if (this.formats.Count == 0) {
                // We will display bytes for any format not supported
                this.DisplayString = data.ToFormatedByteString();
                this.log.Info("DoParse", () => string.Format("NO Format Descriptor Value:{0}", this.DisplayString));
            }
            else {
                int pos = 0;
                StringBuilder sb = new StringBuilder();
                foreach(var f in this.formats) {
                    if (pos > 0) {
                        sb.Append(",");
                    }
                    sb.Append(this.Process(f, ref pos, data));
                }
                this.DisplayString = sb.ToString();
            }
        }


        private string Process(DescParser_PresentationFormat desc, ref int pos, byte[] data) {
            // TODO - handle opaque?
            if (!desc.Format.IsHandled()) {
                if (desc.Format == DataFormatEnum.Unhandled) {
                    return string.Format("Unhandled:{0}", data.ToFormatedByteString());
                }
                return string.Format("Unhandled - {0}:{1}", 
                    desc.Format.ToString().UnderlineToSpaces(), data.ToFormatedByteString());
            }

            int required = desc.Format.BytesRequired();
            int remainingBytes = data.Length - pos;
            if (desc.Format.HasLengthRequirement() && required > remainingBytes) {
                return string.Format("{0} byte(s) Data. Requires {1}", remainingBytes, required);
            }

            // TODO - user unit
            byte[] tmp = null;
            int exp = desc.Exponent;
            this.DataType = ((uint)EnumHelpers.ToByte(desc.Format)).ToEnum<BLE_DataType>();
            switch (desc.Format) {
                case Enumerations.DataFormatEnum.Boolean:
                    return ((bool)(data.ToByte(ref pos) >  0)).ToString();

                #region Unsigned types
                //------------------------------------------------------
                // Unsigned
                case Enumerations.DataFormatEnum.UInt_2bit:
                    return ((byte)(((int)data.ToByte(ref pos)) & 0x3)).ToString();
                case Enumerations.DataFormatEnum.UInt_4bit:
                    return ((byte)(((int)data.ToByte(ref pos)) & 0xF)).ToString();
                case Enumerations.DataFormatEnum.UInt_8bit:
                    return data.ToByte(ref pos).Calculate(exp, exp).ToStr(exp);
                case Enumerations.DataFormatEnum.UInt_12bit:
                    return ((ushort)(((int)data.ToUint16(ref pos)) & 0xFFF)).Calculate(exp, exp).ToStr(exp);
                case Enumerations.DataFormatEnum.UInt_16bit:
                    return data.ToUint16(ref pos).Calculate(exp, exp).ToStr(exp);
                case Enumerations.DataFormatEnum.UInt_24bit:
                    tmp = new byte[4];
                    Array.Copy(data, pos, tmp, 0, 3);
                    // Only copying 3 bytes from main buffer. Manually increment pointer
                    pos += 3;
                    return ((uint)(((int)tmp.ToUint32(0)) & 0xFFFFFF)).Calculate(exp, exp).ToStr(exp);
                case Enumerations.DataFormatEnum.UInt_32bit:
                    return data.ToUint32(ref pos).Calculate(exp, exp).ToStr(exp);
                case Enumerations.DataFormatEnum.UInt_48bit:
                    tmp = new byte[8];
                    Array.Copy(data, pos, tmp, 0, 6);
                    // Only copying 6 of 6 bytes. Manually increment
                    pos += 6;
                    return ((UInt64)((tmp.ToUint64(0)) & 0xFFFFFFFFFFFF)).Calculate(exp, exp).ToStr(exp);
                case Enumerations.DataFormatEnum.UInt_64bit:
                    return data.ToUint64(ref pos).Calculate(exp, exp).ToStr(exp);
                case Enumerations.DataFormatEnum.UInt_128bit:
                    // Will not support this - still need to manually increment 16 bytes
                    pos += 16;
                    return data.ToFormatedByteString();
                #endregion

                #region Signed types
                //------------------------------------------------------
                // Signed values
                case Enumerations.DataFormatEnum.Int_8bit:
                    return data.ToSByte(ref pos).Calculate(exp, exp).ToStr(exp);
                case Enumerations.DataFormatEnum.Int_12bit:
                    tmp = new byte[2];
                    Array.Copy(data, pos, tmp, 0, 2);
                    // only copying 2 bytes from main
                    pos += 2;
                    return tmp.ToInt16(0).ToString();
                case Enumerations.DataFormatEnum.Int_16bit:
                    return data.ToInt16(ref pos).ToString();
                case Enumerations.DataFormatEnum.Int_24bit:
                    //tmp = new byte[4];
                    //Array.Copy(data, 0, tmp, 0, 3);
                    //if (data[2] == 0xFF) {
                    //    tmp[3] = 0xFF;
                    //}
                    //return tmp.ToInt32(0).ToString();

                    // Still increment count of 3 bytes
                    pos += 3;
                    return data.ToFormatedByteString();

                //return ((int)(((int)tmp.ToInt32(0)) & 0xFFFFFF)).ToString();

                case Enumerations.DataFormatEnum.Int_32bit:
                    return data.ToInt32(ref pos).Calculate(exp, exp).ToStr(exp);
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
                    // Manually increment the 6 bytes
                    pos += 6;
                    return data.ToFormatedByteString();

                //return (tmp.ToInt64(0) & 0xFFFFFFFFFFFF).ToString();
                //return ((long)(tmp.ToInt64(0) & 0xFFFFFFFFFFFF)).ToString();
                case Enumerations.DataFormatEnum.Int_64bit:
                    return data.ToInt64(ref pos).Calculate(exp, exp).ToStr(exp);
                case Enumerations.DataFormatEnum.Int_128bit:
                    // Will not support this. Still need to move the pointer
                    pos += 16;
                    return data.ToFormatedByteString();

                #endregion

                #region Floating types

                //------------------------------------------------------
                // Floats 754 is current MS
                case Enumerations.DataFormatEnum.IEEE_754_32bit_floating_point:
                    return data.ToFloat32(ref pos).ToString();
                case Enumerations.DataFormatEnum.IEEE_754_64bit_floating_point:
                    return data.ToDouble64(ref pos).ToString();

                // Not supporting for now
                case Enumerations.DataFormatEnum.IEEE_11073_16bit_SFLOAT:
                    tmp = new byte[4];
                    Array.Copy(data, pos, tmp, 0, 2);
                    pos += 2;
                    return ((float)(((int)tmp.ToFloat32(0)) & 0xFFFFFF)).ToString();
                case Enumerations.DataFormatEnum.IEEE_11073_32bit_FLOAT:
                    // https://docs.particle.io/tutorials/device-os/bluetooth-le/


                    return data.ToFloat32(ref pos).ToString(); // ****** NOT SURE OR IEEE

                case Enumerations.DataFormatEnum.IEEE_20601_format: // Non defined data
                    ushort val1 = data.ToUint16(ref pos);
                    ushort val2 = data.ToUint16(ref pos);
                    return string.Format("{0}|{1}", val1, val2);
                #endregion

                #region Strings

                case Enumerations.DataFormatEnum.UTF8_String:
                    // TODO - Copy from pos - but how long? Until end I expect
                    remainingBytes = data.Length - pos;
                    tmp = new byte[remainingBytes];
                    Array.Copy(data, pos, tmp, 0, remainingBytes);
                    pos += remainingBytes;
                    return Encoding.UTF8.GetString(tmp);
                case Enumerations.DataFormatEnum.UTF16_String:
                    // TODO - Copy from pos - but how long? Until end I expect
                    remainingBytes = data.Length - pos;
                    tmp = new byte[remainingBytes];
                    Array.Copy(data, pos, tmp, 0, remainingBytes);
                    pos += remainingBytes;
                    return Encoding.Unicode.GetString(tmp);
                #endregion

                #region Unhandled types

                //------------------------------------------------------
                // Not handled
                case Enumerations.DataFormatEnum.OpaqueStructure:
                case Enumerations.DataFormatEnum.Unhandled:
                case Enumerations.DataFormatEnum.Reserved:
                default:
                    return data.ToFormatedByteString();

                #endregion
            }

        }


    }

}
