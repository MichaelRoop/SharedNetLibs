using System;
using System.Collections.Generic;
using System.Text;

namespace WifiCommon.Net.Enumerations {

    public enum NetAuthenticationType : int {

        /// <summary>None</summary>
        None= 0,

        /// <summary>Unknown</summary>
        Unknown = 1,

        /// <summary>
        /// Open authentication over 802.11 wireless. Devices are authenticated and 
        /// can connect to an access point, but communication with the network 
        /// requires a matching Wired Equivalent Privacy (WEP) key.
        /// </summary>
        Open80211 = 2,

        /// <summary>
        /// Specifies an IEEE 802.11 Shared Key authentication algorithm that 
        /// requires the use of a pre-shared Wired Equivalent Privacy (WEP) key 
        /// for the 802.11 authentication.
        /// </summary>
        SharedKey80211 = 3,

        /// <summary>
        /// Specifies a Wi-Fi Protected Access (WPA) algorithm. IEEE 802.1X port 
        /// authorization is performed by the supplicant, authenticator, and 
        /// authentication server. Cipher keys are dynamically derived through 
        /// the authentication process.
        /// </summary>
        Wpa = 4,

        /// <summary>
        /// Specifies a Wi-Fi Protected Access (WPA) algorithm that uses pre-shared 
        /// keys (PSK). IEEE 802.1X port authorization is performed by the supplicant 
        /// and authenticator. Cipher keys are dynamically derived through a pre-shared key that is used on both the supplicant and authenticator.         
        /// </summary>
        WpaPsk = 5,

        /// <summary>Wi-Fi Protected Access</summary>
        WpaNone = 6,

        /// <summary>
        /// Specifies an IEEE 802.11i Robust Security Network Association (RSNA) 
        /// algorithm. IEEE 802.1X port authorization is performed by the supplicant, 
        /// authenticator, and authentication server. Cipher keys are dynamically 
        /// derived through the authentication process.
        /// </summary>
        Rsna = 7,

        /// <summary>
        /// Specifies an IEEE 802.11i RSNA algorithm that uses PSK. IEEE 802.1X port 
        /// authorization is performed by the supplicant and authenticator. Cipher 
        /// keys are dynamically derived through a pre-shared key that is used on both 
        /// the supplicant and authenticator.
        /// </summary>
        RsnaPsk = 8,

        /// <summary>
        /// Specifies an authentication type defined by an independent hardware vendor (IHV)
        /// </summary>
        Ihv = 9,

        /// <summary>
        /// Specifies a Wi-Fi Protected Access 3 (WPA3) algorithm. WPA3 is an encryption 
        /// security standard for enterprise users. It offers the equivalent of 192-bit 
        /// cryptographic strength, providing additional protections for networks transmitting 
        /// sensitive data.
        /// </summary>
        Wpa3 = 10,

        /// <summary>
        /// Specifies a Wi-Fi Protected Access 3 Simultaneous Authentication of Equals 
        /// (WPA3 SAE) algorithm. WPA3 SAE is the consumer version of WPA3. Simultaneous 
        /// Authentication of Equals (SAE) is a secure key establishment protocol between 
        /// devices; it provides synchronous authentication, and stronger protections for 
        /// users against password-guessing attempts by third parties.
        /// </summary>
        Wpa3Sae = 11,

        /// <summary>
        /// Specifies an opportunistic wireless encryption (OWE) algorithm. OWE provides 
        /// opportunistic encryption over 802.11 wireless, where cipher keys are dynamically 
        /// derived through a Diffie-Hellman key exchange; enabling data protection without 
        /// authentication.
        /// </summary>
        Owe = 12,

    }
}
