using BluetoothCommon.Net.Enumerations;

namespace BluetoothCommon.Net {

    /// <summary>Information about the unpair operation</summary>
    public class BTUnPairOperationStatus {

        /// <summary>The device name</summary>
        public string Name { get; set; } = "";

        /// <summary>Indicates if the operation was successful</summary>
        public bool IsSuccessful { get; set; } = false;

        /// <summary>Specific result of the unpair operation</summary>
        public BT_UnpairingStatus UnpairStatus { get; set; } = BT_UnpairingStatus.Failed;

    }

}
