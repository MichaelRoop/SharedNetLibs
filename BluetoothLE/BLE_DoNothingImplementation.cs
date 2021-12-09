using BluetoothLE.Net.DataModels;
using BluetoothLE.Net.Enumerations;
using BluetoothLE.Net.interfaces;
using Common.Net.Network;

namespace BluetoothLE.Net {

    public class BLE_DoNothingImplementation : IBLETInterface {

        public event EventHandler<string>? DeviceRemoved;
        public event EventHandler<BluetoothLEDeviceInfo>? DeviceDiscovered;
        public event EventHandler<bool>? DeviceDiscoveryCompleted;
        public event EventHandler<NetPropertiesUpdateDataModel>? DeviceUpdated;
        public event EventHandler<BLEGetInfoStatus>? DeviceInfoAssembled;
        public event EventHandler<byte[]>? MsgReceivedEvent;
        public event EventHandler<BLEGetInfoStatus>? DeviceConnectResult;
        public event EventHandler<BLE_CharacteristicReadResult>? CharacteristicReadValueChanged;
        public event EventHandler<BLE_ConnectStatusChangeInfo>? ConnectionStatusChanged;
        public event EventHandler<BLEOperationStatus>? BLE_Error;

        public void Connect(BluetoothLEDeviceInfo deviceInfo) {
            // nothing at the moment
        }

        public void Disconnect() {
            // Do nothing
        }

        public void DiscoverDevices() {
            this.DeviceDiscoveryCompleted?.Invoke(this, false);
        }

        public void CancelDiscoverDevices() {
            this.DeviceDiscoveryCompleted?.Invoke(this, false);
        }


        public void GetInfo(BluetoothLEDeviceInfo deviceInfo) {
            this.DeviceInfoAssembled?.Invoke(
                this,
                new BLEGetInfoStatus(new BluetoothLEDeviceInfo() { Name = "NOT IMPLEMENTED" }, BLEOperationStatus.NotFound));
        }

        public bool SendOutMsg(byte[] msg) {
            return false;
        }



#pragma warning disable IDE0051 // Remove unused private members
        private void ToEliminateCompilerWarnings(byte[] msg) {
#pragma warning restore IDE0051 // Remove unused private members
            this.MsgReceivedEvent?.Invoke(this, msg);
            this.DeviceRemoved?.Invoke(this, "NOT IMPLEMENTED");
            this.DeviceUpdated?.Invoke(this, new NetPropertiesUpdateDataModel());
            this.DeviceDiscovered?.Invoke(this, new BluetoothLEDeviceInfo());
            this.DeviceUpdated?.Invoke(this, new NetPropertiesUpdateDataModel());
            this.DeviceConnectResult?.Invoke(this, new BLEGetInfoStatus());
            this.CharacteristicReadValueChanged?.Invoke(this, 
                new BLE_CharacteristicReadResult(
                    new BLE_CharacteristicDataModel(), 
                    BLE_CharacteristicCommunicationStatus.Success, 
                    Array.Empty<byte>(), string.Empty));
            this.ConnectionStatusChanged?.Invoke(this, new BLE_ConnectStatusChangeInfo());
            this.BLE_Error?.Invoke(this, BLEOperationStatus.Success);
        }


    }
}
