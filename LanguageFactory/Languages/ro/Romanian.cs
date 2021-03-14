﻿using LanguageFactory.Net.data;
using LanguageFactory.Net.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageFactory.Net.Languages.ro {

    public class Romanian : SupportedLanguage {

        public Romanian() : base() {
            this.SetLanguage(LangCode.Romanian, "Română");

            // Common messages
            this.AddMsg(MsgCode.save, "Salvare");
            this.AddMsg(MsgCode.login, "Conecta");
            this.AddMsg(MsgCode.logoff, "Deconecta");
            this.AddMsg(MsgCode.copy, "Copiere");
            this.AddMsg(MsgCode.no, "Nu");
            this.AddMsg(MsgCode.yes, "Da");
            this.AddMsg(MsgCode.New, "Nou");
            this.AddMsg(MsgCode.Ok, "OK");
            this.AddMsg(MsgCode.exit, "Părăsiți");
            this.AddMsg(MsgCode.start, "Start");
            this.AddMsg(MsgCode.stop, "Stop");
            this.AddMsg(MsgCode.language, "Limbi");
            this.AddMsg(MsgCode.send, "Trimiteți");
            this.AddMsg(MsgCode.command, "Comandă");
            this.AddMsg(MsgCode.commands, "Comenzi");
            this.AddMsg(MsgCode.response, "Răspuns");
            this.AddMsg(MsgCode.select, "Selectați");
            this.AddMsg(MsgCode.Search, "Căutare");
            this.AddMsg(MsgCode.connect, "Conectare");
            this.AddMsg(MsgCode.Connected, "Conectat");
            this.AddMsg(MsgCode.Disconnected, "Deconectat");
            this.AddMsg(MsgCode.ConnectionFailure, "Conexiune nereușită");
            this.AddMsg(MsgCode.Disconnect, "Deconectare");
            this.AddMsg(MsgCode.NotConnected, "Neconectat");
            this.AddMsg(MsgCode.cancel, "Anulare");
            this.AddMsg(MsgCode.info, "Informații");
            this.AddMsg(MsgCode.Settings, "Setări");
            this.AddMsg(MsgCode.Terminators, "Terminatori");
            this.AddMsg(MsgCode.Name, "Nume");
            this.AddMsg(MsgCode.Error, "Eroare");
            this.AddMsg(MsgCode.Warning, "Avertisment");
            this.AddMsg(MsgCode.EmptyName, "Numele nu poate fi gol");
            this.AddMsg(MsgCode.LoadFailed, "Nu s-a reușit încărcarea");
            this.AddMsg(MsgCode.SaveFailed, "Nu s-a salvat ");
            this.AddMsg(MsgCode.EnterName, "Introduceți numele");
            this.AddMsg(MsgCode.Continue, "Continuare?");
            this.AddMsg(MsgCode.Configure, "Configurare");
            this.AddMsg(MsgCode.NoServices, "Niciun serviciu");
            this.AddMsg(MsgCode.PairBluetooth, "Împerechere Bluetooth");
            this.AddMsg(MsgCode.EnterPin, "Introduceți PIN-ul");
            this.AddMsg(MsgCode.PairedDevices, "Dispozitive împerecheate");
            this.AddMsg(MsgCode.Pair, "Împerechea");
            this.AddMsg(MsgCode.Unpair, "Anulați asocierea");
            this.AddMsg(MsgCode.Password, "Parolă");
            this.AddMsg(MsgCode.HostName, "Nume gazdă");
            this.AddMsg(MsgCode.NetworkService, "NetworkService");
            this.AddMsg(MsgCode.Port, "Port");
            this.AddMsg(MsgCode.NetworkSecurityKey, "Cheie de securitate rețea");
            this.AddMsg(MsgCode.Network, "Rețea");
            this.AddMsg(MsgCode.Socket, "Soclu");
            this.AddMsg(MsgCode.Credentials, "Acreditări");
            this.AddMsg(MsgCode.About, "Despre");
            this.AddMsg(MsgCode.Icons, "Pictograme");
            this.AddMsg(MsgCode.Author, "Autor");
            this.AddMsg(MsgCode.Services, "Servicii");
            this.AddMsg(MsgCode.Properties, "Proprietăți");
            this.AddMsg(MsgCode.UserManual, "Ghid de utilizare");
            this.AddMsg(MsgCode.Vendor, "Vânzător");
            this.AddMsg(MsgCode.Product, "Produs");
            this.AddMsg(MsgCode.Enabled, "Activat");
            this.AddMsg(MsgCode.Default, "Implicit");
            this.AddMsg(MsgCode.BaudRate, "Rată de transfer");
            this.AddMsg(MsgCode.DataBits, "Biți de date");
            this.AddMsg(MsgCode.StopBits, "Biți de stop");
            this.AddMsg(MsgCode.Parity, "Paritate");
            this.AddMsg(MsgCode.FlowControl, "Control flux");
            this.AddMsg(MsgCode.Read, "Citite");
            this.AddMsg(MsgCode.ReadFailure, "Eroare de citire");
            this.AddMsg(MsgCode.Write, "Scriere");
            this.AddMsg(MsgCode.WriteFailue, "Imposibil de scris");
            this.AddMsg(MsgCode.Delete, "Ștergere");
            this.AddMsg(MsgCode.DeleteFailure, "Imposibil de șters");
            this.AddMsg(MsgCode.CannotDeleteLast, "Nu se poate șterge ultimul");
            this.AddMsg(MsgCode.Timeout, "Pauză");
            this.AddMsg(MsgCode.Log, "Jurnal");
            this.AddMsg(MsgCode.None, "Niciuna");
            this.AddMsg(MsgCode.NotFound, "Negăsit");
            this.AddMsg(MsgCode.UnknownError, "Eroare necunoscută");
            this.AddMsg(MsgCode.UnhandledError, "Eroare netratată");
            this.AddMsg(MsgCode.Support, "Asistență");
            this.AddMsg(MsgCode.Edit, "Editare");
            this.AddMsg(MsgCode.Create, "Creare");
            this.AddMsg(MsgCode.NothingSelected, "Nimic selectat");
            this.AddMsg(MsgCode.Ethernet, "Ethernet");
            this.AddMsg(MsgCode.EmptyParameter, "Parametrul gol nu poate fi adăugat");
            this.AddMsg(MsgCode.AbandonChanges, "Abandonare date nesalvate?");
            this.AddMsg(MsgCode.Run, "Executare");
            this.AddMsg(MsgCode.InsufficienPermissions, "Permisiuni insuficiente");
            this.AddMsg(MsgCode.CodeSamples, "Exemple de cod");
            this.AddMsg(MsgCode.AuthenticationType, "Tip de autentificare");
            this.AddMsg(MsgCode.EncryptionType, "Tip de criptare");
            this.AddMsg(MsgCode.SignalStrength, "Intensitate semnal");
            this.AddMsg(MsgCode.UpTime, "Durata funcționării");
            this.AddMsg(MsgCode.MacAddress, "Adresă MAC");
            this.AddMsg(MsgCode.Kind, "Tip");
            this.AddMsg(MsgCode.BeaconInterval, "Interval de beacon");
            this.AddMsg(MsgCode.AccessStatus, "AccessStatus");
            this.AddMsg(MsgCode.AddressType, "interval de");
            this.AddMsg(MsgCode.Paired, "Împerecheat");
            this.AddMsg(MsgCode.ProtectionLevel, "Nivel de protecție");
            this.AddMsg(MsgCode.SecureConnection, "Conexiune protejată");
            this.AddMsg(MsgCode.Id, "ID");
            this.AddMsg(MsgCode.Allowed, "Permis");
            this.AddMsg(MsgCode.Address, "Adresă");
            this.AddMsg(MsgCode.DeviceClass, "Clasă dispozitiv");
            this.AddMsg(MsgCode.ServiceClass, "Clasă serviciu");
            this.AddMsg(MsgCode.LastSeen, "Last Seen");
            this.AddMsg(MsgCode.LastUsed, "Last Used");
            this.AddMsg(MsgCode.Authenticated, "Autentificat");
            this.AddMsg(MsgCode.RemoteHost, "Gazdă la distanță");
            this.AddMsg(MsgCode.RemoteService, "Servicii la distanță");
            this.AddMsg(MsgCode.Clear, "Golire");
            this.AddMsg(MsgCode.ResetAll, "Resetare totală");
            this.AddMsg(MsgCode.Characteristic, "Caracteristică");
            this.AddMsg(MsgCode.Descriptor, "Descriptor");
            this.AddMsg(MsgCode.Min, "Min");
            this.AddMsg(MsgCode.Max, "Maxim");
            this.AddMsg(MsgCode.ReadOnly, "Doar în citire");
            this.AddMsg(MsgCode.InvalidInput, "Intrare incorectă");
            this.AddMsg(MsgCode.ParseFailed, "Parcurgere nereușită");
            this.AddMsg(MsgCode.OutOfRange, "În afara intervalului");
            this.AddMsg(MsgCode.email, "E-mail");
            this.AddMsg(MsgCode.CrashReport, "Raport de cădere");
            this.AddMsg(MsgCode.DataType, "Tip de date");
            this.AddMsg(MsgCode.Service, "Serviciu");
            this.AddMsg(MsgCode.Notifications, "Notificări");
            this.AddMsg(MsgCode.Disabled, "Dezactivat");
            this.AddMsg(MsgCode.Description, "Descriere");
            this.AddMsg(MsgCode.Unit, "Unitate");
            this.AddMsg(MsgCode.Exponent, "Exponent");
            this.AddMsg(MsgCode.True, "Adevărat");
            this.AddMsg(MsgCode.False, "Fals");
            this.AddMsg(MsgCode.Even, "Pare");
            this.AddMsg(MsgCode.Odd, "Impare");
            this.AddMsg(MsgCode.Mark, "Mark");
            this.AddMsg(MsgCode.Space, "Space");

        }


    }

}
