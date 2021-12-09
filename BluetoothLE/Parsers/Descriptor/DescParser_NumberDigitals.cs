using LogUtils.Net;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Descriptor {

    /// <summary> Number of Digitals (0x2909) Data type: uint8 </summary>
    public class DescParser_NumberDigitals : DescParser_Base {

        private readonly ClassLog log = new ("DescParser_NumberDecimals");

        public byte Number { get; set; }

        public override int RequiredBytes { get; protected set; } = BYTE_LEN;

        protected override void DoParse(byte[] data) {
            this.Number = data.ToByte(0);
            this.DisplayString = string.Format("Number of Digitals:{0}", this.Number);
            this.log.Info("DoParse", () => string.Format("Display:{0}", this.DisplayString));
        }


        protected override void ResetMembers() {
            this.Number = 0;
            base.ResetMembers();
        }

    }

}
