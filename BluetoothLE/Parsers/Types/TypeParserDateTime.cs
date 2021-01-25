using BluetoothLE.Net.Parsers.Characteristics;
using LogUtils.Net;
using System;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Types {

    public class TypeParserDateTime : CharParser_Base {

        private ClassLog log = new ClassLog("TypeParser_DateTime");

        private TypeParserYear yearParser = new TypeParserYear();

        public DateTime Value { get; private set; } = DateTime.Now;

        public override int RequiredBytes { get; protected set; } = 7; // TODO - use year


        protected override void DoParse(byte[] data) {
            int pos = 0;
            byte[] tmp = data.ToByteArray(this.yearParser.RequiredBytes, ref pos);
            this.yearParser.Parse(tmp);
            if (this.yearParser.IsValid) {
                byte month = data.ToByte(ref pos);
                byte day = data.ToByte(ref pos);
                byte hour = data.ToByte(ref pos);
                byte minutes = data.ToByte(ref pos);
                byte seconds = data.ToByte(ref pos);
                if (this.Validate(month, day, hour, minutes, seconds)) {
                    try {
                        this.Value = new DateTime(this.yearParser.Year, month, day, hour, minutes, seconds, DateTimeKind.Local);
                        this.DisplayString =
                            string.Format("{0} {1}",
                            this.Value.ToLongDateString(), this.Value.ToLongTimeString());
                    }
                    catch (Exception e) {
                        this.log.Exception(9999, "DoParse", "", e);
                        this.DisplayString = string.Format(
                            "Invalid Date Time - {0} {1} {2} {3}:{4}:{5}",
                            yearParser.Year, month, day, hour, minutes, seconds);
                    }
                }
                else {
                    this.DisplayString = string.Format(
                        "Invalid Date Time - {0} {1} {2} {3}:{4}:{5}",
                        yearParser.Year, month, day, hour, minutes, seconds);
                }
            }
            else {
                this.DisplayString = this.yearParser.DisplayString;
            }
        }


        protected override void ResetMembers() {
            this.Value = DateTime.Now;
            base.ResetMembers();
        }

        //TypeParserHelpers.is

        private bool Validate(byte month, byte day, byte hour, byte minutes, byte seconds) {
            if (month.IsMonthValid() &&
                day.IsDayValid() && hour.IsHourValid()&&
                minutes.IsMinuteValid() && seconds.IsSecondsValid()) {
                return true;
            }
            return false;
        }

    }
}
