using BluetoothLE.Net.Parsers.Characteristics;
using System.Text;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Types {

    public class TypeParserExactTime256 : CharParser_Base {

        private readonly TypeParserDayDateTime dayDateTimeParser = new ();


        public DayOfWeek Day { get { return this.dayDateTimeParser.Day; } }

        public DateTime DateAndTime { get { return this.dayDateTimeParser.DateAndTime; } }

        public int MsFragment { get; private set; } = 0;


        public TypeParserExactTime256() : base() { 
            this.Setup(); 
        }


        protected override void DoParse(byte[] data) {
            int pos = 0;
            byte[] dayDtBlock = data.ToByteArray(this.dayDateTimeParser.RequiredBytes, ref pos);
            this.MsFragment = data.ToByte(ref pos).GetSecond256FragmentAsMs();
            StringBuilder sb = new ();
            sb.Append(this.dayDateTimeParser.Parse(dayDtBlock))
                .Append('.')
                .Append(this.MsFragment);
            this.DisplayString = sb.ToString();
        }


        protected override void ResetMembers() {
            // Other two will reset on new parse
            this.MsFragment = 0;
            base.ResetMembers();
        }


        private void Setup() {
            this.RequiredBytes = this.dayDateTimeParser.RequiredBytes + BYTE_LEN;
        }

    }

}
