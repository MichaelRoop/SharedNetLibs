namespace BluetoothCommon.Net.Enumerations {

    /// <summary>Cross platform common enumeration for pair operation</summary>
    public enum BT_PairingStatus {
        /// <summary>The device object is now paired</summary>
        Paired = 0,

        /// <summary>not in a state where it can be paired</summary>
        NotReadyToPair = 1,

        /// <summary>Not currently paired</summary>
        NotPaired = 2,

        /// <summary>Already been paired</summary>
        AlreadyPaired = 3,

        /// <summary>Device rejected connection</summary>
        Rejected = 4,

        /// <summary>Too many connections</summary>
        TooManyConnections = 5,

        /// <summary>Hardware failure</summary>
        HardwareFailure = 6,

        /// <summary>Authentication timed out</summary>
        AuthenticationTimeout = 7,

        /// <summary>Authentication protocol no supported</summary>
        AuthenticationNotAllowed = 8,

        /// <summary>Device or application rejected authentication</summary>
        AuthenticationFailure = 9,

        /// <summary>No network profiles for device to use</summary>
        NoSupportedProfiles = 10,

        /// <summary>Minimum level of protection not supported by device or application</summary>
        ProtectionLevelCouldNotBeMet = 11,

        /// <summary>Access denied due to application not having permissions</summary>
        AccessDenied = 12,

        /// <summary>Incorrect Ceremony data</summary>
        InvalidCeremonyData = 13,

        /// <summary>Pairing action completed before completion</summary>
        PairingCanceled = 14,

        /// <summary>Already attempting pairing</summary>
        OperationAlreadyInProgress = 15,

        /// <summary>event handler or pairing kinds not supported</summary>
        RequiredHandlerNotRegistered = 16,

        /// <summary>Application handler rejected pairing</summary>
        RejectedByHandler = 17,

        /// <summary>Device already has association</summary>
        RemoteDeviceHasAssociation = 18,

        /// <summary>Unknown failure</summary>
        Failed = 19,



        // Not coming from the pairing call but 
        NoParingObject = 100,
        NotSupported = 101,




    }
}
