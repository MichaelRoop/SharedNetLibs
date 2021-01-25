
using System.Collections.Generic;

namespace BluetoothLE.Net.interfaces {


    /// <summary>Common properties and methods of Characteristic value parsers</summary>
    public interface ICharParser : IBLEParser {

        /// <summary>Allows Characteristic parser to Descriptor info</summary>
        /// <param name="descParsers"></param>
        void SetDescriptorParsers(List<IDescParser> descParsers);

    }

}
