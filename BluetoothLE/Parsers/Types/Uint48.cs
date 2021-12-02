using VariousUtils.Net;


namespace BluetoothLE.Net.Parsers.Types {

    public class UInt48 : IComparable, IComparable<UInt48>, IConvertible, IEquatable<UInt48>, IFormattable {

        #region Data

        private UInt64 value = 0;

        #endregion

        #region Properties

        public UInt64 Value { get { return this.value; } }
        public static UInt64 MaxValue { get { return 281474976710655; } }
        public static UInt64 MinValue { get { return 0; } }

        #endregion

        #region Static methods

        public static byte[] GetBytes(UInt64 value) {
            byte[] tmp = new byte[8];
            value.WriteToBuffer(tmp, 0);
            byte[] result = new byte[6];
            Array.Copy(tmp, result, 6);
            return result;
        }


        /// <summary>Convert the string and initialize a value</summary>
        /// <param name="s">The string to parse</param>
        /// <param name="result">The value to initialize</param>
        /// <returns>true if the string is a valid number in the range of an Int24</returns>
        public static bool TryParse(string s, out UInt64 result) {
            if (UInt64.TryParse(s, out result)) {
                return result >= UInt48.MinValue && result <= UInt48.MaxValue;
            }
            return false;
        }

        #endregion

        #region Constructors

        public static UInt48 GetNew(UInt64 val) {
            return new UInt48(val);
        }

        public static UInt48 GetNew(byte[] data, ref int pos) {
            byte[] tmp = new byte[8];
            // Only copying 6 bytes from buffer. Manually increment pointer
            Array.Copy(data, pos, tmp, 0, 6);
            pos += 6;
            return new UInt48(tmp.ToUint64(0) & 0xFFFFFFFFFFFF);
        }


        public UInt48(UInt64 val) {
            if (val > UInt48.MaxValue) {
                throw new ArgumentOutOfRangeException(string.Format("Max value {0}", UInt48.MaxValue));
            }
            this.value = (UInt64)(val & 0xFFFFFFFFFFFF);
        }

        #endregion

        #region Operators

        public static bool operator ==(UInt48 u1, UInt48 u2) {
            if (object.ReferenceEquals(u1, u2)) { return true; }
            if (object.ReferenceEquals(u1, null)) { return false; }
            if (object.ReferenceEquals(u2, null)) { return false; }
            return u1.Equals(u2);
        }

        public static bool operator !=(UInt48 u1, UInt48 u2) {
            if (object.ReferenceEquals(u1, u2)) { return false; }
            if (object.ReferenceEquals(u1, null)) { return true; }
            if (object.ReferenceEquals(u2, null)) { return true; }
            return !u1.Equals(u2);
        }


        public static bool operator ==(UInt48 u1, UInt64 u2) {
            if (object.ReferenceEquals(u2, null)) { return false; }
            return u1.Value == u2;
        }

        public static bool operator !=(UInt48 u1, UInt64 u2) {
            if (object.ReferenceEquals(u2, null)) { return true; }
            return u1.Value != u2;
        }

        #endregion

        #region overrides
        public override bool Equals(object? obj) {
            return (obj is UInt48) ? this.Equals((UInt48)obj) : false;
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public override string ToString() {
            return this.value.ToString();
        }

        #endregion

        #region IComparable
        public int CompareTo(object? obj) {
            UInt24 u = (UInt24)obj;
            return CompareTo(u);
        }
        #endregion

        #region IComparable<Uint24>
        public int CompareTo(UInt48 other) {
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

        public bool Equals(UInt48 other) {
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
            return Convert.ToUInt16(this.Value, provider);
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
