using CommunicationStack.Net.interfaces;
using LogUtils.Net;

namespace CommunicationStack.Net.Stacks {

    public class DummyOutCommChannel : ICommStackChannel {

        /// <summary>Fire when the msg is assembled</summary>
        public event EventHandler<byte[]>? MsgReceivedEvent;


        public bool SendOutMsg(byte[] msg) {
            Log.Error(9999, "Using Dummy outgoing comm channel");
            return false;
        }


#pragma warning disable IDE0051 // Remove unused private members
        private void ToSatisfyCompiler() {
#pragma warning restore IDE0051 // Remove unused private members
            this.MsgReceivedEvent?.Invoke(this, Array.Empty<byte>());
        }

    }
}
