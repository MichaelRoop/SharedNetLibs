using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_Temperature : CharParser_Base {

        public double Value { get; private set; }

        public override int RequiredBytes { get; protected set; } = UINT16_LEN;

        protected override void DoParse(byte[] data) {
            // Spec exponent -2 resolution 0.01
            this.Value = data.ToInt16(0).Calculate(-2, 2);
            this.DisplayString = this.Value.ToStr("#######0.00");
        }

    }

}
