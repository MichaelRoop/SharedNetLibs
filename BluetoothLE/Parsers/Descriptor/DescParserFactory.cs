using BluetoothLE.Net.interfaces;
using ChkUtils.Net;
using ChkUtils.Net.ErrObjects;
using LogUtils.Net;
using System;

namespace BluetoothLE.Net.Parsers.Descriptor {

    public class DescParserFactory : IDescParserFactory {

        #region Data

        private ClassLog log = new ClassLog("DescParserFactory");

        #endregion


        public IDescParser GetParser(Guid descriptorUuid, UInt16 handle) {
            ErrReport report;
            IDescParser parser = WrapErr.ToErrReport<IDescParser>(out report, 9999, 
                () => string.Format("Failed to find descriptor parser"), 
                () => {
                    if (BLE_ParseHelpers.IsSigDefinedUuid(descriptorUuid)) {
                        GattNativeDescriptorUuid descriptorEnum;
                        if (Enum.TryParse(descriptorUuid.ToShortId().ToString(), out descriptorEnum)) {
                            switch (descriptorEnum) {
                                case GattNativeDescriptorUuid.CharacteristicExtendedProperties:
                                    return new DescParser_CharacteristicExtendedProperties();
                                case GattNativeDescriptorUuid.CharacteristicUserDescription:
                                    return new DescParser_UserDescription();
                                case GattNativeDescriptorUuid.ClientCharacteristicConfiguration:
                                    return new DescParser_ClientCharacteristicConfig();
                                case GattNativeDescriptorUuid.ServerCharacteristicConfiguration:
                                    return new DescParser_ServerCharacteristicConfig();
                                case GattNativeDescriptorUuid.CharacteristicPresentationFormat:
                                    return new DescParser_PresentationFormat();
                                case GattNativeDescriptorUuid.CharacteristicAggregateFormat:
                                    return new DescParser_CharacteristicAggregateFormat();
                                case GattNativeDescriptorUuid.ValidRange:
                                    return new DescParser_ValidRange();
                                case GattNativeDescriptorUuid.ExternalReportReference:
                                    return new DescParser_Default(); // TODO implement ***
                                case GattNativeDescriptorUuid.ReportReference:
                                    return new DescParser_ReportReference();
                                case GattNativeDescriptorUuid.NumberOfDigitals:
                                    return new DescParser_NumberDigitals();
                                case GattNativeDescriptorUuid.ValueTriggerSetting:
                                    return new DescParser_Default(); // TODO implement ***
                                case GattNativeDescriptorUuid.EnvironmentalSensingConfiguration:
                                case GattNativeDescriptorUuid.EnvironmentalSensingMeasurement:
                                case GattNativeDescriptorUuid.EnvironmentalSensingTriggerSetting:
                                    return new DescParser_Default(); // TODO implement ***
                                case GattNativeDescriptorUuid.TimeTriggerSetting:
                                    return new DescParser_TimeTriggerSetting();
                                default:
                                    return new DescParser_Default();
                            }
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
