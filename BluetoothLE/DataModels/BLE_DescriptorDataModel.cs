using BluetoothLE.Net.Enumerations;
using BluetoothLE.Net.interfaces;
using BluetoothLE.Net.Parsers.Descriptor;
using System;

namespace BluetoothLE.Net.DataModels {

    public class BLE_DescriptorDataModel : IUniquelyIdentifiable {

        public ushort AttributeHandle { get; set; } = 0;

        public Guid Uuid { get; set; } = Guid.Empty;
        
        public BLE_ProtectionLevel ProtectionLevel { get; set; } = BLE_ProtectionLevel.DefaultPlain;

        public string DisplayName { get; set; } = "";

        public IDescParser Parser { get; set; } = new DescParser_Default();

        public BLE_DescriptorDataModel() {
        }

    }
}
