
using BluetoothLE.Net.Enumerations;
using System.Collections.Generic;

namespace BluetoothLE.Net.interfaces {


    /// <summary>Common properties and methods of Characteristic value parsers</summary>
    public interface ICharParser : IBLEParser {

        /// <summary>Allows Characteristic parser to Descriptor info</summary>
        /// <param name="descParsers">The list of descriptors for the characteristic</param>
        /// <return>BLEOperationStatus.Success or an error code</return>
        BLEOperationStatus SetDescriptorParsers(List<IDescParser> descParsers);

    }

}
