using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationStack.Net.interfaces {

    /// <summary>Minimal interface for comm channels to implement to be used with stack</summary>
    public interface ICommStackChannel {

        /// <summary>Fire when the msg is assembled</summary>
        event EventHandler<byte[]> MsgReceivedEvent;

        
        bool SendOutMsg(byte[] msg);

    }
}
