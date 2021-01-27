using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics {

    /// <summary>Parse value of 0.1 pascal units from bytes</summary>
    public class CharParser_Pressure : CharParser_Base {

        public double Value { get; private set; }

        public override int RequiredBytes { get; protected set; } = UINT32_LEN;


        protected override void DoParse(byte[] data) {
            // Spec exponent -1 resolution 0.1
            this.Value = data.ToUint32(0).Calculate(-1, 1);
            this.DisplayString = this.Value.ToStr("#######0.0");
        }

    }

}
