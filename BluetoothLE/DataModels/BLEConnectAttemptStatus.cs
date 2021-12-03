using BluetoothLE.Net.Enumerations;

namespace BluetoothLE.Net.DataModels {

    public class BLEConnectAttemptStatus {

        public BluetoothLEDeviceInfo? DeviceInfo { get; set; } = null;
        public BLEOperationStatus Status { get; set; } = BLEOperationStatus.Success;

        public BLEConnectAttemptStatus(BluetoothLEDeviceInfo info, BLEOperationStatus status) {
            this.DeviceInfo = info;
            this.Status = status;
        }

    }
}
