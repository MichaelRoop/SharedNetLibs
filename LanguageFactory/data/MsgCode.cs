namespace LanguageFactory.data {

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

    }
}
