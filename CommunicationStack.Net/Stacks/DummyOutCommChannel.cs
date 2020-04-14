using CommunicationStack.Net.interfaces;
using LogUtils.Net;
using System;

namespace CommunicationStack.Net.Stacks {

    public class DummyOutCommChannel : ICommStackChannel {

        /// <summary>Fire when the msg is assembled</summary>
        public event EventHandler<byte[]> MsgReceivedEvent;


        public bool SendOutMsg(byte[] msg) {
            Log.Error(9999, "Using Dummy outgoing comm channel");
            return false;
        }
    }
}
