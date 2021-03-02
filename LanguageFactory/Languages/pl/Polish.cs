using LanguageFactory.Net.data;
using LanguageFactory.Net.Messaging;

namespace LanguageFactory.Net.Languages.pl {

    public class Polish : SupportedLanguage {

        public Polish() : base() {
            this.SetLanguage(LangCode.Polish, "Polski");

            // Common messages
            this.AddMsg(MsgCode.save, "Zapisać");
            this.AddMsg(MsgCode.login, "Zalogować");
            this.AddMsg(MsgCode.logoff, "Wyloguj");
            this.AddMsg(MsgCode.copy, "Kopiuj");
            this.AddMsg(MsgCode.no, "Nie");
            this.AddMsg(MsgCode.yes, "Tak");
            this.AddMsg(MsgCode.New, "Nowy");
            this.AddMsg(MsgCode.Ok, "OK");
            this.AddMsg(MsgCode.exit, "Zakończ");
            this.AddMsg(MsgCode.start, "Start");
            this.AddMsg(MsgCode.stop, "Zatrzymaj");
            this.AddMsg(MsgCode.language, "Języki");
            this.AddMsg(MsgCode.send, "Wyślij");
            this.AddMsg(MsgCode.command, "Polecenie");
            this.AddMsg(MsgCode.commands, "Polecenia");
            this.AddMsg(MsgCode.response, "Odpowiedź");
            this.AddMsg(MsgCode.select, "Wybierz");
            this.AddMsg(MsgCode.Search, "Wyszukaj");
            this.AddMsg(MsgCode.connect, "Połącz");
            this.AddMsg(MsgCode.Connected, "Połączono");
            this.AddMsg(MsgCode.Disconnected, "Rozłączono");
            this.AddMsg(MsgCode.ConnectionFailure, "Błąd połączenia");
            this.AddMsg(MsgCode.Disconnect, "Rozłącz");
            this.AddMsg(MsgCode.NotConnected, "Nie podłączono");
            this.AddMsg(MsgCode.cancel, "Anuluj");
            this.AddMsg(MsgCode.info, "Informacje");
            this.AddMsg(MsgCode.Settings, "Ustawienia");
            this.AddMsg(MsgCode.Terminators, "Terminatory");
            this.AddMsg(MsgCode.Name, "Nazwa");
            this.AddMsg(MsgCode.Error, "Błąd");
            this.AddMsg(MsgCode.Warning, "Ostrzeżenie");
            this.AddMsg(MsgCode.EmptyName, "Nazwa nie może być pusta");
            this.AddMsg(MsgCode.LoadFailed, "Ładowanie nie powiodło się");
            this.AddMsg(MsgCode.SaveFailed, "Zapisywanie nie powiodło się");
            this.AddMsg(MsgCode.EnterName, "Wprowadź nazwę");
            this.AddMsg(MsgCode.Continue, "Kontynuuj?");
            this.AddMsg(MsgCode.Configure, "Konfiguruj");
            this.AddMsg(MsgCode.NoServices, "Brak usług");
            this.AddMsg(MsgCode.PairBluetooth, "Sparuj urządzenia Bluetooth");
            this.AddMsg(MsgCode.EnterPin, "Podaj PIN");
            this.AddMsg(MsgCode.PairedDevices, "Sparowane urządzenia");
            this.AddMsg(MsgCode.Pair, "Paruj");
            this.AddMsg(MsgCode.Unpair, "Rozłącz");
            this.AddMsg(MsgCode.Password, "Hasło");
            this.AddMsg(MsgCode.HostName, "Nazwa hosta");
            this.AddMsg(MsgCode.NetworkService, "Usługa sieciowa");
            this.AddMsg(MsgCode.Port, "Port");
            this.AddMsg(MsgCode.NetworkSecurityKey, "Klucz zabezpieczeń sieciowych");
            this.AddMsg(MsgCode.Network, "Sieć");
            this.AddMsg(MsgCode.Socket, "Gniazdo");
            this.AddMsg(MsgCode.Credentials, "Poświadczenia");
            this.AddMsg(MsgCode.About, "Informacje");
            this.AddMsg(MsgCode.Icons, "Ikony");
            this.AddMsg(MsgCode.Author, "Autor");
            this.AddMsg(MsgCode.Services, "Usługi");
            this.AddMsg(MsgCode.Properties, "Właściwości");
            this.AddMsg(MsgCode.UserManual, "Podręcznik użytkownika");
            this.AddMsg(MsgCode.Vendor, "Dostawca");
            this.AddMsg(MsgCode.Product, "Produkt");
            this.AddMsg(MsgCode.Enabled, "Włączone");
            this.AddMsg(MsgCode.Default, "Domyślna");
            this.AddMsg(MsgCode.BaudRate, "Szybkość transmisji");
            this.AddMsg(MsgCode.DataBits, "Bity danych");
            this.AddMsg(MsgCode.StopBits, "Bity stopu");
            this.AddMsg(MsgCode.Parity, "Parzystość");
            this.AddMsg(MsgCode.FlowControl, "Sterowanie przepływem");
            this.AddMsg(MsgCode.Read, "Przeczytane");
            this.AddMsg(MsgCode.ReadFailure, "Błąd odczytu");
            this.AddMsg(MsgCode.Write, "Zapis");
            this.AddMsg(MsgCode.WriteFailue, "Nie można zapisać");
            this.AddMsg(MsgCode.Delete, "Usuń");
            this.AddMsg(MsgCode.DeleteFailure, "Usuwanie nie powiodło się");
            this.AddMsg(MsgCode.CannotDeleteLast, "Nie można usunąć ostatniej");
            this.AddMsg(MsgCode.Timeout, "Przekroczenie limitu czasu");
            this.AddMsg(MsgCode.Log, "Dziennik");
            this.AddMsg(MsgCode.None, "Nic");
            this.AddMsg(MsgCode.NotFound, "Nie znaleziono");
            this.AddMsg(MsgCode.UnknownError, "Nieznany błąd");
            this.AddMsg(MsgCode.UnhandledError, "Nieobsługiwany błąd");
            this.AddMsg(MsgCode.Support, "Wsparcie");
            this.AddMsg(MsgCode.Edit, "Edytuj");
            this.AddMsg(MsgCode.Create, "Utwórz");
            this.AddMsg(MsgCode.NothingSelected, "Niczego nie wybrano");
            this.AddMsg(MsgCode.Ethernet, "Ethernet");
            this.AddMsg(MsgCode.EmptyParameter, "Nie można dodać pustego parametru");
            this.AddMsg(MsgCode.AbandonChanges, "Porzuć zmiany?");
            this.AddMsg(MsgCode.Run, "Uruchom");
            this.AddMsg(MsgCode.InsufficienPermissions, "Niewystarczające uprawnienia");
            this.AddMsg(MsgCode.CodeSamples, "Przykłady kodu");
            this.AddMsg(MsgCode.AuthenticationType, "Typ uwierzytelniania");
            this.AddMsg(MsgCode.EncryptionType, "Typ szyfrowania");
            this.AddMsg(MsgCode.SignalStrength, "Siła sygnału");
            this.AddMsg(MsgCode.UpTime, "Czas pracy");
            this.AddMsg(MsgCode.MacAddress, "Adres MAC");
            this.AddMsg(MsgCode.Kind, "Rodzaj");

            this.AddMsg(MsgCode.BeaconInterval, "Interwał sygnalizatora");
            this.AddMsg(MsgCode.AccessStatus, "Stan dostępu");
            this.AddMsg(MsgCode.AddressType, "Typ adresu");
            this.AddMsg(MsgCode.Paired, "Sparowano");
            this.AddMsg(MsgCode.ProtectionLevel, "Poziom ochrony");
            this.AddMsg(MsgCode.SecureConnection, "Bezpieczne połączenie");
            this.AddMsg(MsgCode.Id, "ID");
            this.AddMsg(MsgCode.Allowed, "Dozwolone");
            this.AddMsg(MsgCode.Address, "Adres");
            this.AddMsg(MsgCode.DeviceClass, "Klasa urządzenia");
            this.AddMsg(MsgCode.ServiceClass, "Klasa usługi");
            this.AddMsg(MsgCode.LastSeen, "Last Seen");
            this.AddMsg(MsgCode.LastUsed, "Last Used");
            this.AddMsg(MsgCode.Authenticated, "Uwierzytelniono");
            this.AddMsg(MsgCode.RemoteHost, "Host zdalny");
            this.AddMsg(MsgCode.RemoteService, "Usługa zdalna języka");
            this.AddMsg(MsgCode.Clear, "Wyczyść");
            this.AddMsg(MsgCode.ResetAll, "Resetuj wszystko");
            this.AddMsg(MsgCode.Characteristic, "Charakterystyka");
            this.AddMsg(MsgCode.Descriptor, "Deskryptor");
            this.AddMsg(MsgCode.Min, "Min");
            this.AddMsg(MsgCode.Max, "Maks");
            this.AddMsg(MsgCode.ReadOnly, "Tylko do odczytu");
            this.AddMsg(MsgCode.InvalidInput, "Nieprawidłowe dane wejściowe");
            this.AddMsg(MsgCode.ParseFailed, "Analizowanie składni nie powiodło się");
            this.AddMsg(MsgCode.OutOfRange, "Poza zakresem");
            this.AddMsg(MsgCode.email, "E-mail");
            this.AddMsg(MsgCode.CrashReport, "Udostępnij ostatni raport o awarii");
            this.AddMsg(MsgCode.DataType, "Typ danych");
            this.AddMsg(MsgCode.Service, "Usługa");
            this.AddMsg(MsgCode.Notifications, "Powiadomienia");
            this.AddMsg(MsgCode.Disabled, "Wyłączone");
            this.AddMsg(MsgCode.Description, "Opis");
            this.AddMsg(MsgCode.Unit, "Jednostka");
            this.AddMsg(MsgCode.Exponent, "Wykładnik");
            this.AddMsg(MsgCode.True, "Prawda");
            this.AddMsg(MsgCode.False, "Fałsz");
            this.AddMsg(MsgCode.Even, "Parzystość");
            this.AddMsg(MsgCode.Odd, "Nieparzystość");
            this.AddMsg(MsgCode.Mark, "Ustaw bit parzystości");
            this.AddMsg(MsgCode.Space, "Parzystość spacji");

        }

    }

}
