using CommunicationStack.Net.DataModels;
using CommunicationStack.Net.Enumerations;
using Ethernet.Common.Net.DataModels;
using Ethernet.Common.Net.interfaces;
using System;

namespace Ethernet.Common.Net {

    public class EthernetDoNothingImplementation : IEthernetInterface {
        public bool Connected { get { return false; } }

        public event EventHandler<EthernetParams> ParamsRequestedEvent;
        public event EventHandler<MsgPumpResults> OnEthernetConnectionAttemptCompleted;
        public event EventHandler<MsgPumpResults> OnError;
        public event EventHandler<byte[]> MsgReceivedEvent;

        public void ConnectAsync(EthernetParams dataModel) {
            this.OnEthernetConnectionAttemptCompleted?.Invoke(this, new MsgPumpResults() {
                Code = MsgPumpResultCode.NotConnected,
                ErrorString = "NOT IMPLEMENTED",
                //SocketErr = SocketErrCode.Unknown,
            });
        }

        public void Disconnect() {
        }

        public bool SendOutMsg(byte[] msg) {
            return false;
        }


        private void ToSatisfyCompiler() {
            this.ParamsRequestedEvent?.Invoke(this, new EthernetParams());
            this.OnError?.Invoke(this, new MsgPumpResults());
            this.MsgReceivedEvent?.Invoke(this, null);
        }

    }
}
