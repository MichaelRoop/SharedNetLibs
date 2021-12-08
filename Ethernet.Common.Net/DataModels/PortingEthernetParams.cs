namespace Ethernet.Common.Net.DataModels {

    /// <summary>This file is to port Ethernet data over to object with Extra Index info</summary>
    /// <remarks>
    /// TODO
    /// Created in March 6, 2021 so I should be able to get rid of it in a year. Only 300 Apps
    /// out there with likely no one using Ethernet
    /// JSON needed to find the same file name and path but it has since been moved
    /// </remarks>
    public class EthernetParams {
        /// <summary>Used for storage item unique identifier</summary>
        public string UId { get; set; } = Guid.Empty.ToString();

        /// <summary>User friendly identifier</summary>
        public string Display { get; set; } = string.Empty;

        /// <summary>Socket host name or IP</summary>
        public string EthernetAddress { get; set; } = string.Empty;

        /// <summary>Socket port such as 80 for HTTP</summary>
        public string EthernetServiceName { get; set; } = string.Empty;


        public string DisplayString {
            get {
                string name = this.Display.Length > 0
                    ? string.Format("{0}:{1}:{2}", this.Display, this.EthernetAddress, this.EthernetServiceName)
                    : string.Format("{0}:{1}", this.EthernetAddress, this.EthernetServiceName);
                return name;
            }
        }


        public EthernetParams() {
            // to create a unique storage file name
            this.UId = Guid.NewGuid().ToString();
        }


    }
}
