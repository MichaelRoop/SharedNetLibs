namespace WifiCommon.Net.Enumerations {

    public enum NetworkKind {

        /// <summary>Either Infrastructure or Adhoc</summary>
        Any = 0,

        /// <summary>Normal kind</summary>
        Infrastructure = 1,

        /// <summary>Independant (IBSS) network</summary>
        Adhoc = 2,
    }
}
