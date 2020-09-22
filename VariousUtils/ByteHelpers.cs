using System;

namespace VariousUtils.Net {

    public static class ByteHelpers {


        public static char ToChar(this byte value) {
            return Convert.ToChar(value);
        }


        public static string ToFormatedByteString(this byte[] data) {
            return string.Format("0x{0}", BitConverter.ToString(data).Replace("-", ",0x"));
        }


        public static int FindFirstBytePatternPos(this byte[] buff, byte[] terminator, int dataLen) {
            if (terminator.Length == 0) {
                return -1;
            }
            if (terminator.Length == 1) {
                return Array.FindIndex(buff, 0, dataLen, (b) => b == terminator[0]);
            }

            int pos = -1;
            for (int i = 0; i < dataLen; i++) {
                // Found first byte of pattern
                if (buff[i] == terminator[0]) {
                    // Now step through all the bytes of the pattern
                    int matches = 0;
                    for (int j = 0; j < terminator.Length && ((i + j) < dataLen); j++) {
                        if (buff[i + j] == terminator[j]) {
                            matches++;
                        }
                        else {
                            // mismatch, keep looking after
                            break;
                        }
                    }
                    if (matches == terminator.Length) {
                        pos = i;
                        // Break out of outer loop
                        break;
                    }
                }
            }
            return pos;
        }


        public static byte[] FifoPop(this byte[] buff, byte[] terminator, ref int nextPos) {
            int terminatorPos = buff.FindFirstBytePatternPos(terminator, nextPos);
            //nextPos = dataLen;
            if (terminatorPos == -1) {
                return new byte[0];
            }
            int msgLen = terminatorPos;
            byte[] result = new byte[msgLen];
            Array.Copy(buff, result, msgLen);
            string s = result.ToAsciiString();


            int remaining = (nextPos - (msgLen + terminator.Length));
            // The Array Copy will move the data over much more efficiently than even a for loop
            // https://stackoverflow.com/questions/2381245/c-sharp-quickest-way-to-shift-array
            Array.Copy(buff, msgLen + terminator.Length, buff, 0, remaining);
            nextPos = remaining;

            // Wipe part of the buffer past new reduced length 
            int endReset = nextPos + (msgLen + terminator.Length);
            for (int i = nextPos; i < endReset; i++) {
                buff[i] = 0;
            }
            return result;
        }


        public static bool FifoPush(this byte[] buff, byte[] data, ref int nextPos) {
            if (buff.Length < (nextPos + data.Length)) {
                return false;
            }
            Array.Copy(data, 0, buff, nextPos, data.Length);
            nextPos += data.Length;
            return true;
        }

        #region Read From Buffer

        public static byte ToByte(this byte[] data, int pos) {
            return data[pos];
        }


        public static sbyte ToSByte(this byte[] data, int pos) {
            return (sbyte)data[pos];
        }


        public static UInt16 ToUint16(this byte[] data, int pos) {
            if (BitConverter.IsLittleEndian) {
                return BitConverter.ToUInt16(data, pos);
            }
            return BitConverter.ToUInt16(data, pos).ReverseBytes();
        }


        public static Int16 ToInt16(this byte[] data, int pos) {
            if (BitConverter.IsLittleEndian) {
                return BitConverter.ToInt16(data, pos);
            }
            return BitConverter.ToInt16(data, pos).ReverseBytes();
        }


        public static UInt32 ToUint32(this byte[] data, int pos) {
            if (BitConverter.IsLittleEndian) {
                return BitConverter.ToUInt32(data, pos);
            }
            return BitConverter.ToUInt32(data, pos).ReverseBytes();
        }


        public static Int32 ToInt32(this byte[] data, int pos) {
            if (BitConverter.IsLittleEndian) {
                return BitConverter.ToInt32(data, pos);
            }
            return BitConverter.ToInt32(data, pos).ReverseBytes();
        }


        public static UInt64 ToUint64(this byte[] data, int pos) {
            if (BitConverter.IsLittleEndian) {
                return BitConverter.ToUInt64(data, pos);
            }
            return BitConverter.ToUInt64(data, pos).ReverseBytes();
        }


        public static Int64 ToInt64(this byte[] data, int pos) {
            if (BitConverter.IsLittleEndian) {
                return BitConverter.ToInt64(data, pos);
            }
            return BitConverter.ToInt64(data, pos).ReverseBytes();
        }

        #endregion

        #region Read from buffer and increment position

        public static byte ToByte(this byte[] data, ref int pos) {
            byte result = data.ToByte(pos);
            pos++;
            return result;
        }


