using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace VariousUtils {

    public static class StringHelpers {

        public static byte[] ToAsciiByteArray(this string value) {
            return Encoding.ASCII.GetBytes(value);
        }


        public static string ToAsciiString(this byte[] value) {
            return Encoding.ASCII.GetString(value);
        }


        public static string CamelCaseToSpaces(this string data) {
            string[] pieces = Regex.Split(data, @"(?<!^)(?=[A-Z])");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i< pieces.Length; i++) {
                if (i > 0) {
                    sb.Append(" ");
                }
                sb.Append(pieces[i]);
            }
            return sb.ToString();
        }


    }
}
