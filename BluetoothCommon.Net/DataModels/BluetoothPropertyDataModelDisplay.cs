
namespace BluetoothCommon.Net.DataModels {

    public class BluetoothPropertyDataModelDisplay {

        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string DataType { get; set; } = string.Empty;

        public BluetoothPropertyDataModelDisplay(BluetoothPropertyDataModel data) {
            this.Key = data.Key;
            if (data.DataType == PropertyDataType.TypeString) {
                this.Value = string.Format("\"{0}\"", data.Value.ToString());
            }
            else {
                this.Value = data.Value.ToString();
            }
            this.DataType = data.DataType.ToFriendlyString();
        }
    }

}
