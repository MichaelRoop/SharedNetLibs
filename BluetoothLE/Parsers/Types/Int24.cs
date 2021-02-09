using System;
using System.Collections.Generic;
using System.Text;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Types {

    public class Int24 : IComparable, IComparable<Int24>, IConvertible, IEquatable<Int24>, IFormattable {

        #region Data

        #endregion

        #region Properties

        public Int32 Value { get; private set; } = 0;
        public static Int32 MaxValue { get { return 8388607; } }
        public static Int32 MinValue { get { return -8388608; } }

        #endregion

        #region Constructors

        /// <summary>Convert a 32 bit int to a 24bit int in a byte array</summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] GetBytes(Int32 value) {
            // Could just set them to min or max
            if (value < Int24.MinValue || value > Int24.MaxValue) {
                throw new ArgumentOutOfRangeException("value",
                    string.Format("{0} out or range {1} to {2}",
                    value, Int24.MinValue, Int24.MaxValue));
            }

            bool negative = value < 0;
            // Filter out the third byte
            value = value & 0xFFFFFF;
            if (negative) {
                // Set the bit for negative
                value = value | 0x800000;
            }
            byte[] resultData = new byte[3];
            byte[] tmp = new byte[4];
            value.WriteToBuffer(tmp, 0);
            Array.Copy(tmp, 0, resultData, 0, 3);
            return resultData;
        }


        public static Int24 GetNew(Int32 val) {
            return new Int24(val);
        }

        public static Int24 GetNew(byte[] data, ref int pos) {
            //byte[] tmp = new byte[4];
            //Array.Copy(data, pos, tmp, 0, 3);
            //pos += 3;
            //return new Int24(BitConverter.ToInt32(new ReadOnlySpan<byte>(tmp)));

            //byte[] tmp = new byte[4];
            //Array.Copy(data, pos, tmp, 0, 3);
            //pos += 3;
            //return new Int24(tmp.ToInt32(0));


            /*
            
            // This works. But we will just send the full 4 bytes and shift after
            byte[] tmp = new byte[4];
            if (data[2].IsBitSet(7)) {
                tmp[3] = 0xFF;
            }
            Array.Copy(data, pos, tmp, 0, 3);
            pos += 3;
            return new Int24(tmp.ToInt32(0));
            */


            byte[] tmp = new byte[4];
            Array.Copy(data, pos, tmp, 0, 3);
            pos += 3;
            return new Int24(tmp.ToInt32(0));

            //val |= data[pos + 2];
            //pos += 3;

            //return new Int24(val);

        }


        public Int24(Int32 val) {
            //https://stackoverflow.com/questions/10876265/convert-12-bit-int-to-16-or-32-bits
            //// if first bit to third byte is set
            //this.Value = ((val & 0x0800) > 0) 
            //    ?  (Int16)(val | 0xF000) 
            //    : val;

            //var v = 0xF0000000;

            //uint32 rVal = 0xF12343; //24Bit value
            //int32_t adcValue32 = rVal & 0x800000 ? 0xff000000 | rVal : rVal;


            //this.Value = val;

            //this.Value = BitTools.IsBitSet(val, 24)
            //    //                          0xFF000000
            //    ? (Int32)((uint)val | (uint)0xFF000000)
            //    : (Int32)val;
            int z = 55;

            int x = val >> 24;


            // Need to check if int24 signed pos on AND Top bytes 0x000
            //if ((val & 0x800000) > 0) {
            if (((val & 0x800000) > 0) && (val >> 24) == 0) {
                val = (Int32)(val | 0xFF000000);
            }
            this.Value = val;

            // This will not catch out of range +
            if (val < Int24.MinValue || val > Int24.MaxValue) {
                throw new ArgumentOutOfRangeException(
                    "val", string.Format(
                        "{0} out or range {1} to {2}", 
                        val, Int24.MinValue, Int24.MaxValue));
            }



            //if (val > UInt12.MaxValue) {
            //    throw new ArgumentOutOfRangeException(string.Format("Max value {0}", Int12.MaxValue));
            //}
            //// Check if masking works
            //this.value = (Int16)(val & 0x03);
        }

        #endregion

        #region Operators

        public static bool operator ==(Int24 u1, Int24 u2) {
            if (object.ReferenceEquals(u1, u2)) { return true; }
            if (object.ReferenceEquals(u1, null)) { return false; }
            if (object.ReferenceEquals(u2, null)) { return false; }
            return u1.Equals(u2);
        }

        public static bool operator !=(Int24 u1, Int24 u2) {
            if (object.ReferenceEquals(u1, u2)) { return false; }
            if (object.ReferenceEquals(u1, null)) { return true; }
            if (object.ReferenceEquals(u2, null)) { return true; }
            return !u1.Equals(u2);
        }


        public static bool operator ==(Int24 u1, Int32 u2) {
            if (object.ReferenceEquals(u2, null)) { return false; }
            return u1.Value == u2;
        }

        public static bool operator !=(Int24 u1, Int32 u2) {
            if (object.ReferenceEquals(u2, null)) { return true; }
            return u1.Value != u2;
        }

        #endregion

        #region overrides
        public override bool Equals(object obj) {
            Int24 u = obj as Int24;
            if (u != null) {
                return this.Equals(u);
            }
            return false;
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public override string ToString() {
            return this.Value.ToString();
        }

        #endregion

        #region IComparable
        public int CompareTo(object obj) {
            Int12 u = (Int12)obj;
            return CompareTo(u);
        }
        #endregion

        #region IComparable<Int24>
        public int CompareTo(Int24 other) {
            if (this.Value < other.Value) {
                return 1;
            }
            else if (this.Value > other.Value) {
                return -1;
            }
            else {
                return 0;
            }
        }

        #endregion

        #region IEquitable

        public bool Equals(Int24 other) {
            if (other != null) {
                return this.Value == other.Value;
            }
            return false;
        }

        #endregion

        #region IConvertible

        public TypeCode GetTypeCode() {
            return TypeCode.Object;
        }

        public bool ToBoolean(IFormatProvider provider) {
            return Convert.ToBoolean(this.Value, provider);
        }

        public byte ToByte(IFormatProvider provider) {
            return Convert.ToByte(this.Value, provider);
        }

        public char ToChar(IFormatProvider provider) {
            return Convert.ToChar(this.Value, provider);
        }

        public DateTime ToDateTime(IFormatProvider provider) {
            return Convert.ToDateTime(this.Value, provider);
        }

        public decimal ToDecimal(IFormatProvider provider) {
            return Convert.ToDecimal(this.Value, provider);
        }

        public double ToDouble(IFormatProvider provider) {
            return Convert.ToDouble(this.Value, provider);
        }

        public short ToInt16(IFormatProvider provider) {
            return Convert.ToInt16(this.Value, provider);
        }

        public int ToInt32(IFormatProvider provider) {
            return Convert.ToInt32(this.Value, provider);
        }

        public long ToInt64(IFormatProvider provider) {
            return Convert.ToInt64(this.Value, provider);
        }

        public sbyte ToSByte(IFormatProvider provider) {
            return Convert.ToSByte(this.Value, provider);
        }

        public float ToSingle(IFormatProvider provider) {
            return Convert.ToSingle(this.Value, provider);
        }

        public string ToString(IFormatProvider provider) {
            // Modify this ?
            return Convert.ToString(this.Value, provider);
        }

        public object ToType(Type conversionType, IFormatProvider provider) {
            // likely not
            return Convert.ChangeType(this.Value.ToString(), conversionType, provider);
        }

        public ushort ToUInt16(IFormatProvider provider) {
            return Convert.ToUInt16(this.Value, provider);
        }

        public uint ToUInt32(IFormatProvider provider) {
            return Convert.ToUInt32(this.Value, provider);
        }

        public ulong ToUInt64(IFormatProvider provider) {
            return Convert.ToUInt64(this.Value, provider);
        }

        #endregion

        #region IFormatable

        public string ToString(string format, IFormatProvider formatProvider) {
            return this.Value.ToString(format, formatProvider);
        }

        #endregion

    }

}
