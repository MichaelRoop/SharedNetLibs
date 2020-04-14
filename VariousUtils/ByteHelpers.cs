using System;

namespace VariousUtils {

    public static class ByteHelpers {


        public static char ToChar(this byte value) {
            return Convert.ToChar(value);
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


        public static byte[] FifoPop(this byte[] buff, byte[] terminator, int dataLen, ref int nextPos) {
            int terminatorPos = buff.FindFirstBytePatternPos(terminator, dataLen);
            //nextPos = dataLen;
            if (terminatorPos == -1) {
                return new byte[0];
            }
            int msgLen = terminatorPos;
            byte[] result = new byte[msgLen];
            Array.Copy(buff, result, msgLen);
            string s = result.ToAsciiString();


            int remaining = (dataLen - (msgLen + terminator.Length));
            Array.Copy(buff, msgLen + terminator.Length, buff, 0, remaining);
            //nextPos = remaining;
            //nextPos = buff.FindFirstBytePatternPos(terminator, remaining);
            nextPos = remaining;

            // Wipe out the end of the buffer
            //Buffer.et.SetByte(buff, nextPos, 0);
            int endReset = nextPos + (msgLen + terminator.Length);
            for (int i = nextPos; i < endReset; i++) {
                buff[i] = 0;
            }


            //nextPos = dataLen - (result.Length + terminator.Length);
            // The Array Copy will move the data over much more efficiently than even a for loop
            // https://stackoverflow.com/questions/2381245/c-sharp-quickest-way-to-shift-array
            //Array.Copy(buff, nextPos, buff, 0, dataLen);
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


    }


}
