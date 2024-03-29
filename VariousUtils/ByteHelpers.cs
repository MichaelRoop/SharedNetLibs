﻿namespace VariousUtils.Net {

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
                return Array.Empty<byte>();
            }
            int msgLen = terminatorPos;
            byte[] result = new byte[msgLen];
            Array.Copy(buff, result, msgLen);
            //string s = result.ToAsciiString();


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


        public static float ToFloat32(this byte[] data, int pos) {
            if (BitConverter.IsLittleEndian) {
                return BitConverter.ToSingle(data, pos);
            }
            return BitConverter.ToSingle(data, pos).ReverseBytes();
        }


        public static double ToDouble64(this byte[] data, int pos) {
            if (BitConverter.IsLittleEndian) {
                return BitConverter.ToDouble(data, pos);
            }
            return BitConverter.ToDouble(data, pos).ReverseBytes();
        }



        public static byte[] ToByteArray(this byte[] data, int length, int pos) {
            byte[] block = new byte[length];
            Array.Copy(data, pos, block, 0, block.Length);
            return block;
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

        public static float ToFloat32(this byte[] data, ref int pos) {
            float tmp = data.ToFloat32(pos);
            pos += sizeof(float);
            return tmp;
        }

        public static double ToDouble64(this byte[] data, ref int pos) {
            double tmp = data.ToDouble64(pos);
            pos += sizeof(double);
            return tmp;
        }


        public static byte[] ToByteArray(this byte[] data, int length, ref int pos) {
            byte[] block = data.ToByteArray(length, pos);
            pos += block.Length;
            return block;
        }

        #endregion

        #region Write to buffer

        //----------------------------------------------------------------------------------------------------

        public static void WriteToBuffer(this byte value, byte[] buffer, int pos) {
            // BitConverter will cast to 16 bit value
            buffer[pos] = value;
        }


        public static void WriteToBuffer(this sbyte value, byte[] buffer, int pos) {
            // BitConverter will cast to 16 bit value
            buffer[pos] = (byte)value;
        }


        public static void WriteToBuffer(this UInt16 value, byte[] buffer, int pos) {
            byte[] block = BitConverter.GetBytes(value);
            Array.Copy(block, 0, buffer, pos, block.Length);
        }


        public static void WriteToBuffer(this Int16 value, byte[] buffer, int pos) {
            byte[] block = BitConverter.GetBytes(value);
            Array.Copy(block, 0, buffer, pos, block.Length);
        }


        public static void WriteToBuffer(this UInt32 value, byte[] buffer, int pos) {
            byte[] block = BitConverter.GetBytes(value);
            Array.Copy(block, 0, buffer, pos, block.Length);
        }


        public static void WriteToBuffer(this Int32 value, byte[] buffer, int pos) {
            byte[] block = BitConverter.GetBytes(value);
            Array.Copy(block, 0, buffer, pos, block.Length);
        }


        public static void WriteToBuffer(this UInt64 value, byte[] buffer, int pos) {
            byte[] block = BitConverter.GetBytes(value);
            Array.Copy(block, 0, buffer, pos, block.Length);
        }


        public static void WriteToBuffer(this Int64 value, byte[] buffer, int pos) {
            byte[] block = BitConverter.GetBytes(value);
            Array.Copy(block, 0, buffer, pos, block.Length);
        }


        public static void WriteToBuffer(this float value, byte[] buffer, int pos) {
            byte[] block = BitConverter.GetBytes(value);
            Array.Copy(block, 0, buffer, pos, block.Length);
        }


        public static void WriteToBuffer(this double value, byte[] buffer, int pos) {
            byte[] block = BitConverter.GetBytes(value);
            Array.Copy(block, 0, buffer, pos, block.Length);
        }

        public static void WriteToBuffer(this byte[] value, byte[] buffer, int pos) {
            Array.Copy(value, 0, buffer, pos, value.Length);
        }



        //----------------------------------------------------------------------------------------------------



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
            //if (!BitConverter.IsLittleEndian) {
            //    value.ReverseBytes();
            //}

            byte[] block = BitConverter.GetBytes(value);
            Array.Copy(block, 0, buffer, pos, block.Length);
            pos += block.Length;
        }


        public static void WriteToBuffer(this float value, byte[] buffer, ref int pos) {
            byte[] block = BitConverter.GetBytes(value);
            Array.Copy(block, 0, buffer, pos, block.Length);
            pos += block.Length;
        }


        public static void WriteToBuffer(this double value, byte[] buffer, ref int pos) {
            byte[] block = BitConverter.GetBytes(value);
            Array.Copy(block, 0, buffer, pos, block.Length);
            pos += block.Length;
        }


        public static void WriteToBuffer(this byte[] value, byte[] buffer, ref int pos) {
            Array.Copy(value, 0, buffer, pos, value.Length);
            pos += value.Length;
        }

        #endregion

        #region Create byte array

        public static byte[] ToByteArray(this byte value) {
            byte[] buff = new byte[sizeof(byte)];
            value.WriteToBuffer(buff, 0);
            return buff;
        }

        public static byte[] ToByteArray(this sbyte value) {
            byte[] buff = new byte[sizeof(sbyte)];
            value.WriteToBuffer(buff, 0);
            return buff;
        }

        public static byte[] ToByteArray(this UInt16 value) {
            byte[] buff = new byte[sizeof(UInt16)];
            value.WriteToBuffer(buff, 0);
            return buff;
        }

        public static byte[] ToByteArray(this Int16 value) {
            byte[] buff = new byte[sizeof(Int16)];
            value.WriteToBuffer(buff, 0);
            return buff;
        }

        public static byte[] ToByteArray(this UInt32 value) {
            byte[] buff = new byte[sizeof(UInt32)];
            value.WriteToBuffer(buff, 0);
            return buff;
        }

        public static byte[] ToByteArray(this Int32 value) {
            byte[] buff = new byte[sizeof(Int32)];
            value.WriteToBuffer(buff, 0);
            return buff;
        }

        public static byte[] ToByteArray(this UInt64 value) {
            byte[] buff = new byte[sizeof(UInt64)];
            value.WriteToBuffer(buff, 0);
            return buff;
        }

        public static byte[] ToByteArray(this Int64 value) {
            byte[] buff = new byte[sizeof(Int64)];
            value.WriteToBuffer(buff, 0);
            return buff;
        }

        public static byte[] ToByteArray(this Single value) {
            byte[] buff = new byte[sizeof(Single)];
            value.WriteToBuffer(buff, 0);
            return buff;
        }

        #endregion

        #region Reverse bytes

        public static UInt16 ReverseBytes(this UInt16 value) {
            return (UInt16)((value & 0xFFU) << 8 | (value & 0xFF00U) >> 8);
        }


        public static Int16 ReverseBytes(this Int16 value) {
            return (Int16)((UInt16)value).ReverseBytes();
        }


        public static UInt32 ReverseBytes(this UInt32 value) {
            return (value & 0x000000FFU) << 24 | (value & 0x0000FF00U) << 8 |
                   (value & 0x00FF0000U) >> 8 | (value & 0xFF000000U) >> 24;
        }


        public static Int32 ReverseBytes(this Int32 value) {
            return (Int32)((UInt32)value).ReverseBytes();
        }


        public static float ReverseBytes(this float value) {
            return (float)((UInt32)value).ReverseBytes();
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


        public static double ReverseBytes(this double value) {
            // TODO - test this
            return (double)ReverseBytes((UInt64)value);
        }



        #endregion

        #region Calculate size

        public static ushort AddSize(this byte value, ref ushort size) {
            size += value.GetSize();
            return size;
        }

        public static ushort AddSize(this sbyte value, ref ushort size) {
            size += value.GetSize();
            return size;
        }

        public static ushort AddSize(this Int16 value, ref ushort size) {
            size += value.GetSize();
            return size;
        }

        public static ushort AddSize(this UInt16 value, ref ushort size) {
            size += value.GetSize();
            return size;
        }

        public static ushort AddSize(this Int32 value, ref ushort size) {
            size += value.GetSize();
            return size;
        }

        public static ushort AddSize(this UInt32 value, ref ushort size) {
            size += value.GetSize();
            return size;
        }

        public static ushort AddSize(this Single value, ref ushort size) {
            size += value.GetSize();
            return size;
        }

        public static ushort AddSize(this byte[] value, ref ushort size) {
            size += value.GetSize();
            return size;
        }

        public static ushort GetSize(this byte value) {
            return 1;
        }

        public static ushort GetSize(this sbyte value) {
            return 1;
        }

        public static ushort GetSize(this Int16 value) {
            return sizeof(short);
        }

        public static ushort GetSize(this UInt16 value) {
            return sizeof(ushort);
        }

        public static ushort GetSize(this Int32 value) {
            return sizeof(Int32);
        }

        public static ushort GetSize(this UInt32 value) {
            return sizeof(UInt32);
        }

        public static ushort GetSize(this Single value) {
            return sizeof(Single);
        }

        public static ushort GetSize(this byte[] value) {
            return (byte)value.Length;
        }





        #endregion

    }


}
