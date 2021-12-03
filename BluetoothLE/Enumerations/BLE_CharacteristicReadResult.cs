using BluetoothLE.Net.DataModels;

namespace BluetoothLE.Net.Enumerations {

    public class BLE_CharacteristicReadResult {

        public BLE_CharacteristicDataModel DataModel { get; set; }
        
        public BLE_CharacteristicCommunicationStatus Status { get; set; }
        
        public byte[] Data { get; set; }

        public string DataAsString { get; set; }

        public BLE_CharacteristicReadResult(
            BLE_CharacteristicDataModel dataModel,
            BLE_CharacteristicCommunicationStatus status,
            byte[] data,
            string dataAsString) {

            DataModel = dataModel;
            Status = status;
            Data = data;
            DataAsString = dataAsString;
        }



    }

}
