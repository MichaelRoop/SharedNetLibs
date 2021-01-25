﻿
using System.Collections.Generic;

namespace BluetoothLE.Net.interfaces {


    /// <summary>Common properties and methods of Characteristic value parsers</summary>
    public interface ICharParser {

        /// <summary>Allows Characteristic parser to Descriptor info</summary>
        /// <param name="descParsers"></param>
        void SetDescriptorParsers(List<IDescParser> descParsers);


        /// <summary>The number of bytes the parser requires</summary>
        int RequiredBytes { get; }


        /// <summary>User friendly display of descriptor value(s)</summary>
        string DisplayString { get; }


        /// <summary>Parse out the variable values from the read bytes</summary>
        /// <param name="data">The bytes from Descriptor read</param>
        /// <returns>Display string with the parsed data</returns>
        string Parse(byte[] data);



    }

}
