using BluetoothLE.Net.Enumerations;

namespace BluetoothLE.Net.Tools {


    /// <summary>Information build range user messages</summary>
    public class RangeMinMax {

        /// <summary>To use higher up for any language conversion</summary>
        public BLE_DataType DataTypeEnum { get; set; } = BLE_DataType.Reserved;

        /// <summary>Type evaluated</summary>
        public string DataType { get; set; } = string.Empty;

        /// <summary>Maximum allowable value for type</summary>
        public string Min { get; set; } = "0";

        /// <summary>Minimum allowable value for type</summary>
        public string Max { get; set; } = "0";


        public RangeMinMax() { }


        public RangeMinMax(BLE_DataType dataType, string min, string max) {
            this.DataTypeEnum = dataType;
            this.DataType = dataType.ToStr();
            this.Min = min;
            this.Max = max;
        }

    }
}
