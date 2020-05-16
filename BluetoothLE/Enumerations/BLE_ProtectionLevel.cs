
namespace BluetoothLE.Net.Enumerations {
    
    /// <summary>Portable GATT Protection levels</summary>
    public enum BLE_ProtectionLevel {

        /// <summary>Default level</summary>
        DefaultPlain = 0,
        
        /// <summary>Authentication required</summary>
        AuthenticationRequired = 1,

        /// <summary>Encryption required</summary>
        EncryptionRequired = 2,

        /// <summary>Encryption and authentication required</summary>
        EncryptionAndAuthenticationRequired = 3

    }
}
