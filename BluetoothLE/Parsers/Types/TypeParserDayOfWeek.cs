using BluetoothLE.Net.Parsers.Characteristics;
using System;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Types {

    public class TypeParserDayOfWeek : CharParser_Base {

        public DayOfWeek Day { get; private set; } = DayOfWeek.Sunday;

        public override int RequiredBytes { get; protected set; } = BYTE_LEN;

        protected override void DoParse(byte[] data) {
            byte day = ByteHelpers.ToByte(data, 0);
            if (day == 0) {
                this.DisplayString = "Unknown";
            }
            else if (day > 0 && day < 8) {
                // Note: BLE starts week on Monday 1 while 
                // MS array starts sunday [0]
                int ndx = (day == 7) ? 0 : day;
                this.Day = (DayOfWeek)ndx;
                this.DisplayString = Day.GetDayStr();
            }
            else {
                this.DisplayString = "Invalid";
                this.Day = DayOfWeek.Sunday;
            }
        }


        protected override void ResetMembers() {
            this.Day = DayOfWeek.Sunday;
            base.ResetMembers();
        }

    }

}
