using Common.Net.Enumerations;
using Common.Net.Network.Enumerations;

namespace Common.Net.Network {

    public class NetPropertyDataModel {

        public NetPropertyType Target { get; set; } = NetPropertyType.UnHandled;
        public string Key { get; set; } = string.Empty;
        public PropertyDataType DataType { get; set; } = PropertyDataType.TypeUnknown;
        public object Value { get; set; } = new object();

    }
}
