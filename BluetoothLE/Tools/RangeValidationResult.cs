
using BluetoothLE.Net.Enumerations;

namespace BluetoothLE.Net.Tools {

    /// <summary>Returns results of validation of input data to display to user</summary>
    public class RangeValidationResult {

        /// <summary>Result of validation test</summary>
        public BLE_DataValidationStatus Status { get; set; } = BLE_DataValidationStatus.NotHandled;

        public byte[] Payload { get; set; } = new byte[0];

        /// <summary>The original data entered by user</summary>
        public string UserEntryString { get; set; } = "";


        /// <summary>Provide holder for translated message at higher level</summary>
        public string Message { get; set; } = "";

        public DataTypeDisplay Range { get; set; } = new DataTypeDisplay();


        public RangeValidationResult() { }

        public RangeValidationResult(string value) {
            this.UserEntryString = value;
        }

        public RangeValidationResult(string value, BLE_DataValidationStatus status) : this(value) {
            this.Status = status;
        }



    }

}
