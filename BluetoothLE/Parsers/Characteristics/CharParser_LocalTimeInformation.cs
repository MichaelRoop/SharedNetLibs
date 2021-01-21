using LogUtils.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_LocalTimeInformation : CharParser_Base {

        ClassLog log = new ClassLog("CharParser_LocalTimeInformation");

        protected override bool DoParse(byte[] data) {
            if (this.CopyToRawData(data, 2)) {
                StringBuilder sb = new StringBuilder();
                // org.bluetooth.characteristic.time_zone
                // Time zone 15 minute increments / by 60 minutes gives UTC hour offset
                sb.Append("UTC[");
                sbyte zone = (sbyte)this.RawData[0];  //  Convert.ToSByte(this.RawData[0]);
                if (zone == -128) {
                    sb.Append("?] ");
                }
                else {
                    if (zone < -48 || zone > 56) {
                        this.log.Error(9999, () => string.Format("Zone {0} out of range -48 to +56", zone));
                        sb.Append("ERR] ");
                    }
                    else {
                        sb.Append(((zone * 15) / 60)).Append("] ");
                    }
                }

                // org.bluetooth.characteristic.dst_offset
                // Byte 2 Daylight savings uint8_t 0-8
                switch (Convert.ToInt32(this.RawData[1])) {
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


                this.strValue = sb.ToString();
                return true;
            }
            return false;
        }

        protected override Type GetDerivedType() {
            return this.GetType();
            ;
        }
    }
}
