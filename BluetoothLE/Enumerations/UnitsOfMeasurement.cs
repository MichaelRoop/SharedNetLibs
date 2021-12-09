namespace BluetoothLE.Net.Enumerations {

    /// <summary>
    /// Units of measurement from the BLE SIG
    /// https://www.bluetooth.com/specifications/assigned-numbers/units/
    /// </summary>
    public enum UnitsOfMeasurement : ushort {
        // This is not the spec but it could come in if user does not set it
        Unknown = 0x0000,

        // Spec Units
        Unitless = 0x2700,
        LengthMetre = 0x2701,
        MassKilogram = 0x2702,
        TimeSecond = 0x2703,
        ElectricCurrentAampere = 0x2704,
        ThermodynamicTemperatureKelvin = 0x2705,
        AmountOfSubstanceMole = 0x2706,
        LuminousIntensityCandela = 0x2707,
        AreaSquareMetres = 0x2710,
        VolumeCubicMetres = 0x2711,
        VelocityMetresPerSecond = 0x2712,
        AccelerationMetresPerSecondSquared = 0x2713,
        WavenumberReciprocalMetre = 0x2714,
        DensityKilogramPerCubicMetre = 0x2715,
        SurfaceDensityKilogramPerSquareMetre = 0x2716,
        SpecificVolumeCubicMetrePerKilogram = 0x2717,
        CurrentDensityAmperePerSquareMetre = 0x2718,
        MagneticFieldStrengthAmperePerMetre = 0x2719,
        AmountConcentrationMolePerCubicMetre = 0x271A,
        MassConcentrationKilogramPerCubicMetre = 0x271B,
        LuminanceCandelaPerSquareMetre = 0x271C,
        RefractiveIndex = 0x271D,
        RelativePermeability = 0x271E,
        PlaneAngleRadian = 0x2720,
        SolidAangleSteradian = 0x2721,
        FrequencyHhertz = 0x2722,
        ForceNewton = 0x2723,
        PressurePascal = 0x2724,
        EnergyJoule = 0x2725,
        PowerWatt = 0x2726,
        ElectricChargeCoulomb = 0x2727,
        ElectricPotentialDifferenceVolt = 0x2728,
        CapacitanceFarad = 0x2729,
        ElectricResistanceOhm = 0x272A,
        ElectricConductanceSiemens = 0x272B,
        MagneticFluxWeber = 0x272C,
        MagneticFluxDensityTesla = 0x272D,
        InductanceHenry = 0x272E,
        CelsiusTemperatureDegreeCelsius = 0x272F,
        LuminousFluxLlumen = 0x2730,
        IlluminanceLlux = 0x2731,
        ActivityReferredToARadionuclideBecquerel = 0x2732,
        AbsorbedDoseGray = 0x2733,
        DoseEquivalentSievert = 0x2734,
        CatalyticActivityKatal = 0x2735,
        DynamicViscosityPascalSecond = 0x2740,
        MomentOfForceNewtonMetre = 0x2741,
        SurfaceTensionNewtonPerMetre = 0x2742,
        AngularVelocityRradianPerSecond = 0x2743,
        AngularAccelerationRradianPerSecondSquared = 0x2744,
        HeatFluxDensityWattPerSquareMetre = 0x2745,
        HeatCapacityJoulePerKelvin = 0x2746,
        SpecificHeatCapacityJoulePerKilogramKelvin = 0x2747,
        SpecificEnergyJoulePerKilogram = 0x2748,
        ThermalConductivityWattPerMetreKelvin = 0x2749,
        EnergyDensityJoulePerCubicMetre = 0x274A,
        ElectricFieldStrengthVoltPerMetre = 0x274B,
        ElectricChargeDensityCoulombPerCubicMetre = 0x274C,
        SurfaceChargeDensityCoulombPerSquareMetre = 0x274D,
        ElectricFluxDensityCoulombPerSquareMetre = 0x274E,
        PermittivityFaradPerMetre = 0x274F,
        PermeabilityHenryPerMetre = 0x2750,
        MolarEnergyJoulePerMole = 0x2751,
        MolarEntropyJoulePerMoleKelvin = 0x2752,
        ExposureCoulombPerKilogram = 0x2753,
        AbsorbedDoseRateGrayPerSecond = 0x2754,
        RadiantIntensityWattPerSteradian = 0x2755,
        RadianceWattPerSquareMetreSteradian = 0x2756,
        CatalyticActivityConcentrationKatalPerCubicMetre = 0x2757,
        TimeMinute = 0x2760,
        TimeHour = 0x2761,
        TimeDay = 0x2762,
        PlaneAngleDegree = 0x2763,
        PlaneAngleMinute = 0x2764,
        PlaneAngleSecond = 0x2765,
        AreaHectare = 0x2766,
        VolumeLitre = 0x2767,
        MassTonne = 0x2768,
        PressureBar = 0x2780,
        PressureMillimetreOfMercury = 0x2781,
        LengthÅngström = 0x2782,
        LengthNauticalMile = 0x2783,
        AreaBarn = 0x2784,
        VelocityKnot = 0x2785,
        LogarithmicRadioQuantityNneper = 0x2786,
        LogarithmicRadioQuantityBel = 0x2787,
        LengthYard = 0x27A0,
        LengthParsec = 0x27A1,
        LengthInch = 0x27A2,
        LengthFoot = 0x27A3,
        LengthMile = 0x27A4,
        PressurePoundForcePerSquareInch = 0x27A5,
        VelocityKilometrePerHour = 0x27A6,
        VelocityMilePerHour = 0x27A7,
        AngularVelocityRevolutionPerMinute = 0x27A8,
        EnergyGramCalorie = 0x27A9,
        EnergyKilogramCalorie = 0x27AA,
        EnergyKilowattHour = 0x27AB,
        ThermodynamicTemperatureDegreeFahrenheit = 0x27AC,
        Percentage = 0x27AD,
        PerMille = 0x27AE,
        PeriodBeatsPerMinute = 0x27AF,
        ElectricChargeAmpereHours = 0x27B0,
        MassDensityMilligramPerDecilitre = 0x27B1,
        MassDensityMillimolePerLitre = 0x27B2,
        TimeYear = 0x27B3,
        TimeMmonth = 0x27B4,
        ConcentrationCountPerCubicMetre = 0x27B5,
        IrradianceWwattPerSquareMetre = 0x27B6,
        MilliliterPerKilogramPerMinute = 0x27B7,
        MassPound = 0x27B8,
        MetabolicEquivalent = 0x27B9,
        StepPerMinute = 0x27BA,
        StrokePerMinute = 0x27BC,
        PaceKilometrePerMinute = 0x27BD,
        LuminousEfficacyLlumenPerWatt = 0x27BE,
        LuminousEnergyLumenHour = 0x27BF,
        LuminousExposureLuxHour = 0x27C0,
        MassFlowGramPerSecond = 0x27C1,
        VolumeFlowLlitrePerSecond = 0x27C2,
        SoundPressureDecibel = 0x27C3,
        ConcentrationPartsPerMillion = 0x27C4,
        ConcentrationPartsPerBillion = 0x27C5,

        // My enum
        NOT_HANDLED = 0xFFFF,
    }


    public static class UnitsOfMeasurementExtensions {

        public static UInt16 ToUint16(this UnitsOfMeasurement value) {
            return (UInt16)value;
        }


        public static string ToStr(this UnitsOfMeasurement units) {
#pragma warning disable IDE0066 // Convert switch statement to expression
            switch (units) {
#pragma warning restore IDE0066 // Convert switch statement to expression
                case UnitsOfMeasurement.LengthMetre:
                    return "m";
                #region Mass
                case UnitsOfMeasurement.MassKilogram:
                    return "kg";
                case UnitsOfMeasurement.MassConcentrationKilogramPerCubicMetre:
                    return "";
                case UnitsOfMeasurement.MassTonne:
                    return "t";
                case UnitsOfMeasurement.MassDensityMilligramPerDecilitre:
                    return "";
                case UnitsOfMeasurement.MassDensityMillimolePerLitre:
                    return "";
                case UnitsOfMeasurement.MassPound:
                    return "lb";
                case UnitsOfMeasurement.MassFlowGramPerSecond:
                    return "";
                #endregion
                #region Time
                case UnitsOfMeasurement.TimeSecond:
                    return "s";
                case UnitsOfMeasurement.TimeMinute:
                    return "m";
                case UnitsOfMeasurement.TimeHour:
                    return "h";
                case UnitsOfMeasurement.TimeDay:
                    return "d";
                case UnitsOfMeasurement.TimeYear:
                    return "y";
                case UnitsOfMeasurement.TimeMmonth:
                    return "";
                #endregion
                #region Speed
                case UnitsOfMeasurement.VelocityKnot:
                    return "kn";
                case UnitsOfMeasurement.VelocityKilometrePerHour:
                    return "kph";
                case UnitsOfMeasurement.VelocityMilePerHour:
                    return "mph";
                #endregion
                #region Length
                case UnitsOfMeasurement.LengthYard:
                    return "yd";
                case UnitsOfMeasurement.LengthParsec:
                    return "";
                case UnitsOfMeasurement.LengthInch:
                    return "in";
                case UnitsOfMeasurement.LengthFoot:
                    return "ft";
                case UnitsOfMeasurement.LengthMile:
                    return "";
                #endregion
                #region Velocity
                case UnitsOfMeasurement.VelocityMetresPerSecond:
                    return "m/s";
                case UnitsOfMeasurement.AngularVelocityRradianPerSecond:
                    return "rad/s";
                case UnitsOfMeasurement.AngularVelocityRevolutionPerMinute:
                    return "rpm";
                #endregion

                case UnitsOfMeasurement.ElectricCurrentAampere:
                    return "A";
                case UnitsOfMeasurement.ThermodynamicTemperatureKelvin:
                    return "K";
                case UnitsOfMeasurement.AmountOfSubstanceMole:
                    return "mol";
                case UnitsOfMeasurement.LuminousIntensityCandela:
                    return "cd";
                case UnitsOfMeasurement.AreaSquareMetres:
                    return "m2";
                case UnitsOfMeasurement.VolumeCubicMetres:
                    return "m3";
                case UnitsOfMeasurement.AccelerationMetresPerSecondSquared:
                    return "m/s2";
                case UnitsOfMeasurement.DensityKilogramPerCubicMetre:
                    return "kg/m3";
                case UnitsOfMeasurement.SurfaceDensityKilogramPerSquareMetre:
                    return "kg/m2";
                case UnitsOfMeasurement.SpecificVolumeCubicMetrePerKilogram:
                    return "m3/kg";
                case UnitsOfMeasurement.AmountConcentrationMolePerCubicMetre:
                    return "mol/m3";
                case UnitsOfMeasurement.LuminanceCandelaPerSquareMetre:
                    return "cd/m2";
                case UnitsOfMeasurement.FrequencyHhertz:
                    return "Hz";
                case UnitsOfMeasurement.ForceNewton:
                    return "N";
                case UnitsOfMeasurement.PressurePascal:
                    return "Pa";
                case UnitsOfMeasurement.EnergyJoule:
                    return "J";
                case UnitsOfMeasurement.PowerWatt:
                    return "W";
                case UnitsOfMeasurement.ElectricChargeCoulomb:
                    return "C";
                case UnitsOfMeasurement.ElectricPotentialDifferenceVolt:
                    return "V";
                case UnitsOfMeasurement.CapacitanceFarad:
                    return "F";
                case UnitsOfMeasurement.ElectricResistanceOhm:
                    // ALT-234 - not working. turn off mouse keys?
                    return "Ω";
                case UnitsOfMeasurement.ElectricConductanceSiemens:
                    return "S";
                case UnitsOfMeasurement.InductanceHenry:
                    return "H";
                case UnitsOfMeasurement.IlluminanceLlux:
                    return "lx";
                case UnitsOfMeasurement.ActivityReferredToARadionuclideBecquerel:
                    return "Bq";
                case UnitsOfMeasurement.AbsorbedDoseGray:
                    return "Gy";
                case UnitsOfMeasurement.DoseEquivalentSievert:
                    return "Sv";
                case UnitsOfMeasurement.VolumeLitre:
                    return "l";
                case UnitsOfMeasurement.EnergyKilowattHour:
                    return "kWh";
                case UnitsOfMeasurement.ThermodynamicTemperatureDegreeFahrenheit:
                    return "F";
                case UnitsOfMeasurement.Percentage:
                    return "%";
                case UnitsOfMeasurement.PlaneAngleRadian:
                    return "rad";
                case UnitsOfMeasurement.SolidAangleSteradian:
                    return "sr";
                case UnitsOfMeasurement.MagneticFluxWeber:
                    return "Wb";
                case UnitsOfMeasurement.MagneticFluxDensityTesla:
                    return "T";
                case UnitsOfMeasurement.CatalyticActivityKatal:
                    return "kat";
                case UnitsOfMeasurement.WavenumberReciprocalMetre:
                    return "m−1";
                case UnitsOfMeasurement.MagneticFieldStrengthAmperePerMetre:
                    return "A/m";
                case UnitsOfMeasurement.CurrentDensityAmperePerSquareMetre:
                    return "A/m2";
                case UnitsOfMeasurement.DynamicViscosityPascalSecond:
                    return "Pa-s";
                case UnitsOfMeasurement.MomentOfForceNewtonMetre:
                    return "N-m";
                case UnitsOfMeasurement.SurfaceTensionNewtonPerMetre:
                    return "N/m";
                case UnitsOfMeasurement.AngularAccelerationRradianPerSecondSquared:
                    return "rad/s2";
                case UnitsOfMeasurement.HeatFluxDensityWattPerSquareMetre:
                    return "W/m2";
                case UnitsOfMeasurement.HeatCapacityJoulePerKelvin:
                    return "J/K";
                case UnitsOfMeasurement.SpecificHeatCapacityJoulePerKilogramKelvin:
                    return "J/(kg⋅K)";
                case UnitsOfMeasurement.SpecificEnergyJoulePerKilogram:
                    return "J/kg";
                case UnitsOfMeasurement.ThermalConductivityWattPerMetreKelvin:
                    return "W/(m⋅K)";
                case UnitsOfMeasurement.EnergyDensityJoulePerCubicMetre:
                    return "J/m3";
                case UnitsOfMeasurement.ElectricFieldStrengthVoltPerMetre:
                    return "V/m";
                case UnitsOfMeasurement.ElectricChargeDensityCoulombPerCubicMetre:
                    return "C/m3";
                case UnitsOfMeasurement.SurfaceChargeDensityCoulombPerSquareMetre:
                    return "C/m2";
                case UnitsOfMeasurement.ElectricFluxDensityCoulombPerSquareMetre:
                    return "C/m2";
                case UnitsOfMeasurement.PermittivityFaradPerMetre:
                    return "F/m";
                case UnitsOfMeasurement.PermeabilityHenryPerMetre:
                    return "H/m";
                case UnitsOfMeasurement.MolarEnergyJoulePerMole:
                    return "J/mol";
                case UnitsOfMeasurement.MolarEntropyJoulePerMoleKelvin:
                    return "J/(mol⋅K)";
                case UnitsOfMeasurement.ExposureCoulombPerKilogram:
                    return "C/kg";
                case UnitsOfMeasurement.AbsorbedDoseRateGrayPerSecond:
                    return "Gy/s";
                case UnitsOfMeasurement.RadiantIntensityWattPerSteradian:
                    return "W/sr";
                case UnitsOfMeasurement.RadianceWattPerSquareMetreSteradian:
                    return "W/(m2⋅sr)";
                case UnitsOfMeasurement.CatalyticActivityConcentrationKatalPerCubicMetre:
                    return "kat/m3";
                case UnitsOfMeasurement.AreaHectare:
                    return "ha";
                case UnitsOfMeasurement.PlaneAngleDegree:
                    return "°";
                case UnitsOfMeasurement.PlaneAngleMinute:
                    return "′";
                case UnitsOfMeasurement.PlaneAngleSecond:
                    return "″";
                case UnitsOfMeasurement.LogarithmicRadioQuantityNneper:
                    return "Np";
                case UnitsOfMeasurement.LogarithmicRadioQuantityBel:
                    return "B";
                case UnitsOfMeasurement.SoundPressureDecibel:
                    return "dB";
                case UnitsOfMeasurement.LuminousFluxLlumen:
                    return "lm";
                case UnitsOfMeasurement.LuminousExposureLuxHour:
                    return "lx/h";
                case UnitsOfMeasurement.IrradianceWwattPerSquareMetre:
                    return "W/m2";


                case UnitsOfMeasurement.RefractiveIndex:
                    return "";
                case UnitsOfMeasurement.RelativePermeability:
                    return "";
                case UnitsOfMeasurement.CelsiusTemperatureDegreeCelsius:
                    return "";
                case UnitsOfMeasurement.PressureBar:
                    return "";
                case UnitsOfMeasurement.PressureMillimetreOfMercury:
                    return "";
                case UnitsOfMeasurement.LengthÅngström:
                    return "";
                case UnitsOfMeasurement.LengthNauticalMile:
                    return "";
                case UnitsOfMeasurement.AreaBarn:
                    return "";
                case UnitsOfMeasurement.PressurePoundForcePerSquareInch:
                    return "";
                case UnitsOfMeasurement.EnergyGramCalorie:
                    return "";
                case UnitsOfMeasurement.EnergyKilogramCalorie:
                    return "";
                case UnitsOfMeasurement.PerMille:
                    return "";
                case UnitsOfMeasurement.PeriodBeatsPerMinute:
                    return "";
                case UnitsOfMeasurement.ElectricChargeAmpereHours:
                    return "";
                case UnitsOfMeasurement.ConcentrationCountPerCubicMetre:
                    return "";
                case UnitsOfMeasurement.MilliliterPerKilogramPerMinute:
                    return "";
                case UnitsOfMeasurement.MetabolicEquivalent:
                    return "";
                case UnitsOfMeasurement.StepPerMinute:
                    return "";
                case UnitsOfMeasurement.StrokePerMinute:
                    return "";
                case UnitsOfMeasurement.PaceKilometrePerMinute:
                    return "";
                case UnitsOfMeasurement.LuminousEfficacyLlumenPerWatt:
                    return "";
                case UnitsOfMeasurement.LuminousEnergyLumenHour:
                    return "";
                case UnitsOfMeasurement.VolumeFlowLlitrePerSecond:
                    return "";
                case UnitsOfMeasurement.ConcentrationPartsPerMillion:
                    return "";
                case UnitsOfMeasurement.ConcentrationPartsPerBillion:
                    return "";
                case UnitsOfMeasurement.Unitless:
                case UnitsOfMeasurement.NOT_HANDLED:
                default:
                    return "";
            }
        }


    }



}
