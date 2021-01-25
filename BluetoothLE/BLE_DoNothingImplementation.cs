using BluetoothLE.Net.DataModels;
using BluetoothLE.Net.Enumerations;
using BluetoothLE.Net.interfaces;
using Common.Net.Network;
using System;

namespace BluetoothLE.Net {

    public class BLE_DoNothingImplementation : IBLETInterface {

        public event EventHandler<string> DeviceRemoved;
        public event EventHandler<BluetoothLEDeviceInfo> DeviceDiscovered;
        public event EventHandler<bool> DeviceDiscoveryCompleted;
        public event EventHandler<NetPropertiesUpdateDataModel> DeviceUpdated;
        public event EventHandler<BLEGetInfoStatus> DeviceInfoAssembled;
        public event EventHandler<byte[]> MsgReceivedEvent;
        public event EventHandler<BLEGetInfoStatus> DeviceConnectResult;
        public event EventHandler<BLE_CharacteristicReadResult> CharacteristicReadValueChanged;

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



        private void ToEliminateCompilerWarnings(byte[] msg) {
            this.MsgReceivedEvent?.Invoke(this, msg);
            this.DeviceRemoved?.Invoke(this, "NOT IMPLEMENTED");
            this.DeviceUpdated?.Invoke(this, new NetPropertiesUpdateDataModel());
            this.DeviceDiscovered?.Invoke(this, new BluetoothLEDeviceInfo());
            this.DeviceUpdated?.Invoke(this, new NetPropertiesUpdateDataModel());
            this.DeviceConnectResult?.Invoke(this, null);
            this.CharacteristicReadValueChanged.Invoke(this, null);
        }


    }
}
