using System;
using System.Collections.Generic;
using System.Text;

namespace VariousUtils.Net {

    public class RangeInfo {
        public string Min { get; set; }
        public string Max { get; set; }
        public RangeInfo(object min, object max) {
            this.Min = min.ToString();
            this.Max = max.ToString();
        }
    }


    public static class NumericValidators {

        public static void IsByte(this string value, Action onSuccess, Action<RangeInfo> onError) {
            byte b;
            if (Byte.TryParse(value, out b)) {
                onSuccess();
            }
            else {
                onError(new RangeInfo(byte.MinValue, byte.MaxValue));
            }
        }


        public static void IsSByte(this string value, Action onSuccess, Action<RangeInfo> onError) {
            sbyte b;
            if (sbyte.TryParse(value, out b)) {
                onSuccess();
            }
            else {
                onError(new RangeInfo(sbyte.MinValue, sbyte.MaxValue));
            }
        }




        //public static void IsSByte(this string value, Action onSuccess, Action<RangeInfo> onError) {
        //}




    }
}
