using BluetoothLE.Net.interfaces;
using LogUtils.Net;

namespace BluetoothLE.Net.Parsers.Descriptor {
    public abstract class DescParser_Base : BLEParserBase, IDescParser {

        /// <summary>Number of bytes in byte field</summary>
        protected const int BYTE_LEN = 1;
        /// <summary>Number of bytes for uint16 field</summary>
        protected const int UINT16_LEN = sizeof(ushort);
        /// <summary>Number of bytes for uint32 field</summary>
        protected const int UINT32_LEN = sizeof(uint);
        /// <summary>Number of bytes for time second field</summary>
        protected const int TIMESECOND_LEN = 3; // 3 bytes, 24bit

    }

}
