using System;
using System.Collections.Generic;
using System.Text;

namespace WifiCommon.Net.Enumerations {
    
    /// <summary>Physical layer characteristics</summary>
    public enum WifiPhyPhysicalLayerKind : int {

        /// <summary>Unspecified PHY type</summary>
        Unknown = 0,

        /// <summary>Frequency-hopping, spread-spectrum (FHSS) PHY</summary>
        FHSS_FrequencyHoppingSpreadSpectrum = 1,

        /// <summary>Direct sequence, spread-spectrum (DSSS) PHY</summary>
        DSSS_DirectSequenceSpreadSpectrum = 2,

        /// <summary>Infrared (IR) baseband PHY</summary>
        IR_IRBaseband = 3,

        /// <summary>Orthogonal frequency division multiplex (OFDM) PHY</summary>
        OFDM_OrthogonalFrequencyDivisionMultiplex = 4,

        /// <summary>High-rated DSSS (HRDSSS) PHY</summary>
        HRDSSS_HighRatedDsss = 5,

        /// <summary>Extended Rate (ERP) PHY</summary>
        ERP_ExtendedRate = 6,

        /// <summary>High Throughput (HT) PHY for 802.11n PHY</summary>
        HT_High_Throughput_802_11n = 7,

        /// <summary>Very High Throughput (VHT) PHY for 802.11ac PHY</summary>
        VHT_VeryHighThroughput_802_11ac = 8,

        /// <summary>Directional multi-gigabit (DMG) PHY for 802.11ad</summary>
        DMG_DirectionalMultiGigabit_802_11ad = 9,

        /// <summary>High-Efficiency Wireless (HEW) PHY for 802.11ax</summary>
        HE_HighEfficiencyWireless_802_11ax = 10,

    }
}
