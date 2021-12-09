using BluetoothLE.Net.Enumerations;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_AlertLevel : CharParser_Base {

        public override int RequiredBytes { get; protected set; } = BYTE_LEN;

        public override BLE_DataType DataType => BLE_DataType.UInt_8bit;

        protected override void DoParse(byte[] data) {
            this.DisplayString = data[0] switch {
                0 => "No Alert",
                1 => "Mild Alert",
                2 => "High Alert",
                _ => "ERR",
            };
        }

    }

}
