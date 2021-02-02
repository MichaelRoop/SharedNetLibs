using BluetoothLE.Net.Enumerations;

namespace BluetoothLE.Net.DataModels {

    public class BLE_ConnectStatusChangeInfo {

        public BLE_ConnectStatus Status { get; set; } = BLE_ConnectStatus.Disconnected;
        public string Message { get; set; } = string.Empty;

    }

}
