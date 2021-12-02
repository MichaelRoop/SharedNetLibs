using System;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Types {


    public class UInt02 : IComparable, IComparable<UInt02>, IConvertible, IEquatable<UInt02>, IFormattable {

        #region Data

        private byte value = 0;

        #endregion

        #region Properties

        public byte Value { get { return this.value; } }        
        public static Byte MaxValue { get { return 3; } }
        public static Byte MinValue { get { return 0; } }

        #endregion

        #region Static methods

        /// <summary>Convert the string and initialize a value</summary>
        /// <param name="s">The string to parse</param>
        /// <param name="result">The value to initialize</param>
        /// <returns>true if the string is a valid number in the range of an Int24</returns>
        public static bool TryParse(string s, out byte result) {
            if (Byte.TryParse(s, out result)) {
                return result >= UInt02.MinValue && result <= UInt02.MaxValue;
            }
            return false;
        }

        #endregion

        #region Constructors

        public static UInt02 GetNew(byte b) {
            return new UInt02(b);
        }

        public static UInt02 GetNew(byte[] data, ref int pos) {
            // Will do masking up front when reading from byte array
            return new UInt02((byte)(data.ToByte(ref pos) & 0x3));
        }

        public UInt02(byte b) {
            if (b > 3) {
                throw new ArgumentOutOfRangeException("Max value 3");
            }
            this.value = (byte)(b & 0x3);
        }

        #endregion

        #region Operators

        public static bool operator == (UInt02 u1, UInt02 u2) {
            if (object.ReferenceEquals(u1, u2)) { return true; }
            if (object.ReferenceEquals(u1, null)) { return false; }
            if (object.ReferenceEquals(u2, null)) { return false; }
            return u1.Equals(u2);
        }

        public static bool operator !=(UInt02 u1, UInt02 u2) {
            if (object.ReferenceEquals(u1, u2)) { return false; }
            if (object.ReferenceEquals(u1, null)) { return true; }
            if (object.ReferenceEquals(u2, null)) { return true; }
            return !u1.Equals(u2);
        }


        public static bool operator ==(UInt02 u1, Byte u2) {
            if (object.ReferenceEquals(u2, null)) { return false; }
            return u1.Value == u2;
        }

        public static bool operator !=(UInt02 u1, Byte u2) {
            if (object.ReferenceEquals(u2, null)) { return true; }
            return u1.Value != u2;
        }

        #endregion

        #region overrides
        public override bool Equals(object? obj) {
            return (obj is UInt02) ? this.Equals((UInt02)obj) : false;
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public override string ToString() {
            return this.value.ToString();
        }

        #endregion

        #region IComparable
        public int CompareTo(object obj) {
            UInt02 u = (UInt02)obj;
            return CompareTo(u);
        }
        #endregion

        #region IComparable<Uint02>
        public int CompareTo(UInt02 other) {
            if (this.value < other.value) {
                return 1;
            }
            else if (this.value > other.value) {
                return -1;
            }
            else {
                return 0;
            }
        }

        #endregion

        #region IEquitable

        public bool Equals(UInt02 other) {
            if (other != null) {
                return this.value == other.value;
            }
            return false;
        }

        #endregion

        #region IConvertible

        public TypeCode GetTypeCode() {
            return TypeCode.Object;
        }

        public bool ToBoolean(IFormatProvider provider) {
            return Convert.ToBoolean(this.value, provider);
        }

        public byte ToByte(IFormatProvider provider) {
            return Convert.ToByte(this.value, provider);
        }

        public char ToChar(IFormatProvider provider) {
            return Convert.ToChar(this.value, provider);
        }

        public DateTime ToDateTime(IFormatProvider provider) {
            return Convert.ToDateTime(this.value, provider);
        }

        public decimal ToDecimal(IFormatProvider provider) {
            return Convert.ToDecimal(this.value, provider);
        }

        public double ToDouble(IFormatProvider provider) {
            return Convert.ToDouble(this.value, provider);
        }

        public short ToInt16(IFormatProvider provider) {
            return Convert.ToInt16(this.value, provider);
        }

        public int ToInt32(IFormatProvider provider) {
            return Convert.ToInt32(this.value, provider);
        }

        public long ToInt64(IFormatProvider provider) {
            return Convert.ToInt64(this.value, provider);
        }

        public sbyte ToSByte(IFormatProvider provider) {
            return Convert.ToSByte(this.value, provider);
        }

        public float ToSingle(IFormatProvider provider) {
            return Convert.ToSingle(this.value, provider);
        }

        public string ToString(IFormatProvider provider) {
            // Modify this ?
            return Convert.ToString(this.value, provider);
        }

        public object ToType(Type conversionType, IFormatProvider provider) {
            // likely not
            return Convert.ChangeType(this.value.ToString(), conversionType, provider);
        }

        public ushort ToUInt16(IFormatProvider provider) {
            return Convert.ToUInt16(this.value, provider);
        }

        public uint ToUInt32(IFormatProvider provider) {
            return Convert.ToUInt32(this.value, provider);
        }

        public ulong ToUInt64(IFormatProvider provider) {
            return Convert.ToUInt64(this.value, provider);
        }

        #endregion

        #region IFormatable

        public string ToString(string format, IFormatProvider formatProvider) {
            return this.Value.ToString(format, formatProvider);
        }

        #endregion

    }
}
