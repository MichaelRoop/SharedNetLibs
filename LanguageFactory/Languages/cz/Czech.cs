﻿using LanguageFactory.Net.data;
using LanguageFactory.Net.Messaging;

namespace LanguageFactory.Net.Languages.cz {

    public class Czech : SupportedLanguage {

        public Czech() {
            this.SetLanguage(LangCode.Czech, "Çekçe");

            // Common messages
            this.AddMsg(MsgCode.save, "Uložit");
            this.AddMsg(MsgCode.login, "Přihlášení");
            this.AddMsg(MsgCode.logoff, "Odhlášení");
            this.AddMsg(MsgCode.copy, "Kopírovat");
            this.AddMsg(MsgCode.no, "Ne");
            this.AddMsg(MsgCode.yes, "Ano");
            this.AddMsg(MsgCode.New, "Nová");
            this.AddMsg(MsgCode.Ok, "OK");
            this.AddMsg(MsgCode.exit, "Konec");
            this.AddMsg(MsgCode.start, "Zahájit");
            this.AddMsg(MsgCode.stop, "Zastavit");
            this.AddMsg(MsgCode.language, "Jazyk");
            this.AddMsg(MsgCode.send, "Odeslat");
            this.AddMsg(MsgCode.command, "Příkaz");
            this.AddMsg(MsgCode.commands, "Příkazy");
            this.AddMsg(MsgCode.response, "Odpověď");
            this.AddMsg(MsgCode.select, "Vybrat");
            this.AddMsg(MsgCode.Search, "Hledat");
            this.AddMsg(MsgCode.connect, "Připojit");
            this.AddMsg(MsgCode.Connected, "Připojeno");
            this.AddMsg(MsgCode.ConnectionFailure, "Chyba připojení");
            this.AddMsg(MsgCode.Disconnect, "Odpojit");
            this.AddMsg(MsgCode.NotConnected, "Nepřipojeno");
            this.AddMsg(MsgCode.cancel, "Storno");
            this.AddMsg(MsgCode.info, "Informace");
            this.AddMsg(MsgCode.Settings, "Nastavení");
            this.AddMsg(MsgCode.Terminators, "Ukončovací znaky");
            this.AddMsg(MsgCode.Name, "Název");
            this.AddMsg(MsgCode.Error, "Chyba");
            this.AddMsg(MsgCode.Warning, "Varování");
            this.AddMsg(MsgCode.EmptyName, "Název nemůže být prázdný");
            this.AddMsg(MsgCode.LoadFailed, "Nelze načíst");
            this.AddMsg(MsgCode.SaveFailed, "Uložení se nezdařilo");
            this.AddMsg(MsgCode.EnterName, "Zadejte název");
            this.AddMsg(MsgCode.Continue, "Pokračovat?");
            this.AddMsg(MsgCode.Configure, "Konfigurovat");
            this.AddMsg(MsgCode.NoServices, "Nebyly nabídnuty žádné služby");
            this.AddMsg(MsgCode.PairBluetooth, "Spárovat Bluetooth");
            this.AddMsg(MsgCode.EnterPin, "Zadání PIN kódu");
            this.AddMsg(MsgCode.PairedDevices, "Spárovaná zařízení");
            this.AddMsg(MsgCode.Pair, "Spárovat");
            this.AddMsg(MsgCode.Unpair, "Zrušit párování");
            this.AddMsg(MsgCode.Password, "Heslo");
            this.AddMsg(MsgCode.HostName, "Název hostitele");
            this.AddMsg(MsgCode.NetworkService, "Síťová služba");
            this.AddMsg(MsgCode.Port, "Port");
            this.AddMsg(MsgCode.NetworkSecurityKey, "Klíč zabezpečení sítě");
            this.AddMsg(MsgCode.Network, "Síť");
            this.AddMsg(MsgCode.Socket, "Soket");
            this.AddMsg(MsgCode.Credentials, "Přihlašovací údaje");
            this.AddMsg(MsgCode.About, "O produktu");
            this.AddMsg(MsgCode.Icons, "Ikony");
            this.AddMsg(MsgCode.Author, "Autor");
            this.AddMsg(MsgCode.Services, "Služby");
            this.AddMsg(MsgCode.Properties, "Vlastnosti");
            this.AddMsg(MsgCode.UserManual, "Uživatelská příručka");
            this.AddMsg(MsgCode.Vendor, "Dodavatel");
            this.AddMsg(MsgCode.Product, "Produkt");
            this.AddMsg(MsgCode.Default, "Výchozí");
            this.AddMsg(MsgCode.BaudRate, "Přenosová rychlost");
            this.AddMsg(MsgCode.Enabled, "Povoleno");
            this.AddMsg(MsgCode.DataBits, "Datové bity");
            this.AddMsg(MsgCode.StopBits, "Stop bity");
            this.AddMsg(MsgCode.Parity, "Parita");
            this.AddMsg(MsgCode.FlowControl, "Řízení toku");
            this.AddMsg(MsgCode.Read, "Číst");
            this.AddMsg(MsgCode.ReadFailure, "Chyba čtení");
            this.AddMsg(MsgCode.Write, "Zápis");
            this.AddMsg(MsgCode.WriteFailue, "Chyba zápisu");
            this.AddMsg(MsgCode.Timeout, "Časový limit");
            this.AddMsg(MsgCode.Delete, "Odstraňovat");
            this.AddMsg(MsgCode.DeleteFailure, "Odstranění se nezdařilo");
            this.AddMsg(MsgCode.CannotDeleteLast, "Nelze odstranit poslední položku");
            this.AddMsg(MsgCode.Log, "Protokol");
            this.AddMsg(MsgCode.None, "Žádné");
            this.AddMsg(MsgCode.NotFound, "Nenalezeno");
            this.AddMsg(MsgCode.UnknownError, "Neznámá chyba");
            this.AddMsg(MsgCode.UnhandledError, "Neošetřená chyba");
            this.AddMsg(MsgCode.Support, "Podpora");
            this.AddMsg(MsgCode.Edit, "Úpravit");
            this.AddMsg(MsgCode.Create, "Vytvořit");
            this.AddMsg(MsgCode.NothingSelected, "Není vybrána žádná položka");
            this.AddMsg(MsgCode.Ethernet, "Ethernet");
            this.AddMsg(MsgCode.EmptyParameter, "Nelze přidat prázdný parametr");
            this.AddMsg(MsgCode.AbandonChanges, "Zahodit změny?");
            this.AddMsg(MsgCode.Run, "Spustit");
            this.AddMsg(MsgCode.InsufficienPermissions, "Nedostatečná oprávnění");
            this.AddMsg(MsgCode.CodeSamples, "Ukázky kódu");
            this.AddMsg(MsgCode.AuthenticationType, "Typ ověřování");
            this.AddMsg(MsgCode.EncryptionType, "Typ šifrování");
            this.AddMsg(MsgCode.SignalStrength, "Síla signálu");
            this.AddMsg(MsgCode.UpTime, "Doba provozu");
            this.AddMsg(MsgCode.MacAddress, "Adresa MAC");
            this.AddMsg(MsgCode.Kind, "Typ");
            this.AddMsg(MsgCode.BeaconInterval, "Interval signálu");
            this.AddMsg(MsgCode.AccessStatus, "Stav přístupu");
            this.AddMsg(MsgCode.AddressType, "Typ adresy");
            this.AddMsg(MsgCode.Paired, "Spárováno");
            this.AddMsg(MsgCode.ProtectionLevel, "Úroveň ochrany");
            this.AddMsg(MsgCode.SecureConnection, "Zabezpečené připojení");
            this.AddMsg(MsgCode.Id, "ID");
            this.AddMsg(MsgCode.Allowed, "Povoleno");
            this.AddMsg(MsgCode.Address, "Adresa");
            this.AddMsg(MsgCode.DeviceClass, "Třída zařízení");
            this.AddMsg(MsgCode.ServiceClass, "Třída služeb");
            this.AddMsg(MsgCode.LastSeen, "Last Seen");
            this.AddMsg(MsgCode.LastUsed, "Last Used");
            this.AddMsg(MsgCode.Authenticated, "Ověřen");
            this.AddMsg(MsgCode.RemoteHost, "Vzdálený hostitel");
            this.AddMsg(MsgCode.RemoteService, "Vzdálená služba");
            this.AddMsg(MsgCode.Clear, "Vymazat");
            this.AddMsg(MsgCode.ResetAll, "Obnovit výchozí");
            this.AddMsg(MsgCode.Disconnected, "Odpojené");
            this.AddMsg(MsgCode.Characteristic, "Charakteristika");
            this.AddMsg(MsgCode.Descriptor, "Popisovač");
            this.AddMsg(MsgCode.Min, "Min");
            this.AddMsg(MsgCode.Max, "Max");
            this.AddMsg(MsgCode.ReadOnly, "Jen pro čtení");
            this.AddMsg(MsgCode.InvalidInput, "Neplatné zadání");
            this.AddMsg(MsgCode.ParseFailed, "Analýza selhala");
            this.AddMsg(MsgCode.OutOfRange, "Mimo rozsah");
            this.AddMsg(MsgCode.email, "E-mail");
            this.AddMsg(MsgCode.CrashReport, "Hlášení o selhání");


        }


    }
}
