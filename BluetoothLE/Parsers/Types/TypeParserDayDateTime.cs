using BluetoothLE.Net.Parsers.Characteristics;
using System;
using System.Text;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Types {

    public class TypeParserDayDateTime : CharParser_Base {

        private TypeParserDateTime dateTime = new TypeParserDateTime();
        private TypeParserDayOfWeek dayOfWeek = new TypeParserDayOfWeek();

        public DayOfWeek Day { get {  return this.dayOfWeek.Day; } }

        public DateTime DateAndTime { get { return this.dateTime.Value; } }


        public TypeParserDayDateTime() : base() { 
            this.Setup(); 
        }


        protected override void DoParse(byte[] data) {
            int pos = 0;
            byte[] dtBlock = data.ToByteArray(this.dateTime.RequiredBytes, ref pos);
            byte[] dowBlock = data.ToByteArray(this.dayOfWeek.RequiredBytes, ref pos);
            StringBuilder sb = new StringBuilder();
            sb.Append(this.dayOfWeek.Parse(dowBlock))
                .Append(" ")
                .Append(this.dateTime.Parse(dtBlock));
            this.DisplayString = sb.ToString();
        }


        private void Setup() {
            this.RequiredBytes = this.dateTime.RequiredBytes + this.dayOfWeek.RequiredBytes;
        }

    }

}
