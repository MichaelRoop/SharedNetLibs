using BluetoothLE.Net.Enumerations;
using System;

namespace BluetoothLE.Net.interfaces {

    public interface IBLEParser {

        /// <summary>Unique GATT identifier from the item it parses for</summary>
        UInt16 AttributeHandle { get; set; }


        /// <summary>The number of bytes the parser requires</summary>
        int RequiredBytes { get; }

        /// <summary>User friendly display of descriptor value(s)</summary>
        string DisplayString { get; }

        /// <summary>The data type for the characteristic</summary>
        BLE_DataType DataType { get; }


        /// <summary>Parse out the variable values from the read bytes</summary>
        /// <param name="data">The bytes from Descriptor read</param>
        /// <returns>Display string with the parsed data</returns>
        string Parse(byte[] data);

    }
}
