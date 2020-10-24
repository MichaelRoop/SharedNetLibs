using System.Collections.Generic;

namespace BluetoothCommon.Net.DataModels {

    public class BluetoothPropertiesUpdateDataModel {

        public string Id { get; set; } = "";
        public Dictionary<string, BluetoothPropertyDataModel> ServiceProperties { get; set; } = new Dictionary<string, BluetoothPropertyDataModel>();
        public string Kind { get; set; } = "";

    }
}
