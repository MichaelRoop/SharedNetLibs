﻿using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Types {

    public class UInt12 : IComparable, IComparable<UInt12>, IConvertible, IEquatable<UInt12>, IFormattable {

        #region Data

        private readonly UInt16 value = 0;

        #endregion

        #region Properties

        public UInt16 Value { get { return this.value; } }
        public static UInt16 MaxValue { get { return 4095; } }
        public static UInt16 MinValue { get { return 0; } }

        #endregion

        #region Static methods

        /// <summary>Convert the string and initialize a value</summary>
        /// <param name="s">The string to parse</param>
        /// <param name="result">The value to initialize</param>
        /// <returns>true if the string is a valid number in the range of an Int24</returns>
        public static bool TryParse(string s, out UInt16 result) {
            if (UInt16.TryParse(s, out result)) {
                return result >= UInt12.MinValue && result <= UInt12.MaxValue;
            }
            return false;
        }

        #endregion

        #region Constructors

        public static UInt12 GetNew(UInt16 val) {
            return new UInt12(val);
        }

        public static UInt12 GetNew(byte[] data, ref int pos) {
            // Will do masking up front when reading from byte array
            return new UInt12((UInt16)(data.ToUint16(ref pos) & 0x0FFF));
        }

        public UInt12(UInt16 val) {
            if (val > UInt12.MaxValue) {
                throw new ArgumentOutOfRangeException(string.Format("Max value {0}", UInt12.MaxValue));
            }
            this.value = (UInt16)(val & 0xFFF);
        }

        #endregion

        #region Operators

        public static bool operator ==(UInt12 u1, UInt12 u2) {
            if (ReferenceEquals(u1, u2)) { return true; }
            if (u1 is null || u2 is null) { return false; }
            return u1.Equals(u2);
        }

        public static bool operator !=(UInt12 u1, UInt12 u2) {
            if (ReferenceEquals(u1, u2)) { return false; }
            if (u1 is null || u2 is null) { return true; }
            return !u1.Equals(u2);
        }


        public static bool operator ==(UInt12 u1, UInt16 u2) {
            return u1.Value == u2;
        }

        public static bool operator !=(UInt12 u1, UInt16 u2) {
            return u1.Value != u2;
        }

        #endregion

        #region overrides
        public override bool Equals(object? obj) => (obj is UInt12 @int) && this.Equals(@int);

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public override string ToString() {
            return this.value.ToString();
        }

        #endregion

        #region IComparable
        public int CompareTo(object? obj) {
            return this.CompareTo(obj as Int12);
        }
        #endregion

        #region IComparable<Uint12>
        public int CompareTo(UInt12? other) {
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

        public bool Equals(UInt12? other) => other is not null && this.Value == other.Value;

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
