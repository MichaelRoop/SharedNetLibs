﻿using System;
using System.Collections.Generic;
using System.Text;
using WifiCommon.Net.Enumerations;

namespace WifiCommon.Net.DataModels {

    /// <summary>Information on one available WIFI network</summary>
    /// <remarks>
    /// https://docs.microsoft.com/en-us/uwp/api/windows.devices.wifi.wifiavailablenetwork?view=winrt-19041
    /// </remarks>
    public class WifiNetworkInfo {

        /// <summary></summary>
        public string SSID { get; set; } = "NA";

        /// <summary></summary>
        public NetworkKind Kind { get; set; } = NetworkKind.Infrastructure;

        /// <summary></summary>
        public TimeSpan BeaconInterval { get; set; } = TimeSpan.Zero;

        /// <summary></summary>
        public string MacAddress_BSSID { get; set; } = "";

        /// <summary></summary>
        public int ChanneCenterFrequencyKlhz { get; set; } = 0;

        /// <summary></summary>
        public bool IsWifiDirect { get; set; } = false;

        /// <summary></summary>
        public double RssiInDecibleMilliwatts { get; set; } = 0;

        /// <summary></summary>
        public WifiPhyPhysicalLayerKind PhysicalLayerKind { get; set; } = WifiPhyPhysicalLayerKind.Unknown;

        /// <summary>Security authentication</summary>
        public NetAuthenticationType AuthenticationType { get; set; } = NetAuthenticationType.None;

        /// <summary>Security encryption</summary>
        // Security settings
        public NetEncryptionType EncryptionType { get; set; } = NetEncryptionType.None;

        /// <summary></summary>
        public byte SignalStrengthInBars { get; set; } = 0;

        /// <summary></summary>
        public TimeSpan UpTime { get; set; } = TimeSpan.Zero;



    }
}
