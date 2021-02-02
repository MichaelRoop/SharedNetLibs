using LanguageFactory.Net.data;
using LanguageFactory.Net.Messaging;

namespace LanguageFactory.Net.Languages.bn {


    public class Bengali : SupportedLanguage {

        public Bengali() : base() {
            this.SetLanguage(LangCode.Bengali, "বাংলা");

            // Common messages
            this.AddMsg(MsgCode.save, "সংরক্ষণ করা");
            this.AddMsg(MsgCode.login, "লগইন");
            this.AddMsg(MsgCode.logoff, "লগ অফ");
            this.AddMsg(MsgCode.copy, "অনুলিপি করা");
            this.AddMsg(MsgCode.no, "না");
            this.AddMsg(MsgCode.yes, "হ্যাঁ");
            this.AddMsg(MsgCode.New, "নতুন");
            this.AddMsg(MsgCode.Ok, "ঠিক");
            this.AddMsg(MsgCode.exit, "প্রস্থান");
            this.AddMsg(MsgCode.start, "শুরু করুন");
            this.AddMsg(MsgCode.stop, "থামা");
            this.AddMsg(MsgCode.language, "ভাষা");
            this.AddMsg(MsgCode.send, "পাঠান");
            this.AddMsg(MsgCode.command, "কম্যান্ড");
            this.AddMsg(MsgCode.commands, "কম্যান্ডগুলি");
            this.AddMsg(MsgCode.response, "প্রত্যুত্তর");
            this.AddMsg(MsgCode.select, "নির্বাচন করুন");
            this.AddMsg(MsgCode.Search, "সন্ধান");
            this.AddMsg(MsgCode.connect, "সংযোগ করুন");
            this.AddMsg(MsgCode.Connected, "সংযুক্ত");
            this.AddMsg(MsgCode.ConnectionFailure, "সংযোগ ব্যর্থ");
            this.AddMsg(MsgCode.Disconnect, "বিছিন্ন করুন");
            this.AddMsg(MsgCode.NotConnected, "সংযুক্ত নেই");
            this.AddMsg(MsgCode.cancel, "বাতিল করুন");
            this.AddMsg(MsgCode.info, "তথ্য");
            this.AddMsg(MsgCode.Settings, "সেটিংস");
            this.AddMsg(MsgCode.Terminators, "টার্মিনেটার");
            this.AddMsg(MsgCode.Name, "নাম");
            this.AddMsg(MsgCode.Error, "ত্রুটি");
            this.AddMsg(MsgCode.Warning, "সতর্কীকরণ");
            this.AddMsg(MsgCode.EmptyName, "নাম খালি থাকতে পারে না");
            this.AddMsg(MsgCode.LoadFailed, "লোড করতে ব্যর্থ হয়েছে৷");
            this.AddMsg(MsgCode.SaveFailed, "সংরক্ষণ করতে বিফল হয়েছে।");
            this.AddMsg(MsgCode.EnterName, "নাম লিখুন");
            this.AddMsg(MsgCode.Continue, "চালিয়ে যান?");
            this.AddMsg(MsgCode.Configure, "কনফিগার");
            this.AddMsg(MsgCode.NoServices, "নো পরিষেবা");
            this.AddMsg(MsgCode.PairBluetooth, "Bluetooth জোড়া বাঁধুন");
            this.AddMsg(MsgCode.EnterPin, "PIN প্রবেশ করুন");
            this.AddMsg(MsgCode.PairedDevices, "জোড়বদ্ধ ডিভাইসগুলি");
            this.AddMsg(MsgCode.Pair, "জোড়বদ্ধ করা");
            this.AddMsg(MsgCode.Unpair, "আনপেয়ার করা");
            this.AddMsg(MsgCode.Password, "পাসওয়ার্ড");
            this.AddMsg(MsgCode.HostName, "আয়োজকের নাম");
            this.AddMsg(MsgCode.NetworkService, "নেটওয়ার্ক পরিষেবা");
            this.AddMsg(MsgCode.Port, "পোর্ট করুন");
            this.AddMsg(MsgCode.NetworkSecurityKey, "নেটওয়ার্ক নিরাপত্তা কী প্রবেশ করান");
            this.AddMsg(MsgCode.Network, "নেটওয়ার্ক");
            this.AddMsg(MsgCode.Socket, "সকেট");
            this.AddMsg(MsgCode.Credentials, "প্রমাণপত্রাদি");
            this.AddMsg(MsgCode.About, "সম্পর্কে");
            this.AddMsg(MsgCode.Icons, "আইকনগুলি");
            this.AddMsg(MsgCode.Author, "প্রণেতা");
            this.AddMsg(MsgCode.Services, "সেবাসমূহ");
            this.AddMsg(MsgCode.Properties, "বৈশিষ্ট্যসমূহ");
            this.AddMsg(MsgCode.UserManual, "ব্যবহারকারীর নির্দেশিকা দেখুন");
            this.AddMsg(MsgCode.Vendor, "বিক্রেতা");
            this.AddMsg(MsgCode.Product, "পণ্য");
            this.AddMsg(MsgCode.Enabled, "সক্ষম হয়েছে");
            this.AddMsg(MsgCode.Default, "ডিফল্ট");
            this.AddMsg(MsgCode.BaudRate, "বড রেট");
            this.AddMsg(MsgCode.DataBits, "ডেটা বিট");
            this.AddMsg(MsgCode.StopBits, "Stop Bits");
            this.AddMsg(MsgCode.Parity, "সাদৃশ্য");
            this.AddMsg(MsgCode.FlowControl, "Flow Control");
            this.AddMsg(MsgCode.Read, "পঠিত");
            this.AddMsg(MsgCode.ReadFailure, "পড়তে ব্যর্থ হয়েছে।");
            this.AddMsg(MsgCode.Write, "লেখা");
            this.AddMsg(MsgCode.WriteFailue, "লিখনে ব্যর্থতা");
            this.AddMsg(MsgCode.Delete, "মুছুন");
            this.AddMsg(MsgCode.DeleteFailure, "বিলোপ করা ব্যর্থ হয়েছে");
            this.AddMsg(MsgCode.CannotDeleteLast, "শেষটি মুছতে পারে না");
            this.AddMsg(MsgCode.Timeout, "সময়সীমা সমাপ্ত");
            this.AddMsg(MsgCode.Log, "লগ");
            this.AddMsg(MsgCode.None, "একটিও নয়");
            this.AddMsg(MsgCode.NotFound, "খুঁজে পাওয়া যায়নি");
            this.AddMsg(MsgCode.UnknownError, "অজানা ত্রুটি");
            this.AddMsg(MsgCode.UnhandledError, "অজানা ত্রুটি");
            this.AddMsg(MsgCode.Support, "সমর্থন");
            this.AddMsg(MsgCode.Edit, "সম্পাদনা");
            this.AddMsg(MsgCode.Create, "তৈরি করুন");
            this.AddMsg(MsgCode.NothingSelected, "কোনো নির্বাচন নেই");
            this.AddMsg(MsgCode.Ethernet, "ইথারনেট");
            this.AddMsg(MsgCode.EmptyParameter, "খালি প্যারামিটার");
            this.AddMsg(MsgCode.AbandonChanges, "পরিবর্তনগুলো পরিত্যাগ করুন?");
            this.AddMsg(MsgCode.Run, "চালনা");
            this.AddMsg(MsgCode.InsufficienPermissions, "অপ্রতুল অনুমতিগুলি");
            this.AddMsg(MsgCode.CodeSamples, "কোড নমুনাগুলি");
            this.AddMsg(MsgCode.AuthenticationType, "প্রমাণীকরণের প্রকার");
            this.AddMsg(MsgCode.EncryptionType, "এনক্রিপশনের প্রকার");
            this.AddMsg(MsgCode.SignalStrength, "সিগন্যালের শক্তি");
            this.AddMsg(MsgCode.UpTime, "আপ সময়");
            this.AddMsg(MsgCode.MacAddress, "MAC ঠিকানা");
            this.AddMsg(MsgCode.Kind, "প্রকার");
            this.AddMsg(MsgCode.BeaconInterval, "(Beacon) ব্যবধান");
            this.AddMsg(MsgCode.AccessStatus, "স্থিতি");
            this.AddMsg(MsgCode.AddressType, "ঠিকানার প্রকার");
            this.AddMsg(MsgCode.Paired, "জোড়া");
            this.AddMsg(MsgCode.ProtectionLevel, "সুরক্ষা স্তর");
            this.AddMsg(MsgCode.SecureConnection, "সুরক্ষিত সংযোগের মাধ্যমে ");
            this.AddMsg(MsgCode.Id, "Id");
            this.AddMsg(MsgCode.Allowed, "মঞ্জুরিপ্রাপ্ত");
            this.AddMsg(MsgCode.Address, "ঠিকানা");
            this.AddMsg(MsgCode.DeviceClass, "Device Class");
            this.AddMsg(MsgCode.ServiceClass, "Service Class");
            this.AddMsg(MsgCode.LastSeen, "Last Seen");
            this.AddMsg(MsgCode.LastUsed, "Last Used");
            this.AddMsg(MsgCode.Authenticated, "প্রমাণীকৃত");
            this.AddMsg(MsgCode.RemoteHost, "দূরবর্তী আয়োজক");
            this.AddMsg(MsgCode.RemoteService, "রিমোট পরিষেবার");
            this.AddMsg(MsgCode.Clear, "পরিষ্কার করুন");
            this.AddMsg(MsgCode.ResetAll, "সকল ডিফল্ট পুনরায় সেট করুন");
            this.AddMsg(MsgCode.Disconnected, "সংযোগ বিচ্ছিন্ন");


            //this.AddMsg(MsgCode., "");
        }

    }


}
