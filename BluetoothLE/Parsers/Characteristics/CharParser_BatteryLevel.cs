using System;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_BatteryLevel : CharParser_Base {

        public override int RequiredBytes { get; protected set; } = 1;

        // TODO - remove entirely
        public CharParser_BatteryLevel(byte[] data) : base(data) { }
        public CharParser_BatteryLevel() : base() { }


        protected override bool DoParse(byte[] data) {
            if (this.CopyToRawData(data)) {
                // Will be 1 in length
                int tmp = Convert.ToInt32(this.RawData[0].ToString());
                this.strValue = tmp.ToString();
                return true;
            }
            return false;
        }

    }
}
