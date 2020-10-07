using BluetoothCommon.Net.Enumerations;

namespace BluetoothCommon.Net {

    /// <summary>Information about the current pair operation</summary>
    public class BTPairOperationStatus {

        /// <summary>The device name</summary>
        public string Name { get; set; } = "";

        /// <summary>Indicates if the operation was successful</summary>
        public bool IsSuccessful { get; set; } = false;

        /// <summary>Specific result if this was a pair operation</summary>
        public BT_PairingStatus PairStatus { get; set; } = BT_PairingStatus.Failed;

    }
}
