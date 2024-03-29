﻿using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace VariousUtils.Net {

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
            StringBuilder sb = new (data.Length + 10);
            for (int i = 0; i < data.Length; i++) {
                sb.Append(string.Format("{0}0x{1:X2}", (i > 0 ? "," : ""), data[i]));
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
            StringBuilder sb = new ();
            for (int i = 0; i< pieces.Length; i++) {
                if (i > 0) {
                    sb.Append(' ');
                }
                sb.Append(pieces[i]);
            }
            return sb.ToString();
        }


        public static string UnderlineToSpaces(this string data) {
            return data.Replace('_', ' ');
        }


        /// <summary>Culture specific rendering of double</summary>
        /// <param name="value">The double source</param>
        /// <param name="format">Format string of output</param>
        /// <returns>Formated string conforming to culture</returns>
        public static string ToStr(this double value, int digits) {
            return value.ToString(digits.ToExpFormat(), CultureInfo.CurrentCulture);
        }


        /// <summary>Culture specific rendering of double</summary>
        /// <param name="value">The double source</param>
        /// <param name="format">Format string of output</param>
        /// <returns>Formated string conforming to culture</returns>
        public static string ToStr(this float value, int digits) {
            return value.ToString(digits.ToExpFormat(), CultureInfo.CurrentCulture);
        }

        // TODO - figure out exponent for ulong
        public static string ToStr(this ulong value, int digits) {
            return value.ToString(digits.ToExpFormat(), CultureInfo.CurrentCulture);
        }


        public static string ToExpFormat(this int exponent) {
            return exponent switch {
                -1 => "#######0.0",
                -2 => "#######0.00",
                -3 => "#######0.000",
                -4 => "#######0.0000",
                -5 => "#######0.00000",
                -6 => "#######0.000000",
                -7 => "#######0.0000000",
                -8 => "#######0.00000000",
                -9 => "#######0.000000000",
                _ => "0",
            };
        }


        //https://stackoverflow.com/questions/2954962/convert-integer-to-binary-in-c-sharp
        public static string ToFormatedBinaryString(this UInt64 base10) {

            // Limited to Uint32
            //StringBuilder sb = new StringBuilder(Convert.ToString(base10, 2));
            //for (int i = sb.Length - 4; i > 0; i -= 4) {
            //    sb.Insert(i, ' ');
            //}
            //return sb.ToString();

            
            string binary = "";
            do {
                binary = (base10 % 2) + binary;
                base10 /= 2;
            }
            while (base10 > 0);

            // Need to add spaces
            Char[] arr = binary.ToCharArray();
            Array.Reverse(arr);

            List<char> target = new ();
            for (int i = 0; i < arr.Length; i++) {
                if (i % 4 == 0) {
                    target.Add(' ');
                }
                target.Add(arr[i]);
            }

            target.Reverse();
            return new string(target.ToArray());
            
        }




    }
}
