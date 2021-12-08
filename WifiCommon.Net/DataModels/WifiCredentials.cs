namespace WifiCommon.Net.DataModels {

    /// <summary>Information required to connect to a wifi network</summary>
    public class WifiCredentials {

        /// <summary>Determine if the user canceled the operation</summary>
        public bool IsUserCanceled { get; set; } = false;
        public bool IsUserSaveRequest { get; set; } = false;

        public string SSID { get; set; } = string.Empty;

        /// <summary>Part of MS to differentiate between networks with same SSID</summary>
        public Guid Id { get; set; } = Guid.Empty;

        // TODO - a property to fill in and pass up. To determine if user name is required

        /// <summary>The password for the wifi network</summary>
        public string WifiPassword { get; set; } = string.Empty;

        /// <summary>The user name for the wifi network, required for some protocols</summary>
        public string WifiUserName { get; set; } = string.Empty;

        /// <summary>Socket host name or IP</summary>
        public string RemoteHostName { get; set; } = string.Empty;

        /// <summary>Socket port such as 80 for HTTP</summary>
        public string RemoteServiceName { get; set; } = string.Empty;

    }
}
