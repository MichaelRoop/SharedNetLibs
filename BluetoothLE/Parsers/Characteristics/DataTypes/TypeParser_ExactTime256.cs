using System.Text;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics.DataTypes {

    public class TypeParser_ExactTime256 : CharParser_Base {

        TypeParser_DayDateTime dayDateTimeParser = new TypeParser_DayDateTime();

        public override int RequiredBytes { get; protected set; } = 0;

        public TypeParser_ExactTime256() : base() { this.Setup(); }


        protected override bool DoParse(byte[] data) {
            if (this.CopyToRawData(data)) {
                int pos = 0;
                byte[] dayDtBlock = data.ToByteArray(this.dayDateTimeParser.RequiredBytes, ref pos);
                byte fraction = data.ToByte(ref pos);
                StringBuilder sb = new StringBuilder();
                sb.Append(this.dayDateTimeParser.Parse(dayDtBlock))
                    .Append(".")
                    .Append(fraction.Get256Fragment());
                this.DisplayString = sb.ToString();
                return true;
            }
            return false;
        }


        private void Setup() {
            this.RequiredBytes = this.dayDateTimeParser.RequiredBytes + 1;
        }

    }

}
