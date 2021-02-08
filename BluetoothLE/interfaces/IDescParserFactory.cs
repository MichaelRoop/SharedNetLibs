using System;
using System.Collections.Generic;
using System.Text;

namespace BluetoothLE.Net.interfaces {

    public interface IDescParserFactory {

        /// <summary>Get the parser for the descriptor</summary>
        /// <param name="descriptorUuid">Descriptor Uuid</param>
        /// <param name="handle">Descriptor handle</param>
        /// <returns>The parser for the descriptor or default</returns>
        IDescParser GetParser(Guid descriptorUuid, UInt16 handle);

    }
}
