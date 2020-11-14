using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationStack.Net.MsgPumps {

    public class NetSocketConnectData {

        public string RemoteHostName { get; set; } = string.Empty;

        public int RemotePort { get; set; } = 0;

        public NetSocketConnectData() { }

        public NetSocketConnectData(string addr, int port) {
            this.RemoteHostName = addr;
            this.RemotePort = port;
        }


    }
}
