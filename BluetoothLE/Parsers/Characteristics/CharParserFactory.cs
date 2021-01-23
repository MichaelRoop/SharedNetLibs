﻿using BluetoothLE.Net.interfaces;
using BluetoothLE.Net.Parsers.Characteristics.DataTypes;
using ChkUtils.Net;
using ChkUtils.Net.ErrObjects;
using LogUtils.Net;
using System;

namespace BluetoothLE.Net.Parsers.Characteristics {

    /// <summary>Factory to process Characteristic byte read</summary>
    public class CharParserFactory : ICharParserFactory {

        #region Data

        private ClassLog log = new ClassLog("CharParserFactory");
        private CharParser_AlertCategoryID alertCategoryId = new CharParser_AlertCategoryID();
        private CharParser_AlertCategoryIDBitmask alertCategoryIDBitmask = new CharParser_AlertCategoryIDBitmask();
        private CharParser_AlertLevel alertLevel = new CharParser_AlertLevel();
        private CharParser_Appearance appearanceParser = new CharParser_Appearance();
        private CharParser_BatteryLevel batteryLevelParser = new CharParser_BatteryLevel();
        private CharParser_CurrentTime currentTime = new CharParser_CurrentTime();
        private TypeParser_DateTime dateTime = new TypeParser_DateTime();
        private TypeParser_DayDateTime dayDateTime = new TypeParser_DayDateTime();
        private TypeParser_DayOfWeek dayOfWeek = new TypeParser_DayOfWeek();
        private CharParser_DaylightSavingsTimeOffset dtsOffset = new CharParser_DaylightSavingsTimeOffset();
        private CharParser_Default defaultParser = new CharParser_Default();
        private TypeParser_ExactTime256 exactTime256 = new TypeParser_ExactTime256();
        private CharParser_Humidity humidity = new CharParser_Humidity();
        private CharParser_LocalTimeInformation localTimeInfo = new CharParser_LocalTimeInformation();
        private CharParser_PPnPID pPnPidParser = new CharParser_PPnPID();
        private CharParser_Pressure pressure = new CharParser_Pressure();
        private CharParser_String stringParser = new CharParser_String();
        private CharParser_TemperatureCelcius temperatureCelcius = new CharParser_TemperatureCelcius();
        private CharParser_TimeZone timeZone = new CharParser_TimeZone();

        private CharParser_PeripheralPrefferedConnectParams ppConnParamParser = new CharParser_PeripheralPrefferedConnectParams();


        #endregion


        public string GetParsedValueAsString(Guid characteristicUuid, byte[] data) {
            try {
                ICharParser parser = this.GetParser(characteristicUuid);
                if (parser == null) {
                    return "* Failed to retrieve parser *";
                }
                return parser.Parse(data);
            }
            catch (Exception e) {
                this.log.Exception(9999, "GetParsedValueAsString", "", e);
                return "* FAILED ON CHARACTERISTIC VALUE PARSE *";
            }
        }


