using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationStack.Net.Enumerations {
    
    public enum MsgPumpResultCode {
        //Success,
        Connected,
        NotConnected,
        ReadFailure,
        WriteFailure,
        ConnectionFailure,
        EmptyParams,
    }

}
