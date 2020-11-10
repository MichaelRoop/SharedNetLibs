namespace Common.Net.Network.Enumerations {

    // From the MS libraries SocketErrorStatus
    public enum SocketErrCode : int {
        //
        // Summary:
        //     The socket status is unknown.
        Unknown = 0,
        //
        // Summary:
        //     The operation was aborted.
        OperationAborted = 1,
        //
        // Summary:
        //     A bad response was received from the HTTP server.
        HttpInvalidServerResponse = 2,
        //
        // Summary:
        //     A connection timeout was exceeded.
        ConnectionTimedOut = 3,
        //
        // Summary:
        //     The address family is not supported.
        AddressFamilyNotSupported = 4,
        //
        // Summary:
        //     The socket type is not supported.
        SocketTypeNotSupported = 5,
        //
        // Summary:
        //     The host was not found.
        HostNotFound = 6,
        //
        // Summary:
        //     The requested name is valid and was found in the database, but it does not have
        //     the correct associated data being resolved for.
        NoDataRecordOfRequestedType = 7,
        //
        // Summary:
        //     This is usually a temporary error during hostname resolution and means that the
        //     local server did not receive a response from an authoritative server.
        NonAuthoritativeHostNotFound = 8,
        //
        // Summary:
        //     The specified class was not found.
        ClassTypeNotFound = 9,
        //
        // Summary:
        //     The address is already in use.
        AddressAlreadyInUse = 10,
        //
        // Summary:
        //     Cannot assign requested address.
        CannotAssignRequestedAddress = 11,
        //
        // Summary:
        //     The connection was refused.
        ConnectionRefused = 12,
        //
        // Summary:
        //     The network is unreachable.
        NetworkIsUnreachable = 13,
        //
        // Summary:
        //     The host is unreachable.
        UnreachableHost = 14,
        //
        // Summary:
        //     The network is down.
        NetworkIsDown = 15,
        //
        // Summary:
        //     The network dropped connection on reset.
        NetworkDroppedConnectionOnReset = 16,
        //
        // Summary:
        //     Software caused a connection abort.
        SoftwareCausedConnectionAbort = 17,
        //
        // Summary:
        //     The connection was reset by the peer.
        ConnectionResetByPeer = 18,
        //
        // Summary:
        //     The host is down.
        HostIsDown = 19,
        //
        // Summary:
        //     The pipe is being closed.
        NoAddressesFound = 20,
        //
        // Summary:
        //     Too many open files.
        TooManyOpenFiles = 21,
        //
        // Summary:
        //     A message sent on a datagram socket was larger than the internal message buffer
        //     or some other network limit, or the buffer used to receive a datagram was smaller
        //     than the datagram itself.
        MessageTooLong = 22,
        //
        // Summary:
        //     A required certificate is not within its validity period when verifying against
        //     the current system clock or the timestamp in the signed file. This error is also
        //     returned if the validity periods of the certification chain do not nest correctly.
        CertificateExpired = 23,
        //
        // Summary:
        //     A certificate chain processed, but terminated in a root certificate which is
        //     not trusted by the trust provider. This error is also returned if a certificate
        //     chain could not be built to a trusted root authority.
        CertificateUntrustedRoot = 24,
        //
        // Summary:
        //     The certificate is not valid for the requested usage. This error is also returned
        //     if the certificate has an invalid name. The name is not included in the permitted
        //     list or is explicitly excluded.
        CertificateCommonNameIsIncorrect = 25,
        //
        // Summary:
        //     The certificate is not valid for the requested usage.
        CertificateWrongUsage = 26,
        //
        // Summary:
        //     A certificate was explicitly revoked by its issuer. This error is also returned
        //     if the certificate was explicitly marked as untrusted by the user.
        CertificateRevoked = 27,
        //
        // Summary:
        //     The revocation function was unable to check revocation for the certificate.
        CertificateNoRevocationCheck = 28,
        //
        // Summary:
        //     The revocation function was unable to check revocation because the revocation
        //     server was offline.
        CertificateRevocationServerOffline = 29,
        //
        // Summary:
        //     The supplied certificate is invalid. This can be returned for a number of reasons:
        CertificateIsInvalid = 30
    }


}

