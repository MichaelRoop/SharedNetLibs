using System;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Types {

    public class Int48 : IComparable, IComparable<Int48>, IConvertible, IEquatable<Int48>, IFormattable {

        #region Properties

        /// <summary>Int48 bit value held in Int64</summary>
        public Int64 Value { get; private set; } = 0;

        /// <summary>Maximum allowed value for Int24</summary>
        public static Int64 MaxValue { get { return 140737488355327; } }

        /// <summary>Minimum allowed value for Int24</summary>
        public static Int64 MinValue { get { return -140737488355328; } }

        #endregion

        #region Static methods

        /// <summary>Convert a 64 bit int to a 6 byte 48bit int</summary>
        /// <param name="value">The Int64 that holds the Int48 value</param>
        /// <exception cref="ArgumentOutOfRangeException">If value exceeds Int48 range</exception>
        /// <returns>6 byte array with 48bit Int</returns>
        public static byte[] GetBytes(Int64 value) {
            if (value < Int48.MinValue || value > Int48.MaxValue) {
                throw new ArgumentOutOfRangeException("value",
                    string.Format("{0} out or range {1} to {2}",
                    value, Int48.MinValue, Int48.MaxValue));
            }

            bool negative = value < 0;
            // Filter out anything over 48 bits (6th byte) of incoming Int64
            value = value & 0x0000FFFFFFFFFFFF;
            if (negative) {
                // Set the 48th sign bit
                value = value | 0x800000000000;
            }
            byte[] resultData = new byte[6];
            byte[] tmp = new byte[8];
            value.WriteToBuffer(tmp, 0);
            Array.Copy(tmp, 0, resultData, 0, 6);
            return resultData;
        }


        /// <summary>Create an Int24 bit object with value from Int32</summary>
        /// <param name="value">The value to convert</param>
        /// <exception cref="ArgumentOutOfRangeException">If value exceeds Int24 range</exception>
        /// <returns>An Int24 bit object with converted value</returns>
        public static Int48 GetNew(Int64 value) {
            return new Int48(value);
        }


        /// <summary>Create an Int48 object with value from 6 bytes in array</summary>
        /// <param name="data">The byte array</param>
        /// <param name="pos">Position to read and increment from</param>
        /// <returns>An Int48 object with value from byte array</returns>
        public static Int48 GetNew(byte[] data, ref int pos) {

            // TODO - modify for 6 bytes copy to 8 byte holder

            // Copy the 3 bytes into the least significant position of 4 byte array
            byte[] tmp = new byte[8];
            Array.Copy(data, pos, tmp, 0, 6);
            pos += 6;

            // Create uint and mask accordingly
            Int64 value = tmp.ToInt64(0);

            // 48th bit is int48 signed indicator
            if ((value & 0x800000000000) > 0) {
                // Signed Int48 so set bits 49-64 which are Uint64 sign indicator
                value = (Int64)((ulong)value | 0xFFFF000000000000);
            }
            return new Int48() {
                Value = value,
            };
        }


        /// <summary>Convert the string and initialize a value</summary>
        /// <param name="s">The string to parse</param>
        /// <param name="result">The value to initialize</param>
        /// <returns>true if the string is a valid number in the range of an Int24</returns>
        public static bool TryParse(string s, out Int64 result) {
            if (Int64.TryParse(s, out result)) {
                return result >= Int48.MinValue && result <= Int48.MaxValue;
            }
            return false;
        }

        #endregion

        #region Constructors

        /// <summary>Default constructor</summary>
        public Int48() {
        }


        /// <summary>Constructor with value from Int32</summary>
        /// <param name="value">The value to convert</param>
        /// <exception cref="ArgumentOutOfRangeException">If value exceeds Int24 range</exception>
        public Int48(Int64 val) {
            // If we filter on range, the sign bit for int48 will always be set
            if (val < Int48.MinValue || val > Int48.MaxValue) {
                throw new ArgumentOutOfRangeException(
                    "val", string.Format(
                        "{0} out or range {1} to {2}",
                        val, Int48.MinValue, Int48.MaxValue));
            }
            this.Value = val;
        }

        #endregion

        #region Operators

        public static bool operator ==(Int48 u1, Int48 u2) {
            if (object.ReferenceEquals(u1, u2)) { return true; }
            if (object.ReferenceEquals(u1, null)) { return false; }
            if (object.ReferenceEquals(u2, null)) { return false; }
            return u1.Equals(u2);
        }

        public static bool operator !=(Int48 u1, Int48 u2) {
            if (object.ReferenceEquals(u1, u2)) { return false; }
            if (object.ReferenceEquals(u1, null)) { return true; }
            if (object.ReferenceEquals(u2, null)) { return true; }
            return !u1.Equals(u2);
        }


        public static bool operator ==(Int48 u1, Int64 u2) {
            if (object.ReferenceEquals(u2, null)) { return false; }
            return u1.Value == u2;
        }

        public static bool operator !=(Int48 u1, Int64 u2) {
            if (object.ReferenceEquals(u2, null)) { return true; }
            return u1.Value != u2;
        }

        #endregion

        #region overrides
        public override bool Equals(object? obj) {
            return (obj is Int48) ? this.Equals((Int48)obj) : false;
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
            return this.CompareTo(obj as Int48);
        }
        #endregion

        #region IComparable<Int48>
        public int CompareTo(Int48? other) {
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

        public bool Equals(Int48? other) {
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
