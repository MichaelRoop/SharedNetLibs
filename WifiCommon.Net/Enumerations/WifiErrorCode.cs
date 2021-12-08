namespace WifiCommon.Net.Enumerations {
    public enum WifiErrorCode {
        Unknown,
        Success,
        NoAdapters,
        NetworkNotAvailable,
        AccessRevoked,
        InvalidCredentials,
        Timeout,
        UnsupportedAuthenticationProtocol,


        EmptyHostName,
        EmptyServiceName,
        EmptyPassword,
        UserCanceled,
        NonNumericPort,
        EmptySsid,
    }
}
