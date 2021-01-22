using LogUtils.Net;
using System;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics.DataTypes {

    public class TypeParser_DateTime : CharParser_Base {

        private ClassLog log = new ClassLog("TypeParser_DateTime");

        public override int RequiredBytes { get; protected set; } = 7;


        protected override bool DoParse(byte[] data) {
            int pos = 0;
            ushort year = ByteHelpers.ToUint16(data, ref pos);
            byte month = ByteHelpers.ToByte(data, ref pos);
            byte day = ByteHelpers.ToByte(data, ref pos);
            byte hour = ByteHelpers.ToByte(data, ref pos);
            byte minutes = ByteHelpers.ToByte(data, ref pos);
            byte seconds = ByteHelpers.ToByte(data, ref pos);
            if (this.Validate(year, month, day, hour, minutes, seconds)) {
                try {
                    DateTime dt = new DateTime(year, month, day, hour, minutes, seconds, DateTimeKind.Local);
                    this.DisplayString = string.Format("{0} {1}", dt.ToLongDateString(), dt.ToLongTimeString());
                    return true;
                }
                catch (Exception e) {
                    this.log.Exception(9999, "DoParse", "", e);
                    this.DisplayString = string.Format(
                        "Invalid Date Time - {0} {1} {2} {3}:{4}:{5}",
                        year, month, day, hour, minutes, seconds);
                    return true;
                }
            }
            else {
                this.DisplayString = string.Format(
                    "Invalid Date Time - {0} {1} {2} {3}:{4}:{5}",
                    year, month, day, hour, minutes, seconds);
                return true;
            }
        }


        private bool Validate(ushort year, byte month, byte day, byte hour, byte minutes, byte seconds) {
            if ((year > 1582 && year <= 9999) &&
                (month > 0 && month < 13) &&
                (day > 0 && day < 32) &&
                (hour >= 0 && hour < 24)&&
                (minutes >= 0 && minutes <60) &&
                (seconds >= 0 && seconds < 60)) {
                return true;
            }
            return false;
        }

    }
}
