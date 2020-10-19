using System;
using System.Collections.Generic;
using System.Text;

namespace WifiCommon.Net.DataModels {

    /// <summary>Information required to connect to a wifi network</summary>
    public class WifiCredentials {

        // TODO - a property to fill in and pass up. To determine if user name is required

        /// <summary>The password for the wifi network</summary>
        public string WifiPassword { get; set; }

        /// <summary>The user name for the wifi network, required for some protocols</summary>
        public string WifiUserName { get; set; }

        /// <summary>Socket host name or IP</summary>
        public string RemoteHostName { get; set; }

        /// <summary>Socket port such as 80 for HTTP</summary>
        public string RemoteServiceName { get; set; }

    }
}
