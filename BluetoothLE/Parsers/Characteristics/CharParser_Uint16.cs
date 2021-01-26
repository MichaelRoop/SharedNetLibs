using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_Uint16 : CharParser_Base {

        public override int RequiredBytes { get; protected set; } = UINT16_LEN;

        public ushort Value { get; private set; }

        protected override void DoParse(byte[] data) {
            this.Value = data.ToUint16(0);
            this.DisplayString = this.Value.ToString();
        }


        protected override void ResetMembers() {
            this.Value = 0;
            base.ResetMembers();
        }

    }

}
