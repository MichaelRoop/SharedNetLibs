using LogUtils.Net;
using System;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Descriptor {

    /// <summary>
    /// Parse value returned from Valid Range Descriptor
    /// (0x2906) Data type: uint16 or uint32
    /// </summary>
    /// <remarks>
    ///  Hex values 2 or 4 bytes
    /// ex: 0x020x0D == 2-13
    /// ex: 0x58 0x02 0x20 0x1C == 600 - 7,200 seconds
    /// see: https://www.bluetooth.com/xml-viewer/?src=https://www.bluetooth.com/wp-content/uploads/Sitecore-Media-Library/Gatt/Xml/Descriptors/org.bluetooth.descriptor.valid_range.xml
    /// </remarks>
    public class DescParser_ValidRange : DescParser_Base {

        private ClassLog log = new ClassLog("DescParser_ValidRange");


        public ushort Min { get; set; } = 0;
        public ushort Max { get; set; } = 0;
        public uint ConvertedData { get; set; }
        protected override bool IsDataVariableLength { get; set; } = true;


        protected override void DoParse(byte[] data) {
            // TODO - revisit this. Seems that each of the two values are based on the kind of 
            // Characteristic it is attached to
            // Hex values 2 or 4 bytes
            // ex: 0x020x0D == 2-13
            // ex: 0x58 0x02 0x20 0x1C == 600 - 7,200 seconds
            // see: https://www.bluetooth.com/xml-viewer/?src=https://www.bluetooth.com/wp-content/uploads/Sitecore-Media-Library/Gatt/Xml/Descriptors/org.bluetooth.descriptor.valid_range.xml
            int pos = 0;
            if (data.Length >= UINT32_LEN) {
                this.ConvertedData = data.ToUint32(0);
                // TODO convert from hex
                this.Min = data.ToUint16(ref pos);
                this.Max = data.ToUint16(ref pos);
                // TODO - lot more work to do. Exponents lookup etc. see spec
            }
            else {
                // Two 1 byte numbers
                this.ConvertedData = data.ToUint16(0);
                this.Min = data.ToByte(ref pos);
                this.Max = data.ToByte(ref pos);
            }

            this.DisplayString = string.Format("Min:{0} Max:{1}", this.Min, this.Max);
            this.log.Info("DoParse", () => string.Format("Display:{0}", this.DisplayString));
        }


        protected override void ResetMembers() {
            this.Min = 0;
            this.Max = 0;
            this.ConvertedData = 0;
        }

    }

}
