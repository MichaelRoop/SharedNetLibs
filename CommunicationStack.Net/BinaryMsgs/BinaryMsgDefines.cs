using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationStack.Net.BinaryMsgs {
    public static class BinaryMsgDefines {

        private static byte[] startDelimiters = new byte[] { BinaryMsgDefines.SOH, BinaryMsgDefines.STX };
        private static byte[] endDelimiters = new byte[] { BinaryMsgDefines.ETX, BinaryMsgDefines.EOT };

        public static byte SOH { get { return 0x01; } }
        public static byte STX { get { return 0x02; } }
        public static byte ETX { get { return 0x03; } }
        public static byte EOT { get { return 0x04; } }
        public static byte[] StartDelimiters { get { return BinaryMsgDefines.startDelimiters; } }
        public static byte[] EndDelimiters { get { return BinaryMsgDefines.endDelimiters; } }

        public static int DataTypePos { get { return 4; } }


    }
}
