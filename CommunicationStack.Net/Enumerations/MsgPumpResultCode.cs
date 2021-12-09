namespace CommunicationStack.Net.Enumerations {

    public enum MsgPumpResultCode {
        //Success,
        Connected,
        NotConnected,
        ReadFailure,
        WriteFailure,
        ConnectionFailure,
        EmptyParams,
        InvalidAddress,
        Timeout,
    }

}
