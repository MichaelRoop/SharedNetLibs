﻿using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Types {

    public class UInt04 : IComparable, IComparable<UInt04>, IConvertible, IEquatable<UInt04>, IFormattable {


        #region Data

        private readonly byte value = 0;

        #endregion

        #region Properties

        public byte Value { get { return this.value; } }
        public static Byte MaxValue { get { return 15; } }
        public static Byte MinValue { get { return 0; } }

        #endregion

        #region Static methods

        /// <summary>Convert the string and initialize a value</summary>
        /// <param name="s">The string to parse</param>
        /// <param name="result">The value to initialize</param>
        /// <returns>true if the string is a valid number in the range of an Int24</returns>
        public static bool TryParse(string s, out byte result) {
            if (Byte.TryParse(s, out result)) {
                return result >= UInt04.MinValue && result <= UInt04.MaxValue;
            }
            return false;
        }

        #endregion

        #region Constructors

        public static UInt04 GetNew(byte b) {
            return new UInt04(b);
        }

        public static UInt04 GetNew(byte[] data, ref int pos) {
            // Will do masking up front when reading from byte array
            return new UInt04((byte)(data.ToByte(ref pos) & 0x0F));
        }

        public UInt04(byte b) {
            if (b > 15) {
                throw new ArgumentOutOfRangeException(nameof(b), "Max value 15");
            }
            this.value = (byte)(b & 0x0F);
        }

        #endregion

        #region Operators

        public static bool operator ==(UInt04 u1, UInt04 u2) {
            if (ReferenceEquals(u1, u2)) { return true; }
            if (u1 is null || u2 is null) { return false; }
            return u1.Equals(u2);
        }

        public static bool operator !=(UInt04 u1, UInt04 u2) {
            if (ReferenceEquals(u1, u2)) { return false; }
            if (u1 is null || u2 is null) { return true; }
            return !u1.Equals(u2);
        }


        public static bool operator ==(UInt04 u1, Byte u2) {
            return u1.Value == u2;
        }

        public static bool operator !=(UInt04 u1, Byte u2) {
            return u1.Value != u2;
        }

        #endregion

        #region overrides
        public override bool Equals(object? obj) => (obj is UInt04 @i) && this.Equals(@i);

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public override string ToString() {
            return this.value.ToString();
        }

        #endregion

        #region IComparable
        public int CompareTo(object? obj) {
            return this.CompareTo(obj as UInt04);
        }
        #endregion

        #region IComparable<Uint04>
        public int CompareTo(UInt04? other) {
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

        public bool Equals(UInt04? other) => other is not null && this.Value == other.Value;

        #endregion

        #region IConvertible

        public TypeCode GetTypeCode() {
            return TypeCode.Object;
        }

        public bool ToBoolean(IFormatProvider? provider) {
            return Convert.ToBoolean(this.value, provider);
        }

        public byte ToByte(IFormatProvider? provider) {
            return Convert.ToByte(this.value, provider);
        }

        public char ToChar(IFormatProvider? provider) {
            return Convert.ToChar(this.value, provider);
        }

        public DateTime ToDateTime(IFormatProvider? provider) {
            return Convert.ToDateTime(this.value, provider);
        }

        public decimal ToDecimal(IFormatProvider? provider) {
            return Convert.ToDecimal(this.value, provider);
        }

        public double ToDouble(IFormatProvider? provider) {
            return Convert.ToDouble(this.value, provider);
        }

        public short ToInt16(IFormatProvider? provider) {
            return Convert.ToInt16(this.value, provider);
        }

        public int ToInt32(IFormatProvider? provider) {
            return Convert.ToInt32(this.value, provider);
        }

        public long ToInt64(IFormatProvider? provider) {
            return Convert.ToInt64(this.value, provider);
        }

        public sbyte ToSByte(IFormatProvider? provider) {
            return Convert.ToSByte(this.value, provider);
        }

        public float ToSingle(IFormatProvider? provider) {
            return Convert.ToSingle(this.value, provider);
        }

        public string ToString(IFormatProvider? provider) {
            // Modify this ?
            return Convert.ToString(this.value, provider);
        }

        public object ToType(Type conversionType, IFormatProvider? provider) {
            // likely not
            return Convert.ChangeType(this.value.ToString(), conversionType, provider);
        }

        public ushort ToUInt16(IFormatProvider? provider) {
            return Convert.ToUInt16(this.value, provider);
        }

        public uint ToUInt32(IFormatProvider? provider) {
            return Convert.ToUInt32(this.value, provider);
        }

        public ulong ToUInt64(IFormatProvider? provider) {
            return Convert.ToUInt64(this.value, provider);
        }

        #endregion

        #region IFormatable

        public string ToString(string? format, IFormatProvider? formatProvider) {
            return this.Value.ToString(format, formatProvider);
        }

        #endregion




    }

}
