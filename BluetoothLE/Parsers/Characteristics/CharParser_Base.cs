using BluetoothLE.Net.Enumerations;
using BluetoothLE.Net.interfaces;
using System.Collections.Generic;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public abstract class CharParser_Base : BLEParserBase, ICharParser {

        protected List<IDescParser> DescriptorParsers { get; private set; } = new List<IDescParser>();


        public BLEOperationStatus SetDescriptorParsers(List<IDescParser> descParsers) {
            this.DescriptorParsers = descParsers;
            return this.OnDescriptorsAdded();
        }

        protected virtual BLEOperationStatus OnDescriptorsAdded() {
            // By default we do nothing. The default Parser can use this to determine its
            // type if it has a format descriptor
            return BLEOperationStatus.Success;
        }

    }

}
