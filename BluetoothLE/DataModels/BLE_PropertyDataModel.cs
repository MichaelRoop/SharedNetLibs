namespace BluetoothLE.Net.DataModels {

    public enum PropertyType {
        UnHandled,
        ItemNameDisplay,
        CanPair,
        IsPaired,
        IsConnected,
        IsConnectable,
        ContainerId,
        IconPath,
        GlyphIconPath,

    }


    public enum PropertyDataType {
        TypeUnknown,
        TypeString,
        TypeBool,
        TypeGuid,
    }


    /// <summary>Cross platform holder of Services Properties info</summary>
    public class BLE_PropertyDataModel {
        public PropertyType Target { get; set; }
        public string Key { get; set; } = "";
        public PropertyDataType DataType { get; set; } = PropertyDataType.TypeUnknown;
        public object Value { get; set; } = new object();

    }

    public static class PropertyDataTypeExtensions {

        public static string ToFriendlyString(this PropertyDataType dataType) {
            switch (dataType) {
                case PropertyDataType.TypeUnknown: return "Unknown";
                case PropertyDataType.TypeString: return "String";
                case PropertyDataType.TypeBool: return "Bool";
                case PropertyDataType.TypeGuid: return "Guid";
                default: return dataType.ToString();
            }
        }

    }

}
