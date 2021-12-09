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
            if (sbyte.TryParse(value, out sbyte v)) {
                onSuccess();
            }
            else {
                onError(v.GetRange());
            }
        }


        public static void IsInt16(this string value, Action onSuccess, Action<NumericRange> onError) {
            if (Int16.TryParse(value, out Int16 v)) {
                onSuccess();
            }
            else {
                onError(v.GetRange());
            }
        }


        public static void IsInt32(this string value, Action onSuccess, Action<NumericRange> onError) {
            if (Int32.TryParse(value, out Int32 v)) {
                onSuccess();
            }
            else {
                onError(v.GetRange());
            }
        }


        public static void IsInt64(this string value, Action onSuccess, Action<NumericRange> onError) {
            if (Int64.TryParse(value, out Int64 v)) {
                onSuccess();
            }
            else {
                onError(v.GetRange());
            }
        }


        public static void IsByte(this string value, Action onSuccess, Action<NumericRange> onError) {
            if (Byte.TryParse(value, out byte b)) {
                onSuccess();
            }
            else {
                onError(b.GetRange());
            }
        }


        public static void IsUInt16(this string value, Action onSuccess, Action<NumericRange> onError) {
            if (UInt16.TryParse(value, out UInt16 v)) {
                onSuccess();
            }
            else {
                onError(v.GetRange());
            }
        }


        public static void IsUInt32(this string value, Action onSuccess, Action<NumericRange> onError) {
            if (UInt32.TryParse(value, out UInt32 v)) {
                onSuccess();
            }
            else {
                onError(v.GetRange());
            }
        }


        public static void IsUInt64(this string value, Action onSuccess, Action<NumericRange> onError) {
            if (UInt64.TryParse(value, out UInt64 v)) {
                onSuccess();
            }
            else {
                onError(v.GetRange());
            }
        }


        public static void IsFloat32(this string value, Action onSuccess, Action<NumericRange> onError) {
            if (Single.TryParse(value, out Single v)) {
                onSuccess();
            }
            else {
                onError(v.GetRange());
            }
        }


        public static void IsDouble(this string value, Action onSuccess, Action<NumericRange> onError) {
            if (double.TryParse(value, out double v)) {
                onSuccess();
            }
            else {
                onError(v.GetRange());
            }
        }

    }
}
