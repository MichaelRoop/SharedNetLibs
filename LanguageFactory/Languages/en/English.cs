using LanguageFactory.Net.data;
using LanguageFactory.Net.Messaging;

namespace LanguageFactory.Net.Languages.en {
    public class English : SupportedLanguage {

        public English() : base() {
            this.SetLanguage(LangCode.English, "English");

            // Common messages
            this.AddMsg(MsgCode.save, "Save");

            this.AddMsg(MsgCode.login, "Login");
            this.AddMsg(MsgCode.logoff, "Logoff");
            this.AddMsg(MsgCode.copy, "Copy");
            this.AddMsg(MsgCode.no, "No");
            this.AddMsg(MsgCode.yes, "Yes");
            this.AddMsg(MsgCode.New, "New");
            this.AddMsg(MsgCode.Ok, "OK");
            this.AddMsg(MsgCode.exit, "Exit");
            this.AddMsg(MsgCode.start, "Start");
            this.AddMsg(MsgCode.stop, "Stop");
            this.AddMsg(MsgCode.language, "Language");
            this.AddMsg(MsgCode.send, "Send");
            this.AddMsg(MsgCode.command, "Command");
            this.AddMsg(MsgCode.response, "Response");
            this.AddMsg(MsgCode.select, "Select");
            this.AddMsg(MsgCode.discover, "Discover");
            this.AddMsg(MsgCode.connect, "Connect");
            this.AddMsg(MsgCode.cancel, "Cancel");
            this.AddMsg(MsgCode.info, "Info");
            this.AddMsg(MsgCode.Settings, "Settings");
            this.AddMsg(MsgCode.Terminators, "Terminators");
            this.AddMsg(MsgCode.Name, "Name");
            this.AddMsg(MsgCode.Error, "Error");
            this.AddMsg(MsgCode.CannotDeleteLast, "Cannot delete last entry");
            this.AddMsg(MsgCode.EmptyName, "Name cannot be empty");
            this.AddMsg(MsgCode.LoadFailed, "Failed to load");
            this.AddMsg(MsgCode.SaveFailed, "Failed to save");
            this.AddMsg(MsgCode.EnterName, "Enter name");
            this.AddMsg(MsgCode.Continue, "Continue?");
            this.AddMsg(MsgCode.Configure, "Configure");
            this.AddMsg(MsgCode.NoServices, "No services");
            this.AddMsg(MsgCode.PairBluetooth, "Pair Bluetooth");
            this.AddMsg(MsgCode.EnterPin, "Enter PIN");
            this.AddMsg(MsgCode.PairedDevices, "Paired Devices");
            this.AddMsg(MsgCode.Pair, "Pair");
            this.AddMsg(MsgCode.Unpair, "Unpair");
            this.AddMsg(MsgCode.Disconnect, "Disconnect");
            this.AddMsg(MsgCode.Password, "Password");
            this.AddMsg(MsgCode.HostName, "Host Name");
            this.AddMsg(MsgCode.NetworkService, "Network Service");
            this.AddMsg(MsgCode.Port, "Port");
            this.AddMsg(MsgCode.NetworkSecurityKey, "Network Security Key");
            this.AddMsg(MsgCode.Network, "Network");
            this.AddMsg(MsgCode.Socket, "Socket");

            //this.AddMsg(MsgCode., "");
        }

    }
}
