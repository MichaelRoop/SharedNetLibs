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

        public EnabledDisabled Notifications { get; set; } = EnabledDisabled.Enabled;
        public EnabledDisabled Indications { get; set; } = EnabledDisabled.Enabled;

        public Byte Bitmask { get; set; } = 0;

        public override int RequiredBytes { get; protected set; } = UINT16_LEN;


        protected override void DoParse(byte[] data) {
            this.log.InfoEntry("DoParse");
            // Do not read to Uint16 since it flips the bytes. Need to read byte[0] and check it's bits
            this.Bitmask = data[0];

            this.log.Info("DoParse", () => string.Format("########### data:{0}, Length:{1} data[0]={2}, data[1]={3}", 
                data.ToFormatedByteString(), data.Length, data[0], data[1]));

            //   Bit 0 - Notifications, Bit 1 - Indications
            this.Notifications = (this.Bitmask.IsBitSet(0)) ? EnabledDisabled.Enabled : EnabledDisabled.Disabled;
            this.Indications = (this.Bitmask.IsBitSet(1)) ? EnabledDisabled.Enabled : EnabledDisabled.Disabled;
            this.TranslateDisplayString(
                "Notifications", 
                this.Notifications.ToString(),
                "Indications", 
                this.Indications.ToString());
        }


        public string TranslateDisplayString(
            string notifications, 
            string notificationsEnabled, 
            string indications,
            string indicationsEnabled) {

            this.DisplayString = string.Format(
                "{0} : {1}, {2} : {3}",
                notifications,
                notificationsEnabled,
                indications, 
                indicationsEnabled);

            this.log.Info("DoParse", () => string.Format("Display:{0}", this.DisplayString));
            return this.DisplayString;
        }


        protected override  void ResetMembers() {
            this.Notifications = EnabledDisabled.Disabled;
            this.Indications = EnabledDisabled.Disabled;
            this.Bitmask = 0;
            base.ResetMembers();
        }

    }

}
