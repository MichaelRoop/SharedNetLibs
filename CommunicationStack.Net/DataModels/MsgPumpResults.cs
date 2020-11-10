using Common.Net.Network.Enumerations;
using CommunicationStack.Net.Enumerations;

namespace CommunicationStack.Net.DataModels {

    /// <summary>Data model to hold results of socket connection</summary>
    public class MsgPumpResults {

        /// <summary>Specific result code</summary>
        public MsgPumpResultCode Code { get; set; } = MsgPumpResultCode.Connected;

        /// <summary>Socket error code with more information</summary>
        public SocketErrCode SocketErr { get; set; } = SocketErrCode.Unknown; 

        /// <summary>Language specific text string to be filled in up stream</summary>
        public string ErrorString { get; set; } = string.Empty;


        public MsgPumpResults() { }


        public MsgPumpResults(MsgPumpResultCode code) {
            this.Code = code;
        }


        public MsgPumpResults(MsgPumpResultCode code, string err) {
            this.Code = code;
            this.ErrorString = err;
        }


        public MsgPumpResults(MsgPumpResultCode code, SocketErrCode socketCode) {
            this.Code = code;
            this.SocketErr = socketCode;
            this.ErrorString = this.SocketErr.ToString();
        }



    }
}
