namespace WifiCommon.Net.Enumerations {

    public enum NetEncryptionType {

        /// <summary>None</summary>
        None = 0,

        /// <summary>Unknown</summary>
        Unknown = 1,

        /// <summary>WEP cipher algorithm with a cipher key of any length</summary>
        WEP = 2,

        /// <summary>
        /// Wired Equivalent Privacy (WEP) algorithm, which is the RC4-based 
        /// algorithm that is specified in the IEEE 802.11-1999 standard. This 
        /// enumerator specifies the WEP cipher algorithm with a 40-bit cipher key.
        /// </summary>
        WEP40 = 3,

        /// <summary>WEP cipher algorithm with a 104-bit cipher key</summary>
        WEP104 = 4,

        /// <summary>
        /// Temporal Key Integrity Protocol (TKIP) algorithm, 
        /// which is the RC4-based cipher suite that is based on the algorithms 
        /// that are defined in the WPA specification and IEEE 802.11i-2004 
        /// standard. This cipher also uses the Michael Message Integrity 
        /// Code (MIC) algorithm for forgery protection.
        /// </summary>
        TKIP = 5,

        /// <summary>
        /// AES-CCMP algorithm, as specified in the IEEE 802.11i-2004 
        /// standard and RFC 3610. Advanced Encryption Standard (AES) is the 
        /// encryption algorithm defined in FIPS PUB 197.
        /// </summary>
        CCMP = 6,

        /// <summary>
        /// Wifi Protected Access (WPA) Use Group Key cipher suite. For 
        /// more information about the Use Group Key cipher suite, refer 
        /// to Clause 7.3.2.25.1 of the IEEE 802.11i-2004 standard
        /// </summary>
        WPA_Use_Group = 7,

        /// <summary>
        /// Robust Security Network (RSN) Use Group Key cipher suite. For 
        /// more information about the Use Group Key cipher suite, refer 
        /// to Clause 7.3.2.25.1 of the IEEE 802.11i-2004 standard.
        /// </summary>
        RSN_Use_Group = 8,

        /// <summary>
        /// Encryption type defined by an independent hardware vendor (IHV).
        /// </summary>
        IHV = 9,

    }
}
