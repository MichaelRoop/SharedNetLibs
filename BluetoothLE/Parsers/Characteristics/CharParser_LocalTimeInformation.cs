using LogUtils.Net;
using System.Text;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_LocalTimeInformation : CharParser_Base {

        //private readonly ClassLog log = new ("CharParser_LocalTimeInformation");
        private readonly CharParser_DaylightSavingsTimeOffset dtsOffset = new ();
        private readonly CharParser_TimeZone timeZone = new ();


        public override int RequiredBytes { get; protected set; } = 0;

        public CharParser_LocalTimeInformation() : base() {
            this.RequiredBytes = 
                this.dtsOffset.RequiredBytes + this.timeZone.RequiredBytes;
        }


        protected override void DoParse(byte[] data) {
            StringBuilder sb = new ();
            int pos = 0;
            byte[] zoneBlock = data.ToByteArray(this.timeZone.RequiredBytes, ref pos);
            byte[] dtsBlock = data.ToByteArray(this.dtsOffset.RequiredBytes, ref pos);
            sb.Append(timeZone.Parse(zoneBlock)).Append(' ').Append(dtsOffset.Parse(dtsBlock));
            this.DisplayString = sb.ToString();
        }

    }
}
