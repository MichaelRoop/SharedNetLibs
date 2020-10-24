using System;
using System.Collections.Generic;
using System.Text;

namespace BluetoothLE.Net.DataModels {
    
    public class BLE_PropertyDataModelDisplay {

        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string DataType { get; set; } = string.Empty;

        public BLE_PropertyDataModelDisplay(BLE_PropertyDataModel data) {
            this.Key = data.Key;
            if (data.DataType == PropertyDataType.TypeString) {
                this.Value = string.Format("\"{0}\"", data.Value.ToString());
            }
            else {
                this.Value = data.Value.ToString();
            }
            this.DataType = data.DataType.ToFriendlyString();
        }
    }





}
