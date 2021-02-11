using System;
using System.Collections.Generic;
using System.Text;

namespace BluetoothLE.Net.Parsers.Types {

    // TODO Implement at a later date



    /// <summary>Provide conversion between common Single (IEEE 754) and Float32 IEEE 11073</summary>
    /// <remarks>
    /// Used in medical devices
    /// https://stackoverflow.com/questions/60841331/dart-convert-ieee-11073-32-bit-float-to-a-simple-double
    /// Structure
    /// Special values
    /// +Infinity: 0x007FFFFE
    ///      Na0N: 0x007FFFFF
    ///      NRes: 0x00800000
    /// -Infinity: 0x00800002
    /// 
    /// 
    /// // Apparently I can use the 16 bit conversion code from this article and change the maskeing
    /// https://stackoverflow.com/questions/11564270/how-to-convert-ieee-11073-16-bit-sfloat-to-simple-float-in-java 
    /// if (mantissa >= 0x8000 {
    ///     mantisa - ((0x0FFF + 1) - mantissa);
    /// }
    /// 
    /// 
    /// </remarks>
    public class Float32_IEEE11073 {

        public Float32_IEEE11073() {


            //Double.IsPositiveInfinity
            //Double.IsNegativeInfinity
            //Double.IsFinite // Normal, zero, subnormal
            //Double.IsNaN
            //Double.Parse
            //Double.Epsilon
            //Double.TryParse

            //Double.NaN
            //Double.MaxValue
            //Double.MinValue
            //Double.PositiveInfinity
            //Double.NegativeInfinity
        }

    }
}
