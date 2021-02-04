
namespace BluetoothLE.Net.Tools {

    /// <summary>Returns results of validation of input data to display to user</summary>
    public class RangeValidationResult {

        /// <summary>Result of validation test</summary>
        public bool IsValid { get; set; }

        public byte[] Payload { get; set; } = new byte[0];

        /// <summary>The original data entered by user</summary>
        public string UserEntryString { get; set; }

        public RangeMinMax Range { get; set; }



    }

}
