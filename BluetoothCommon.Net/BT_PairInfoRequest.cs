using System;
using System.Collections.Generic;
using System.Text;

namespace BluetoothCommon.Net {
    
    public class BT_PairInfoRequest {

        public string DeviceName { get; set; } = "NA";

        public bool PinRequested { get; set; } = false;

        public string Pin { get; set; } = "";

        public bool Response { get; set; } = false;

    }
}
