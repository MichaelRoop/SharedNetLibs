using BluetoothLE.Net.interfaces;
using BluetoothLE.Net.Parsers.Types;
using ChkUtils.Net;
using ChkUtils.Net.ErrObjects;
using LogUtils.Net;
using System;

namespace BluetoothLE.Net.Parsers.Characteristics {

    /// <summary>Factory to process Characteristic byte read</summary>
    public class CharParserFactory : ICharParserFactory {

        #region Data

        private ClassLog log = new ClassLog("CharParserFactory");

        #endregion


        public ICharParser GetParser(Guid characteristicUuid, UInt16 handle) {
            ErrReport report;
            ICharParser parser = WrapErr.ToErrReport<ICharParser>(out report, 9999,
                () => string.Format("Failed to find characteristic parser"),
                () => {
                    if (BLE_ParseHelpers.IsSigDefinedUuid(characteristicUuid)) {
                        GattNativeCharacteristicUuid charEnum = BLE_ParseHelpers.GetCharacteristicEnum(characteristicUuid, "");
                        switch (charEnum) {
                            #region String formaters
                            // Common UTF8 strings    
                            case GattNativeCharacteristicUuid.DeviceName:
                            //case GattNativeCharacteristicUuid.String: // TODO - change in Arduino
                            case GattNativeCharacteristicUuid.ManufacturerNameString:
                            case GattNativeCharacteristicUuid.ModelNumberString:
                            case GattNativeCharacteristicUuid.HardwareRevisionString:
                            case GattNativeCharacteristicUuid.FirmwareRevisionString:
                            case GattNativeCharacteristicUuid.SerialNumberString:
                            case GattNativeCharacteristicUuid.SoftwareRevisionString:
                            case GattNativeCharacteristicUuid.FirstName:
                            case GattNativeCharacteristicUuid.Language:
                            case GattNativeCharacteristicUuid.LocationName:
                                return new CharParser_String();
                            #endregion
                            #region Assigned parsers
                            case GattNativeCharacteristicUuid.AlertCategoryID:
                                return new CharParser_AlertCategoryID();
                            case GattNativeCharacteristicUuid.AlertCategoryIDBitMask:
                                return new CharParser_AlertCategoryIDBitmask();
                            case GattNativeCharacteristicUuid.AlertLevel:
                                return new CharParser_AlertLevel();
                            case GattNativeCharacteristicUuid.Appearance:
                                return new CharParser_Appearance();
                            case GattNativeCharacteristicUuid.BatteryLevel:
                                return new CharParser_BatteryLevel();
                            case GattNativeCharacteristicUuid.CurrentTime:
                                return new CharParser_CurrentTime();

                            case GattNativeCharacteristicUuid.DateTime:
                            case GattNativeCharacteristicUuid.ObjectFirstCreated:
                            case GattNativeCharacteristicUuid.ObjectLastModified:
                                return new TypeParserDateTime();

                            case GattNativeCharacteristicUuid.DayDateTime:
                                return new TypeParserDayDateTime();
                            case GattNativeCharacteristicUuid.DayofWeek:
                                return new TypeParserDayOfWeek();
                            case GattNativeCharacteristicUuid.DSTOffset:
                                return new CharParser_DaylightSavingsTimeOffset();
                            case GattNativeCharacteristicUuid.ExactTime256:
                                return new TypeParserExactTime256();
                            case GattNativeCharacteristicUuid.Humidity:
                                return new CharParser_Humidity();
                            case GattNativeCharacteristicUuid.LocalTimeInformation:
                                return new CharParser_LocalTimeInformation();
                            case GattNativeCharacteristicUuid.PnPID:
                                return new CharParser_PPnPID();
                            case GattNativeCharacteristicUuid.Pressure:
                                return new CharParser_Pressure();
                            case GattNativeCharacteristicUuid.PeripheralPreferredConnectionParameters:
                                return new CharParser_PeripheralPrefferedConnectParams();
                            //case GattNativeCharacteristicUuid.TemperatureinCelsius:
                            case GattNativeCharacteristicUuid.Temperature:
                                return new CharParser_Temperature();
                            case GattNativeCharacteristicUuid.TimeZone:
                                return new CharParser_TimeZone();

                            // will need to sort all of these
                            case GattNativeCharacteristicUuid.DateOfBirth:
                                return new CharParser_DateOfBirth();
                            case GattNativeCharacteristicUuid.AlertStatus:
                                return new CharParser_AlertStatus();
                            case GattNativeCharacteristicUuid.Altitude:
                                return new CharParser_Uint16();

                            #endregion

                            #region Uint8

                            // These are exponent 0 - not sure what that means
                            case GattNativeCharacteristicUuid.AerobicHeartRateUpperLimit:
                            case GattNativeCharacteristicUuid.AerobicHeartRateLowerLimit:
                            case GattNativeCharacteristicUuid.AerobicThreshold:
                            case GattNativeCharacteristicUuid.AnaerobicHeartRateLowerLimit:
                            case GattNativeCharacteristicUuid.AnaerobicHeartRateUpperLimit:
                            case GattNativeCharacteristicUuid.AnaerobicThreshold:
                            // regular uint8
                            case GattNativeCharacteristicUuid.Age:
                            case GattNativeCharacteristicUuid.FloorNumber:
                                return new CharParser_Uint8();
                            #endregion


                            // TODO create parsers
                            case GattNativeCharacteristicUuid.AlertNotificationControlPoint:
                            case GattNativeCharacteristicUuid.AggregateInput:
                            //case GattNativeCharacteristicUuid.AnalogInput:
                            //case GattNativeCharacteristicUuid.AnalogOutput:
                            //case GattNativeCharacteristicUuid.BatteryLevelState:
                            //case GattNativeCharacteristicUuid.BatteryPowerState:
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
                            //case GattNativeCharacteristicUuid.DigitalInput:
                            //case GattNativeCharacteristicUuid.DigitalOutput:
                            //case GattNativeCharacteristicUuid.ExactTime100:
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
                            case GattNativeCharacteristicUuid.Elevation:
                            case GattNativeCharacteristicUuid.LNFeature:
                            case GattNativeCharacteristicUuid.LocationandSpeed:
                            case GattNativeCharacteristicUuid.MeasurementInterval:
                            case GattNativeCharacteristicUuid.NewAlert:
                            case GattNativeCharacteristicUuid.Navigation:
                            //case GattNativeCharacteristicUuid.NetworkAvailability:
                            case GattNativeCharacteristicUuid.PeripheralPrivacyFlag:
                            case GattNativeCharacteristicUuid.PositionQuality:
                            case GattNativeCharacteristicUuid.ProtocolMode:
                            case GattNativeCharacteristicUuid.PulseOximetryContinuousMeasurement:
                            //case GattNativeCharacteristicUuid.PulseOximetryControlPoint:
                            case GattNativeCharacteristicUuid.PulseOximetryFeatures:
                            //case GattNativeCharacteristicUuid.PulseOximetryPulsatileEvent:
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
                            //case GattNativeCharacteristicUuid.ScientificTemperatureinCelsius:
                            //case GattNativeCharacteristicUuid.SecondaryTimeZone:
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
                            //case GattNativeCharacteristicUuid.TemperatureinFahrenheit:
                            //case GattNativeCharacteristicUuid.TimeBroadcast:
                            case GattNativeCharacteristicUuid.UnreadAlertStatus:


                            // ---------------------------------
                            // Newly added
                            // ---------------------------------
                            case GattNativeCharacteristicUuid.TrueWindSpeed:
                            case GattNativeCharacteristicUuid.TrueWindDirection:
                            case GattNativeCharacteristicUuid.ApparentWindSpeed:
                            case GattNativeCharacteristicUuid.ApparentWindDirection:
                            case GattNativeCharacteristicUuid.GustFactor:
                            case GattNativeCharacteristicUuid.PollenConcentration:
                            case GattNativeCharacteristicUuid.UvIndex:
                            case GattNativeCharacteristicUuid.Irradiance:
                            case GattNativeCharacteristicUuid.Rainfall:
                            case GattNativeCharacteristicUuid.WindChill:
                            case GattNativeCharacteristicUuid.HeatIndex:
                            case GattNativeCharacteristicUuid.DewPoint:
                            case GattNativeCharacteristicUuid.DescriptorValueChanged:
                            case GattNativeCharacteristicUuid.DateOfThresholdAssessment:
                            case GattNativeCharacteristicUuid.EmailAddress:
                            case GattNativeCharacteristicUuid.FatBurnHeartRateLowerLimit:
                            case GattNativeCharacteristicUuid.FatBurnHeartRateUpperLimit:
                            case GattNativeCharacteristicUuid.FiveZoneHeartRateLimits:
                            case GattNativeCharacteristicUuid.Gender:
                            case GattNativeCharacteristicUuid.HeartRateMax:
                            case GattNativeCharacteristicUuid.Height:
                            case GattNativeCharacteristicUuid.HipCircumference:
                            case GattNativeCharacteristicUuid.LastName:
                            case GattNativeCharacteristicUuid.MaximumRecommendedHeartRate:
                            case GattNativeCharacteristicUuid.RestingHeartRate:
                            case GattNativeCharacteristicUuid.SportTypeforAerobicAndAnaerobicThresholds:
                            case GattNativeCharacteristicUuid.ThreeZoneHeartRateLimits:
                            case GattNativeCharacteristicUuid.TwoZoneHeartRateLimits:
                            case GattNativeCharacteristicUuid.Vo2Max:
                            case GattNativeCharacteristicUuid.WaistCircumference:
                            case GattNativeCharacteristicUuid.Weight:
                            case GattNativeCharacteristicUuid.DatabaseChangeIncrement:
                            case GattNativeCharacteristicUuid.UserIndex:
                            case GattNativeCharacteristicUuid.BodyCompositionFeature:
                            case GattNativeCharacteristicUuid.BodyCompositionMeasurement:
                            case GattNativeCharacteristicUuid.WeightMeasurement:
                            case GattNativeCharacteristicUuid.WeightScaleFeature:
                            case GattNativeCharacteristicUuid.UserControlPoint:
                            case GattNativeCharacteristicUuid.MagneticFluxDensity2d:
                            case GattNativeCharacteristicUuid.MagneticFluxDensity3d:
                            case GattNativeCharacteristicUuid.BarometricPressureTrend:
                            case GattNativeCharacteristicUuid.BondManagementControlPoint:
                            case GattNativeCharacteristicUuid.BondManagementFeature:
                            case GattNativeCharacteristicUuid.CentralAddressResolution:
                            case GattNativeCharacteristicUuid.CGMMeasurement:
                            case GattNativeCharacteristicUuid.CGMFeature:
                            case GattNativeCharacteristicUuid.CGMStatus:
                            case GattNativeCharacteristicUuid.CGMSessionStartTime:
                            case GattNativeCharacteristicUuid.CGMSessionRunTime:
                            case GattNativeCharacteristicUuid.CGMSpecificOpsControlPoint:
                            case GattNativeCharacteristicUuid.IndoorPositioningConfiguration:
                            case GattNativeCharacteristicUuid.Latitude:
                            case GattNativeCharacteristicUuid.Longitude:
                            case GattNativeCharacteristicUuid.LocalNorthCoordinate:
                            case GattNativeCharacteristicUuid.LocalEastCoordinate:
                            case GattNativeCharacteristicUuid.Uncertainty:
                            case GattNativeCharacteristicUuid.Uri:
                            case GattNativeCharacteristicUuid.HttpPHeaders:
                            case GattNativeCharacteristicUuid.HttpStatusCode:
                            case GattNativeCharacteristicUuid.HttpEntityBody:
                            case GattNativeCharacteristicUuid.HttpControlPoint:
                            case GattNativeCharacteristicUuid.HttpSSecurity:
                            case GattNativeCharacteristicUuid.TdsControlPoint:
                            case GattNativeCharacteristicUuid.OtsFeature:
                            case GattNativeCharacteristicUuid.ObjectName:
                            case GattNativeCharacteristicUuid.ObjectType:
                            case GattNativeCharacteristicUuid.ObjectSize:
                            case GattNativeCharacteristicUuid.ObjectId:
                            case GattNativeCharacteristicUuid.ObjectProperties:
                            case GattNativeCharacteristicUuid.ObjectActionControlPoint:
                            case GattNativeCharacteristicUuid.ObjectListControlPoint:
                            case GattNativeCharacteristicUuid.ObjectListFilter:
                            case GattNativeCharacteristicUuid.ObjectChanged:
                            case GattNativeCharacteristicUuid.ResolvablePrivateAddressOnly:
                            case GattNativeCharacteristicUuid.Unspecified:
                            case GattNativeCharacteristicUuid.DirectoryListing:
                            case GattNativeCharacteristicUuid.FitnessMachineFeature:
                            case GattNativeCharacteristicUuid.TreadmillData:
                            case GattNativeCharacteristicUuid.CrossTrainerData:
                            case GattNativeCharacteristicUuid.StepClimberData:
                            case GattNativeCharacteristicUuid.StairClimberData:
                            case GattNativeCharacteristicUuid.RowerData:
                            case GattNativeCharacteristicUuid.IndoorBikeData:
                            case GattNativeCharacteristicUuid.TrainingStatus:
                            case GattNativeCharacteristicUuid.SupportedSpeedRange:
                            case GattNativeCharacteristicUuid.SupportedInclinationRange:
                            case GattNativeCharacteristicUuid.SupportedResistanceLevelRange:
                            case GattNativeCharacteristicUuid.SupportedHeartRateRange:
                            case GattNativeCharacteristicUuid.SupportedPowerRange:
                            case GattNativeCharacteristicUuid.FitnessMachineControlPoint:
                            case GattNativeCharacteristicUuid.FitnessMachineStatus:
                            case GattNativeCharacteristicUuid.MeshProvisioningDataIn:
                            case GattNativeCharacteristicUuid.MeshProvisioningDataOut:
                            case GattNativeCharacteristicUuid.MeshProxyDataIn:
                            case GattNativeCharacteristicUuid.MeshProxyDataOut:
                            case GattNativeCharacteristicUuid.AverageCurrent:
                            case GattNativeCharacteristicUuid.AverageVoltage:
                            case GattNativeCharacteristicUuid.Boolean:
                            case GattNativeCharacteristicUuid.ChromaticDistanceFromPlanckian:
                            case GattNativeCharacteristicUuid.ChromaticityCoordinates:
                            case GattNativeCharacteristicUuid.ChromaticityInCctAndDuvValues:
                            case GattNativeCharacteristicUuid.ChromaticityTolerance:
                            case GattNativeCharacteristicUuid.Cie_13_3_1995ColorRenderingIndex:
                            case GattNativeCharacteristicUuid.Coefficient:
                            case GattNativeCharacteristicUuid.CorrelatedColorTemperature:
                            case GattNativeCharacteristicUuid.Count16:
                            case GattNativeCharacteristicUuid.Count24:
                            case GattNativeCharacteristicUuid.CountryCode:
                            case GattNativeCharacteristicUuid.DateUtc:
                            case GattNativeCharacteristicUuid.ElectricCurrent:
                            case GattNativeCharacteristicUuid.ElectricCurrentRange:
                            case GattNativeCharacteristicUuid.ElectricCurrentSpecification:
                            case GattNativeCharacteristicUuid.ElectricCurrentStatistics:
                            case GattNativeCharacteristicUuid.Energy:
                            case GattNativeCharacteristicUuid.EnergyInAPeriodOfDay:
                            case GattNativeCharacteristicUuid.EventStatistics:
                            case GattNativeCharacteristicUuid.FixedString16:
                            case GattNativeCharacteristicUuid.FixedString24:
                            case GattNativeCharacteristicUuid.FixedString36:
                            case GattNativeCharacteristicUuid.FixedString8:
                            case GattNativeCharacteristicUuid.GenericLevel:
                            case GattNativeCharacteristicUuid.GlobalTradeItemNumber:
                            case GattNativeCharacteristicUuid.Illuminance:
                            case GattNativeCharacteristicUuid.LuminousEfficacy:
                            case GattNativeCharacteristicUuid.LuminousEnergy:
                            case GattNativeCharacteristicUuid.LuminousExposure:
                            case GattNativeCharacteristicUuid.LuminousFlux:
                            case GattNativeCharacteristicUuid.LuminousFluxRange:
                            case GattNativeCharacteristicUuid.LuminousIntensity:
                            case GattNativeCharacteristicUuid.MassFlow:
                            case GattNativeCharacteristicUuid.PerceivedLightness:
                            case GattNativeCharacteristicUuid.Percentage8:
                            case GattNativeCharacteristicUuid.Power:
                            case GattNativeCharacteristicUuid.PowerSpecification:
                            case GattNativeCharacteristicUuid.RelativeRuntimeInACurrentRange:
                            case GattNativeCharacteristicUuid.RelativeRuntimeInAGenericLevelRange:
                            case GattNativeCharacteristicUuid.RelativeValueInAVoltageRange:
                            case GattNativeCharacteristicUuid.RelativeValueInAnIlluminanceRange:
                            case GattNativeCharacteristicUuid.RelativeValueInAPeriodOfDay:
                            case GattNativeCharacteristicUuid.RelativeValueInATemperatureRange:
                            case GattNativeCharacteristicUuid.Temperature8:
                            case GattNativeCharacteristicUuid.Temperature8InAPeriodOfDay:
                            case GattNativeCharacteristicUuid.Temperature8Statistics:
                            case GattNativeCharacteristicUuid.TemperatureRange:
                            case GattNativeCharacteristicUuid.TemperatureStatistics:
                            case GattNativeCharacteristicUuid.TimeDecihour8:
                            case GattNativeCharacteristicUuid.TimeExponential8:
                            case GattNativeCharacteristicUuid.TimeHour24:
                            case GattNativeCharacteristicUuid.TimeMillisecond24:
                            case GattNativeCharacteristicUuid.TimeSecond16:
                            case GattNativeCharacteristicUuid.TimeSecond8:
                            case GattNativeCharacteristicUuid.Voltage:
                            case GattNativeCharacteristicUuid.VoltageSpecification:
                            case GattNativeCharacteristicUuid.VoltageStatistics:
                            case GattNativeCharacteristicUuid.VolumeFlow:
                            case GattNativeCharacteristicUuid.ChromaticityCoordinate:
                            case GattNativeCharacteristicUuid.RcFeature:
                            case GattNativeCharacteristicUuid.RcSettings:
                            case GattNativeCharacteristicUuid.ReconnectionConfigurationControlPoint:
                            case GattNativeCharacteristicUuid.IddStatusChanged:
                            case GattNativeCharacteristicUuid.IddStatus:
                            case GattNativeCharacteristicUuid.IddAnnunciationStatus:
                            case GattNativeCharacteristicUuid.IddFeatures:
                            case GattNativeCharacteristicUuid.IddStatusReaderControlPoint:
                            case GattNativeCharacteristicUuid.IddCommandControlPoint:
                            case GattNativeCharacteristicUuid.IddCommandData:
                            case GattNativeCharacteristicUuid.IddRecordAccessControlPoint:
                            case GattNativeCharacteristicUuid.IddHistoryData:
                            case GattNativeCharacteristicUuid.ClientSupportedFeatures:
                            case GattNativeCharacteristicUuid.DatabaseHash:
                            case GattNativeCharacteristicUuid.BssControlPoint:
                            case GattNativeCharacteristicUuid.BssResponse:
                            case GattNativeCharacteristicUuid.EmergencyID:
                            case GattNativeCharacteristicUuid.EmergencyText:
                            case GattNativeCharacteristicUuid.EnhancedBloodPressureMeasurement:
                            case GattNativeCharacteristicUuid.EnhancedIntermediateCuffPressure:
                            case GattNativeCharacteristicUuid.BloodPressureRecord:
                            case GattNativeCharacteristicUuid.Br_EdrHandoverData:
                            case GattNativeCharacteristicUuid.BluetoothSigData:
                            case GattNativeCharacteristicUuid.ServerSupportedFeatures:
                            case GattNativeCharacteristicUuid.PhysicalActivityMonitorFeatures:
                            case GattNativeCharacteristicUuid.GeneralActivityInstantaneousData:
                            case GattNativeCharacteristicUuid.GeneralActivitySummaryData:
                            case GattNativeCharacteristicUuid.CardioRespiratoryActivityInstantaneousData:
                            case GattNativeCharacteristicUuid.CardioRespiratoryActivitySummaryData:
                            case GattNativeCharacteristicUuid.StepCounterActivitySummaryData:
                            case GattNativeCharacteristicUuid.SleepActivityInstantaneousData:
                            case GattNativeCharacteristicUuid.SleepActivitySummaryData:
                            case GattNativeCharacteristicUuid.PhysicalActivityMonitorControlPoint:
                            case GattNativeCharacteristicUuid.CurrentSession:
                            case GattNativeCharacteristicUuid.Session:
                            case GattNativeCharacteristicUuid.PreferredUnits:
                            case GattNativeCharacteristicUuid.HighResolutionHeight:
                            case GattNativeCharacteristicUuid.MiddleName:
                            case GattNativeCharacteristicUuid.StrideLength:
                            case GattNativeCharacteristicUuid.Handedness:
                            case GattNativeCharacteristicUuid.DeviceWearingPosition:
                            case GattNativeCharacteristicUuid.FourZoneHeartRateLimits:
                            case GattNativeCharacteristicUuid.HighIntensityExerciseThreshold:
                            case GattNativeCharacteristicUuid.ActivityGoal:
                            case GattNativeCharacteristicUuid.SedentaryIntervalNotification:
                            case GattNativeCharacteristicUuid.CaloricIntake:
                            case GattNativeCharacteristicUuid.AudioInputState:
                            case GattNativeCharacteristicUuid.GainSettingsAttribute:
                            case GattNativeCharacteristicUuid.AudioInputType:
                            case GattNativeCharacteristicUuid.AudioInputStatus:
                            case GattNativeCharacteristicUuid.AudioInputControlPoint:
                            case GattNativeCharacteristicUuid.AudioInputDescription:
                            case GattNativeCharacteristicUuid.VolumeState:
                            case GattNativeCharacteristicUuid.VolumeControlPoint:
                            case GattNativeCharacteristicUuid.VolumeFlags:
                            case GattNativeCharacteristicUuid.OffsetState:
                            case GattNativeCharacteristicUuid.AudioLocation:
                            case GattNativeCharacteristicUuid.VolumeOffsetControlPoint:
                            case GattNativeCharacteristicUuid.AudioOutputDescription:
                            case GattNativeCharacteristicUuid.DeviceTimeFeature:
                            case GattNativeCharacteristicUuid.DeviceTimeParameters:
                            case GattNativeCharacteristicUuid.DeviceTime:
                            case GattNativeCharacteristicUuid.DeviceTimeControlPoint:
                            case GattNativeCharacteristicUuid.TimeChangeLogData:
                            case GattNativeCharacteristicUuid.ConstantToneExtensionEnable:
                            case GattNativeCharacteristicUuid.AdvertisingConstantToneExtensionMinimumLength:
                            case GattNativeCharacteristicUuid.AdvertisingConstantToneExtensionMinimumTransmitCount:
                            case GattNativeCharacteristicUuid.AdvertisingConstantToneExtensionTransmitDuration:
                            case GattNativeCharacteristicUuid.AdvertisingConstantToneExtensionInterval:
                            case GattNativeCharacteristicUuid.AdvertisingConstantToneExtensionPhy:

                            case GattNativeCharacteristicUuid.None:
                            default:
                                return new CharParser_Default();
                        }
                    }
                    else {
                        this.log.Error(9999, "GetParser", () =>
                            string.Format("Failed to parse out Guid:{0}", characteristicUuid.ToString()));
                        return new CharParser_Default();
                    }
                });
            if (report.Code == 0) {
                parser.AttributeHandle = handle;
                return parser;
            }
            return new CharParser_Default() { AttributeHandle = handle };
        }
    }
}
