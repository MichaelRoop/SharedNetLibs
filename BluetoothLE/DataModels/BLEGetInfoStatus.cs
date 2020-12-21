using BluetoothLE.Net.Enumerations;

namespace BluetoothLE.Net.DataModels {

    public class BLEGetInfoStatus {
        public BluetoothLEDeviceInfo DeviceInfo { get; set; } = null;
        public BLEOperationStatus Status { get; set; } = BLEOperationStatus.Failed;
        public string Message { get; set; } = string.Empty;

        public BLEGetInfoStatus() { }             

        public BLEGetInfoStatus(BluetoothLEDeviceInfo info, BLEOperationStatus status) {
            this.DeviceInfo = info;
            this.Status = status;
        }

    }
}
