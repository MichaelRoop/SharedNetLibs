using System;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_BatteryLevel : CharParser_Base {

        public override int RequiredBytes { get; protected set; } = 1;

        protected override void DoParse(byte[] data) {
            this.DisplayString = (data[0] > 100) ? "ERR" : data[0].ToString();
        }

    }
}
