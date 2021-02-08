using System;

namespace BluetoothLE.Net.interfaces {

    public interface ICharParserFactory {

        /// <summary>Get the correct parser for Characteristic type</summary>
        /// <param name="characteristicUuid">Characteristic Uuid</param>
        /// <param name="handle">The GATT handle for the Characteristic it parses</param>
        /// <returns>The appropriate parser</returns>
        ICharParser GetParser(Guid characteristicUuid, UInt16 handle);

    }
}
