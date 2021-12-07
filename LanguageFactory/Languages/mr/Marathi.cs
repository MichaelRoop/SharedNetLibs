﻿using LanguageFactory.Net.data;
using LanguageFactory.Net.Messaging;

namespace LanguageFactory.Net.Languages.mr {
    public class Marathi : SupportedLanguage {

        public Marathi() : base() {
            this.SetLanguage(LangCode.Marathi, "मराठी");

            // Common messages
            this.AddMsg(MsgCode.save, "सुरक्षित करा");
            this.AddMsg(MsgCode.login, "लॉग ऑन करा");
            this.AddMsg(MsgCode.logoff, "लॉग ऑफ करा");
            this.AddMsg(MsgCode.copy, "प्रतिलिपी करा");
            this.AddMsg(MsgCode.no, "नाही");
            this.AddMsg(MsgCode.yes, "होय");
            this.AddMsg(MsgCode.New, "नवीन");
            this.AddMsg(MsgCode.Ok, "ठीक");
            this.AddMsg(MsgCode.exit, "निर्गमन करा");
            this.AddMsg(MsgCode.start, "प्रारंभ करा");
            this.AddMsg(MsgCode.stop, "थांबा");
            this.AddMsg(MsgCode.language, "भाषा");
            this.AddMsg(MsgCode.send, "पाठवा");
            this.AddMsg(MsgCode.command, "आज्ञा");
            this.AddMsg(MsgCode.commands, "आदेश");
            this.AddMsg(MsgCode.response, "प्रतिसाद");
            this.AddMsg(MsgCode.select, "निवडा");
            this.AddMsg(MsgCode.Search, "शोध");
            this.AddMsg(MsgCode.connect, "जोडावे");
            this.AddMsg(MsgCode.Connected, "जोडलेले");
            this.AddMsg(MsgCode.Disconnected, "डिसकनेक्ट केलेले");
            this.AddMsg(MsgCode.ConnectionFailure, "नेक्शन अपयशी");
            this.AddMsg(MsgCode.Disconnect, "डिस्कनेक्ट करा");
            this.AddMsg(MsgCode.NotConnected, "कनेक्ट न केलेले");
            this.AddMsg(MsgCode.cancel, "रद्द करा");
            this.AddMsg(MsgCode.info, "माहिती");
            this.AddMsg(MsgCode.Settings, "सेटिंग्ज");
            this.AddMsg(MsgCode.Terminators, "Terminator characters");
            this.AddMsg(MsgCode.Name, "नाव");
            this.AddMsg(MsgCode.Error, "त्रुटी");
            this.AddMsg(MsgCode.Warning, "चेतावणी");
            this.AddMsg(MsgCode.EmptyName, "नाव रिक्त असू शकत नाही");
            this.AddMsg(MsgCode.LoadFailed, "लोड करण्यात अयशस्वी");
            this.AddMsg(MsgCode.SaveFailed, " सुरक्षित करण्‍यात अयशस्‍वी");
            this.AddMsg(MsgCode.EnterName, "नाव प्रविष्ट करा");
            this.AddMsg(MsgCode.Continue, "सुरू ठेवा?");
            this.AddMsg(MsgCode.Configure, "कॉन्फिगर करा");
            this.AddMsg(MsgCode.NoServices, "सेवा उपलब्ध नाहीत");
            this.AddMsg(MsgCode.PairBluetooth, "ब्लुटूथ पेअर करा");
            this.AddMsg(MsgCode.EnterPin, "PIN प्रविष्ट करा");
            this.AddMsg(MsgCode.PairedDevices, "पेअर केलेले डिव्हाइस");
            this.AddMsg(MsgCode.Pair, "जोड");
            this.AddMsg(MsgCode.Unpair, "जोड काढा");
            this.AddMsg(MsgCode.Password, "पासवर्ड");
            this.AddMsg(MsgCode.HostName, "होस्ट नाव");
            this.AddMsg(MsgCode.NetworkService, "नेटवर्क सेवा");
            this.AddMsg(MsgCode.Port, "पोर्ट");
            this.AddMsg(MsgCode.NetworkSecurityKey, "नेटवर्क सुरक्षा कळ");
            this.AddMsg(MsgCode.Network, "नेटवर्क");
            this.AddMsg(MsgCode.Socket, " सॉकेट");
            this.AddMsg(MsgCode.Credentials, "क्रेडेंशियल्स");
            this.AddMsg(MsgCode.About, "विषयी");
            this.AddMsg(MsgCode.Icons, "प्रतीके");
            this.AddMsg(MsgCode.Author, "लेखक");
            this.AddMsg(MsgCode.Services, "सेवा");
            this.AddMsg(MsgCode.Properties, "गुणधर्म");
            this.AddMsg(MsgCode.UserManual, "प्रयोक्ता मार्गदर्शक");
            this.AddMsg(MsgCode.Vendor, "विक्रेता");
            this.AddMsg(MsgCode.Product, "उत्पादन");
            this.AddMsg(MsgCode.Enabled, "सक्षम");
            this.AddMsg(MsgCode.Default, "डिफॉल्ट");
            this.AddMsg(MsgCode.BaudRate, "बॉड दर");
            this.AddMsg(MsgCode.DataBits, "डेटा बिट्स");
            this.AddMsg(MsgCode.StopBits, "Stop Bits");
            this.AddMsg(MsgCode.Parity, "साम्य");
            this.AddMsg(MsgCode.FlowControl, "Flow Control");
            this.AddMsg(MsgCode.Read, "वाचा");
            this.AddMsg(MsgCode.ReadFailure, "वाचणे अयशस्वी");
            this.AddMsg(MsgCode.Write, "लिहा");
            this.AddMsg(MsgCode.WriteFailue, "लिहिण्यात बिघाड");
            this.AddMsg(MsgCode.Delete, "हटवा");
            this.AddMsg(MsgCode.DeleteFailure, "अयशस्वी हटवा");
            this.AddMsg(MsgCode.CannotDeleteLast, "अंतिम प्रविष्टी हटवणे शक्य नाही");
            this.AddMsg(MsgCode.Timeout, "वेळबाह्य");
            this.AddMsg(MsgCode.Log, "लॉग");
            this.AddMsg(MsgCode.None, "कोणतेही नाही");
            this.AddMsg(MsgCode.NotFound, "आढळले नाही");
            this.AddMsg(MsgCode.UnknownError, "अज्ञात त्रुटी");
            this.AddMsg(MsgCode.UnhandledError, "न हाताळलेली त्रुटी");
            this.AddMsg(MsgCode.Support, "समर्थन");
            this.AddMsg(MsgCode.Edit, "संपादित करा");
            this.AddMsg(MsgCode.Create, "तयार करा");
            this.AddMsg(MsgCode.NothingSelected, "निवड नाही");
            this.AddMsg(MsgCode.Ethernet, "Ethernet");
            this.AddMsg(MsgCode.EmptyParameter, "कोणतेही मापदंड मूल्य निर्दिष्ट केलेले नाहीत");
            this.AddMsg(MsgCode.AbandonChanges, "त्याग करणे?");
            this.AddMsg(MsgCode.Run, "चालवा");
            this.AddMsg(MsgCode.InsufficienPermissions, "अपुरी परवानगी");
            this.AddMsg(MsgCode.CodeSamples, "कोड नमुने");
            this.AddMsg(MsgCode.AuthenticationType, "प्रमाणीकरण प्रकार");
            this.AddMsg(MsgCode.EncryptionType, "एनक्रिप्शन प्रकार");
            this.AddMsg(MsgCode.SignalStrength, "सिग्नल क्षमता");
            this.AddMsg(MsgCode.UpTime, "वर वेळ");
            this.AddMsg(MsgCode.MacAddress, "MAC पत्ता");
            this.AddMsg(MsgCode.Kind, "प्रकार");
            this.AddMsg(MsgCode.BeaconInterval, "Beacon मध्यांतर");
            this.AddMsg(MsgCode.AccessStatus, "Access Status");
            this.AddMsg(MsgCode.AddressType, "पत्त्याचा प्रकार");
            this.AddMsg(MsgCode.Paired, "जोडी केलेले");
            this.AddMsg(MsgCode.ProtectionLevel, "संरक्षण स्तर");
            this.AddMsg(MsgCode.SecureConnection, "सुरक्षित कनेक्शन");
            this.AddMsg(MsgCode.Id, "ID");
            this.AddMsg(MsgCode.Allowed, "परवानगी दिलेले");
            this.AddMsg(MsgCode.Address, "पत्ता");
            this.AddMsg(MsgCode.DeviceClass, "Device Class");
            this.AddMsg(MsgCode.ServiceClass, "Service Class");
            this.AddMsg(MsgCode.LastSeen, "शेवटचे पाहिलेले");
            this.AddMsg(MsgCode.LastUsed, "अंतिम वापरलेले");
            this.AddMsg(MsgCode.Authenticated, "प्रमाणीकृत");
            this.AddMsg(MsgCode.RemoteHost, "दूरस्थ होस्ट");
            this.AddMsg(MsgCode.RemoteService, "दूरस्थ सेवेशी");
            this.AddMsg(MsgCode.Clear, "साफ करा");
            this.AddMsg(MsgCode.ResetAll, "सर्व रीसेट करा");
            this.AddMsg(MsgCode.Characteristic, "Characteristic");
            this.AddMsg(MsgCode.Descriptor, "Descriptor");
            this.AddMsg(MsgCode.Min, "किमान");
            this.AddMsg(MsgCode.Max, "कमाल");
            this.AddMsg(MsgCode.ReadOnly, "केवळ वाचनीय");
            this.AddMsg(MsgCode.InvalidInput, "अमान्य इनपुट");
            this.AddMsg(MsgCode.ParseFailed, "पार्स करण्यात अयशस्वी");
            this.AddMsg(MsgCode.OutOfRange, "परिक्षेत्राबाहेर");
            this.AddMsg(MsgCode.email, "ईमेल");
            this.AddMsg(MsgCode.CrashReport, "Crash Report");
            this.AddMsg(MsgCode.DataType, "डेटा टाइप");
            this.AddMsg(MsgCode.Service, "सेवा");
            this.AddMsg(MsgCode.Notifications, "अधिसूचना");
            this.AddMsg(MsgCode.Disabled, "अक्षम");
            this.AddMsg(MsgCode.Description, "वर्णन");
            this.AddMsg(MsgCode.Unit, "यूनिट");
            this.AddMsg(MsgCode.Exponent, "घातांक");
            this.AddMsg(MsgCode.True, "सत्य");
            this.AddMsg(MsgCode.False, "खोटे");
            this.AddMsg(MsgCode.Even, "सम");
            this.AddMsg(MsgCode.Odd, "विषम");
            this.AddMsg(MsgCode.Mark, "Mark");
            this.AddMsg(MsgCode.Space, "Space");
            this.AddMsg(MsgCode.Preview, "पूर्वावलोकन");
            this.AddMsg(MsgCode.Configuration, "कॉ‍न्फिगरेशन");
            this.AddMsg(MsgCode.Configurations, "कॉन्फिगरेशन्स");
            this.AddMsg(MsgCode.Inputs, "इनपुट्स");
            this.AddMsg(MsgCode.Outputs, "आउटपुट");
            this.AddMsg(MsgCode.Digital, "डिजिटल");
            this.AddMsg(MsgCode.Analog, "अ‍ॅनॉलॉग");
            this.AddMsg(MsgCode.Step, "पायरी");
            this.AddMsg(MsgCode.Row, "पंक्ति");
            this.AddMsg(MsgCode.Column, "स्तंभ");
            this.AddMsg(MsgCode.Build, "आवृत्ती");

            //this.AddMsg(MsgCode., "");
        }


    }
}
