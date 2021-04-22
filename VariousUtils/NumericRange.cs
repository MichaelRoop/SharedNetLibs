using System;
using System.Collections.Generic;
using System.Text;

namespace VariousUtils.Net {

    public class NumericRange {

        public string Min { get; set; }

        public string Max { get; set; }

        public NumericRange(object min, object max) {
            this.Min = min.ToString();
            this.Max = max.ToString();
        }

    }


    public static class NumericRangeExtensions {

        public static NumericRange GetRange(this bool value) {
            return new NumericRange(0, 1);
        }

        public static NumericRange GetRange(this byte value) {
            return new NumericRange(byte.MinValue, byte.MaxValue);
        }

        public static NumericRange GetRange(this Int16 value) {
            return new NumericRange(Int16.MinValue, Int16.MaxValue);
        }

        public static NumericRange GetRange(this Int32 value) {
            return new NumericRange(Int32.MinValue, Int32.MaxValue);
        }
        public static NumericRange GetRange(this Int64 value) {
            return new NumericRange(Int64.MinValue, Int64.MaxValue);
        }


        public static NumericRange GetRange(this sbyte value) {
            return new NumericRange(sbyte.MinValue, sbyte.MaxValue);
        }

        public static NumericRange GetRange(this UInt16 value) {
            return new NumericRange(UInt16.MinValue, UInt16.MaxValue);
        }

        public static NumericRange GetRange(this UInt32 value) {
            return new NumericRange(UInt32.MinValue, UInt32.MaxValue);
        }

        public static NumericRange GetRange(this UInt64 value) {
            return new NumericRange(UInt64.MinValue, UInt64.MaxValue);
        }

        public static NumericRange GetRange(this Single value) {
            return new NumericRange(Single.MinValue, Single.MaxValue);
        }

        public static NumericRange GetRange(this double value) {
            return new NumericRange(double.MinValue, double.MaxValue);
        }

    }

}
