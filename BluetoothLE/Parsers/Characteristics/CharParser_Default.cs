using BluetoothLE.Net.Enumerations;
using BluetoothLE.Net.Parsers.Descriptor;
using LogUtils.Net;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using VariousUtils.Net;
using BluetoothLE.Net.Parsers.Types;

namespace BluetoothLE.Net.Parsers.Characteristics {

    /// <summary>For Characteristics not yet implemented to return byte string</summary>
    public class CharParser_Default : CharParser_Base {

        private readonly ClassLog log = new ClassLog("CharParser_Default");

        // This becomes list
        private List<DescParser_PresentationFormat> formats = new List<DescParser_PresentationFormat>();

        protected override bool IsDataVariableLength { get; set; } = true;


        protected override BLEOperationStatus OnDescriptorsAdded() {
            BLEOperationStatus status = BLEOperationStatus.Success;
            this.formats.Clear();

            DescParser_CharacteristicAggregateFormat aggregate = null;
            foreach (var desc in this.DescriptorParsers) {
                if (desc is DescParser_CharacteristicAggregateFormat) {
                    aggregate = desc as DescParser_CharacteristicAggregateFormat;
                    break;
                }
            }

            if (aggregate != null) {
                // If we have an Aggreagate Format Descriptor, then there can be
                // multiple Presentation Format Descriptor (found by handle) in the order
                // that the byte data comes in.
                foreach (var handle in aggregate.AttributeHandles) {
                    // Check for duplicates or missing
                    int count = this.DescriptorParsers.Count(y => y.AttributeHandle == handle);
                    if (count == 1) {
                        // Found Descriptro, now check if Format Descriptor type
                        DescParser_PresentationFormat desc = this.DescriptorParsers.Find(
                            x => x.AttributeHandle == handle) as DescParser_PresentationFormat;
                        if (desc == null) {
                            status = BLEOperationStatus.AggregateFormatHandleNotFormatType;
                            break;
                        }
                        else {
                            this.formats.Add(desc);
                        }
                    }
                    else if (count == 0) {
                        // Spec says it is legal to have aggregate and no format descriptors
                        // but in this case there is a handle for a format that is not found
                        status = BLEOperationStatus.AggregateFormatMissingFormats;
                        break;
                    }
                    else if (count > 1) {
                        status = BLEOperationStatus.AggregateFormatDuplicateFormats;
                        break;
                    }
                }

                // Now validate the total count if no other error
                if (status == BLEOperationStatus.Success) {
                    switch (this.formats.Count) {
                        case 0:
                            // According to spec 0 Format Desc is legal
                            // Mark as Reserved to display byte hex values
                            this.DataType = BLE_DataType.Reserved;
                            break;
                        case 1:
                            // Just assume the type of the one data type present
                            this.DataType = this.formats[0].DataType;
                            break;
                        default:
                            // We will display the results in a comma delimited string
                            this.DataType = BLE_DataType.OpaqueStructure;
                            break;
                    }
                }
            }
            else {
                // Check for multiple formats. Only first accepted
                int count = 0;
                foreach (var desc in this.DescriptorParsers) {
                    if (desc is DescParser_PresentationFormat) {
                        count++;
                    }
                }
                if (count > 1) {
                    // Flag error but keep processing
                    status = BLEOperationStatus.RedundantFormatDescriptorsDiscarded;
                }

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


            return status;
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
                        sb.Append(", ");
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
                    return UInt02.GetNew(data, ref pos).ToString();
                case Enumerations.DataFormatEnum.UInt_4bit:
                    return UInt04.GetNew(data, ref pos).ToString();
                case Enumerations.DataFormatEnum.UInt_8bit:
                    return data.ToByte(ref pos).Calculate(exp, exp).ToStr(exp);
                case Enumerations.DataFormatEnum.UInt_12bit:
                    return UInt12.GetNew(data, ref pos).Value.Calculate(exp, exp).ToStr(exp);
                case Enumerations.DataFormatEnum.UInt_16bit:
                    return data.ToUint16(ref pos).Calculate(exp, exp).ToStr(exp);
                case Enumerations.DataFormatEnum.UInt_24bit:
                    return UInt24.GetNew(data, ref pos).Value.Calculate(exp, exp).ToStr(exp);
                case Enumerations.DataFormatEnum.UInt_32bit:
                    return data.ToUint32(ref pos).Calculate(exp, exp).ToStr(exp);
                case Enumerations.DataFormatEnum.UInt_48bit:
                    return UInt48.GetNew(data, ref pos).Value.Calculate(exp, exp).ToStr(exp);
                case Enumerations.DataFormatEnum.UInt_64bit:
                    UInt64 ret = data.ToUint64(ref pos);
                    if ((exp != 0) && (ret > Double.MinValue && ret < Double.MaxValue)) {
                        // TODO - hack until I can get the exponent figured out for the full value
                        return ret.Calculate(exp, exp).ToStr(exp);
                    }
                    else {
                        // Since we are only sending back strings we can just add
                        // the appropriate 00 for positive exponent or the . or , form minus
                        return ret.ToString();
                    }
                    //return data.ToUint64(ref pos).Calculate(exp, exp).ToStr(exp);
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
                    // TODO exponent stuff when figure out the sign
                    return Int12.GetNew(data, ref pos).ToString();
                case Enumerations.DataFormatEnum.Int_16bit:
                    return data.ToInt16(ref pos).ToString();
                case Enumerations.DataFormatEnum.Int_24bit:
                    // TODO exponent stuff
                    return Int24.GetNew(data, ref pos).ToString();
                case Enumerations.DataFormatEnum.Int_32bit:
                    return data.ToInt32(ref pos).Calculate(exp, exp).ToStr(exp);
                case Enumerations.DataFormatEnum.Int_48bit:
                    // TODO exponent stuff
                    return Int48.GetNew(data, ref pos).ToString();
                case Enumerations.DataFormatEnum.Int_64bit:
                    Int64 ret2 = data.ToInt64(ref pos);
                    if ((exp != 0) && (ret2 > Double.MinValue && ret2 < Double.MaxValue)) {
                        // TODO - hack until I can get the exponent figured out for the full value
                        return ret2.Calculate(exp, exp).ToStr(exp);
                    }
                    else {
                        return ret2.ToString();
                    }
                    //return data.ToInt64(ref pos).Calculate(exp, exp).ToStr(exp);
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

                case Enumerations.DataFormatEnum.IEEE_20601_format:
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
