using BluetoothLE.Net.Enumerations;
using System.Text;

namespace BluetoothLE.Net.Parsers.Characteristics {

    // TODO - this is no longer in the BLE Spec. Not used in App
    public class CharParser_String : CharParser_Base {

        protected override bool IsDataVariableLength { get; set; } = true;

        public override BLE_DataType DataType => BLE_DataType.UTF8_String;


        protected override void DoParse(byte[] data) {
            this.DisplayString = Encoding.UTF8.GetString(data);
        }

    }

}
