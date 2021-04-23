using System;

namespace VariousUtils.Net {



    public static class NumericValidators {

        public static void IsBool(this string value, Action onSuccess, Action<NumericRange> onError) {
            if(value == "0" || value == "1") {
                onSuccess();
            }
            else {
                onError(new NumericRange(0, 1));
            }
        }


        public static void IsSByte(this string value, Action onSuccess, Action<NumericRange> onError) {
            sbyte v;
            if (sbyte.TryParse(value, out v)) {
                onSuccess();
            }
            else {
                onError(v.GetRange());
            }
        }


        public static void IsInt16(this string value, Action onSuccess, Action<NumericRange> onError) {
            Int16 v;
            if (Int16.TryParse(value, out v)) {
                onSuccess();
            }
            else {
                onError(v.GetRange());
            }
        }


        public static void IsInt32(this string value, Action onSuccess, Action<NumericRange> onError) {
            Int32 v;
            if (Int32.TryParse(value, out v)) {
                onSuccess();
            }
            else {
                onError(v.GetRange());
            }
        }


        public static void IsInt64(this string value, Action onSuccess, Action<NumericRange> onError) {
            Int64 v;
            if (Int64.TryParse(value, out v)) {
                onSuccess();
            }
            else {
                onError(v.GetRange());
            }
        }


        public static void IsByte(this string value, Action onSuccess, Action<NumericRange> onError) {
            byte b;
            if (Byte.TryParse(value, out b)) {
                onSuccess();
            }
            else {
                onError(b.GetRange());
            }
        }


        public static void IsUInt16(this string value, Action onSuccess, Action<NumericRange> onError) {
            UInt16 v;
            if (UInt16.TryParse(value, out v)) {
                onSuccess();
            }
            else {
                onError(v.GetRange());
            }
        }


        public static void IsUInt32(this string value, Action onSuccess, Action<NumericRange> onError) {
            UInt32 v;
            if (UInt32.TryParse(value, out v)) {
                onSuccess();
            }
            else {
                onError(v.GetRange());
            }
        }


        public static void IsUInt64(this string value, Action onSuccess, Action<NumericRange> onError) {
            UInt64 v;
            if (UInt64.TryParse(value, out v)) {
                onSuccess();
            }
            else {
                onError(v.GetRange());
            }
        }


        public static void IsFloat32(this string value, Action onSuccess, Action<NumericRange> onError) {
            Single v;
            if (Single.TryParse(value, out v)) {
                onSuccess();
            }
            else {
                onError(v.GetRange());
            }
        }


        public static void IsDouble(this string value, Action onSuccess, Action<NumericRange> onError) {
            double v;
            if (double.TryParse(value, out v)) {
                onSuccess();
            }
            else {
                onError(v.GetRange());
            }
        }

    }
}
