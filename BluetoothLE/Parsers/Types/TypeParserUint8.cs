using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Types {

    public class TypeParserUint8 : BLEParserBase {

        public  byte Value { get; set; } = 0;

        public override int RequiredBytes { get; protected set; } = BYTE_LEN;


        protected override void DoParse(byte[] data) {
            this.Value = data.ToByte(0);
        }


        protected override void ResetMembers() {
            this.Value = 0;
            base.ResetMembers();
        }

    }
}
