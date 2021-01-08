
namespace BluetoothLE.Net.Enumerations {

    /// <summary>Status of BLE characteristic write function</summary>
    /// <remarks>Taken from the UWP library</remarks>
    public enum BLE_CharacteristicCommunicationStatus {

        /// <summary>Success</summary>
        Success = 0,

        /// <summary>Cannot communicate with device</summary>
        Unreachable = 1,

        /// <summary>GATT communication protocol error</summary>
        ProtocolError = 2,

        /// <summary>Access denied</summary>
        AccessDenied = 3,

        /// <summary>Added by me to cover all other errors. Not in UWP</summary>
        UnknownError = 255,

    }
}
