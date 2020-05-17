using BluetoothLE.Net.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BluetoothLE.Net.DataModels {

    /// <summary>Portable implementation of some BLE session info</summary>
    public class BLE_GattSession {

        /// <summary>Should the connection be maintained</summary>
        public bool ShouldConnectionBeMaintained { get; set; } = false;

        /// <summary>Is it possible to maintain the connection</summary>
        public bool CanConnectionBeMaintained { get; set; } = false;

        /// <summary>Max number of bytes per send or read operation</summary>
        public ushort MaxPDUSize { get; set; } = 0;

        public BLE_GattSessionStatus SessionStatus { get; set; } = BLE_GattSessionStatus.Closed;

        public bool IsClassic { get; set; } = false;

        public bool IsLowEnergy { get; set; } = false;

        public string DeviceId { get; set; } = "";



    }
}
