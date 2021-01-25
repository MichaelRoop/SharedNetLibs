using BluetoothLE.Net.Enumerations;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Types {

    public class TypeParserMonthOfYear : BLEParserBase {

        public MonthOfYear Month { get; private set; } = MonthOfYear.Unknown;

        public override int RequiredBytes { get; protected set; } = BYTE_LEN;


        protected override void DoParse(byte[] data) {
            byte tmp = data.ToByte(0);
            this.Month = (tmp > 12) ? MonthOfYear.Unknown : (MonthOfYear)tmp;
            this.DisplayString = this.Month.GetMonthStr();
        }


        protected override void ResetMembers() {
            this.Month = MonthOfYear.Unknown;
            base.ResetMembers();
        }

    }

}
