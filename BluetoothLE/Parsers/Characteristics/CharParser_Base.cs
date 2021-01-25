using BluetoothLE.Net.interfaces;
using System.Collections.Generic;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public abstract class CharParser_Base : BLEParserBase, ICharParser {

        protected List<IDescParser> DescriptorParsers { get; private set; }


        public void SetDescriptorParsers(List<IDescParser> descParsers) {
            this.DescriptorParsers = descParsers;
        }

    }

}
