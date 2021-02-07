using BluetoothLE.Net.interfaces;
using System.Collections.Generic;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public abstract class CharParser_Base : BLEParserBase, ICharParser {

        protected List<IDescParser> DescriptorParsers { get; private set; } = new List<IDescParser>();


        public void SetDescriptorParsers(List<IDescParser> descParsers) {
            this.DescriptorParsers = descParsers;
            this.OnDescriptorsAdded();
        }

        protected virtual void OnDescriptorsAdded() {
            // By default we do nothing. The default Parser can use this to determine its
            // type if it has a format descriptor
        }

    }

}
