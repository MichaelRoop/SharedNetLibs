using BluetoothLE.Net.Enumerations;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_AlertCategoryID : CharParser_Base {

        public override int RequiredBytes { get; protected set; } = BYTE_LEN;

        public override BLE_DataType DataType => BLE_DataType.UInt_8bit;

        protected override void DoParse(byte[] data) {
            this.DisplayString = data[0] switch {
                0 => "Simple Alert",
                1 => "Email",
                2 => "News",
                3 => "Incoming call",
                4 => "Missed call",
                5 => "SMS/MMS arrives",
                6 => "Voice mail",
                7 => "Scheduler",
                8 => "High Prioritized",
                9 => "Instant Message",
                _ => "Unknown",
            };
        }

    }
}