        public static sbyte ToSByte(this byte[] data, ref int pos) {
            sbyte result = data.ToSByte(pos);
            pos++;
            return result;
        }



        public static UInt16 ToUint16(this byte[] data, ref int pos) {
            UInt16 tmp = data.ToUint16(pos);
            pos += sizeof(UInt16);
            return tmp;
        }


        public static Int16 ToInt16(this byte[] data, ref int pos) {
            Int16 tmp = data.ToInt16(pos);
            pos += sizeof(Int16);
            return tmp;
        }


        public static UInt32 ToUint32(this byte[] data, ref int pos) {
            UInt32 tmp = data.ToUint32(pos);
            pos += sizeof(UInt32);
            return tmp;
        }


        public static Int32 ToInt32(this byte[] data, ref int pos) {
            Int32 tmp = data.ToInt32(pos);
            pos += sizeof(Int32);
            return tmp;
        }


        public static UInt64 ToUint64(this byte[] data, ref int pos) {
            UInt64 tmp = data.ToUint64(pos);
            pos += sizeof(UInt64);
            return tmp;
        }


        public static Int64 ToInt64(this byte[] data, ref int pos) {
            Int64 tmp = data.ToInt64(pos);
            pos += sizeof(Int64);
            return tmp;
        }

        #endregion

        #region Write to buffer

        public static void WriteToBuffer(this byte value, byte[] buffer, ref int pos) {
            // BitConverter will cast to 16 bit value
            buffer[pos] = value;
            pos++;
        }


        public static void WriteToBuffer(this sbyte value, byte[] buffer, ref int pos) {
            // BitConverter will cast to 16 bit value
            buffer[pos] = (byte)value;
            pos++;
        }


        public static void WriteToBuffer(this UInt16 value, byte[] buffer, ref int pos) {
            byte[] block = BitConverter.GetBytes(value);
            Array.Copy(block, 0, buffer, pos, block.Length);
            pos += block.Length;
        }


        public static void WriteToBuffer(this Int16 value, byte[] buffer, ref int pos) {
            byte[] block = BitConverter.GetBytes(value);
            Array.Copy(block, 0, buffer, pos, block.Length);
            pos += block.Length;
        }


        public static void WriteToBuffer(this UInt32 value, byte[] buffer, ref int pos) {
            byte[] block = BitConverter.GetBytes(value);
            Array.Copy(block, 0, buffer, pos, block.Length);
            pos += block.Length;
        }


        public static void WriteToBuffer(this Int32 value, byte[] buffer, ref int pos) {
            byte[] block = BitConverter.GetBytes(value);
            Array.Copy(block, 0, buffer, pos, block.Length);
            pos += block.Length;
        }


        public static void WriteToBuffer(this UInt64 value, byte[] buffer, ref int pos) {
            byte[] block = BitConverter.GetBytes(value);
            Array.Copy(block, 0, buffer, pos, block.Length);
            pos += block.Length;
        }


        public static void WriteToBuffer(this Int64 value, byte[] buffer, ref int pos) {
            byte[] block = BitConverter.GetBytes(value);
            Array.Copy(block, 0, buffer, pos, block.Length);
            pos += block.Length;
        }

        #endregion

        #region Reverse bytes

        private static UInt16 ReverseBytes(this UInt16 value) {
            return (UInt16)((value & 0xFFU) << 8 | (value & 0xFF00U) >> 8);
        }


        public static Int16 ReverseBytes(this Int16 value) {
            return (Int16)((UInt16)value).ReverseBytes();
        }


        private static UInt32 ReverseBytes(this UInt32 value) {
            return (value & 0x000000FFU) << 24 | (value & 0x0000FF00U) << 8 |
                   (value & 0x00FF0000U) >> 8 | (value & 0xFF000000U) >> 24;
        }


        public static Int32 ReverseBytes(this Int32 value) {
            return (Int32)((UInt32)value).ReverseBytes();
        }


        public static UInt64 ReverseBytes(this UInt64 value) {
            return (value & 0x00000000000000FFUL) << 56 | (value & 0x000000000000FF00UL) << 40 |
                   (value & 0x0000000000FF0000UL) << 24 | (value & 0x00000000FF000000UL) << 8 |
                   (value & 0x000000FF00000000UL) >> 8 | (value & 0x0000FF0000000000UL) >> 24 |
                   (value & 0x00FF000000000000UL) >> 40 | (value & 0xFF00000000000000UL) >> 56;
        }


        public static Int64 ReverseBytes(this Int64 value) {
            return (Int64)((UInt64)value).ReverseBytes();
        }

        #endregion

    }


}
