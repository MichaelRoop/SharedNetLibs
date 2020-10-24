namespace LanguageFactory.Net.data {

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
        response,
        select,
        discover,
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
        //Id,
        //AccessStatus,
        //AddressType,
        //Enabled,
        //Default,
        //Kind,
        //// Can be paired
        //Paired,
        //PairedSecureConnection,
        //Connectable,
        //Connected,
        //ProtectionLevel,
        //// BT
        ///
        Address,
        DeviceClass,
        ServiceClass,
        LastSeen,
        LastUsed,



    }
}
