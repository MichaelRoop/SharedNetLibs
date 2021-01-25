using BluetoothLE.Net.Parsers.Characteristics;
using LogUtils.Net;
using System;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Types {

    public class TypeParserDateTime : CharParser_Base {

        private ClassLog log = new ClassLog("TypeParser_DateTime");

        public DateTime Value { get; private set; } = DateTime.Now;

        public override int RequiredBytes { get; protected set; } = 7;


        protected override void DoParse(byte[] data) {
            int pos = 0;
            ushort year = ByteHelpers.ToUint16(data, ref pos);
            byte month = ByteHelpers.ToByte(data, ref pos);
            byte day = ByteHelpers.ToByte(data, ref pos);
            byte hour = ByteHelpers.ToByte(data, ref pos);
            byte minutes = ByteHelpers.ToByte(data, ref pos);
            byte seconds = ByteHelpers.ToByte(data, ref pos);
            if (this.Validate(year, month, day, hour, minutes, seconds)) {
                try {
                    this.Value = new DateTime(year, month, day, hour, minutes, seconds, DateTimeKind.Local);
                    this.DisplayString = 
                        string.Format("{0} {1}", 
                        this.Value.ToLongDateString(), this.Value.ToLongTimeString());
                }
                catch (Exception e) {
                    this.log.Exception(9999, "DoParse", "", e);
                    this.DisplayString = string.Format(
                        "Invalid Date Time - {0} {1} {2} {3}:{4}:{5}",
                        year, month, day, hour, minutes, seconds);
                }
            }
            else {
                this.DisplayString = string.Format(
                    "Invalid Date Time - {0} {1} {2} {3}:{4}:{5}",
                    year, month, day, hour, minutes, seconds);
            }
        }


        protected override void ResetMembers() {
            this.Value = DateTime.Now;
            base.ResetMembers();
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
