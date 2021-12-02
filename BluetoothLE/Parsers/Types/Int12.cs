using System;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Types {

    public class Int12 : IComparable, IComparable<Int12>, IConvertible, IEquatable<Int12>, IFormattable {

        #region Data

        #endregion

        #region Properties

        public Int16 Value { get; private set; } = 0;
        public static Int16 MaxValue { get { return 2047; } }
        public static Int16 MinValue { get { return -2048; } }

        #endregion

        /// <summary>Convert the string and initialize a value</summary>
        /// <param name="s"></param>
        /// <param name="result">The value to initialize</param>
        /// <returns>true if the string is a valid number in the range of an Int12</returns>
        public static bool TryParse(string s, out Int16 result) {
            if (Int16.TryParse(s, out result)) {
                return result >= Int12.MinValue && result <= Int12.MaxValue;
            }
            return false;
        }

        #region Constructors

        public static Int12 GetNew(Int16 val) {
            return new Int12(val);
        }

        public static Int12 GetNew(byte[] data, ref int pos) {
            //byte[] tmp = new byte[2];
            //Array.Copy(data, pos, tmp, 0, 2);
            //// only copying 2 bytes from main
            //pos += 2;


             return new Int12(data.ToInt16(ref pos));


            // TODO - check if masking will work with the sign
            //return new Int12((Int16)((int)tmp.ToInt16(0) & 0x3));
            // TODO - hack until find how to handle the sign in 12 bytes
            //return new Int12(tmp.ToInt16(0));
        }

        public Int12(Int16 val) {
            //https://stackoverflow.com/questions/10876265/convert-12-bit-int-to-16-or-32-bits
            //// if first bit to third byte is set
            //this.Value = ((val & 0x0800) > 0) 
            //    ?  (Int16)(val | 0xF000) 
            //    : val;

            this.Value = BitTools.IsBitSet(val, 12)
                ? (Int16)(val | 0xF000)
                : val;



            //if (val > UInt12.MaxValue) {
            //    throw new ArgumentOutOfRangeException(string.Format("Max value {0}", Int12.MaxValue));
            //}
            //// Check if masking works
            //this.value = (Int16)(val & 0x03);
        }

        #endregion

        #region Operators

        public static bool operator ==(Int12 u1, Int12 u2) {
            if (object.ReferenceEquals(u1, u2)) { return true; }
            if (object.ReferenceEquals(u1, null)) { return false; }
            if (object.ReferenceEquals(u2, null)) { return false; }
            return u1.Equals(u2);
        }

        public static bool operator !=(Int12 u1, Int12 u2) {
            if (object.ReferenceEquals(u1, u2)) { return false; }
            if (object.ReferenceEquals(u1, null)) { return true; }
            if (object.ReferenceEquals(u2, null)) { return true; }
            return !u1.Equals(u2);
        }


        public static bool operator ==(Int12 u1, Int16 u2) {
            if (object.ReferenceEquals(u2, null)) { return false; }
            return u1.Value == u2;
        }

        public static bool operator !=(Int12 u1, Int16 u2) {
            if (object.ReferenceEquals(u2, null)) { return true; }
            return u1.Value != u2;
        }

        #endregion

        #region overrides
        public override bool Equals(object? obj) {
            return (obj is Int12) ? this.Equals((Int12)obj) : false;
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public override string ToString() {
            return this.Value.ToString();
        }

        #endregion

        #region IComparable
        public int CompareTo(object? obj) {
            return this.CompareTo(obj as Int12);
        }
        #endregion

        #region IComparable<Int12>
        public int CompareTo(Int12? other) {
            if (other is not null) {
                if (this.Value > other.Value) {
                    return 1;
                }
                else if (this.Value < other.Value) {
                    return -1;
                }
            }
            return 0;
        }

        #endregion

        #region IEquitable

        public bool Equals(Int12? other) {
            return other is null ? false : this.Value == other.Value;
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

        public string ToString(string? format, IFormatProvider? formatProvider) {
            return this.Value.ToString(format, formatProvider);
        }

        #endregion

    }

}
