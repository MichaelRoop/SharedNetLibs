using System;
using System.Collections.Generic;
using System.Text;

namespace VariousUtils {
    public static class CharHelpers {


        public static byte[] ToByteArray(this char value) {
            return new byte[] { Convert.ToByte(value) };
        }

        public static byte ToByte(this char value) {
            return Convert.ToByte(value);
        }



    }






}
