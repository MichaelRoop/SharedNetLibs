using BluetoothLE.Net.interfaces;
using ChkUtils.Net;
using ChkUtils.Net.ErrObjects;
using LogUtils.Net;

namespace BluetoothLE.Net.Parsers.Descriptor {

    /// <summary>Delivers the appropriate parser for descriptor values</summary>
    public class DescParserFactory : IDescParserFactory {

        #region Data

        private readonly ClassLog log = new ("DescParserFactory");

        #endregion


        public IDescParser GetParser(Guid descriptorUuid, UInt16 handle) {
            IDescParser parser = WrapErr.ToErrReport<IDescParser>(out ErrReport report, 9999, 
                () => string.Format("Failed to find descriptor parser"), 
                () => {
                    if (BLE_ParseHelpers.IsSigDefinedUuid(descriptorUuid)) {
                        if (Enum.TryParse(descriptorUuid.ToUShortId().ToString(), out GattNativeDescriptorUuid descriptorEnum)) {
                            return descriptorEnum switch {
                                GattNativeDescriptorUuid.CharacteristicExtendedProperties => new DescParser_CharacteristicExtendedProperties(),
                                GattNativeDescriptorUuid.CharacteristicUserDescription => new DescParser_UserDescription(),
                                GattNativeDescriptorUuid.ClientCharacteristicConfiguration => new DescParser_ClientCharacteristicConfig(),
                                GattNativeDescriptorUuid.ServerCharacteristicConfiguration => new DescParser_ServerCharacteristicConfig(),
                                GattNativeDescriptorUuid.CharacteristicPresentationFormat => new DescParser_PresentationFormat(),
                                GattNativeDescriptorUuid.CharacteristicAggregateFormat => new DescParser_CharacteristicAggregateFormat(),
                                GattNativeDescriptorUuid.ValidRange => new DescParser_ValidRange(),
                                GattNativeDescriptorUuid.ExternalReportReference => new DescParser_Default(),// TODO implement ***
                                GattNativeDescriptorUuid.ReportReference => new DescParser_ReportReference(),
                                GattNativeDescriptorUuid.NumberOfDigitals => new DescParser_NumberDigitals(),
                                GattNativeDescriptorUuid.ValueTriggerSetting => new DescParser_Default(),// TODO implement ***
                                GattNativeDescriptorUuid.EnvironmentalSensingConfiguration or GattNativeDescriptorUuid.EnvironmentalSensingMeasurement or GattNativeDescriptorUuid.EnvironmentalSensingTriggerSetting => new DescParser_Default(),// TODO implement ***
                                GattNativeDescriptorUuid.TimeTriggerSetting => new DescParser_TimeTriggerSetting(),
                                _ => new DescParser_Default(),
                            };
                        }
                        else {
                            this.log.Error(9999, "GetParser", () => 
                                string.Format("Failed to parse out Guid:{0}", descriptorUuid.ToString()));
                            return new DescParser_Default();
                        }
                    }
                    else {
                        this.log.Error(9999, "GetParser", () =>
                            string.Format("Sig not defined:{0}", descriptorUuid.ToString()));
                        return new DescParser_Default();
                    }
                });
            if (report.Code == 0) {
                parser.AttributeHandle = handle;
                return parser;
            }
            return new DescParser_Default();
        }
    }
}
