using CommunicationStack.Net.DataModels;
using CommunicationStack.Net.Enumerations;
using Ethernet.Common.Net.interfaces;
using MultiCommData.Net.StorageDataModels;

namespace Ethernet.Common.Net {

    public class EthernetDoNothingImplementation : IEthernetInterface {
        public bool Connected { get { return false; } }

        public event EventHandler<EthernetParams>? ParamsRequestedEvent;
        public event EventHandler<MsgPumpResults>? OnEthernetConnectionAttemptCompleted;
        public event EventHandler<MsgPumpResults>? OnError;
        public event EventHandler<byte[]>? MsgReceivedEvent;

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


#pragma warning disable IDE0051 // Remove unused private members
        private void ToSatisfyCompiler() {
#pragma warning restore IDE0051 // Remove unused private members
            this.ParamsRequestedEvent?.Invoke(this, new EthernetParams());
            this.OnError?.Invoke(this, new MsgPumpResults());
            this.MsgReceivedEvent?.Invoke(this, Array.Empty<byte>());
        }

    }
}
