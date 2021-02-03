using BluetoothLE.Net.Enumerations;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_BatteryLevel : CharParser_Base {

        public override int RequiredBytes { get; protected set; } = BYTE_LEN;

        public override BLE_DataType DataType => BLE_DataType.UInt_8bit;


        protected override void DoParse(byte[] data) {
            this.DisplayString = (data[0] > 100) ? "ERR" : data[0].ToString();
        }

    }
}
