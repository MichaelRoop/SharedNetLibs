using System;
using System.Collections.Generic;
using System.Text;

namespace BluetoothLE.Net.Enumerations {
    
    /// <summary>From BLE specs
    /// 
    /// </summary>
    public enum CharacteristicProperties {

        /// <summary>No properties that apply</summary>
        None = 0,

        /// <summary>Supports broadcasting</summary>
        Broadcast = 1,

        /// <summary>Readable</summary>
        Read = 2,

        /// <summary>Supports write without response</summary>
        WriteWithoutResponse = 4,

        /// <summary>Writable</summary>
        Write = 8,

        /// <summary>Notifiable</summary>
        Notify = 16,

        /// <summary>Indicatable</summary>
        Indicate = 32,

        /// <summary>Supports signed writes</summary>
        AuthenticatedSignedWrites = 64,

        /// <summary>Has an Extended Properties Descriptor</summary>
        ExtendedProperties = 128,

        /// <summary>Supports reliable writes</summary>
        ReliableWrites = 256,

        /// <summary>Has Writable auxiliaries</summary>
        WritableAuxiliaries = 512

    }
}
