namespace BluetoothLE.Net.interfaces {

    public interface IBLEParser {

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
