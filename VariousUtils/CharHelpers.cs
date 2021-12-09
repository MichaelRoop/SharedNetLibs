namespace VariousUtils.Net {
    public static class CharHelpers {


        public static byte[] ToByteArray(this char value) {
            return new byte[] { Convert.ToByte(value) };
        }

        public static byte ToByte(this char value) {
            return Convert.ToByte(value);
        }



    }






}
