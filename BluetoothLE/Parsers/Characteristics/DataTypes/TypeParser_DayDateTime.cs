using System;
using System.Collections.Generic;
using System.Text;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics.DataTypes {

    public class TypeParser_DayDateTime : CharParser_Base {

        TypeParser_DateTime dateTime = new TypeParser_DateTime();
        TypeParser_DayOfWeek dayOfWeek = new TypeParser_DayOfWeek();
        private int dateTimeBytes = 0;
        private int dayOfWeekBytes = 0;

        public TypeParser_DayDateTime() : base() { this.Setup(); }
        public TypeParser_DayDateTime(byte[] data) : base(data) { this.Setup(); }


        protected override bool DoParse(byte[] data) {
            if (this.CopyToRawData(data, this.RequiredBytes())) {
                int pos = 0;
                byte[] dtBlock = data.ToByteArray(this.dateTimeBytes, ref pos);
                byte[] dowBlock = data.ToByteArray(this.dayOfWeekBytes, ref pos);
                StringBuilder sb = new StringBuilder();
                sb.Append(this.dayOfWeek.Parse(dowBlock))
                    .Append(" ")
                    .Append(this.dateTime.Parse(dtBlock));
                this.strValue = sb.ToString();
                return true;
            }
            return false;
        }


        public override int RequiredBytes() {
            return this.dateTimeBytes + this.dayOfWeekBytes;
        }


        private void Setup() {
            this.dateTimeBytes = this.dateTime.RequiredBytes();
            this.dayOfWeekBytes = this.dayOfWeek.RequiredBytes();
        }


    }
}
