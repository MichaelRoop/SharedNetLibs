using System;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Types {

    public class Int24 : IComparable, IComparable<Int24>, IConvertible, IEquatable<Int24>, IFormattable {

        #region Properties

        /// <summary>Int24 bit value held in Int32</summary>
        public Int32 Value { get; private set; } = 0;

        /// <summary>Maximum allowed value for Int24</summary>
        public static Int32 MaxValue { get { return 8388607; } }

        /// <summary>Minimum allowed value for Int24</summary>
        public static Int32 MinValue { get { return -8388608; } }

        #endregion

        #region Static methods

        /// <summary>Convert a 32 bit int to a 3 byte 24bit int</summary>
        /// <param name="value">The Int32 that holds the Int24 value</param>
        /// <exception cref="ArgumentOutOfRangeException">If value exceeds Int24 range</exception>
        /// <returns>3 byte array with 24bit Int</returns>
        public static byte[] GetBytes(Int32 value) {
            if (value < Int24.MinValue || value > Int24.MaxValue) {
                throw new ArgumentOutOfRangeException("value",
                    string.Format("{0} out or range {1} to {2}",
                    value, Int24.MinValue, Int24.MaxValue));
            }

            bool negative = value < 0;
            // Filter out anything over 24 bits (4th byte) of incoming Int32
            value = value & 0xFFFFFF;
            if (negative) {
                // Set the Int24 sign bit
                value = value | 0x800000;
            }
            byte[] resultData = new byte[3];
            byte[] tmp = new byte[4];
            value.WriteToBuffer(tmp, 0);
            Array.Copy(tmp, 0, resultData, 0, 3);
            return resultData;
        }


        /// <summary>Create an Int24 bit object with value from Int32</summary>
        /// <param name="value">The value to convert</param>
        /// <exception cref="ArgumentOutOfRangeException">If value exceeds Int24 range</exception>
        /// <returns>An Int24 bit object with converted value</returns>
        public static Int24 GetNew(Int32 value) {
            return new Int24(value);
        }


        /// <summary>Create an Int24 object with value from 3 bytes in array</summary>
        /// <param name="data">The byte array</param>
        /// <param name="pos">Position to read and increment from</param>
        /// <returns>An Int24 object with value from byte array</returns>
        public static Int24 GetNew(byte[] data, ref int pos) {
            // Copy the 3 bytes into the least significant position of 4 byte array
            byte[] tmp = new byte[4];
            Array.Copy(data, pos, tmp, 0, 3);
            pos += 3;

            // Create uint and mask accordingly
            int value = tmp.ToInt32(0);

            // 24th bit is int24 signed indicator
            // 1000 0000 0000 0000 0000 0000
            if ((value & 0x800000) > 0) {
                // Signed Int24 so set bits 25-32 which are Uint32 sign indicator
                value = (Int32)(value | 0xFF000000);
            }
            return new Int24() {
                Value = value,
            };
        }

        #endregion

        #region Constructors

        /// <summary>Default constructor</summary>
        public Int24() {
        }


        /// <summary>Constructor with value from Int32</summary>
        /// <param name="value">The value to convert</param>
        /// <exception cref="ArgumentOutOfRangeException">If value exceeds Int24 range</exception>
        public Int24(Int32 val) {
            // If we filter on range, the sign bit for int24 will always be set
            if (val < Int24.MinValue || val > Int24.MaxValue) {
                throw new ArgumentOutOfRangeException(
                    "val", string.Format(
                        "{0} out or range {1} to {2}", 
                        val, Int24.MinValue, Int24.MaxValue));
            }
            this.Value = val;
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
            Int24 u = (Int24)obj;
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
