namespace BluetoothCommon.Net {

    /// <summary>Information to pass up and down to execute pairing</summary>
    public class BT_PairInfoRequest {

        /// <summary>User friendly name</summary>
        public string DeviceName { get; set; } = "NA";

        /// <summary>BT sets true if a PIN is required</summary>
        public bool PinRequested { get; set; } = false;

        /// <summary>The PIN entered by the user</summary>
        public string Pin { get; set; } = "";

        /// <summary>User sets true if pairing is requested</summary>
        public bool Response { get; set; } = false;

    }
}
