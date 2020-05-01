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


        public static string ToAsciiString(this byte[] value, int length) {
            byte[] part = new byte[length];
            Array.Copy(value, part, length);
            return Encoding.ASCII.GetString(part);
        }


        /// <summary>Gives ability to display bytes as hex entities in string</summary>
        /// <param name="data">The data to display</param>
        /// <returns>String with 0x00,0x12 type format</returns>
        public static string ToHexByteString(this byte[] data) {
            StringBuilder sb = new StringBuilder(data.Length + 10);
            for (int i = 0; i < data.Length; i++) {
                sb.Append(string.Format("{0}{1:X2}", (i > 0 ? "," : ""), data[i]));
            }
            return sb.ToString();
        }



        /// <summary>Replace unprintable characters with '*' in string output</summary>
        /// <param name="data">The incoming bytes</param>
        /// <returns>A printable string with non-printable characters replaced</returns>
        public static string ToPrintabletString(byte[] data) {
            byte[] copy = new byte[data.Length];
            Array.Copy(data, copy, copy.Length);
            for (int i = 0; i < data.Length; i++) {
                if (copy[i] >= 0x00 && copy[i] <= 0x1F) {
                    copy[i] = 0x2A; // replace with '*'
                }
            }
            return Encoding.ASCII.GetString(copy);
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
