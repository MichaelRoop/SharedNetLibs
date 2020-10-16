using System;
using System.Collections.Generic;
using System.Text;
using WifiCommon.Net.Enumerations;

namespace WifiCommon.Net.DataModels {

    /// <summary>Information on one available WIFI network</summary>
    /// <remarks>
    /// https://docs.microsoft.com/en-us/uwp/api/windows.devices.wifi.wifiavailablenetwork?view=winrt-19041
    /// </remarks>
    public class WifiNetworkInfo {

        public string SSID { get; set; } = "NA";
        public NetworkKind Kind { get; set; } = NetworkKind.Infrastructure;


    }
}
