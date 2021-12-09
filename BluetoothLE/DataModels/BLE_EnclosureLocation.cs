using BluetoothLE.Net.Enumerations;

namespace BluetoothLE.Net.DataModels {

    /// <summary>Portable implementation of BLE enclosure location info</summary>
    public class BLE_EnclosureLocation {
        public bool InDock { get; set; } = false;
        public bool InLid { get; set; } = false;

        public BLE_DevicePanelLocation Location { get; set; } = BLE_DevicePanelLocation.Unknown;

        public uint ClockWiseRotationInDegrees { get; set; } = 0;


    }
}
