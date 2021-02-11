using System;
using System.Collections.Generic;
using System.Text;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Types {

    public class Float16_IEEE11073 {

        // TODO Implement at a later date

        public float Value { get; private set; } = 0;


        public float MinValue { get { return 0; } }
        public float MaxValue { get { return 0; } }


        public static Float16_IEEE11073 GetNew(byte[] data, ref int pos) {
            //return GetNew1(data, ref pos);
            return GetNew2(data, ref pos);

        }

        #region Solution 1

        private static Float16_IEEE11073 GetNew1(byte[] data, ref int pos) {
            //https://stackoverflow.com/questions/28899195/converting-two-bytes-to-an-ieee-11073-16-bit-sfloat-in-c-sharp
            byte[] tmp = data.ToByteArray(2, ref pos);
            int mantissa = unsignedToSigned(ToInt(tmp[0]) + ((ToInt(tmp[1]) & 0x0F) << 8), 12);
            int exponent = unsignedToSigned(ToInt(tmp[1]) >> 4, 4);
            return new Float16_IEEE11073() {
                Value = (float)(mantissa * Math.Pow(10, exponent)),
            };
        }


        /// <summary>Not sure what this does also. Seems to just pass in the entire value
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static int ToInt(byte value) {
            return value & 0xFF;
        }


        /// <summary>Not sure exactly what this does</summary>
        /// <param name="unsigned"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        private static int unsignedToSigned(int unsigned, int size) {
            if ((unsigned & (1 << size - 1)) != 0) {
                unsigned = -1 * ((1 << size - 1) - (unsigned & ((1 << size - 1) - 1)));
            }
            return unsigned;
        }

        #endregion

        #region Solution 2

        private static Float16_IEEE11073 GetNew2(byte[] data, ref int pos) {
            byte[] tmp = data.ToByteArray(2, ref pos);
            UInt16 ieee11073 = (UInt16)(tmp[0] + 0x100 * tmp[1]);
            int mantissa = ieee11073 & 0x0FFF;
            if (reservedValues.ContainsKey(mantissa)) {
                return new Float16_IEEE11073() {
                    Value = reservedValues[mantissa]
                };
            }

            if (mantissa >= 0x0800) {
                mantissa = -(0x1000 - mantissa);
            }
            int exponent = ieee11073 >> 12;
            if (exponent >= 0x08) {
                exponent = -(0x10 - exponent);
            }
            var magnitude = Math.Pow(10d, exponent);
            return new Float16_IEEE11073() {
                Value = (Single)(mantissa * magnitude)
            };
        }


        // These are the values for the Single and not the 11073 
        private static Dictionary<Int32, Single> reservedValues = new Dictionary<Int32, Single> {
          { 0x07FE, Single.PositiveInfinity },
          { 0x07FF, Single.NaN },
          { 0x0800, Single.NaN },
          { 0x0801, Single.NaN },
          { 0x0802, Single.NegativeInfinity }
        };

        #endregion


    }
}
