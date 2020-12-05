using LanguageFactory.Net.data;
using LanguageFactory.Net.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageFactory.Net.Languages.ru {

    public class Russian : SupportedLanguage {

        public Russian() : base() {
            this.SetLanguage(LangCode.Russian, "Русский");

            // Common messages
            this.AddMsg(MsgCode.save, "Сохранить");
            this.AddMsg(MsgCode.login, "Войти в систему");
            this.AddMsg(MsgCode.logoff, "Выйти из системы");
            this.AddMsg(MsgCode.copy, "Копировать");
            this.AddMsg(MsgCode.no, "нет");
            this.AddMsg(MsgCode.yes, "да");
            this.AddMsg(MsgCode.New, "новый");
            this.AddMsg(MsgCode.Ok, "OK");
            this.AddMsg(MsgCode.exit, "Выход");
            this.AddMsg(MsgCode.start, "Пуск");
            this.AddMsg(MsgCode.stop, "Остановить");
            this.AddMsg(MsgCode.language, "Языки");
            this.AddMsg(MsgCode.send, "Отправка");
            this.AddMsg(MsgCode.command, "Команда");
            this.AddMsg(MsgCode.commands, "Команды");
            this.AddMsg(MsgCode.response, "Ответ");
            this.AddMsg(MsgCode.select, "выбрать");
            this.AddMsg(MsgCode.discover, "Обнаружить");
            this.AddMsg(MsgCode.connect, "Подключиться");
            this.AddMsg(MsgCode.cancel, "Отмена");
            this.AddMsg(MsgCode.info, "Информация");
            this.AddMsg(MsgCode.Settings, "Параметры");
            this.AddMsg(MsgCode.Terminators, "знаки завершения строки");
            this.AddMsg(MsgCode.Name, "Имя");
            this.AddMsg(MsgCode.Error, "Ошибка");
            this.AddMsg(MsgCode.CannotDeleteLast, "Нельзя удалить последнюю оставшуюся запись");
            this.AddMsg(MsgCode.EmptyName, "Имя не может быть пустым");
            this.AddMsg(MsgCode.LoadFailed, "Не удалось загрузить");
            this.AddMsg(MsgCode.SaveFailed, "Не удалось сохранить");
            this.AddMsg(MsgCode.EnterName, "Введите имя");
            this.AddMsg(MsgCode.Continue, "Продолжить?");
            this.AddMsg(MsgCode.Configure, "Настроить");
            this.AddMsg(MsgCode.NoServices, "Не найдены службы");
            this.AddMsg(MsgCode.PairBluetooth, "Связать устройство Bluetooth");
            this.AddMsg(MsgCode.EnterPin, "Введите PIN-код");
            this.AddMsg(MsgCode.PairedDevices, "Связанные устройства");
            this.AddMsg(MsgCode.Pair, "Связать");
            this.AddMsg(MsgCode.Unpair, "Pазорвать соединение");
            this.AddMsg(MsgCode.Disconnect, "Отсоединить");
            this.AddMsg(MsgCode.Password, "Пароль");
            this.AddMsg(MsgCode.HostName, "Имя узла");
            this.AddMsg(MsgCode.NetworkService, "Сетевая служба");
            this.AddMsg(MsgCode.Port, "Порт");
            this.AddMsg(MsgCode.NetworkSecurityKey, "Ключ безопасности сети");
            this.AddMsg(MsgCode.Network, "Сеть");
            this.AddMsg(MsgCode.Socket, "Сокет");
            this.AddMsg(MsgCode.Credentials, "Учетные данные");
            this.AddMsg(MsgCode.About, "О системе");
            this.AddMsg(MsgCode.Icons, "Значки");
            this.AddMsg(MsgCode.Author, "Автор");
            this.AddMsg(MsgCode.Services, "Службы");
            this.AddMsg(MsgCode.Properties, "Свойства");
            this.AddMsg(MsgCode.Delete, "Удалить");
            this.AddMsg(MsgCode.UserManual, "Руководство пользователя");
            this.AddMsg(MsgCode.Vendor, "Поставщик");
            this.AddMsg(MsgCode.Product, "Продукт");
            this.AddMsg(MsgCode.Enabled, "Активирован");
            this.AddMsg(MsgCode.Default, "По умолчанию");
            this.AddMsg(MsgCode.BaudRate, "Скорость (бит/с)");
            this.AddMsg(MsgCode.DataBits, "Биты данных");
            this.AddMsg(MsgCode.StopBits, "Стоповые биты");
            this.AddMsg(MsgCode.Parity, "Четность");
            this.AddMsg(MsgCode.FlowControl, "Управление потоком");
            this.AddMsg(MsgCode.Read, "Чтение");
            this.AddMsg(MsgCode.Write, "Запись");
            this.AddMsg(MsgCode.Timeout, "Таймаут");
            this.AddMsg(MsgCode.Log, "Журнал");
            this.AddMsg(MsgCode.None, "Нет");
            this.AddMsg(MsgCode.NotFound, "Не найден");
            this.AddMsg(MsgCode.NotConnected, "Не подключен");
            this.AddMsg(MsgCode.ConnectionFailure, "Ошибка подключения");
            this.AddMsg(MsgCode.ReadFailure, "Ошибка при чтении");
            this.AddMsg(MsgCode.WriteFailue, "Ошибка записи");
            this.AddMsg(MsgCode.UnknownError, "Неизвестная ошибка");
            this.AddMsg(MsgCode.UnhandledError, "Необработанная ошибка");
            this.AddMsg(MsgCode.Support, "Поддержка");
            this.AddMsg(MsgCode.Edit, "Правка");
            this.AddMsg(MsgCode.Create, "Создать");
            this.AddMsg(MsgCode.NothingSelected, "Ничего не выбрано");
            this.AddMsg(MsgCode.DeleteFailure, "Не удалось удалить");
            this.AddMsg(MsgCode.Ethernet, "Ethernet");
            this.AddMsg(MsgCode.EmptyParameter, "Невозможно добавить пустой параметр");
            this.AddMsg(MsgCode.AbandonChanges, "Отменить изменения?");
            this.AddMsg(MsgCode.Warning, "Предупреждение");
            this.AddMsg(MsgCode.Run, "Выполнить");
            this.AddMsg(MsgCode.InsufficienPermissions, "Недостаточно разрешений");
            this.AddMsg(MsgCode.CodeSamples, "Примеры кода");

            //this.AddMsg(MsgCode., "");
        }



    }
}
