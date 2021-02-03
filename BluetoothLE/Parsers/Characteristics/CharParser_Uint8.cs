using BluetoothLE.Net.Enumerations;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_Uint8 : CharParser_Base {

        public byte Value { get; private set; }

        public override int RequiredBytes { get; protected set; } = BYTE_LEN;

        public override BLE_DataType DataType => BLE_DataType.UInt_8bit;


        protected override void DoParse(byte[] data) {
            this.Value = data[0];
            this.DisplayString = this.Value.ToString();
        }


        protected override void ResetMembers() {
            this.Value = 0;
            base.ResetMembers();
        }

    }
}
