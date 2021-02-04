using System;
using System.Collections.Generic;
using System.Text;

namespace BluetoothLE.Net.Tools {

    /// <summary>Has the results of the conversion from UI string to bytes to send</summary>
    public class DataConversionResult {

        /// <summary>Payload to send to BLE</summary>
        public byte[] Data { get; set; }

    }

}
