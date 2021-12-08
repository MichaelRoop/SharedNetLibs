using LogUtils.Net;
using VariousUtils.Net;

namespace WifiCommon.Net.Enumerations {

    /// <summary>IANA (Internet Assigned Names Authority) WIFI interface types</summary>
    /// <remarks>
    /// https://docs.microsoft.com/en-us/uwp/api/windows.networking.connectivity.networkadapter.ianainterfacetype?view=winrt-19041#Windows_Networking_Connectivity_NetworkAdapter_IanaInterfaceType
    /// </remarks>
    public enum WifiIanaType : int {

        /// <summary>Added as a default when the type cannot be found</summary>
        Undefined = 0,
        Other = 1,
        Ethernet = 6,
        TokenRing = 9,
        PPP = 23,
        SoftwareLoopback = 24,
        ATM = 37,
        IEEE_802_11_Wireless = 71,
        TunnelEncapsulation = 131,
        IEEE_1394_Firewire = 144,

    }


    public static class WifiIanaTypeExtensions {
        public static WifiIanaType ToEnum(this uint value) {
            Log.Info("WifiIanaTypeExtensions", "ToEnum", () => string.Format("Casting {0} to enum", value));
            return EnumHelpers.ToEnum<WifiIanaType>((int)value);
        }


    }

}
