using System;
using System.Collections.Generic;
using System.Text;

namespace BluetoothLE.Net.interfaces {
    

    /// <summary>Common properties and methods of Descriptor value parsers</summary>
    public interface IDescParser {

        /// <summary>The number of bytes the parser requires</summary>
        int RequiredBytes { get; }

        /// <summary>User friendly display of descriptor value(s)</summary>
        string DisplayString { get; }

        /// <summary>
        /// The type of the implementation class which have extra properties
        /// based on the types of data derived from the raw bytes
        /// </summary>
        Type ImplementationType { get; }

        /// <summary>Parse out the variable values from the read bytes</summary>
        /// <param name="data">The bytes from Descriptor read</param>
        /// <returns>Display string with the parsed data</returns>
        string Parse(byte[] data);

    }
}
