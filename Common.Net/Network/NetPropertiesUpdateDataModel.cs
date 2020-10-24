using System.Collections.Generic;

namespace Common.Net.Network {

    public class NetPropertiesUpdateDataModel {
        public string Id { get; set; } = "";
        public Dictionary<string, NetPropertyDataModel> ServiceProperties { get; set; } = new Dictionary<string, NetPropertyDataModel>();
        public string Kind { get; set; } = "";

    }
}
