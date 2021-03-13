using LogUtils.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace VariousUtils.Net {
    public static class BitTools {

        #region Data

        private static List<UInt64> masks = new List<UInt64>();
        private static ClassLog LOG = new ClassLog("BitTools");
        private static ushort BYTE_BITS = sizeof(byte) * 8;
        private static ushort UINT16_BITS = sizeof(ushort) * 8;
        private static ushort UINT32_BITS = sizeof(UInt32) * 8;
        private static ushort UINT64_BITS = sizeof(UInt64) * 8;

        #endregion


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

        public static bool IsBitSet(this short value, int pos) {
            // TODO check limit of bit shift
            return (value & (1 << pos)) != 0;
        }

        public static bool IsBitSet(this int value, int pos) {
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


        #region Bitmask creators with linear list of bools representing bits from least position

        public static bool CreateBitMask(this List<bool> list, ref byte value) {
            if (list.Count == BYTE_BITS) {
                byte tmp = 0;
                for (int i = 0; i < BYTE_BITS; i++) {
                    if (!SetBit(ref tmp, (byte)i, list[i])) {
                        return false;
                    }
                }
                value = tmp;
                return true;
            }
            return false;
        }


        public static bool CreateBitMask(this List<bool> list, ref UInt16 value) {
            if (list.Count == UINT16_BITS) {
                UInt16 tmp = 0;
                for (int i = 0; i < UINT16_BITS; i++) {
                    if (!SetBit(ref tmp, (byte)i, list[i])) {
                        return false;
                    }
                }
                value = tmp;
                return true;
            }
            return false;
        }


        public static bool CreateBitMask(this List<bool> list, ref UInt32 value) {
            if (list.Count == UINT32_BITS) {
                UInt32 tmp = 0;
                for (int i = 0; i < UINT32_BITS; i++) {
                    if (!SetBit(ref tmp, (byte)i, list[i])) {
                        return false;
                    }
                }
                value = tmp;
                return true;
            }
            return false;
        }


        public static bool CreateBitMask(this List<bool> list, ref UInt64 value) {
            if (list.Count == UINT64_BITS) {
                UInt64 tmp = 0;
                for (int i = 0; i < UINT64_BITS; i++) {
                    if (!SetBit(ref tmp, (byte)i, list[i])) {
                        return false;
                    }
                }
                value = tmp;
                return true;
            }
            return false;
        }

        #endregion

        #region Setbit on a data type
        public static bool SetBit(ref byte target, ushort pos, bool on) {
            try {
                if (pos < BYTE_BITS) {
                    if (on) {
                        target |= (byte)masks[pos];
                    }
                    else {
                        target &= (byte)~masks[pos];
                    }
                    return true;
                }
            }
            catch (Exception e) {
                LOG.Exception(9999, "SetBit", "", e);
            }
            return false;
        }


        public static bool SetBit(ref UInt16 target, ushort pos, bool on) {
            try {
                if (pos < UINT16_BITS) {
                    if (on) {
                        target |= (UInt16)masks[pos];
                    }
                    else {
                        target &= (UInt16)~masks[pos];
                    }

                    return true;
                }
            }
            catch (Exception e) {
                LOG.Exception(9999, "SetBit", "", e);
            }
            return false;
        }


        public static bool SetBit(ref UInt32 target, ushort pos, bool on) {
            try {
                if (pos < UINT32_BITS) {
                    if (on) {
                        target |= (UInt32)masks[pos];
                    }
                    else {
                        target &= (UInt32)~masks[pos];
                    }
                    return true;
                }
            }
            catch (Exception e) {
                LOG.Exception(9999, "SetBit", "", e);
            }
            return false;
        }


        public static bool SetBit(ref UInt64 target, ushort pos, bool on) {
            try {
                if (pos < UINT64_BITS) {
                    if (on) {
                        target |= masks[pos];
                    }
                    else {
                        target &= ~masks[pos];
                    }
                    return true;
                }
            }
            catch (Exception e) {
                LOG.Exception(9999, "SetBit", "", e);
            }
            return false;
        }

        #endregion

        #region Get string representation of bits, right to left order of importance

        public static string ToBitString(this byte value) {
            return GetBitString(value.ToByteArray());
        }
        
        public static string ToBitString(this UInt16 value) {
            // Need to flip byte order for human readable linear sequence
            return GetBitString(value.ReverseBytes().ToByteArray());
        }

        public static string ToBitString(this UInt32 value) {
            // Need to flip byte order for human readable linear sequence
            return GetBitString(value.ReverseBytes().ToByteArray());
        }

        public static string GetBitString(this UInt64 value) {
            // Need to flip byte order for human readable linear sequence
            return GetBitString(value.ReverseBytes().ToByteArray());
        }

        private static string GetBitString(byte[] array) {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < array.Length; i++) {
                // Then iterate each bit of each byte
                if (i > 0) {
                    sb.Append(" ");
                }

                for (int j = 7; j >= 0; j--) {
                    if (j == 3) {
                        sb.Append(" ");
                    }
                    sb.Append(IsBitSet(array[i], j) ? "1" : "0");
                }
            }
            return sb.ToString();
        }

        #endregion

        static BitTools() {
            // Build the bit masks for individual bits up to 64th bit
            // 0 - 7
            masks.Add(0x01);
            masks.Add(0x02);
            masks.Add(0x04);
            masks.Add(0x08);
            masks.Add(0x10);
            masks.Add(0x20);
            masks.Add(0x40);
            masks.Add(0x80);
            // 8 - 15
            masks.Add(0x0100);
            masks.Add(0x0200);
            masks.Add(0x0400);
            masks.Add(0x0800);
            masks.Add(0x1000);
            masks.Add(0x2000);
            masks.Add(0x4000);
            masks.Add(0x8000);
            // 16- 23
            masks.Add(0x010000);
            masks.Add(0x020000);
            masks.Add(0x040000);
            masks.Add(0x080000);
            masks.Add(0x100000);
            masks.Add(0x200000);
            masks.Add(0x400000);
            masks.Add(0x800000);
            // 24 - 31
            masks.Add(0x01000000);
            masks.Add(0x02000000);
            masks.Add(0x04000000);
            masks.Add(0x08000000);
            masks.Add(0x10000000);
            masks.Add(0x20000000);
            masks.Add(0x40000000);
            masks.Add(0x80000000);
            // 32 - 39
            masks.Add(0x0100000000);
            masks.Add(0x0200000000);
            masks.Add(0x0400000000);
            masks.Add(0x0800000000);
            masks.Add(0x1000000000);
            masks.Add(0x2000000000);
            masks.Add(0x4000000000);
            masks.Add(0x8000000000);
            // 40 - 47
            masks.Add(0x010000000000);
            masks.Add(0x020000000000);
            masks.Add(0x040000000000);
            masks.Add(0x080000000000);
            masks.Add(0x100000000000);
            masks.Add(0x200000000000);
            masks.Add(0x400000000000);
            masks.Add(0x800000000000);
            // 48 -55
            masks.Add(0x01000000000000);
            masks.Add(0x02000000000000);
            masks.Add(0x04000000000000);
            masks.Add(0x08000000000000);
            masks.Add(0x10000000000000);
            masks.Add(0x20000000000000);
            masks.Add(0x40000000000000);
            masks.Add(0x80000000000000);
            // 56 - 63
            masks.Add(0x0100000000000000);
            masks.Add(0x0200000000000000);
            masks.Add(0x0400000000000000);
            masks.Add(0x0800000000000000);
            masks.Add(0x1000000000000000);
            masks.Add(0x2000000000000000);
            masks.Add(0x4000000000000000);
            masks.Add(0x8000000000000000);
        }


        #endregion

    }
}
