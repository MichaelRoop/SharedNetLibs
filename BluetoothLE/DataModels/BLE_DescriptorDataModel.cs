using System;
using System.Collections.Generic;
using System.Text;

namespace BluetoothLE.Net.DataModels {

    public class BLE_DescriptorDataModel {

        public ushort AttributeHandle { get; set; } = 0;

        public Guid Uuid { get; set; } = Guid.Empty;

        public string DisplayName { get; set; } = "";

        public BLE_DescriptorDataModel() {
       
        }

    }
}
