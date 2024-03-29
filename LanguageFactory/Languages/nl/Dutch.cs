﻿using LanguageFactory.Net.data;
using LanguageFactory.Net.Messaging;

namespace LanguageFactory.Net.Languages.nl {
    public class Dutch : SupportedLanguage {

        public Dutch() : base() {
            this.SetLanguage(LangCode.Dutch, "Nederlands");

            // Common messages
            this.AddMsg(MsgCode.save, "Opslaan");
            this.AddMsg(MsgCode.login, "Aanmelden");
            this.AddMsg(MsgCode.logoff, "Afmelden");
            this.AddMsg(MsgCode.copy, "Kopiëren");
            this.AddMsg(MsgCode.no, "Nee");
            this.AddMsg(MsgCode.yes, "Ja");
            this.AddMsg(MsgCode.New, "Nieuwe");
            this.AddMsg(MsgCode.Ok, "OK");
            this.AddMsg(MsgCode.exit, "Afsluiten");
            this.AddMsg(MsgCode.start, "Starten");
            this.AddMsg(MsgCode.stop, "Stoppen");
            this.AddMsg(MsgCode.language, "Talen");
            this.AddMsg(MsgCode.send, "Verzenden");
            this.AddMsg(MsgCode.command, "Opdracht");
            this.AddMsg(MsgCode.commands, "Opdrachten");
            this.AddMsg(MsgCode.response, "Antwoord");
            this.AddMsg(MsgCode.select, "Selecteren");
            this.AddMsg(MsgCode.Search, "Zoeken");
            this.AddMsg(MsgCode.connect, "Verbinden");
            this.AddMsg(MsgCode.Connected, "Verbonden");
            this.AddMsg(MsgCode.Disconnected, "Verbinding verbroken");
            this.AddMsg(MsgCode.ConnectionFailure, "Verbinden mislukt");
            this.AddMsg(MsgCode.Disconnect, "Verbinding verbreken");
            this.AddMsg(MsgCode.NotConnected, "Niet verbonden");
            this.AddMsg(MsgCode.cancel, "Annuleren");
            this.AddMsg(MsgCode.info, "Info");
            this.AddMsg(MsgCode.Settings, "Instellingen");
            this.AddMsg(MsgCode.Terminators, "Scheidingslijnen");
            this.AddMsg(MsgCode.Name, "Naam");
            this.AddMsg(MsgCode.Error, "Fout");
            this.AddMsg(MsgCode.Warning, "Waarschuwing");
            this.AddMsg(MsgCode.EmptyName, "De naam mag niet leeg zijn");
            this.AddMsg(MsgCode.LoadFailed, "Laden mislukt");
            this.AddMsg(MsgCode.SaveFailed, "Opslaan is mislukt");
            this.AddMsg(MsgCode.EnterName, "Naam opgeven");
            this.AddMsg(MsgCode.Continue, "Doorgaan?");
            this.AddMsg(MsgCode.Configure, "Configureren");
            this.AddMsg(MsgCode.NoServices, "Geen services");
            this.AddMsg(MsgCode.PairBluetooth, "Bluetooth koppelen");
            this.AddMsg(MsgCode.EnterPin, "Pincode invoeren");
            this.AddMsg(MsgCode.PairedDevices, "Gekoppelde apparaten");
            this.AddMsg(MsgCode.Pair, "Koppelen");
            this.AddMsg(MsgCode.Unpair, "Ontkoppelen");
            this.AddMsg(MsgCode.Password, "Wachtwoord");
            this.AddMsg(MsgCode.HostName, "Hostnaam");
            this.AddMsg(MsgCode.NetworkService, "NetworkService");
            this.AddMsg(MsgCode.Port, "Port");
            this.AddMsg(MsgCode.NetworkSecurityKey, "Netwerkbeveiligingssleutel");
            this.AddMsg(MsgCode.Network, "Netwerk");
            this.AddMsg(MsgCode.Socket, "Socket");
            this.AddMsg(MsgCode.Credentials, "Referenties");
            this.AddMsg(MsgCode.About, "Over");
            this.AddMsg(MsgCode.Icons, "Pictogrammen");
            this.AddMsg(MsgCode.Author, "Auteur");
            this.AddMsg(MsgCode.Services, "Services");
            this.AddMsg(MsgCode.Properties, "Eigenschappen");
            this.AddMsg(MsgCode.UserManual, "Gebruikershandleiding");
            this.AddMsg(MsgCode.Vendor, "Leverancier");
            this.AddMsg(MsgCode.Product, "Product");
            this.AddMsg(MsgCode.Enabled, "Ingeschakeld");
            this.AddMsg(MsgCode.Default, "Standaard");
            this.AddMsg(MsgCode.BaudRate, "Baudrate");
            this.AddMsg(MsgCode.DataBits, "Databits");
            this.AddMsg(MsgCode.StopBits, "Stopbits");
            this.AddMsg(MsgCode.Parity, "Pariteit");
            this.AddMsg(MsgCode.FlowControl, "Datatransport- besturing");
            this.AddMsg(MsgCode.Read, "Gelezen");
            this.AddMsg(MsgCode.ReadFailure, "Leesfout");
            this.AddMsg(MsgCode.Write, "Schrijven");
            this.AddMsg(MsgCode.WriteFailue, "Schrijffout");
            this.AddMsg(MsgCode.Delete, "Verwijderen");
            this.AddMsg(MsgCode.DeleteFailure, "Kan niet verwijderen");
            this.AddMsg(MsgCode.CannotDeleteLast, "Laatste kan niet worden verwijderd");
            this.AddMsg(MsgCode.Timeout, "Time-out");
            this.AddMsg(MsgCode.Log, "Logbestand");
            this.AddMsg(MsgCode.None, "Geen");
            this.AddMsg(MsgCode.NotFound, "Niet gevonden");
            this.AddMsg(MsgCode.UnknownError, "Onbekende fout");
            this.AddMsg(MsgCode.UnhandledError, "Niet-verwerkte fout");
            this.AddMsg(MsgCode.Support, "Ondersteuning");
            this.AddMsg(MsgCode.Edit, "Bewerken");
            this.AddMsg(MsgCode.Create, "Maken");
            this.AddMsg(MsgCode.NothingSelected, "Niets geselecteerd");
            this.AddMsg(MsgCode.Ethernet, "Ethernet");
            this.AddMsg(MsgCode.EmptyParameter, "Kan lege parameter niet toevoegen");
            this.AddMsg(MsgCode.AbandonChanges, "Afbreken?");
            this.AddMsg(MsgCode.Run, "Uitvoeren");
            this.AddMsg(MsgCode.InsufficienPermissions, "Onvoldoende machtigingen");
            this.AddMsg(MsgCode.CodeSamples, "Codevoorbeelden");
            this.AddMsg(MsgCode.AuthenticationType, "Authenticatietype");
            this.AddMsg(MsgCode.EncryptionType, "Type versleuteling");
            this.AddMsg(MsgCode.SignalStrength, "Signaalsterkte");
            this.AddMsg(MsgCode.UpTime, "Tijd actief");
            this.AddMsg(MsgCode.MacAddress, "MAC-adres");
            this.AddMsg(MsgCode.Kind, "Soort");
            this.AddMsg(MsgCode.BeaconInterval, "Beacon-interval");
            this.AddMsg(MsgCode.AccessStatus, "Toegangsstatus");
            this.AddMsg(MsgCode.AddressType, "Adrestype");
            this.AddMsg(MsgCode.Paired, "Gekoppeld");
            this.AddMsg(MsgCode.ProtectionLevel, "Beveiligingsniveau");
            this.AddMsg(MsgCode.SecureConnection, "Beveiligde verbinding");
            this.AddMsg(MsgCode.Id, "Id");
            this.AddMsg(MsgCode.Allowed, "Toegestaan");
            this.AddMsg(MsgCode.Address, "Adres");
            this.AddMsg(MsgCode.DeviceClass, "Apparaatklasse");
            this.AddMsg(MsgCode.ServiceClass, "Serviceklasse");
            this.AddMsg(MsgCode.LastSeen, "Last Seen");
            this.AddMsg(MsgCode.LastUsed, "Last Used");
            this.AddMsg(MsgCode.Authenticated, "Geverifieerd");
            this.AddMsg(MsgCode.RemoteHost, "Externe host");
            this.AddMsg(MsgCode.RemoteService, "Externe service");
            this.AddMsg(MsgCode.Clear, "Wissen");
            this.AddMsg(MsgCode.ResetAll, "Standaardwaarden instellen");
            this.AddMsg(MsgCode.Characteristic, "Kenmerk");
            this.AddMsg(MsgCode.Descriptor, "Beschrijving");
            this.AddMsg(MsgCode.Min, "Min");
            this.AddMsg(MsgCode.Max, "Max");
            this.AddMsg(MsgCode.ReadOnly, "Alleen lezen");
            this.AddMsg(MsgCode.InvalidInput, "Ongeldige invoer");
            this.AddMsg(MsgCode.ParseFailed, "Parseren mislukt");
            this.AddMsg(MsgCode.OutOfRange, "Buiten bereik");
            this.AddMsg(MsgCode.email, "E-mail");
            this.AddMsg(MsgCode.CrashReport, "Foutenrapport verzenden");
            this.AddMsg(MsgCode.DataType, "Gegevenssoort");
            this.AddMsg(MsgCode.Service, "Service");
            this.AddMsg(MsgCode.Notifications, "Meldingen");
            this.AddMsg(MsgCode.Disabled, "Uitgeschakeld");
            this.AddMsg(MsgCode.Description, "Beschrijving");
            this.AddMsg(MsgCode.Unit, "Eenheid");
            this.AddMsg(MsgCode.Exponent, "Exponent");
            this.AddMsg(MsgCode.True, "Waar");
            this.AddMsg(MsgCode.False, "Onwaar");
            this.AddMsg(MsgCode.Even, "Even");
            this.AddMsg(MsgCode.Odd, "Oneven");
            this.AddMsg(MsgCode.Mark, "Markeren");
            this.AddMsg(MsgCode.Space, "Spatiepariteit");
            this.AddMsg(MsgCode.Preview, "Voorbeeld");
            this.AddMsg(MsgCode.Configuration, "Configuratie");
            this.AddMsg(MsgCode.Configurations, "Configuraties");
            this.AddMsg(MsgCode.Inputs, "Ingangen");
            this.AddMsg(MsgCode.Outputs, "Uitgangen");
            this.AddMsg(MsgCode.Digital, "Digitaal");
            this.AddMsg(MsgCode.Analog, "Analoog");
            this.AddMsg(MsgCode.Step, "Stap");
            this.AddMsg(MsgCode.Row, "Rij");
            this.AddMsg(MsgCode.Column, "Kolom");
            this.AddMsg(MsgCode.Build, "Build");
            this.AddMsg(MsgCode.Unknown, "Onbekend");

        }

    }

}
