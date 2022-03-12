using CommunicationStack.Net.DataModels;
using CommunicationStack.Net.Enumerations;
using SerialCommon.Net.DataModels;
using SerialCommon.Net.interfaces;

namespace SerialCommon.Net {

    public class SerialDoNothingImplementation : ISerialInterface {
        public bool Connected { get { return false; } }

        public event EventHandler<List<SerialDeviceInfo>>? DiscoveredDevices;
        public event EventHandler<SerialUsbError>? OnError;
        public event EventHandler<MsgPumpResults>? OnSerialConnectionAttemptCompleted;
        public event EventHandler<byte[]>? MsgReceivedEvent;

        public void ConnectAsync(SerialDeviceInfo dataModel) {
            this.OnSerialConnectionAttemptCompleted?.Invoke(this, new MsgPumpResults() {
                Code = MsgPumpResultCode.ConnectionFailure,
                ErrorString = "NOT IMPLEMENTED"
            });
        }

        public void Disconnect() {
        }

        public void DiscoverSerialDevicesAsync() {
            List<SerialDeviceInfo> infos = new ();
            this.DiscoveredDevices?.Invoke(this, infos);
        }

        public bool SendOutMsg(byte[] msg) {
            return false;
        }


#pragma warning disable IDE0051 // Remove unused private members
        private void ToSatisfyCompiler() {
            this.OnError?.Invoke(this, new SerialUsbError());
            this.MsgReceivedEvent?.Invoke(this, Array.Empty<byte>());
        }
#pragma warning restore IDE0051 // Remove unused private members

    }
}
