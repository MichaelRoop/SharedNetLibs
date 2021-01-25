using System;

namespace BluetoothLE.Net.interfaces {


    /// <summary>Common properties and methods of Descriptor value parsers</summary>
    public interface IDescParser : IBLEParser {

        /// <summary>
        /// The type of the implementation class which have extra properties
        /// based on the types of data derived from the raw bytes
        /// </summary>
        Type ImplementationType { get; }

    }
}
