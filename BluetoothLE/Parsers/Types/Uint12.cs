using System;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Types {

    public class Uint12 : IComparable, IComparable<Uint12>, IConvertible, IEquatable<Uint12>, IFormattable {

        #region Data

        private UInt16 value = 0;

        #endregion

        #region Properties

        public UInt16 Value { get { return this.value; } }
        public static UInt16 MaxValue { get { return 4095; } }
        public static UInt16 MinValue { get { return 0; } }

        #endregion

        #region Constructors

        public static Uint12 GetNew(UInt16 val) {
            return new Uint12(val);
        }

        public static Uint12 GetNew(byte[] data, ref int pos) {
            // Will do masking up front when reading from byte array
            return new Uint12((UInt16)(data.ToUint16(ref pos) & 0x0FFF));
        }

        public Uint12(UInt16 val) {
            if (val > Uint12.MaxValue) {
                throw new ArgumentOutOfRangeException(string.Format("Max value {0}", Uint12.MaxValue));
            }
            this.value = (UInt16)(val & 0xFFF);
        }

        #endregion

        #region Operators

        public static bool operator ==(Uint12 u1, Uint12 u2) {
            if (object.ReferenceEquals(u1, u2)) { return true; }
            if (object.ReferenceEquals(u1, null)) { return false; }
            if (object.ReferenceEquals(u2, null)) { return false; }
            return u1.Equals(u2);
        }

        public static bool operator !=(Uint12 u1, Uint12 u2) {
            if (object.ReferenceEquals(u1, u2)) { return false; }
            if (object.ReferenceEquals(u1, null)) { return true; }
            if (object.ReferenceEquals(u2, null)) { return true; }
            return !u1.Equals(u2);
        }


        public static bool operator ==(Uint12 u1, UInt16 u2) {
            if (object.ReferenceEquals(u2, null)) { return false; }
            return u1.Value == u2;
        }

        public static bool operator !=(Uint12 u1, UInt16 u2) {
            if (object.ReferenceEquals(u2, null)) { return true; }
            return u1.Value != u2;
        }

        #endregion

        #region overrides
        public override bool Equals(object obj) {
            Uint12 u = obj as Uint12;
            if (u != null) {
                return this.Equals(u);
            }
            return false;
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
            Uint12 u = (Uint12)obj;
            return CompareTo(u);
        }
        #endregion

        #region IComparable<Uint12>
        public int CompareTo(Uint12 other) {
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

        public bool Equals(Uint12 other) {
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
