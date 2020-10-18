namespace CommunicationStack.Net.DataModels {

    /// <summary>Data model to hold results of socket connection</summary>
    public class MsgPumpConnectResults {

        /// <summary>Success status</summary>
        public bool IsSuccessful { get; set; } = false;
        // TODO - add specific code


        public MsgPumpConnectResults() { }
        public MsgPumpConnectResults(bool success) {
            this.IsSuccessful = success;
        }

    }
}
