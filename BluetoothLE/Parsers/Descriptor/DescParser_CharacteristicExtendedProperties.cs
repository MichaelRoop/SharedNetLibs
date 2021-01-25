using BluetoothLE.Net.Enumerations;
using LogUtils.Net;
using System;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Descriptor {

    /// <summary>
    /// Parse value from Characteristic Extentended Properties descriptor.
    /// (0x2900) Data type: uint16
    /// </summary>
    /// <remarks>
    /// https://www.bluetooth.com/xml-viewer/?src=https://www.bluetooth.com/wp-content/uploads/Sitecore-Media-Library/Gatt/Xml/Descriptors/org.bluetooth.descriptor.gatt.characteristic_extended_properties.xml
    /// </remarks>
    public class DescParser_CharacteristicExtendedProperties : DescParser_Base {

        private ClassLog log = new ClassLog("DescParser_CharacteristicExtendedProperties");


        public EnabledDisabled ReliableWrite { get; set; } = EnabledDisabled.Disabled;
        public EnabledDisabled ReliableAuxiliary { get; set; } = EnabledDisabled.Disabled;
        public ushort ConvertedData { get; set; }

        public override int RequiredBytes { get; protected set; } = UINT16_LEN;


        /// <summary>
        /// Reset the object with values parsed from the 2 bytes of data retrieved from the Descriptor
        /// </summary>
        /// <param name="data">The 2 bytes of data returned from the OS descriptor</param>
        protected override void DoParse(byte[] data) {
            this.ConvertedData = data.ToUint16(0);
            //   Bit 0 - Reliable Write. Bit 1 Reliable Auxiliary. Others reserved
            this.ReliableWrite = (this.ConvertedData.IsBitSet(0)) ? EnabledDisabled.Enabled : EnabledDisabled.Disabled;
            this.ReliableAuxiliary = (this.ConvertedData.IsBitSet(1)) ? EnabledDisabled.Enabled : EnabledDisabled.Disabled;
            this.DisplayString = 
                string.Format("Reliable Write:{0} Reliable Auxiliary:{1}",
                this.ReliableWrite.ToString(), this.ReliableAuxiliary.ToString());
            this.log.Info("Reset", () => string.Format("Display:{0}", this.DisplayString));
        }


        protected override void  ResetMembers() {
            this.ReliableWrite = EnabledDisabled.Disabled;
            this.ReliableAuxiliary = EnabledDisabled.Disabled;
            this.ConvertedData = 0;
        }

    }

}
