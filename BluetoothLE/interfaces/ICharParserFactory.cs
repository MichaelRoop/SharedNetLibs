using System;

namespace BluetoothLE.Net.interfaces {

    public interface ICharParserFactory {

        /// <summary>Get the correct parser for Characteristic type</summary>
        /// <param name="characteristicUuid">Characteristic Uuid</param>
        /// <returns>The appropriate parser</returns>
        ICharParser GetParser(Guid characteristicUuid);


        /// <summary>Get the parsed value as string based on the characteristic Uuid</summary>
        /// <param name="characteristicUuid">The characteristic Uuid</param>
        /// <param name="data">The byte data read</param>
        /// <returns>Value as passed through the parser</returns>
        string GetParsedValueAsString(Guid characteristicUuid, byte[] data);


    }
}
