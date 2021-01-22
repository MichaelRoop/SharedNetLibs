using System;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_BatteryLevel : CharParser_Base {

        public override int RequiredBytes { get; protected set; } = 1;

        protected override bool DoParse(byte[] data) {
            if (this.CopyToRawData(data)) {
                // Will be 1 in length
                int tmp = Convert.ToInt32(this.RawData[0].ToString());
                this.DisplayString = tmp.ToString();
                return true;
            }
            return false;
        }

    }
}
