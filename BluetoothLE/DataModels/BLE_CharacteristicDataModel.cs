using System;
using System.Collections.Generic;
using System.Text;

namespace BluetoothLE.Net.DataModels {
    
    /// <summary>Cross platform holder of BLE Characteristic information</summary>
    public class BLE_CharacteristicDataModel {

        /// <summary>Unique identifier given by device</summary>
        public ushort AttributeHandle { get; set; }

        /// <summary>Unique identifier</summary>
        public Guid Uuid { get; set; }


        public string CharName { get; set; } = "xxxx";

        /// <summary>User friendly description or empty</summary>
        public string UserDescription { get; set; }

        public Dictionary<string, BLE_DescriptorDataModel> Descriptors { get; set; } = new Dictionary<string, BLE_DescriptorDataModel>();


        /// <summary>The service that holds this characteristic</summary>
        public BLE_ServiceDataModel Service { get; set; }

        public BLE_CharacteristicDataModel() {
            //this.Descriptors = new Dictionary<string, BLE_DescriptorDataModel>();
            //this.Descriptors.Add("44", new BLE_DescriptorDataModel() {
            //    DisplayName = "blipo descriptor in characteristic",
            //});
        }





    }
}
