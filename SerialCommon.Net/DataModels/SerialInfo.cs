using Common.Net.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerialCommon.Net.DataModels {

    public class SerialInfo {
        public string Name { get; set; } = string.Empty;
        public bool IsDefault { get; set; } = false;
        public bool IsEnabled { get; set; } = false;

        // Not sure if the same
        public Dictionary<string, NetPropertyDataModel> Properties { get; set; } = new Dictionary<string, NetPropertyDataModel>();
        // Device information kind

}

}
