using LanguageFactory.Net.data;
using LanguageFactory.Net.Messaging;

namespace LanguageFactory.Net.Languages.uk {

    public class Ukranian : SupportedLanguage {

        public Ukranian() : base() {
            this.SetLanguage(LangCode.Ukranian, "Українська");

            // Common messages
            this.AddMsg(MsgCode.save, "Зберегти");
            this.AddMsg(MsgCode.login, "Увійти");
            this.AddMsg(MsgCode.logoff, "Вийти");
            this.AddMsg(MsgCode.copy, "Копіювати");
            this.AddMsg(MsgCode.no, "Ні");
            this.AddMsg(MsgCode.yes, "Так");
            this.AddMsg(MsgCode.New, "Новий");
            this.AddMsg(MsgCode.Ok, "OK");
            this.AddMsg(MsgCode.exit, "Вийти");
            this.AddMsg(MsgCode.start, "Почати");
            this.AddMsg(MsgCode.stop, "Припинити");
            this.AddMsg(MsgCode.language, "Мови");
            this.AddMsg(MsgCode.send, "Надіслати");
            this.AddMsg(MsgCode.command, "Команда");
            this.AddMsg(MsgCode.commands, "Команди");
            this.AddMsg(MsgCode.response, "Відповідь");
            this.AddMsg(MsgCode.select, "Вибрати");
            this.AddMsg(MsgCode.Search, "Пошук");
            this.AddMsg(MsgCode.connect, "Підключення");
            this.AddMsg(MsgCode.cancel, "Скасувати");
            this.AddMsg(MsgCode.info, "Відомості");
            this.AddMsg(MsgCode.Settings, "Настройки");
            this.AddMsg(MsgCode.Terminators, "Знаки завершення");
            this.AddMsg(MsgCode.Name, "Ім'я");
            this.AddMsg(MsgCode.Error, "Помилка");
            this.AddMsg(MsgCode.CannotDeleteLast, "Неможливо видалити останній запи");
            this.AddMsg(MsgCode.EmptyName, "Ім'я не може бути пустим");
            this.AddMsg(MsgCode.LoadFailed, "Не вдалося завантажити");
            this.AddMsg(MsgCode.SaveFailed, "Не вдалося зберегти");
            this.AddMsg(MsgCode.EnterName, "Введіть ім’я");
            this.AddMsg(MsgCode.Continue, "Продовжити?");
            this.AddMsg(MsgCode.Configure, "Настроїти");
            this.AddMsg(MsgCode.NoServices, "Немає служб");
            this.AddMsg(MsgCode.PairBluetooth, "З’єднання через Bluetooth");
            this.AddMsg(MsgCode.EnterPin, "Введіть PIN-код");
            this.AddMsg(MsgCode.PairedDevices, "З’єднані пристрої");
            this.AddMsg(MsgCode.Pair, "Створити пару");
            this.AddMsg(MsgCode.Unpair, "Скасувати пару");
            this.AddMsg(MsgCode.Disconnect, "Відключити");
            this.AddMsg(MsgCode.Password, "Пароль");
            this.AddMsg(MsgCode.HostName, "Ім’я хоста");
            this.AddMsg(MsgCode.NetworkService, "Мережева служба");
            this.AddMsg(MsgCode.Port, "Порт");
            this.AddMsg(MsgCode.NetworkSecurityKey, "Мережевий ключ безпеки");
            this.AddMsg(MsgCode.Network, "Мережа");
            this.AddMsg(MsgCode.Socket, "Сокет");
            this.AddMsg(MsgCode.Credentials, "Облікові дані");
            this.AddMsg(MsgCode.About, "Про систему");
            this.AddMsg(MsgCode.Icons, "Піктограми");
            this.AddMsg(MsgCode.Author, "Автор");
            this.AddMsg(MsgCode.Services, "Служби");
            this.AddMsg(MsgCode.Properties, "Властивості");
            this.AddMsg(MsgCode.Delete, "Видалити");
            this.AddMsg(MsgCode.UserManual, "Посібник користувача");
            this.AddMsg(MsgCode.Vendor, "Постачальник");
            this.AddMsg(MsgCode.Product, "Продукт");
            this.AddMsg(MsgCode.Enabled, "Увімкнуто");
            this.AddMsg(MsgCode.Default, "За замовчуванням");
            this.AddMsg(MsgCode.BaudRate, "Швидкість порту");
            this.AddMsg(MsgCode.DataBits, "Біти даних");
            this.AddMsg(MsgCode.StopBits, "Стопові біти");
            this.AddMsg(MsgCode.Parity, "Парність");
            this.AddMsg(MsgCode.FlowControl, "Керування потоком");
            this.AddMsg(MsgCode.Read, "Прочитано");
            this.AddMsg(MsgCode.Write, "Записування");
            this.AddMsg(MsgCode.Timeout, "Час очікування");
            this.AddMsg(MsgCode.Log, "Журнал");
            this.AddMsg(MsgCode.None, "Нічого");
            this.AddMsg(MsgCode.NotFound, "Не найден");
            this.AddMsg(MsgCode.NotConnected, "Не з’єднано");
            this.AddMsg(MsgCode.ConnectionFailure, "Помилка підключення");
            this.AddMsg(MsgCode.ReadFailure, "Не вдалося прочитати файл");
            this.AddMsg(MsgCode.WriteFailue, "Помилка записування");
            this.AddMsg(MsgCode.UnknownError, "Невідома помилка");
            this.AddMsg(MsgCode.UnhandledError, "Необроблена помилка");
            this.AddMsg(MsgCode.Support, "Підтримка");
            this.AddMsg(MsgCode.Edit, "Змінити");
            this.AddMsg(MsgCode.Create, "Створити");
            this.AddMsg(MsgCode.NothingSelected, "Нічого не вибрано");
            this.AddMsg(MsgCode.DeleteFailure, "Не вдалося видалити");
            this.AddMsg(MsgCode.Ethernet, "Ethernet");
            this.AddMsg(MsgCode.EmptyParameter, "Пустий параметр додати не можна");
            this.AddMsg(MsgCode.AbandonChanges, "Вилучити зміни?");
            this.AddMsg(MsgCode.Warning, "Попередження");
            this.AddMsg(MsgCode.Run, "Виконання");
            this.AddMsg(MsgCode.InsufficienPermissions, "Недостатньо дозволів");
            this.AddMsg(MsgCode.CodeSamples, "Зразки коду");
            this.AddMsg(MsgCode.AuthenticationType, "Тип автентифікації");
            this.AddMsg(MsgCode.EncryptionType, "Тип шифрування");
            this.AddMsg(MsgCode.SignalStrength, "Рівень сигналу");
            this.AddMsg(MsgCode.UpTime, "Час роботи");
            this.AddMsg(MsgCode.MacAddress, "MAC-адреса");
            this.AddMsg(MsgCode.Kind, "Тип");
            this.AddMsg(MsgCode.BeaconInterval, "Інтервал Beacon");
            this.AddMsg(MsgCode.AccessStatus, "Рівень доступу");
            this.AddMsg(MsgCode.AddressType, "Тип адреси");
            this.AddMsg(MsgCode.Paired, "З’єднано");
            this.AddMsg(MsgCode.Connected, "Підключено");
            this.AddMsg(MsgCode.ProtectionLevel, "Рівень захисту");
            this.AddMsg(MsgCode.SecureConnection, "Захищене підключення");
            this.AddMsg(MsgCode.Id, "ID");
            this.AddMsg(MsgCode.Allowed, "Дозволено");
            this.AddMsg(MsgCode.Address, "Адреса");
            this.AddMsg(MsgCode.DeviceClass, "Клас пристрою");
            this.AddMsg(MsgCode.ServiceClass, "Клас cлужба");
            this.AddMsg(MsgCode.LastSeen, "Last Seen");
            this.AddMsg(MsgCode.LastUsed, "Last Used");
            this.AddMsg(MsgCode.Authenticated, "Автентифіковано");
            this.AddMsg(MsgCode.RemoteHost, "віддалений хост");
            this.AddMsg(MsgCode.RemoteService, "віддалений cлужба");
            this.AddMsg(MsgCode.Clear, "Очистити");
            this.AddMsg(MsgCode.ResetAll, "Скинути все");


            //this.AddMsg(MsgCode., "");
        }

    }
}
