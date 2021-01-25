using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Types {

    public class TypeParserYear : BLEParserBase {


        public ushort Year { get; private set; }
        public bool IsValid { get; private set; }

        public override int RequiredBytes { get; protected set; } = UINT16_LEN;

        protected override void DoParse(byte[] data) {
            this.Process(data.ToUint16(0));
        }


        protected override void ResetMembers() {
            this.Year = 0;
            this.IsValid = false;
            base.ResetMembers();
        }


        private void Process(ushort year) {
            LogUtils.Net.Log.Info("----------", "----YEAR-----", year.ToString());
            this.IsValid = year.IsYearValid();
            this.Year = (this.IsValid) ? year : (ushort)0;
            this.DisplayString = year.GetYearStr();
        }

    }

}
