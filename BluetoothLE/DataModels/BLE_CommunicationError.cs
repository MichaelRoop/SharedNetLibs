﻿using BluetoothLE.Net.Enumerations;

namespace BluetoothLE.Net.DataModels {

    public class BLE_CommunicationError {

        public BLE_CharacteristicDataModel DataModel { get; set; }

        public BLE_CharacteristicCommunicationStatus Status { get; set; }

        public BLE_CommunicationError(
            BLE_CharacteristicDataModel dataModel,
            BLE_CharacteristicCommunicationStatus status) { 
            this.DataModel = dataModel;
            this.Status = status;
        }


    }
}
