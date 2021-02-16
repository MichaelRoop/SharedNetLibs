﻿namespace LanguageFactory.Net.data {

    /// <summary>Supported messages</summary>
    /// <remarks>
    /// Will add a set of common messages
    /// Add more for specific application. 
    /// Do not remove any entries since multiple apps may depend on them
    /// </remarks>
    public enum MsgCode {
        undefined,
        save,
        login,
        logoff,
        copy,
        no,
        yes,
        New,
        Ok,
        exit,
        stop,
        start,
        language,
        send,
        command,
        commands,
        response,
        select,
        Search,
        connect,
        cancel,
        info,
        Settings,
        Terminators,
        Name,
        Error,
        CannotDeleteLast,
        EmptyName,
        LoadFailed,
        SaveFailed,
        EnterName,
        Continue,
        Configure,

        NoServices,
        PairBluetooth,
        EnterPin,
        PairedDevices,
        Pair,
        Unpair,
        Disconnect,
        Password,
        HostName,
        NetworkService,
        Port,
        NetworkSecurityKey,
        Network,
        Socket,
        Credentials,
        About,
        Icons,
        Author,
        Services,
        Properties,


        //// BLE Fields
        //True,
        //False,
        //AddressType,
        //Connectable,
        Address,
        Delete,
        UserManual,
        Product,
        Vendor,

        Enabled,
        Default,
        BaudRate,
        DataBits,
        StopBits,
        Parity,

        FlowControl,
        Read,
        Write,
        Timeout,
        Log,
        None,
        NotFound,
        NotConnected,
        ConnectionFailure,
        ReadFailure,
        WriteFailue,
        UnknownError,
        UnhandledError,
        Support,
        Edit,
        Create,
        NothingSelected,
        DeleteFailure,
        Ethernet,
        EmptyParameter,
        Warning,
        AbandonChanges,
        Run,
        InsufficienPermissions,
        CodeSamples,
        AuthenticationType,
        EncryptionType,
        UpTime,
        SignalStrength,
        MacAddress,
        Kind,
        BeaconInterval,

        AccessStatus,
        AddressType,
        Paired,
        Connected,
        ProtectionLevel,
        SecureConnection,
        Id,
        Allowed,
        DeviceClass,
        ServiceClass,
        LastSeen,
        LastUsed,
        Authenticated,
        RemoteHost,
        RemoteService,
        Clear,
        ResetAll,
        Disconnected,

        Characteristic,
        Descriptor,
        Min,
        Max,
        DataType,
        NoWriteAccess,
        InvalidInput,
        ParseFailed,
        OutOfRange,
        email,
        CrashReport,


        // Composite - no direct lookup
        ReadTimeout,
        WriteTimeout,
        PairedWithSecureConnection,
        PairingAllowed,
        ServicesFailure,
    }
}
