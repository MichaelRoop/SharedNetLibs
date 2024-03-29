﻿using LanguageFactory.Net.data;
using LanguageFactory.Net.Messaging;

namespace LanguageFactory.Net.Languages.pr {
    public class Punjabi : SupportedLanguage {

        public Punjabi() : base() { 
            this.SetLanguage(LangCode.Punjabi, "ਪੰਜਾਬੀ");

            // Common messages
            this.AddMsg(MsgCode.save, "ਸੁਰੱਖਿਅਤ ਕਰੋ");
            this.AddMsg(MsgCode.login, "ਦਾਖਲ ਹੋਣਾ");
            this.AddMsg(MsgCode.logoff, "ਬੰਦ ਕਰੋ");
            this.AddMsg(MsgCode.copy, "ਪ੍ਰਤਿਲਿਪੀ");
            this.AddMsg(MsgCode.no, "ਨਹੀਂ");
            this.AddMsg(MsgCode.yes, "ਹਾਂ");
            this.AddMsg(MsgCode.New, "ਨਵਾਂ");
            this.AddMsg(MsgCode.Ok, "ਠੀਕ");
            this.AddMsg(MsgCode.exit, "ਨਿਕਾਸ");
            this.AddMsg(MsgCode.start, "ਸ਼ੁਰੂਵਾਤ");
            this.AddMsg(MsgCode.stop, "ਰੋਕੋ");
            this.AddMsg(MsgCode.language, "ਭਾਸ਼ਾ");
            this.AddMsg(MsgCode.send, "ਭੇਜੋ");
            this.AddMsg(MsgCode.command, "ਆਦੇਸ਼");
            this.AddMsg(MsgCode.commands, "ਆਦੇਸ਼");
            this.AddMsg(MsgCode.response, "ਪ੍ਰਤੀਕਿਰਿਆ");
            this.AddMsg(MsgCode.select, "ਚੋਣ ਕਰੋ");
            this.AddMsg(MsgCode.Search, "ਖੋਜ ਕਰੋ");
            this.AddMsg(MsgCode.connect, "ਸਪੰਰਕ ਕਰੋ");
            this.AddMsg(MsgCode.Connected, "ਸੰਪਰਕ ਕੀਤਾ");
            this.AddMsg(MsgCode.Disconnected, "ਡਿਸਕਨੈਕਟ ਹੋਇਆ");
            this.AddMsg(MsgCode.ConnectionFailure, "ਕਨੈਕਸ਼ਨ ਅਸਫਲਤਾ");
            this.AddMsg(MsgCode.Disconnect, "ਡਿਸਕਨੈਕਟ ਕਰੋ");
            this.AddMsg(MsgCode.NotConnected, "ਕਨੈਕਟ ਨਹੀਂ ਹੈ");
            this.AddMsg(MsgCode.cancel, "ਰੱਦ ਕਰੋ");
            this.AddMsg(MsgCode.info, "ਜਾਣਕਾਰੀ");
            this.AddMsg(MsgCode.Settings, "ਸੈਟਿੰਗਾਂ");
            this.AddMsg(MsgCode.Terminators, "Terminators");
            this.AddMsg(MsgCode.Name, "ਨਾਮ");
            this.AddMsg(MsgCode.Error, "ਤਰੁਟੀ");
            this.AddMsg(MsgCode.Warning, "ਚੇਤਾਵਨੀ");
            this.AddMsg(MsgCode.EmptyName, "ਦਾ ਨਾਮ ਖਾਲੀ ਨਹੀਂ ਹੋ ਸਕਦਾ");
            this.AddMsg(MsgCode.LoadFailed, "ਲੋਡ ਨਹੀਂ ਹੋ ਪਾਇਆ");
            this.AddMsg(MsgCode.SaveFailed, "ਸੁਰੱਖਿਅਤ ਕਰਨ ਵਿੱਚ ਅਸਫਲ ਹੋਇਆ");
            this.AddMsg(MsgCode.EnterName, "ਨਾਮ ਦਾਖ਼ਲ");
            this.AddMsg(MsgCode.Continue, "ਜਾਰੀ ਰੱਖੋ?");
            this.AddMsg(MsgCode.Configure, "ਕੌਨਫਿਗਰ ਕਰੋ");
            this.AddMsg(MsgCode.NoServices, "ਕੋਈ ਸੇਵਾ ਉਪਲਬਧ ਨਹੀਂ");
            this.AddMsg(MsgCode.PairBluetooth, "Bluetooth ਨਾਲ ਜੋੜਾ ਬਣਾਉ");
            this.AddMsg(MsgCode.EnterPin, "PIN ਦਾਖਲ ਕਰੋ");
            this.AddMsg(MsgCode.PairedDevices, "ਜੋੜ ਕੀਤੇ ਡਿਵਾਈਸਿਸ");
            this.AddMsg(MsgCode.Pair, "ਜੋੜਾ ਬਣਾਓ");
            this.AddMsg(MsgCode.Unpair, "ਅਣਜੁੜਿਆ");
            this.AddMsg(MsgCode.Password, "ਪਾਸਵਰਡ");
            this.AddMsg(MsgCode.HostName, "ਹੋਸਟ ਨਾਮ");
            this.AddMsg(MsgCode.NetworkService, "ਨੈਟਵਰਕ ਸੇਵਾ");
            this.AddMsg(MsgCode.Port, "ਪੋਰਟ");
            this.AddMsg(MsgCode.NetworkSecurityKey, "ਨੈਟਵਰਕ ਸੁਰੱਖਿਆ ਕੁੰਜੀ");
            this.AddMsg(MsgCode.Network, "ਨੈੱਟਵਰਕ");
            this.AddMsg(MsgCode.Socket, "ਸਾਕੇਟ");
            this.AddMsg(MsgCode.Credentials, "ਕ੍ਰਿਡੈਂਸ਼ਿਅਲਸ");
            this.AddMsg(MsgCode.About, "ਸੰਬੰਧੀ");
            this.AddMsg(MsgCode.Icons, "ਆਈਕੋਨ");
            this.AddMsg(MsgCode.Author, "ਲੇਖਕ");
            this.AddMsg(MsgCode.Services, "ਸੇਵਾਵਾਂ");
            this.AddMsg(MsgCode.Properties, "ਗੁਣ");
            this.AddMsg(MsgCode.UserManual, "ਉਪਭੋਗਤਾ ਮਾਰਗਦਰਸ਼ਕ");
            this.AddMsg(MsgCode.Vendor, "ਵਿਕਰੇਤਾ");
            this.AddMsg(MsgCode.Product, "ਪ੍ਰੌਡਕਟ");
            this.AddMsg(MsgCode.Enabled, "ਸਮਰੱਥ ਕੀਤਾ");
            this.AddMsg(MsgCode.Default, "ਡਿਫੌਲਟ");
            this.AddMsg(MsgCode.BaudRate, "ਬੌਡ ਰੇਟ");
            this.AddMsg(MsgCode.DataBits, "ਡੇਟਾ ਬਿਟਸ");
            this.AddMsg(MsgCode.StopBits, "Stop Bits");
            this.AddMsg(MsgCode.Parity, "Parity");
            this.AddMsg(MsgCode.FlowControl, "Flow Control");
            this.AddMsg(MsgCode.Read, "ਪੜ੍ਹੋ");
            this.AddMsg(MsgCode.ReadFailure, "ਪੜ੍ਹਨ ਲਈ ਅਸਫ਼ਲ ਹੈ।");
            this.AddMsg(MsgCode.Write, "ਲਿੱਖੋ");
            this.AddMsg(MsgCode.WriteFailue, "ਲਿਖਣ ਵਿੱਚ ਅਸਫਲ");
            this.AddMsg(MsgCode.Delete, "ਮਿਟਾਓ");
            this.AddMsg(MsgCode.DeleteFailure, "ਮਿਟਾਉਣ ਵਿੱਚ ਅਸਫਲ ਹੋਏ");
            this.AddMsg(MsgCode.CannotDeleteLast, "ਅਖੀਰਲਾ ਦਾਖਲਾ ਨਹੀਂ ਮਿਟਾ ਸਕਦੇ");
            this.AddMsg(MsgCode.Timeout, "ਸਮਾਂ ਸਮਾਪਤ ਹੋ ਗਿਆ");
            this.AddMsg(MsgCode.Log, "ਲੌਗ");
            this.AddMsg(MsgCode.None, "ਕੋਈ ਨਹੀਂ");
            this.AddMsg(MsgCode.NotFound, "ਨਹੀਂ ਮਿਲਿਆ");
            this.AddMsg(MsgCode.UnknownError, "ਅਗਿਆਤ ਗ਼ਲਤੀ");
            this.AddMsg(MsgCode.UnhandledError, "Unhandled Error");
            this.AddMsg(MsgCode.Support, "ਸਹਾਇਤਾ");
            this.AddMsg(MsgCode.Edit, "ਸੰਪਾਦਨ ਕਰੋ");
            this.AddMsg(MsgCode.Create, "ਬਣਾਉ");
            this.AddMsg(MsgCode.NothingSelected, "ਕੁਝ ਚੁਣੋ");
            this.AddMsg(MsgCode.Ethernet, "ਈਥਰਨੈਟ");
            this.AddMsg(MsgCode.EmptyParameter, "ਮਾਪਦੰਡ ਮਾਨ ਦਾਖਲ ਕਰੋ");
            this.AddMsg(MsgCode.AbandonChanges, "ਬਦਲਾਵਾਂ ਨੂੰ ਬਰਖਾਸਤ ਕਰੋ?");
            this.AddMsg(MsgCode.Run, "ਚੱਲਣਾ");
            this.AddMsg(MsgCode.InsufficienPermissions, "ਨਾਕਾਫੀ ਇਜਾਜ਼ਤਾਂ");
            this.AddMsg(MsgCode.CodeSamples, "ਕੋਡ ਨਮੂਨੇ");
            this.AddMsg(MsgCode.AuthenticationType, "ਪੁਸ਼ਟੀਕਰਣ ਕਿਸਮ");
            this.AddMsg(MsgCode.EncryptionType, "ਏਨਕ੍ਰਿਪਸ਼ਨ ਕਿਸਮ");
            this.AddMsg(MsgCode.SignalStrength, "ਸਿਗਨਲ ਪ੍ਰਬਲਤਾ");
            this.AddMsg(MsgCode.UpTime, "ਉਪਰਲਾ ਸਮਾਂ");
            this.AddMsg(MsgCode.MacAddress, "MAC ਪਤਾ");
            this.AddMsg(MsgCode.Kind, "ਪ੍ਰਕਾਰ");
            this.AddMsg(MsgCode.BeaconInterval, "ਅੰਤਰਾਲ Beacon");
            this.AddMsg(MsgCode.AccessStatus, "ਸਥਿਤੀ");
            this.AddMsg(MsgCode.AddressType, "ਪਤਾ ਪ੍ਰਕਾਰ");
            this.AddMsg(MsgCode.Paired, "ਜੋੜਾ ਬਣਾਏ ਗਏ");
            this.AddMsg(MsgCode.ProtectionLevel, "ਸੁਰੱਖਿਆ ਪੱਧਰ");
            this.AddMsg(MsgCode.SecureConnection, "ਸੁਰੱਖਿਅਤ ਕਨੈਕਸ਼ਨ");
            this.AddMsg(MsgCode.Id, "ID");
            this.AddMsg(MsgCode.Allowed, "ਇਜਾਜ਼ਤ ਪ੍ਰਾਪਤ");
            this.AddMsg(MsgCode.Address, "ਪਤਾ");
            this.AddMsg(MsgCode.DeviceClass, "Device Class");
            this.AddMsg(MsgCode.ServiceClass, "Service Class");
            this.AddMsg(MsgCode.LastSeen, "ਆਖਰੀ ਵਾਰ ਦੇਖਿਆ ਗਿਆ");
            this.AddMsg(MsgCode.LastUsed, "ਆਖਿਰ ਵਾਰੀ ਵਰਤਿਆ");
            this.AddMsg(MsgCode.Authenticated, "ਪ੍ਰਮਾਣਤ");
            this.AddMsg(MsgCode.RemoteHost, "Remote Host");
            this.AddMsg(MsgCode.RemoteService, "Remote Service");
            this.AddMsg(MsgCode.Clear, "ਮਿਟਾਓ");
            this.AddMsg(MsgCode.ResetAll, "ਸਾਰੇ ਦੁਬਾਰਾ ਸੈਟ ਕਰੋ");
            this.AddMsg(MsgCode.Characteristic, "Characteristic");
            this.AddMsg(MsgCode.Descriptor, "Descriptor");
            this.AddMsg(MsgCode.Min, "ਨਿਊਨਤਮ");
            this.AddMsg(MsgCode.Max, "ਅਧਿਕਤਮ");
            this.AddMsg(MsgCode.ReadOnly, "ਸਿਰਫ਼ ਪੜ੍ਹੋ");
            this.AddMsg(MsgCode.InvalidInput, "ਅਯੋਗ ਇਨਪੁਟ");
            this.AddMsg(MsgCode.ParseFailed, "Parse failed");
            this.AddMsg(MsgCode.OutOfRange, "ਮਾਨ ਦਾਇਰੇ ਤੋਂ ਬਾਹਰ");
            this.AddMsg(MsgCode.email, "ਈਮੇਲ");
            this.AddMsg(MsgCode.CrashReport, "Crash Report");
            this.AddMsg(MsgCode.DataType, "ਡੇਟਾ ਕਿਸਮ");
            this.AddMsg(MsgCode.Service, "ਸੇਵਾ");
            this.AddMsg(MsgCode.Notifications, "ਸੂਚਨਾਵਾਂ");
            this.AddMsg(MsgCode.Disabled, "ਅਸਮਰੱਥ");
            this.AddMsg(MsgCode.Description, "ਵਰਣਨ");
            this.AddMsg(MsgCode.Unit, "ਇਕਾਈ");
            this.AddMsg(MsgCode.Exponent, "ਘਾਤਾਂਕ");
            this.AddMsg(MsgCode.True, "ਸਹੀ");
            this.AddMsg(MsgCode.False, "ਗਲਤ");
            this.AddMsg(MsgCode.Even, "ਸਮ");
            this.AddMsg(MsgCode.Odd, "ਵਿਸ਼ਮ");
            this.AddMsg(MsgCode.Mark, "Mark");
            this.AddMsg(MsgCode.Space, "Space");
            this.AddMsg(MsgCode.Preview, "ਪੂਰਵਦਰਸ਼ਨ");
            this.AddMsg(MsgCode.Configuration, "Configuration");
            this.AddMsg(MsgCode.Configurations, "Configurations");
            this.AddMsg(MsgCode.Inputs, "Inputs");
            this.AddMsg(MsgCode.Outputs, "Outputs");
            this.AddMsg(MsgCode.Digital, "ਡਿਜਿਟਲ");
            this.AddMsg(MsgCode.Analog, "ਐਨਾਲੌਗ");
            this.AddMsg(MsgCode.Step, "ਚਰਣ");
            this.AddMsg(MsgCode.Row, "ਕਤਾਰ");
            this.AddMsg(MsgCode.Column, "ਥੰਮ੍ਹ");
            this.AddMsg(MsgCode.Build, "ਸੰਸਕਰਣ");
            this.AddMsg(MsgCode.Unknown, "ਅਗਿਆਤ");

            //this.AddMsg(MsgCode., "");
        }

    }
}
