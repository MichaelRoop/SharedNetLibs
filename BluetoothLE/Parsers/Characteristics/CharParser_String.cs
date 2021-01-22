using System.Text;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_String : CharParser_Base {

        public override int RequiredBytes { get; protected set; } = 0;


        protected override bool DoParse(byte[] data) {
            // Required bytes variable so we will set it as how many are incoming
            this.RequiredBytes = data.Length;
            if (this.CopyToRawData(data)) {
                this.DisplayString = Encoding.UTF8.GetString(this.RawData);
                return true;
            }
            return false;
        }

    }

}
