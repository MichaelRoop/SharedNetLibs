using Common.Net.Enumerations;

namespace Common.Net.Network {

    /// <summary>Network property information rendered as displayable strings</summary>
    public class NetPropertyDataModelDisplay {
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string DataType { get; set; } = string.Empty;

        public NetPropertyDataModelDisplay(NetPropertyDataModel data) {
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
