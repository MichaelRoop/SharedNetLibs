using System;
using System.Collections.Generic;
using System.Text;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics.DataTypes {

    public class TypeParser_ExactTime256 : CharParser_Base {

        TypeParser_DayDateTime dayDateTimeParser = new TypeParser_DayDateTime();
        int dayDateTimeBytes = 0;

        public TypeParser_ExactTime256() : base() { this.Setup(); }
        public TypeParser_ExactTime256(byte[] data) : base(data) { this.Setup(); }

        protected override bool DoParse(byte[] data) {
            if (this.CopyToRawData(data, this.RequiredBytes())) {
                int pos = 0;
                byte[] dayDtBlock = data.ToByteArray(this.dayDateTimeBytes, ref pos);
                byte fraction = data.ToByte(ref pos);
                StringBuilder sb = new StringBuilder();
                sb.Append(this.dayDateTimeParser.Parse(dayDtBlock))
                    .Append(".")
                    .Append(fraction.Get256Fragment());
                this.strValue = sb.ToString();
                return true;
            }
            return false;
        }

        public override int RequiredBytes() {
            return this.dayDateTimeBytes + 1;
        }


        private void Setup() {
            this.dayDateTimeBytes = this.dayDateTimeParser.RequiredBytes();
        }


    }
}
