namespace VariousUtils.Net {
    public static class BitTools {

        public static byte SetBit(byte data, int pos, bool on) {
            return (on) ? (byte)(data | 1 << pos) : (byte)(data & ~(1 << pos));
        }



        /// <summary>Check if the bit numbered pos is set to 1</summary>
        /// <param name="value">The data member to check</param>
        /// <param name="pos">The bit position</param>
        /// <returns>true if bit set to 1</returns>
        public static bool IsBitSet(this byte value, int pos) {
            // TODO check limit of bit shift
            return (value & (1 << pos)) != 0;
        }


        /// <summary>Check if the bit numbered pos is set to 1</summary>
        /// <param name="value">The data member to check</param>
        /// <param name="pos">The bit position</param>
        /// <returns>true if bit set to 1</returns>
        public static bool IsBitSet(this ushort value, int pos) {
            // TODO check limit of bit shift
            return (value & (1 << pos)) != 0;
        }




    }
}
