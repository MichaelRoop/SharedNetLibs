namespace BluetoothLE.Net.Enumerations {

    /// <summary>Portable implementation of access status</summary>
    public enum BLE_DeviceAccessStatus {

        /// <summary>No specific info</summary>
        Unspecified = 0,

        /// <summary>Access allowed</summary>
        Allowed = 1,

        /// <summary>Access denied by user</summary>
        DeniedByUser = 2,

        /// <summary>Access denied by system</summary>
        DeniedBySystem = 3

    }
}
