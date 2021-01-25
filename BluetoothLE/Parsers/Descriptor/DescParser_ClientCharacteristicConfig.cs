using BluetoothLE.Net.Enumerations;
using LogUtils.Net;
using System;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Descriptor {

    /// <summary>
    /// Client Characteristic Configuration Descriptor value parser
    /// (0x2902) Data type: uint16
    /// </summary>
    /// <remarks>
    /// Uint16 data: Values 0-3
    ///   Bit 0 - Notifications disabled/enabled
    ///   Bit 1 - Indications disabled/enabled
    ///   Other bits reserved for future use
    /// </remarks>
    public class DescParser_ClientCharacteristicConfig : DescParser_Base {
        
        private readonly ClassLog log = new ClassLog("DescParser_ClientCharacteristicConfig");

        public EnabledDisabled Notifications { get; set; } = EnabledDisabled.Disabled;
        public EnabledDisabled Indications { get; set; } = EnabledDisabled.Disabled;
        public ushort ConvertedData { get; set; }

        public override int RequiredBytes { get; protected set; } = UINT16_LEN;


        protected override void DoParse(byte[] data) {
            this.log.InfoEntry("DoParse");
            this.ConvertedData = data.ToUint16(0);

            //   Bit 0 - Notifications, Bit 1 - Indications
            this.Notifications = (this.ConvertedData.IsBitSet(0)) ? EnabledDisabled.Enabled : EnabledDisabled.Disabled;
            this.Indications = (this.ConvertedData.IsBitSet(1)) ? EnabledDisabled.Enabled : EnabledDisabled.Disabled;
            this.DisplayString = string.Format("Notifications:{0}, Indications:{1}", 
                this.Notifications.ToString(), this.Indications.ToString());
            this.log.Info("DoParse", () => string.Format("Display:{0}", this.DisplayString));
        }


        protected override  void ResetMembers() {
            this.Notifications = EnabledDisabled.Disabled;
            this.Indications = EnabledDisabled.Disabled;
            this.ConvertedData = 0;
            base.ResetMembers();
        }

    }

}
