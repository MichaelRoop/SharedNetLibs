﻿
namespace BluetoothCommon.Net.Enumerations {

    /// <summary>The service unique ids. 
    /// 
    /// </summary>
    /// <remarks>
    /// see: https://www.bluetooth.com/specifications/assigned-numbers/service-discovery/
    /// </remarks>
    public enum BT_ServiceType {
        NotHandled = 0,
        /// <summary>ServiceDiscoveryServerServiceClassID - Service class</summary>
        ServiceDiscoveryServerServiceClassId = 01000,
        /// <summary> Bluetooth Core Specification- Service class</summary>
        BrowseGroupDescriptorServiceClassId = 0x1001,
        /// <summary> Serial Port Profile (SPP) - Service class, Profile</summary>
        SerialPort = 0x1101,
        /// <summary>LAN Access Profile</summary>
        LanUsingPPP = 0x1102,


        // TODO - add later
        /// <summary>  - Service class, Profile</summary>

        /*
                LANAccessUsingPPP	0x1102	LAN Access Profile
                [DEPRECATED]
                        NOTE: Used as both Service Class Identifier and Profile Identifier.	Service Class/ Profile
                DialupNetworking	0x1103	Dial-up Networking Profile (DUN)
                NOTE: Used as both Service Class Identifier and Profile Identifier.	Service Class/ Profile
                IrMCSync	0x1104	Synchronization Profile (SYNC)
                NOTE: Used as both Service Class Identifier and Profile Identifier.	Service Class/ Profile
                OBEXObjectPush	0x1105	Object Push Profile (OPP)
                NOTE: Used as both Service Class Identifier and Profile.	Service Class/ Profile
                OBEXFileTransfer	0x1106	File Transfer Profile (FTP)
                NOTE: Used as both Service Class Identifier and Profile Identifier.	Service Class/ Profile
                IrMCSyncCommand	0x1107	Synchronization Profile (SYNC)	
                Headset	0x1108	Headset Profile (HSP)
                NOTE: Used as both Service Class Identifier and Profile Identifier.	Service Class/ Profile
                CordlessTelephony	0x1109	Cordless Telephony Profile (CTP)
                NOTE: Used as both Service Class Identifier and Profile Identifier.
                [DEPRECATED] Service Class/ Profile
                AudioSource	0x110A	Advanced Audio Distribution Profile (A2DP)	Service Class
                AudioSink	0x110B	Advanced Audio Distribution Profile (A2DP)	Service Class
                A/V_RemoteControlTarget	0x110C	Audio/Video Remote Control Profile (AVRCP)	Service Class
                AdvancedAudioDistribution	0x110D	Advanced Audio Distribution Profile (A2DP)	Profile
                A/V_RemoteControl	0x110E	Audio/Video Remote Control Profile (AVRCP)
                NOTE: Used as both Service Class Identifier and Profile Identifier.	Service Class/ Profile
                A/V_RemoteControlController	0x110F	Audio/Video Remote Control Profile (AVRCP)
                NOTE: The AVRCP specification v1.3 and later require that 0x110E also be included in the ServiceClassIDList before 0x110F for backwards compatibility.	Service Class
                Intercom	0x1110	Intercom Profile (ICP)
                NOTE: Used as both Service Class Identifier and Profile Identifier.
                [DEPRECATED] Service Class
                Fax	0x1111	Fax Profile (FAX)
                NOTE: Used as both Service Class Identifier and Profile Identifier.
                [DEPRECATED] Service Class
                Headset – Audio Gateway (AG)	0x1112	Headset Profile (HSP)	Service Class
                WAP	0x1113	Interoperability Requirements for Bluetooth technology as a WAP, Bluetooth SIG [DEPRECATED] Service Class
                WAP_CLIENT	0x1114	Interoperability Requirements for Bluetooth technology as a WAP, Bluetooth SIG [DEPRECATED] Service Class
                PANU	0x1115	Personal Area Networking Profile (PAN)
                NOTE: Used as both Service Class Identifier and Profile Identifier for PANU role.	Service Class / Profile
                NAP	0x1116	Personal Area Networking Profile (PAN)
                NOTE: Used as both Service Class Identifier and Profile Identifier for NAP role.	Service Class / Profile
                GN	0x1117	Personal Area Networking Profile (PAN)
                NOTE: Used as both Service Class Identifier and Profile Identifier for GN role.	Service Class / Profile
                DirectPrinting	0x1118	Basic Printing Profile (BPP)	Service Class
                ReferencePrinting	0x1119	See Basic Printing Profile (BPP)	Service Class
                Basic Imaging Profile	0x111A	Basic Imaging Profile (BIP)	Profile
                ImagingResponder	0x111B	Basic Imaging Profile (BIP)	Service Class
                ImagingAutomaticArchive	0x111C	Basic Imaging Profile (BIP)	Service Class
                ImagingReferencedObjects	0x111D	Basic Imaging Profile (BIP)	Service Class
                Handsfree	0x111E	Hands-Free Profile (HFP)
                NOTE: Used as both Service Class Identifier and Profile Identifier.	Service Class / Profile
                HandsfreeAudioGateway	0x111F	Hands-free Profile (HFP)	Service Class
                DirectPrintingReferenceObjectsService	0x1120	Basic Printing Profile (BPP)	Service Class
                ReflectedUI	0x1121	Basic Printing Profile (BPP)	Service Class
                BasicPrinting	0x1122	Basic Printing Profile (BPP)	Profile
                PrintingStatus	0x1123	Basic Printing Profile (BPP)	Service Class
                HumanInterfaceDeviceService	0x1124	Human Interface Device (HID)
                NOTE: Used as both Service Class Identifier and Profile Identifier.	Service Class / Profile
                HardcopyCableReplacement	0x1125	Hardcopy Cable Replacement Profile (HCRP)	Profile
                HCR_Print	0x1126	Hardcopy Cable Replacement Profile (HCRP)	Service Class
                HCR_Scan	0x1127	Hardcopy Cable Replacement Profile (HCRP)	Service Class
                Common_ISDN_Access	0x1128	Common ISDN Access Profile (CIP)
                NOTE: Used as both Service Class Identifier and Profile Identifier.
                [DEPRECATED] Service Class / Profile
                SIM_Access	0x112D	SIM Access Profile (SAP)
                NOTE: Used as both Service Class Identifier and Profile Identifier.	Service Class / Profile
                Phonebook Access – PCE	0x112E	Phonebook Access Profile (PBAP)	Service Class
                Phonebook Access – PSE	0x112F	Phonebook Access Profile (PBAP)	Service Class
                Phonebook Access	0x1130	Phonebook Access Profile (PBAP)	Profile
                Headset – HS	0x1131	Headset Profile (HSP)
                NOTE: See erratum #3507.
                0x1108 and 0x1203 should also be included in the ServiceClassIDList before 0x1131 for backwards compatibility.	Service Class
                Message Access Server	0x1132	Message Access Profile (MAP)	Service Class
                Message Notification Server	0x1133	Message Access Profile (MAP)	Service Class
                Message Access Profile	0x1134	Message Access Profile (MAP)	Profile
                GNSS	0x1135	Global Navigation Satellite System Profile (GNSS)	Profile
                GNSS_Server	0x1136	Global Navigation Satellite System Profile (GNSS)	Service Class
                ​3D Display	0x1137​	​3D Synchronization Profile (3DSP)	Service Class​
                ​3D Glasses	​0x1138	​3D Synchronization Profile (3DSP)	​Service Class
                ​3D Synchronization	0x1139​	​3D Synchronization Profile (3DSP)	​Profile
                ​MPS Profile UUID	​0x113A	​Multi-Profile Specification (MPS)	​Profile
                ​MPS SC UUID	​0x113B	​Multi-Profile Specification (MPS)	​Service Class
                ​CTN Access Service​	​0x113C​	​Calendar, Task, and Notes (CTN) Profile	​Service Class
                ​CTN Notification Service​	​0x113D	​​Calendar Tasks and Notes (CTN) Profile	​Service Class
                ​CTN Profile	​0x113E	​​Calendar Tasks and Notes (CTN) Profile	​Profile
                PnPInformation	0x1200	Device Identification (DID)
                NOTE: Used as both Service Class Identifier and Profile Identifier.	Service Class / Profile
                GenericNetworking	0x1201	N/A Service Class
                GenericFileTransfer	0x1202	N/A Service Class
                GenericAudio	0x1203	N/A Service Class
                GenericTelephony	0x1204	N/A Service Class
                UPNP_Service	0x1205	Enhanced Service Discovery Profile (ESDP) [DEPRECATED] Service Class
                UPNP_IP_Service	0x1206	Enhanced Service Discovery Profile (ESDP) [DEPRECATED] Service Class
                ESDP_UPNP_IP_PAN	0x1300	Enhanced Service Discovery Profile (ESDP) [DEPRECATED] Service Class
                ESDP_UPNP_IP_LAP	0x1301	Enhanced Service Discovery Profile (ESDP)[DEPRECATED] Service Class
                ESDP_UPNP_L2CAP	0x1302	Enhanced Service Discovery Profile (ESDP)[DEPRECATED] Service Class
                VideoSource	0x1303	Video Distribution Profile (VDP)	Service Class
                VideoSink	0x1304	Video Distribution Profile (VDP)	Service Class
                VideoDistribution	0x1305	Video Distribution Profile (VDP)	Profile
                HDP	0x1400	Health Device Profile   Profile
                HDP Source	0x1401	Health Device Profile (HDP)	Service Class
                HDP Sink	0x1402	Health Device Profile (HDP)	Service Class
                (Max value 0xFFFF)	
                */


    }
}
