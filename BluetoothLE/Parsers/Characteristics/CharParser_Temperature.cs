using BluetoothLE.Net.Parsers.Types;
using System.Globalization;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_Temperature : CharParser_Base {

        TypeParserUint16Exp2 parser = new TypeParserUint16Exp2();

        public double Value { get { return this.parser.Value; } } 

        public override int RequiredBytes { get; protected set; } = new TypeParserUint16Exp2().RequiredBytes;


        protected override void DoParse(byte[] data) {
            parser.Parse(data);
            this.DisplayString = parser.DisplayString;
        }

    }

}
