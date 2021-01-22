using LogUtils.Net;
using System.Text;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_TimeZone : CharParser_Base {

        ClassLog log = new ClassLog("CharParser_TimeZone");

        public override int RequiredBytes { get; protected set; } = 1;

        protected override void DoParse(byte[] data) {
            StringBuilder sb = new StringBuilder();
            // org.bluetooth.characteristic.time_zone
            // Time zone 15 minute increments / by 60 minutes gives UTC hour offset
            sb.Append("UTC[");
            sbyte zone = ByteHelpers.ToSByte(data, 0);
            if (zone == -128) {
                sb.Append("?]");
            }
            else {
                if (zone < -48 || zone > 56) {
                    this.log.Error(9999, () => string.Format("Zone {0} out of range -48 to +56", zone));
                    sb.Append("ERR]");
                }
                else {
                    sb.Append(((zone * 15) / 60)).Append("]");
                }
            }
            this.DisplayString = sb.ToString();
        }

    }

}