        public ICharParser GetParser(Guid characteristicUuid) {
            ICharParser parser = null;
            ErrReport report;
            parser = WrapErr.ToErrReport<ICharParser>(out report, 9999,
                () => string.Format("Failed to find characteristic parser"),
                () => {
                    if (BLE_ParseHelpers.IsSigDefinedUuid(characteristicUuid)) {
                        GattNativeCharacteristicUuid charEnum = BLE_ParseHelpers.GetCharacteristicEnum(characteristicUuid, "");
                        switch (charEnum) {
                            #region String formaters
                            // Common UTF8 strings    
                            case GattNativeCharacteristicUuid.DeviceName:
                            case GattNativeCharacteristicUuid.String:
                            case GattNativeCharacteristicUuid.ManufacturerNameString:
                            case GattNativeCharacteristicUuid.ModelNumberString:
                            case GattNativeCharacteristicUuid.HardwareRevisionString:
                            case GattNativeCharacteristicUuid.FirmwareRevisionString:
                            case GattNativeCharacteristicUuid.SerialNumberString:
                            case GattNativeCharacteristicUuid.SoftwareRevisionString:
                                return this.stringParser;
                            #endregion
                            #region Assigned parsers
                            case GattNativeCharacteristicUuid.AlertCategoryID:
                                return this.alertCategoryId;
                            case GattNativeCharacteristicUuid.AlertCategoryIDBitMask:
                                return this.alertCategoryIDBitmask;
                            case GattNativeCharacteristicUuid.AlertLevel:
                                return this.alertLevel;
                            case GattNativeCharacteristicUuid.Appearance:
                                return this.appearanceParser;
                            case GattNativeCharacteristicUuid.BatteryLevel:
                                return this.batteryLevelParser;
                            case GattNativeCharacteristicUuid.CurrentTime:
                                return this.currentTime;
                            case GattNativeCharacteristicUuid.DateTime:
                                return this.dateTime;
                            case GattNativeCharacteristicUuid.DayDateTime:
                                return this.dayDateTime;
                            case GattNativeCharacteristicUuid.DayofWeek:
                                return this.dayOfWeek;
                            case GattNativeCharacteristicUuid.DSTOffset:
                                return this.dtsOffset;
                            case GattNativeCharacteristicUuid.ExactTime256:
                                return this.exactTime256;
                            case GattNativeCharacteristicUuid.Humidity:
                                return this.humidity;
                            case GattNativeCharacteristicUuid.LocalTimeInformation:
                                return this.localTimeInfo;
                            case GattNativeCharacteristicUuid.PnPID:
                                return this.pPnPidParser;
                            case GattNativeCharacteristicUuid.Pressure:
                                return this.pressure;
                            case GattNativeCharacteristicUuid.PeripheralPreferredConnectionParameters:
                                return this.ppConnParamParser;
                            case GattNativeCharacteristicUuid.TemperatureinCelsius:
                                return this.temperatureCelcius;
                            case GattNativeCharacteristicUuid.TimeZone:
                                return this.timeZone;
                            #endregion



                            // TODO create parsers
                            case GattNativeCharacteristicUuid.AlertNotificationControlPoint:
                            case GattNativeCharacteristicUuid.AlertStatus:
                            case GattNativeCharacteristicUuid.AggregateInput:
                            // TODO - the 0x2A58 - input is described as both input and output
                            case GattNativeCharacteristicUuid.AnalogInput:
                            case GattNativeCharacteristicUuid.AnalogOutput:
                            // TODO - what is battery level state
                            case GattNativeCharacteristicUuid.BatteryLevelState:
                            case GattNativeCharacteristicUuid.BatteryPowerState:
                            case GattNativeCharacteristicUuid.BloodPressureFeature:
                            case GattNativeCharacteristicUuid.BloodPressureMeasurement:
                            case GattNativeCharacteristicUuid.BodySensorLocation:
                            case GattNativeCharacteristicUuid.BootKeyboardInputReport:
                            case GattNativeCharacteristicUuid.BootKeyboardOutputReport:
                            case GattNativeCharacteristicUuid.BootMouseInputReport:
                            case GattNativeCharacteristicUuid.CSCFeature:
                            case GattNativeCharacteristicUuid.CSCMeasurement:
                            case GattNativeCharacteristicUuid.CyclingPowerControlPoint:
                            case GattNativeCharacteristicUuid.CyclingPowerFeature:
                            case GattNativeCharacteristicUuid.CyclingPowerMeasurement:
                            case GattNativeCharacteristicUuid.CyclingPowerVector:
                            // 0x2A56 is the input. Can we also write out with it?
                            // spec says is is used to expose and change
                            case GattNativeCharacteristicUuid.DigitalInput:
                            case GattNativeCharacteristicUuid.DigitalOutput:
                            case GattNativeCharacteristicUuid.ExactTime100:
                            case GattNativeCharacteristicUuid.GlucoseFeature:
                            case GattNativeCharacteristicUuid.GlucoseMeasurement:
                            case GattNativeCharacteristicUuid.GlucoseMeasurementContext:
                            case GattNativeCharacteristicUuid.HeartRateControlPoint:
                            case GattNativeCharacteristicUuid.HeartRateMeasurement:
                            case GattNativeCharacteristicUuid.HIDControlPoint:
                            case GattNativeCharacteristicUuid.HIDInformation:
                            case GattNativeCharacteristicUuid.IEEE11073_20601RegulatoryCertificationDataList:
                            case GattNativeCharacteristicUuid.IntermediateCuffPressure:
                            case GattNativeCharacteristicUuid.IntermediateTemperature:
                            case GattNativeCharacteristicUuid.LNControlPoint:
                            case GattNativeCharacteristicUuid.LNFeature:
                            case GattNativeCharacteristicUuid.LocationandSpeed:
                            case GattNativeCharacteristicUuid.MeasurementInterval:
                            case GattNativeCharacteristicUuid.NewAlert:
                            case GattNativeCharacteristicUuid.Navigation:
                            case GattNativeCharacteristicUuid.NetworkAvailability:
                            case GattNativeCharacteristicUuid.PeripheralPrivacyFlag:
                            case GattNativeCharacteristicUuid.PositionQuality:
                            case GattNativeCharacteristicUuid.ProtocolMode:
                            case GattNativeCharacteristicUuid.PulseOximetryContinuousMeasurement:
                            case GattNativeCharacteristicUuid.PulseOximetryControlPoint:
                            case GattNativeCharacteristicUuid.PulseOximetryFeatures:
                            case GattNativeCharacteristicUuid.PulseOximetryPulsatileEvent:
                            case GattNativeCharacteristicUuid.ReconnectionAddress:
                            case GattNativeCharacteristicUuid.RecordAccessControlPoint:
                            case GattNativeCharacteristicUuid.ReferenceTimeInformation:
                            case GattNativeCharacteristicUuid.Report:
                            case GattNativeCharacteristicUuid.ReportMap:
                            case GattNativeCharacteristicUuid.RingerControlPoint:
                            case GattNativeCharacteristicUuid.RingerSetting:
                            case GattNativeCharacteristicUuid.RSCFeature:
                            case GattNativeCharacteristicUuid.RSCMeasurement:
                            case GattNativeCharacteristicUuid.SCControlPoint:
                            case GattNativeCharacteristicUuid.ScanIntervalWindow:
                            case GattNativeCharacteristicUuid.ScanRefresh:
                            case GattNativeCharacteristicUuid.ScientificTemperatureinCelsius:
                            case GattNativeCharacteristicUuid.SecondaryTimeZone:
                            case GattNativeCharacteristicUuid.SensorLocation:
                            case GattNativeCharacteristicUuid.ServiceChanged:
                            case GattNativeCharacteristicUuid.SimpleKeyState:
                            case GattNativeCharacteristicUuid.SupportedNewAlertCategory:
                            case GattNativeCharacteristicUuid.SupportedUnreadAlertCategory:
                            case GattNativeCharacteristicUuid.SystemID:
                            case GattNativeCharacteristicUuid.TemperatureMeasurement:
                            case GattNativeCharacteristicUuid.TemperatureType:
                            case GattNativeCharacteristicUuid.TimeAccuracy:
                            case GattNativeCharacteristicUuid.TimeSource:
                            case GattNativeCharacteristicUuid.TimeUpdateControlPoint:
                            case GattNativeCharacteristicUuid.TimeUpdateState:
                            case GattNativeCharacteristicUuid.TimewithDST:
                            case GattNativeCharacteristicUuid.TxPowerLevel:
                            case GattNativeCharacteristicUuid.TemperatureinFahrenheit:
                            case GattNativeCharacteristicUuid.TimeBroadcast:
                            case GattNativeCharacteristicUuid.UnreadAlertStatus:

                            case GattNativeCharacteristicUuid.None:
                            default:
                                return this.defaultParser;
                        }
                    }
                    else {
                        this.log.Error(9999, "GetParser", () =>
                            string.Format("Failed to parse out Guid:{0}", characteristicUuid.ToString()));
                        return this.defaultParser;
                    }
                });

                return report.Code == 0 ? parser : null;
        }
    }
}
