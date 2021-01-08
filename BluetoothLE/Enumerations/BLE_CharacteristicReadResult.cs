using BluetoothLE.Net.DataModels;

namespace BluetoothLE.Net.Enumerations {

    public class BLE_CharacteristicReadResult {

        public BLE_CharacteristicDataModel DataModel { get; set; }
        
        public BLE_CharacteristicCommunicationStatus Status { get; set; }
        
        public byte[] Data { get; set; }

    }

}
