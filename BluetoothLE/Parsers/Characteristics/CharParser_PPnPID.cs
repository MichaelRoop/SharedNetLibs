using System;
using System.Text;

namespace BluetoothLE.Net.Parsers.Characteristics {

    /// <summary>Parse the data fields of the PPnPID</summary>
    public class CharParser_PPnPID : CharParser_Base {

        public override int RequiredBytes { get; protected set; } = 7;


        protected override bool DoParse(byte[] data) {
            if (this.CopyToRawData(data)) {
                // 7 bytes
                //0x02,0x5E,0x04,0x17,0x08,0x31,0x01
                // field1 - 1 byte uint8 source of Vendor ID
                // field2 - 2 byte Uint16 - product vendor namespace
                // field3 - 2 byte Uint16 - manufacturer ID
                // field4 - 2 byte Uint16 - manufacturer version of product
                StringBuilder sb = new StringBuilder();
                sb
                    .Append("Vendor ID:")
                    .Append(this.RawData[0]).Append(", ")
                    .Append("Vendor Namespace:")
                    .Append(BitConverter.ToInt16(this.RawData, 1)).Append(", ")
                    .Append("Manufacturer ID:")
                    .Append(BitConverter.ToInt16(this.RawData, 3)).Append(", ")
                    .Append("Manufacturer Namespace:")
                    .Append(BitConverter.ToInt16(this.RawData, 5));
                this.strValue = sb.ToString();
                return true;
            }
            return false;
        }

    }

}
