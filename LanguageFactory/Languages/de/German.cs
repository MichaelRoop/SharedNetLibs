﻿using LanguageFactory.Net.data;
using LanguageFactory.Net.Messaging;

namespace LanguageFactory.Net.Languages.de {

    public class German : SupportedLanguage {

        public German() : base() {
            this.SetLanguage(LangCode.German, "Deutsch");

            // Common messages
            this.AddMsg(MsgCode.save, "Speichern");

            this.AddMsg(MsgCode.login, "Anmelden");
            this.AddMsg(MsgCode.logoff, "Abmelden");
            this.AddMsg(MsgCode.copy, "Kopieren");
            this.AddMsg(MsgCode.no, "Nein");
            this.AddMsg(MsgCode.yes, "Ja");
            this.AddMsg(MsgCode.New, "Neu");
            this.AddMsg(MsgCode.Ok, "OK");
            this.AddMsg(MsgCode.exit, "Beenden");
            this.AddMsg(MsgCode.start, "Starten");
            this.AddMsg(MsgCode.stop, "Stopp");
            this.AddMsg(MsgCode.language, "Sprache");
            this.AddMsg(MsgCode.send, "Senden");
            this.AddMsg(MsgCode.command, "Befehl");
            this.AddMsg(MsgCode.commands, "Befehle");
            this.AddMsg(MsgCode.response, "Antwort");
            this.AddMsg(MsgCode.select, "Auswählen");
            this.AddMsg(MsgCode.discover, "Entdecken");
            this.AddMsg(MsgCode.connect, "Verbinden");
            this.AddMsg(MsgCode.cancel, "Abbrechen");
            this.AddMsg(MsgCode.info, "Info");
            this.AddMsg(MsgCode.Settings, "Einstellungen");
            this.AddMsg(MsgCode.Terminators, "Zeilenabschlusszeiche");
            this.AddMsg(MsgCode.Name, "Name");
            this.AddMsg(MsgCode.Error, "Fehler");
            this.AddMsg(MsgCode.CannotDeleteLast, "Löschen Kann Nicht Die Letzte ");
            this.AddMsg(MsgCode.EmptyName, "Der Name Kann Nicht Leer Sein");
            this.AddMsg(MsgCode.LoadFailed, "Fehler Beim Laden");
            this.AddMsg(MsgCode.SaveFailed, "Fehler Beim Speichern");
            this.AddMsg(MsgCode.EnterName, "Namen Eingeben");
            this.AddMsg(MsgCode.Continue, "Weiter?");
            this.AddMsg(MsgCode.Configure, "Konfigurieren");
            this.AddMsg(MsgCode.NoServices, "Dienste Nicht Gefunden");
            this.AddMsg(MsgCode.PairBluetooth, "Bluetooth Koppeln");
            this.AddMsg(MsgCode.EnterPin, "PIN eingeben");
            this.AddMsg(MsgCode.PairedDevices, "Gekoppelte Geräte");
            this.AddMsg(MsgCode.Pair, "Koppeln");
            this.AddMsg(MsgCode.Unpair, "Entkoppeln");
            this.AddMsg(MsgCode.Disconnect, "Verbindung Trennen");
            this.AddMsg(MsgCode.Password, "Kennwort");
            this.AddMsg(MsgCode.HostName, "Hostnamen");
            this.AddMsg(MsgCode.NetworkService, "Netzwerkdienst");
            this.AddMsg(MsgCode.Port, "Port");
            this.AddMsg(MsgCode.NetworkSecurityKey, "Sicherheitsschlüssel");
            this.AddMsg(MsgCode.Network, "Netzwerk");
            this.AddMsg(MsgCode.Socket, "Socket");
            this.AddMsg(MsgCode.Credentials, "Anmeldeinformationen");
            this.AddMsg(MsgCode.About, "Info");
            this.AddMsg(MsgCode.Icons, "Symbole");
            this.AddMsg(MsgCode.Author, "Autor");
            this.AddMsg(MsgCode.Services, "Dienstleistungen");
            this.AddMsg(MsgCode.Properties, "Eigenschaften");
            this.AddMsg(MsgCode.Delete, "Löschen");
            this.AddMsg(MsgCode.UserManual, "Benutzerhandbuch");
            this.AddMsg(MsgCode.Vendor, "Anbieter");
            this.AddMsg(MsgCode.Product, "Produkt");
            this.AddMsg(MsgCode.Enabled, "Aktiviert");
            this.AddMsg(MsgCode.Default, "Standard");
            this.AddMsg(MsgCode.BaudRate, "Baudrate");
            this.AddMsg(MsgCode.DataBits, "Datenbits");
            this.AddMsg(MsgCode.StopBits, "Stoppbits");
            this.AddMsg(MsgCode.Parity, "Parität");
            this.AddMsg(MsgCode.FlowControl, "Flusssteuerung");
            this.AddMsg(MsgCode.Read, "Lesen");
            this.AddMsg(MsgCode.Write, "Schreiben");
            this.AddMsg(MsgCode.Timeout, "Zeitlimit");
            this.AddMsg(MsgCode.Log, "Log");
            this.AddMsg(MsgCode.None, "Keine");
            this.AddMsg(MsgCode.NotFound, "Nicht Gefunden");
            this.AddMsg(MsgCode.NotConnected, "Nicht Verbunden");
            this.AddMsg(MsgCode.ConnectionFailure, "Verbindungsfehler");
            this.AddMsg(MsgCode.ReadFailure, "Lesefehler");
            this.AddMsg(MsgCode.WriteFailue, "Fehler beim Schreiben");
            this.AddMsg(MsgCode.UnknownError, "Unbekannter Fehler");
            this.AddMsg(MsgCode.UnhandledError, "Unbehandelter Fehler");
            this.AddMsg(MsgCode.Support, "Support");
            this.AddMsg(MsgCode.Edit, "Bearbeiten");
            this.AddMsg(MsgCode.Create, "Erstellen");
            this.AddMsg(MsgCode.NothingSelected, "Keine Auswahl");
            this.AddMsg(MsgCode.DeleteFailure, "Fehler beim Löschen");
            this.AddMsg(MsgCode.Ethernet, "Ethernet");
            this.AddMsg(MsgCode.EmptyParameter, "Es kann kein leerer Parameter hinzugefügt werden");
            this.AddMsg(MsgCode.AbandonChanges, "Änderungen verwerfen?");
            this.AddMsg(MsgCode.Warning, "Warnung");
            this.AddMsg(MsgCode.Run, "Ausführen");
            this.AddMsg(MsgCode.InsufficienPermissions, "Unzureichende Berechtigungen");
            this.AddMsg(MsgCode.CodeSamples, "Codebeispiele");
            this.AddMsg(MsgCode.AuthenticationType, "Authentifizierungstyp");
            this.AddMsg(MsgCode.EncryptionType, "Verschlüsselungstyp");
            this.AddMsg(MsgCode.SignalStrength, "Signalstärke");
            this.AddMsg(MsgCode.UpTime, "Betriebszeit");
            this.AddMsg(MsgCode.MacAddress, "MAC-Adresse");
            this.AddMsg(MsgCode.Kind, "Art");
            this.AddMsg(MsgCode.BeaconInterval, "Beaconintervall");
            this.AddMsg(MsgCode.AccessStatus, "Zugriffsstatus");
            this.AddMsg(MsgCode.AddressType, "Adresstyp");
            this.AddMsg(MsgCode.Paired, "Gekoppelt");
            this.AddMsg(MsgCode.Connected, "Verbunden");
            this.AddMsg(MsgCode.ProtectionLevel, "Schutzgrad");
            this.AddMsg(MsgCode.SecureConnection, "Sichere Verbindung");
            this.AddMsg(MsgCode.Id, "ID");
            this.AddMsg(MsgCode.Allowed, "Zugelassen");
            this.AddMsg(MsgCode.Address, "Addresse");
            this.AddMsg(MsgCode.DeviceClass, "Geräteklasse");
            this.AddMsg(MsgCode.ServiceClass, "Serviceklasse");
            this.AddMsg(MsgCode.LastSeen, "Zuletzt gesehen");
            this.AddMsg(MsgCode.LastUsed, "Zuletzt verwendet");
            this.AddMsg(MsgCode.Authenticated, "Authentifiziert");
            this.AddMsg(MsgCode.RemoteHost, "Remotehost");
            this.AddMsg(MsgCode.RemoteService, "Remotedienst");
            this.AddMsg(MsgCode.Clear, "Löschen");


            //this.AddMsg(MsgCode., "");
        }


    }

}
