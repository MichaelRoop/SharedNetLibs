using BluetoothLE.Net.Parsers.Types;

namespace BluetoothLE.Net.Parsers.Characteristics {

    /// <summary>Parse value of 0.1 pascal units from bytes</summary>
    public class CharParser_Pressure : CharParser_Base {

        private TypeParserUint32Exp1 parser = new TypeParserUint32Exp1();

        public double Value { get { return this.parser.Value; } }

        public override int RequiredBytes { get; protected set; } = new TypeParserUint32Exp1().RequiredBytes;


        protected override void DoParse(byte[] data) {
            this.parser.Parse(data);
            this.DisplayString = parser.DisplayString;
        }

    }

}
