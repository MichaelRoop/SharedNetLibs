using BluetoothLE.Net.Enumerations;
using LogUtils.Net;
using System;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Descriptor {

    /// <summary>
    /// Parse the 16bit value from the Server Characteristic Config Descriptor
    /// (0x2903) Data type: uint16
    /// </summary>
    public class DescParser_ServerCharacteristicConfig : DescParser_Base {

        private ClassLog log = new ClassLog("DescParser_ServerCharacteristicConfig");


        public EnabledDisabled Broadcasts { get; set; } = EnabledDisabled.Disabled;

        public ushort ConvertedData { get; set; }

        public override int RequiredBytes { get; protected set; } = UINT16_LEN;


        /// <summary>
        /// Reset the object with values parsed from the 2 bytes of data retrieved from the Descriptor
        /// </summary>
        /// <param name="data">The 2 bytes of data returned from the OS descriptor</param>
        protected override void DoParse(byte[] data) {
            this.ConvertedData = data.ToUint16(0);
            //   Bit 0 - Broadcasts. Others reserved
            this.Broadcasts = (this.ConvertedData.IsBitSet(0)) ? EnabledDisabled.Enabled : EnabledDisabled.Disabled;
            this.DisplayString = string.Format("Broadcasts:{0}", this.Broadcasts.ToString());
            this.log.Info("Reset", () => string.Format("Display:{0}", this.DisplayString));
        }


        protected override void ResetMembers() {
            this.Broadcasts = EnabledDisabled.Disabled;
            this.ConvertedData = 0;
            base.ResetMembers();
        }

    }

}
