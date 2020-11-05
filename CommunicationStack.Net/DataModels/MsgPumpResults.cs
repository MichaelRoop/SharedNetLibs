using CommunicationStack.Net.Enumerations;

namespace CommunicationStack.Net.DataModels {

    /// <summary>Data model to hold results of socket connection</summary>
    public class MsgPumpResults {

        /// <summary>Specific result code</summary>
        public MsgPumpResultCode Code { get; set; } = MsgPumpResultCode.Connected;

        /// <summary>Language specific text string to be filled in up stream</summary>
        public string ErrorString { get; set; } = string.Empty;


        public MsgPumpResults() { }
        public MsgPumpResults(MsgPumpResultCode code) {
            this.Code = code;
        }

    }
}
