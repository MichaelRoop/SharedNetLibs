using LanguageFactory.Net.data;
using LanguageFactory.Net.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageFactory.Net.Languages.hi {
    
    public class Hindi : SupportedLanguage {

        public Hindi() : base() {
            this.SetLanguage(LangCode.Hindi, "हिन्दी");

            // Common messages
            this.AddMsg(MsgCode.save, "सहेजें");

            this.AddMsg(MsgCode.login, "लॉगऑन");
            this.AddMsg(MsgCode.logoff, "लॉगऑफ़ करें");
            this.AddMsg(MsgCode.copy, "प्रतिलिपि बनाएँ");
            this.AddMsg(MsgCode.no, "नहीं");
            this.AddMsg(MsgCode.yes, "हाँ");
            this.AddMsg(MsgCode.New, "नया");
            this.AddMsg(MsgCode.Ok, "ठीक");
            this.AddMsg(MsgCode.exit, "बाहर निकलें");
            this.AddMsg(MsgCode.start, "प्रारंभ करें");
            this.AddMsg(MsgCode.stop, "रोकें");
            this.AddMsg(MsgCode.language, "भाषाएँ");
            this.AddMsg(MsgCode.send, "भेजें");
            this.AddMsg(MsgCode.command, "कमांड");
            this.AddMsg(MsgCode.commands, "आदेश");
            this.AddMsg(MsgCode.response, "प्रतिसाद");
            this.AddMsg(MsgCode.select, "चुनें");
            this.AddMsg(MsgCode.Search, "खोजें");
            this.AddMsg(MsgCode.connect, "कनेक्ट करें");
            this.AddMsg(MsgCode.cancel, "रद्द करें");
            this.AddMsg(MsgCode.info, "Info");
            this.AddMsg(MsgCode.Settings, "सेटिंग्स");
            this.AddMsg(MsgCode.Terminators, "Terminators");
            this.AddMsg(MsgCode.Name, "नाम");
            this.AddMsg(MsgCode.Error, "त्रुटि");
            this.AddMsg(MsgCode.CannotDeleteLast, "अंतिम प्रविष्टि नहीं हटाई जा सकती");
            this.AddMsg(MsgCode.EmptyName, "नाम रिक्त नहीं हो सकता");
            this.AddMsg(MsgCode.LoadFailed, "लोड करने में विफल");
            this.AddMsg(MsgCode.SaveFailed, "सहेजने में विफल");
            this.AddMsg(MsgCode.EnterName, "नाम दर्ज करें");
            this.AddMsg(MsgCode.Continue, "जारी रखें");
            this.AddMsg(MsgCode.Configure, "कॉन्फ़िगर करें");
            this.AddMsg(MsgCode.NoServices, "कोई सेवा नहीं");
            this.AddMsg(MsgCode.PairBluetooth, "Bluetooth को युग्मित करें");
            this.AddMsg(MsgCode.EnterPin, "PIN दर्ज करें");
            this.AddMsg(MsgCode.PairedDevices, "युग्मित डिवाइसेस");
            this.AddMsg(MsgCode.Pair, "युग्‍मित करें");
            this.AddMsg(MsgCode.Unpair, "अयुग्मित करें");
            this.AddMsg(MsgCode.Disconnect, "डिस्कनेक्ट करें");
            this.AddMsg(MsgCode.Password, "पासवर्ड");
            this.AddMsg(MsgCode.HostName, "होस्ट का नाम");
            this.AddMsg(MsgCode.NetworkService, "नेटवर्क सेवा");
            this.AddMsg(MsgCode.Port, "पोर्ट");
            this.AddMsg(MsgCode.NetworkSecurityKey, "नेटवर्क सुरक्षा कुंजी");
            this.AddMsg(MsgCode.Network, "नेटवर्क");
            this.AddMsg(MsgCode.Socket, "सॉकेट");
            this.AddMsg(MsgCode.Credentials, "क्रैडेंशियल्स");
            this.AddMsg(MsgCode.About, "के बारे में");
            this.AddMsg(MsgCode.Icons, "आइकन");
            this.AddMsg(MsgCode.Author, "लेखक");
            this.AddMsg(MsgCode.Services, "सेवाएँ");
            this.AddMsg(MsgCode.Properties, "गुण");
            this.AddMsg(MsgCode.Delete, "हटाएँ");
            this.AddMsg(MsgCode.UserManual, "उपयोगकर्ता पुस्तिका");
            this.AddMsg(MsgCode.Vendor, "विक्रेता");
            this.AddMsg(MsgCode.Product, "उत्पाद");
            this.AddMsg(MsgCode.Enabled, "सक्रिय किया गया");
            this.AddMsg(MsgCode.Default, "डिफ़ॉल्ट");
            this.AddMsg(MsgCode.BaudRate, "बॉड दर");
            this.AddMsg(MsgCode.DataBits, "डेटा बिट्स");
            this.AddMsg(MsgCode.StopBits, "Stop Bits");
            this.AddMsg(MsgCode.Parity, "पैरिटी");
            this.AddMsg(MsgCode.FlowControl, "Flow Control");
            this.AddMsg(MsgCode.Read, "पढ़ें");
            this.AddMsg(MsgCode.Write, "लिखें");
            this.AddMsg(MsgCode.Timeout, "समय बाह्य");
            this.AddMsg(MsgCode.Log, "लॉग");
            this.AddMsg(MsgCode.None, "कोई नहीं");
            this.AddMsg(MsgCode.NotFound, "नहीं मिला");
            this.AddMsg(MsgCode.NotConnected, "कनेक्ट नहीं है");
            this.AddMsg(MsgCode.ConnectionFailure, "कनेक्शन विफलता");
            this.AddMsg(MsgCode.ReadFailure, "डेटा पठन त्रुटि");
            this.AddMsg(MsgCode.WriteFailue, "डेटा लेखन त्रुटि");
            this.AddMsg(MsgCode.UnknownError, "अज्ञात त्रुटि");
            this.AddMsg(MsgCode.UnhandledError, "हैंडल न की गई त्रुटि");
            this.AddMsg(MsgCode.Support, "समर्थन");
            this.AddMsg(MsgCode.Edit, "संपादन");
            this.AddMsg(MsgCode.Create, "बनाएँ");
            this.AddMsg(MsgCode.NothingSelected, "कुछ भी चयनित नहीं है");
            this.AddMsg(MsgCode.DeleteFailure, "हटाएँ असफल");
            this.AddMsg(MsgCode.Ethernet, "ईथरनेट");
            this.AddMsg(MsgCode.EmptyParameter, "रिक्त पैरामीटर नहीं जोड़ा जा सकता");
            this.AddMsg(MsgCode.AbandonChanges, "प्रक्रिया का त्याग करें");
            this.AddMsg(MsgCode.Warning, "चेतावनी");
            this.AddMsg(MsgCode.Run, "चलाएँ");
            this.AddMsg(MsgCode.InsufficienPermissions, "अपर्याप्त अनुमतियाँ");
            this.AddMsg(MsgCode.CodeSamples, "कोड नमूने");
            this.AddMsg(MsgCode.AuthenticationType, "प्रमाणीकरण प्रकार");
            this.AddMsg(MsgCode.EncryptionType, "एन्क्रिप्शन प्रकार");
            this.AddMsg(MsgCode.SignalStrength, "सिग्नल क्षमता");
            this.AddMsg(MsgCode.UpTime, "अप टाइम");
            this.AddMsg(MsgCode.MacAddress, "MAC पता");
            this.AddMsg(MsgCode.Kind, "प्रकार");
            this.AddMsg(MsgCode.BeaconInterval, "बीकन अंतराल");
            this.AddMsg(MsgCode.AccessStatus, "पहुंच की स्थिति");
            this.AddMsg(MsgCode.AddressType, "पता प्रकार");
            this.AddMsg(MsgCode.Paired, "युग्मित");
            this.AddMsg(MsgCode.Connected, "कनेक्ट किया गया");
            this.AddMsg(MsgCode.ProtectionLevel, "सुरक्षा स्तर");
            this.AddMsg(MsgCode.SecureConnection, "सुरक्षित कनेक्शन");
            this.AddMsg(MsgCode.Id, "ID");
            this.AddMsg(MsgCode.Allowed, "अनुमत");
            this.AddMsg(MsgCode.Address, "पता");
            this.AddMsg(MsgCode.DeviceClass, "Device Class");
            this.AddMsg(MsgCode.ServiceClass, "Service Class");
            this.AddMsg(MsgCode.LastSeen, "अंतिम बार देखा");
            this.AddMsg(MsgCode.LastUsed, "अंतिम बार उपयोग किया");
            this.AddMsg(MsgCode.Authenticated, "प्रमाणीकृत");
            this.AddMsg(MsgCode.RemoteHost, "दूरस्थ होस्ट");
            this.AddMsg(MsgCode.RemoteService, "दूरस्थ सेवा ");
            this.AddMsg(MsgCode.Clear, "साफ़ करें");


            //this.AddMsg(MsgCode., "");

        }


    }
}
