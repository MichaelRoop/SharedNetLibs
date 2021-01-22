using System;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_BatteryLevel : CharParser_Base {

        public override int RequiredBytes { get; protected set; } = 1;

        protected override bool DoParse(byte[] data) {
            // TODO - do a parse to confirm it is a number?
            if (data[0] > 100) {
                this.DisplayString = "ERR";
            }
            else {
                //this.DisplayString = Convert.ToInt32(data[0].ToString()).ToString();
                this.DisplayString = data[0].ToString();
            }
            return true;
        }

    }
}
