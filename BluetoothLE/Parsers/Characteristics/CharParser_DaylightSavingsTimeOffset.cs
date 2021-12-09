using BluetoothLE.Net.Enumerations;
using System.Text;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_DaylightSavingsTimeOffset : CharParser_Base {

        public override int RequiredBytes { get; protected set; } = BYTE_LEN;

        public override BLE_DataType DataType => BLE_DataType.UInt_8bit;


        protected override void DoParse(byte[] data) {
            StringBuilder sb = new ();
            // org.bluetooth.characteristic.dst_offset
            // Byte 2 Daylight savings uint8_t 0-8
            switch (Convert.ToInt32(data[0])) {
                case 0:
                    sb.Append("Standard Time");
                    break;
                case 2:
                    sb.Append("Daylight savings (+0.5h)");
                    break;
                case 4:
                    sb.Append("Daylight savings (+1h)");
                    break;
                case 8:
                    sb.Append("Daylight savings (+2h)");
                    break;
                case 255:
                    sb.Append("Daylight savings (Unknown)");
                    break;
                default:
                    sb.Append("Daylight savings (ERR)");
                    break;
            }
            this.DisplayString = sb.ToString();
        }

    }

}
