using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationStack.Net.BinaryMsgs {

    /// <summary>Return the object as minimal display info</summary>
    public class BinaryMsgMinData {
        public byte MsgId { get; set; } = 0;
        public double MsgValue { get; set; } = 0;

    }

}
