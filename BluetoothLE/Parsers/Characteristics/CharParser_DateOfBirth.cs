using BluetoothLE.Net.Enumerations;
using BluetoothLE.Net.Parsers.Types;
using System;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_DateOfBirth : CharParser_Base {

        public ushort Year { get { return this.yearParser.Year; } }
        public MonthOfYear Month { get { return this.monthParser.Month; } }
        public DayOfWeek Day { get { return this.dayParser.Day; }  }

        private TypeParserYear yearParser = new TypeParserYear();
        private TypeParserMonthOfYear monthParser = new TypeParserMonthOfYear();
        private TypeParserDayOfWeek dayParser = new TypeParserDayOfWeek();

        public CharParser_DateOfBirth() : base() {
            this.RequiredBytes = 
                this.yearParser.RequiredBytes +
                this.monthParser.RequiredBytes + 
                this.dayParser.RequiredBytes;
        }


        protected override void DoParse(byte[] data) {
            int pos = 0;
            this.yearParser.Parse(data.ToByteArray(this.yearParser.RequiredBytes, ref pos));
            this.monthParser.Parse(data.ToByteArray(this.monthParser.RequiredBytes, ref pos));
            this.dayParser.Parse(data.ToByteArray(this.dayParser.RequiredBytes, ref pos));
            this.DisplayString = string.Format(
                "{0}, {1}, {2}",
                this.yearParser.DisplayString, this.monthParser.DisplayString, this.dayParser.DisplayString);
        }

    }
}
