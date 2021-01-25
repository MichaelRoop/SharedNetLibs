using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Types {

    public class TypeParserYear : BLEParserBase {


        public ushort Year { get; private set; }
        public bool IsValid { get; private set; }

        public override int RequiredBytes { get; protected set; } = UINT16_LEN;

        protected override void DoParse(byte[] data) {
            this.Validate(data.ToUint16(0));
            if (this.IsValid) {
                this.DisplayString = this.Year.ToString();
            }
            else {
                this.DisplayString = "Out of range";
            }
        }


        protected override void ResetMembers() {
            this.Year = 0;
            this.IsValid = false;
            base.ResetMembers();
        }


        private void Validate(ushort year) {
            LogUtils.Net.Log.Info("----------", "----YEAR-----", year.ToString());

            if (year > 1582 && year <= 9999) {
                this.IsValid = true;
                this.Year = year;
            }
        }

    }

}
