using System;
using System.Collections.Generic;
using System.Text;

namespace Ethernet.Common.Net.DataModels {

    public class EthernetParams {

        /// <summary>Socket host name or IP</summary>
        public string EthernetAddress { get; set; } = string.Empty;

        /// <summary>Socket port such as 80 for HTTP</summary>
        public string EthernetServiceName { get; set; } = string.Empty;






    }
}
