using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationStack.Net.BinaryMsgs {

    public static class BinaryMsgDefines {

        #region Data

        private static byte[] startDelimiters = new byte[] { BinaryMsgDefines.SOH, BinaryMsgDefines.STX };
        private static byte[] endDelimiters = new byte[] { BinaryMsgDefines.ETX, BinaryMsgDefines.EOT };

        #endregion

        public static int SOHPos { get { return 0; } }
        public static int STXPos { get { return 1; } }
        public static int SizePos { get { return 2; } }
        public static int DataTypePos { get { return 4; } }
        public static int IdPos { get { return 5; } }
        public static int DataPos { get { return 6; } }


        public static byte SOH { get { return 0x01; } }
        public static byte STX { get { return 0x02; } }
        public static byte ETX { get { return 0x03; } }
        public static byte EOT { get { return 0x04; } }

        public static byte[] StartDelimiters { get { return BinaryMsgDefines.startDelimiters; } }
        public static byte[] EndDelimiters { get { return BinaryMsgDefines.endDelimiters; } }

        #region sizes

        public static int SizeHeader { get { return IdPos + 1; } }
        public static int SizeFooter { get { return 2; } }

        public static int SizeMsgBool { get { return SizeHeader + SizeFooter + sizeof(byte); } }
        public static int SizeMsgUInt8 { get { return SizeHeader + SizeFooter + sizeof(byte); } }
        public static int SizeMsgInt8 { get { return SizeHeader + SizeFooter + sizeof(sbyte); } }
        public static int SizeMsgUInt16 { get { return SizeHeader + SizeFooter + sizeof(UInt16); } }
        public static int SizeMsgInt16 { get { return SizeHeader + SizeFooter + sizeof(Int16); } }
        public static int SizeMsgUInt32 { get { return SizeHeader + SizeFooter + sizeof(UInt32); } }
        public static int SizeMsgInt32 { get { return SizeHeader + SizeFooter + sizeof(Int32); } }
        public static int SizeMsgFloat { get { return SizeHeader + SizeFooter + sizeof(Single); } }

        #endregion

    }
}
