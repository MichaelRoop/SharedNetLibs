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

        #region SetMask


        public static void SetMaskAllOn(this byte[] mask, int pos) {
            mask[pos] = 0xFF;
        }

        public static void SetMaskAllOff(this byte[] mask, int pos) {
            mask[pos] = 0;
        }


        public static void SetMask(this byte[] mask, int pos,
            bool zero, bool one, bool two, bool three, bool four, bool five, bool six, bool seven) {
            // set all bits off
            byte b = mask[pos];
            b = 0;
            b = BitTools.SetBit(b, 0, zero);
            b = BitTools.SetBit(b, 1, one);
            b = BitTools.SetBit(b, 2, two);
            b = BitTools.SetBit(b, 3, three);
            b = BitTools.SetBit(b, 4, four);
            b = BitTools.SetBit(b, 5, five);
            b = BitTools.SetBit(b, 6, six);
            b = BitTools.SetBit(b, 7, seven);
            mask[pos] = b;
        }


        public static void SetMask(this byte[] mask, int pos,
            bool zero, bool one, bool two, bool three, bool four, bool five, bool six) {
            mask.SetMask(pos, zero, one, two, three, four, five, six, false);
        }

        public static void SetMask(this byte[] mask, int pos,
            bool zero, bool one, bool two, bool three, bool four, bool five) {
            mask.SetMask(pos, zero, one, two, three, four, five, false);
        }

        public static void SetMask(this byte[] mask, int pos,
            bool zero, bool one, bool two, bool three, bool four) {
            mask.SetMask(pos, zero, one, two, three, four, false);
        }

        public static void SetMask(this byte[] mask, int pos, bool zero, bool one, bool two, bool three) {
            mask.SetMask(pos, zero, one, two, three, false);
        }

        public static void SetMask(this byte[] mask, int pos, bool zero, bool one, bool two) {
            mask.SetMask(pos, zero, one, two, false);
        }

        public static void SetMask(this byte[] mask, int pos, bool zero, bool one) {
            mask.SetMask(pos, zero, one, false);
        }

        public static void SetMask(this byte[] mask, int pos, bool zero) {
            mask.SetMask(pos, zero, false);
        }

        #endregion

    }
}
