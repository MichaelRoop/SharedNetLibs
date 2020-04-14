using System;
using System.Collections.Generic;
using System.Text;

namespace VariousUtils {

    public static class StringHelpers {

        public static byte[] ToAsciiByteArray(this string value) {
            return Encoding.ASCII.GetBytes(value);
        }


        public static string ToAsciiString(this byte[] value) {
            return Encoding.ASCII.GetString(value);
        }



    }
}
