using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics.DataTypes {

    public class TypeParser_DayOfWeek : CharParser_Base {
        protected override bool DoParse(byte[] data) {
            if (this.CopyToRawData(data, 1)) {
                byte day = ByteHelpers.ToByte(data, 0);
                if (day == 0) {
                    this.strValue = "Unknown";
                }
                else if (day > 0 && day < 8) {
                    // Note: BLE starts week on Monday 1 while 
                    // MS array starts sunday [0]
                    int ndx = (day == 7) ? 0 : day;
                    this.strValue = DateTimeFormatInfo.CurrentInfo.GetDayName((DayOfWeek)ndx);
                }
                else {
                    this.strValue = "Invalid";
                }
                return true;
            }
            return false;
        }


        public override int RequiredBytes() {
            return 1;
        }

    }
}
