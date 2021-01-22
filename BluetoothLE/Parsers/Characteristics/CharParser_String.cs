using System.Text;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_String : CharParser_Base {

        public override int RequiredBytes { get; protected set; } = 0;

        protected override bool IsDataVariableLength { get; set; } = true;

        protected override bool DoParse(byte[] data) {
            this.DisplayString = Encoding.UTF8.GetString(data);
            return true;
        }



    }

}
