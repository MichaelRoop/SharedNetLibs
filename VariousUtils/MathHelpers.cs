﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VariousUtils.Net {

    public static class MathHelper {

        public static double Calculate(double value, double exponent, int digits) {
            //https://stackoverflow.com/questions/55553884/what-is-exponent-value-in-this-table-of-bluetooth-characteristic-format-types
            return Math.Round(value * Math.Pow(10, exponent), Math.Abs(digits));
        }




        public static double Calculate(this UInt16 value, double exponent, int digits) {
            return Calculate((double)value, exponent, digits);
        }

        public static double Calculate(this Int16 value, double exponent, int digits) {
            return Calculate((double)value, exponent, digits);
        }

        public static double Calculate(this UInt32 value, double exponent, int digits) {
            return Calculate((double)value, exponent, digits);
        }

        public static double Calculate(this Int32 value, double exponent, int digits) {
            return Calculate((double)value, exponent, digits);
        }


    }
}
