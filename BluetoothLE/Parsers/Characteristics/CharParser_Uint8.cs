using BluetoothLE.Net.Parsers.Types;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_Uint8 : CharParser_Base {

        private TypeParserUint8 parser = new TypeParserUint8();

        byte Value { get { return this.parser.Value; } }

        public CharParser_Uint8() {
            this.RequiredBytes = this.parser.RequiredBytes;
        }


        protected override void DoParse(byte[] data) {
            this.parser.Parse(data);
            this.DisplayString = this.parser.DisplayString;

        }
    }
}
