using System.Text;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_String : CharParser_Base {

        protected override bool IsDataVariableLength { get; set; } = true;

        protected override void DoParse(byte[] data) {
            this.DisplayString = Encoding.UTF8.GetString(data);
        }

    }

}
