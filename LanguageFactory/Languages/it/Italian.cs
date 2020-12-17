using LanguageFactory.Net.data;
using LanguageFactory.Net.Messaging;

namespace LanguageFactory.Net.Languages.it {

    public class Italian : SupportedLanguage {

        public Italian() : base() {
            this.SetLanguage(LangCode.Italian, "Italiano");

            // Common messages
            this.AddMsg(MsgCode.save, "Salva");
            this.AddMsg(MsgCode.login, "Accedere");
            this.AddMsg(MsgCode.logoff, "Disconnettere");
            this.AddMsg(MsgCode.copy, "Copia");
            this.AddMsg(MsgCode.no, "No");
            this.AddMsg(MsgCode.yes, "Sì");
            this.AddMsg(MsgCode.New, "Nuovo");
            this.AddMsg(MsgCode.Ok, "OK");
            this.AddMsg(MsgCode.exit, "Esci");
            this.AddMsg(MsgCode.start, "Avvio");
            this.AddMsg(MsgCode.stop, "Arresta");
            this.AddMsg(MsgCode.language, "Lingua");
            this.AddMsg(MsgCode.send, "Invia");
            this.AddMsg(MsgCode.command, "Comando");
            this.AddMsg(MsgCode.commands, "Comandi");
            this.AddMsg(MsgCode.response, "Risposta");
            this.AddMsg(MsgCode.select, "Seleziona");
            this.AddMsg(MsgCode.discover, "Recupera elenco");
            this.AddMsg(MsgCode.connect, "Connetti");
            this.AddMsg(MsgCode.cancel, "Annulla");
            this.AddMsg(MsgCode.info, "Info");
            this.AddMsg(MsgCode.Settings, "Impostazioni");
            this.AddMsg(MsgCode.Terminators, "Terminatori");
            this.AddMsg(MsgCode.Name, "Nessuno");
            this.AddMsg(MsgCode.Error, "Errore");
            this.AddMsg(MsgCode.CannotDeleteLast, "Impossibile eliminare l'ultimo");
            this.AddMsg(MsgCode.EmptyName, "Nome non può essere vuoto");
            this.AddMsg(MsgCode.LoadFailed, "Impossibile caricare");
            this.AddMsg(MsgCode.SaveFailed, "Impossibile salvare");
            this.AddMsg(MsgCode.EnterName, "Immettere il nome");
            this.AddMsg(MsgCode.Continue, "Continua?");
            this.AddMsg(MsgCode.Configure, "Configura");
            this.AddMsg(MsgCode.NoServices, "Nessun servizio offerto");
            this.AddMsg(MsgCode.PairBluetooth, "Associa Bluetooth");
            this.AddMsg(MsgCode.EnterPin, "Immetti il PIN");
            this.AddMsg(MsgCode.PairedDevices, "Dispositivi associati");
            this.AddMsg(MsgCode.Pair, "Associa");
            this.AddMsg(MsgCode.Unpair, "Disassocia");
            this.AddMsg(MsgCode.Disconnect, "Disconnetti");
            this.AddMsg(MsgCode.Password, "Password");
            this.AddMsg(MsgCode.HostName, "Nome host");
            this.AddMsg(MsgCode.NetworkService, "Servizio di rete");
            this.AddMsg(MsgCode.Port, "Porta");
            this.AddMsg(MsgCode.NetworkSecurityKey, "Chiave di sicurezza di rete");
            this.AddMsg(MsgCode.Network, "Rete");
            this.AddMsg(MsgCode.Socket, "Socket");
            this.AddMsg(MsgCode.Credentials, "Credenziali");
            this.AddMsg(MsgCode.About, "Informazioni");
            this.AddMsg(MsgCode.Icons, "Icone");
            this.AddMsg(MsgCode.Author, "Autore");
            this.AddMsg(MsgCode.Services, "Servizi");
            this.AddMsg(MsgCode.Properties, "Proprietà");
            this.AddMsg(MsgCode.Delete, "Elimina");
            this.AddMsg(MsgCode.UserManual, "Manuale utente");
            this.AddMsg(MsgCode.Vendor, "Fornitore");
            this.AddMsg(MsgCode.Product, "Prodotto");
            this.AddMsg(MsgCode.Enabled, "Attivato");
            this.AddMsg(MsgCode.Default, "Predefinito");
            this.AddMsg(MsgCode.BaudRate, "Velocità in baud");
            this.AddMsg(MsgCode.DataBits, "Bit di dati");
            this.AddMsg(MsgCode.StopBits, "Bit di stop");
            this.AddMsg(MsgCode.Parity, "Parità");
            this.AddMsg(MsgCode.FlowControl, "Controllo di flusso");
            this.AddMsg(MsgCode.Read, "Leggere");
            this.AddMsg(MsgCode.Write, "Scrittura");
            this.AddMsg(MsgCode.Timeout, "Timeout");
            this.AddMsg(MsgCode.Log, "Log");
            this.AddMsg(MsgCode.None, "Nessuno");
            this.AddMsg(MsgCode.NotFound, "Non trovato");
            this.AddMsg(MsgCode.NotConnected, "Non connesso");
            this.AddMsg(MsgCode.ConnectionFailure, "Errore di connessione");
            this.AddMsg(MsgCode.ReadFailure, "Errore di lettura");
            this.AddMsg(MsgCode.WriteFailue, "Errore di scrittura");
            this.AddMsg(MsgCode.UnknownError, "Errore sconosciuto");
            this.AddMsg(MsgCode.UnhandledError, "Errore non gestito");
            this.AddMsg(MsgCode.Support, "Supporto");
            this.AddMsg(MsgCode.Edit, "Modifica");
            this.AddMsg(MsgCode.Create, "Crea");
            this.AddMsg(MsgCode.NothingSelected, "Nessun elemento selezionato");
            this.AddMsg(MsgCode.DeleteFailure, "Errore di eliminazione");
            this.AddMsg(MsgCode.Ethernet, "Ethernet");
            this.AddMsg(MsgCode.EmptyParameter, "Impossibile aggiungere un parametro vuoto");
            this.AddMsg(MsgCode.AbandonChanges, "Ignora modifiche?");
            this.AddMsg(MsgCode.Warning, "Avviso");
            this.AddMsg(MsgCode.Run, "Esegui");
            this.AddMsg(MsgCode.InsufficienPermissions, "Autorizzazioni insufficienti");
            this.AddMsg(MsgCode.CodeSamples, "Esempi di codice");
            this.AddMsg(MsgCode.AuthenticationType, "Tipo di autenticazione");
            this.AddMsg(MsgCode.EncryptionType, "Tipo di crittografia");
            this.AddMsg(MsgCode.SignalStrength, "Potenza segnale");
            this.AddMsg(MsgCode.UpTime, "Tempo di attività");
            this.AddMsg(MsgCode.MacAddress, "Indirizzo MAC");
            this.AddMsg(MsgCode.Kind, "Tipo");
            this.AddMsg(MsgCode.BeaconInterval, "Intervallo beacon");
            this.AddMsg(MsgCode.AccessStatus, "Stato accesso");
            this.AddMsg(MsgCode.AddressType, "Tipo di indirizzo");
            this.AddMsg(MsgCode.Paired, "Associato");
            this.AddMsg(MsgCode.Connected, "Connesso");
            this.AddMsg(MsgCode.ProtectionLevel, "Livello di protezione");
            this.AddMsg(MsgCode.SecureConnection, "Connessione sicura");
            this.AddMsg(MsgCode.Id, "Id");
            this.AddMsg(MsgCode.Allowed, "Consentito");
            this.AddMsg(MsgCode.Address, "Indirizzo");
            this.AddMsg(MsgCode.DeviceClass, "Classe dispositivo");
            this.AddMsg(MsgCode.ServiceClass, "Classe servizio");
            this.AddMsg(MsgCode.LastSeen, "Ultima visualizzazione");
            this.AddMsg(MsgCode.LastUsed, "Ultimo utilizzo");
            this.AddMsg(MsgCode.Authenticated, "Autenticato");
            this.AddMsg(MsgCode.RemoteHost, "Host remoto");
            this.AddMsg(MsgCode.RemoteService, "Servizio remoto");

            //this.AddMsg(MsgCode., "");
        }


    }

}
