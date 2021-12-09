namespace BluetoothCommon.Net {

    /// <summary>To get information about the BT Classic radio</summary>
    public class BTRadioInfo {
        public bool IsInitialized { get; set; } = false;
        public string Manufacturer { get; set; } = "N/A";
        public string LinkManagerProtocol { get; set; } = "N/A";
        public List<string> Features { get; set; } = new List<string>();

    }
}

