using LanguageFactory.Net.data;
using LanguageFactory.Net.Messaging;

namespace LanguageFactory.Net.Languages.tr {

    public class Turkish : SupportedLanguage {

        public Turkish() : base() {
            this.SetLanguage(LangCode.Turkish, "Türkçe");

            // Common messages
            this.AddMsg(MsgCode.save, "Kaydet");
            this.AddMsg(MsgCode.login, "Oturum aç");
            this.AddMsg(MsgCode.logoff, "Oturumu kapatmak");
            this.AddMsg(MsgCode.copy, "Kopya");
            this.AddMsg(MsgCode.no, "Hayır");
            this.AddMsg(MsgCode.yes, "Evet");
            this.AddMsg(MsgCode.New, "Yeni");
            this.AddMsg(MsgCode.Ok, "Tamam");
            this.AddMsg(MsgCode.exit, "Çıkış");
            this.AddMsg(MsgCode.start, "Başlat");
            this.AddMsg(MsgCode.stop, "Durdur");
            this.AddMsg(MsgCode.language, "Diller");
            this.AddMsg(MsgCode.send, "Gönder");
            this.AddMsg(MsgCode.command, "Komut");
            this.AddMsg(MsgCode.commands, "Komutlar");
            this.AddMsg(MsgCode.response, "Yanıt");
            this.AddMsg(MsgCode.select, "Seç");
            this.AddMsg(MsgCode.Search, "Ara");
            this.AddMsg(MsgCode.connect, "Bağlan");
            this.AddMsg(MsgCode.cancel, "İptal etmek");
            this.AddMsg(MsgCode.info, "Bilgi");
            this.AddMsg(MsgCode.Settings, "Ayarlar");
            this.AddMsg(MsgCode.Terminators, "Sonlandırıcıları");
            this.AddMsg(MsgCode.Name, "Ad");
            this.AddMsg(MsgCode.Error, "Hata");
            this.AddMsg(MsgCode.CannotDeleteLast, "Son girdi silinmiyor");
            this.AddMsg(MsgCode.EmptyName, "Ad boş olamaz");
            this.AddMsg(MsgCode.LoadFailed, "Yüklenemedi");
            this.AddMsg(MsgCode.SaveFailed, "Kaydedemedi");
            this.AddMsg(MsgCode.EnterName, "Ad Girin");
            this.AddMsg(MsgCode.Continue, "Devam?");
            this.AddMsg(MsgCode.Configure, "Yapılandır");
            this.AddMsg(MsgCode.NoServices, "Bir hizmet sunulmuyor");
            this.AddMsg(MsgCode.PairBluetooth, "Bluetooth eşleştir");
            this.AddMsg(MsgCode.EnterPin, "PIN girin");
            this.AddMsg(MsgCode.PairedDevices, "Eşleştirilmiş cihazlar");
            this.AddMsg(MsgCode.Pair, "Eşleştir");
            this.AddMsg(MsgCode.Unpair, "Eşleştirmeyi Kaldır");
            this.AddMsg(MsgCode.Disconnect, "Bağlantıyı Kes");
            this.AddMsg(MsgCode.Password, "Parolayı");
            this.AddMsg(MsgCode.HostName, "Ana Bilgisayar Adı");
            this.AddMsg(MsgCode.NetworkService, "Ağ Hizmetleri");
            this.AddMsg(MsgCode.Port, "Bağlantı Nok");
            this.AddMsg(MsgCode.NetworkSecurityKey, "Ağ güvenlik anahtarı");
            this.AddMsg(MsgCode.Network, "Ağ");
            this.AddMsg(MsgCode.Socket, "Yuva");
            this.AddMsg(MsgCode.Credentials, "Kimlik Bilgileri");
            this.AddMsg(MsgCode.About, "Hakkında");
            this.AddMsg(MsgCode.Icons, "Simgeler");
            this.AddMsg(MsgCode.Author, "Yazar");
            this.AddMsg(MsgCode.Services, "Hizmetler");
            this.AddMsg(MsgCode.Properties, "Özellikler");
            this.AddMsg(MsgCode.Delete, "Sil");
            this.AddMsg(MsgCode.UserManual, "Kullanıcı el kitabı");
            this.AddMsg(MsgCode.Vendor, "Satıcı");
            this.AddMsg(MsgCode.Product, "Ürün");
            this.AddMsg(MsgCode.Enabled, "Etkin");
            this.AddMsg(MsgCode.Default, "Varsayılan");
            this.AddMsg(MsgCode.BaudRate, "Baud Hızı");
            this.AddMsg(MsgCode.DataBits, "Veri bitleri");
            this.AddMsg(MsgCode.StopBits, "Dur Bitleri");
            this.AddMsg(MsgCode.Parity, "Eşlik");
            this.AddMsg(MsgCode.FlowControl, "Akış Denetimi");
            this.AddMsg(MsgCode.Read, "Oku");
            this.AddMsg(MsgCode.Write, "Yazma");
            this.AddMsg(MsgCode.Timeout, "Zaman aşımı");
            this.AddMsg(MsgCode.Log, "Günlük");
            this.AddMsg(MsgCode.None, "Yok");
            this.AddMsg(MsgCode.NotFound, "Bulunamadı");
            this.AddMsg(MsgCode.NotConnected, "Bağlı değil");
            this.AddMsg(MsgCode.ConnectionFailure, "Bağlantı Hatası");
            this.AddMsg(MsgCode.ReadFailure, "Okuma Hatası");
            this.AddMsg(MsgCode.WriteFailue, "Yazma hatası");
            this.AddMsg(MsgCode.UnknownError, "Bilinmeyen hata");
            this.AddMsg(MsgCode.UnhandledError, "İşlenmemiş hata");
            this.AddMsg(MsgCode.Support, "Destek");
            this.AddMsg(MsgCode.Edit, "Düzenle");
            this.AddMsg(MsgCode.Create, "Oluştur");
            this.AddMsg(MsgCode.NothingSelected, "Hiçbir Şey Seçilmedi");
            this.AddMsg(MsgCode.DeleteFailure, "Silinemedi");
            this.AddMsg(MsgCode.Ethernet, "Ethernet");
            this.AddMsg(MsgCode.EmptyParameter, "Boş parametre eklenemez");
            this.AddMsg(MsgCode.AbandonChanges, "Değişiklikleri at?");
            this.AddMsg(MsgCode.Warning, "Uyarı");
            this.AddMsg(MsgCode.Run, "Çalıştır");
            this.AddMsg(MsgCode.InsufficienPermissions, "İzinler yetersiz");
            this.AddMsg(MsgCode.CodeSamples, "Kod örnekleri");
            this.AddMsg(MsgCode.AuthenticationType, "Kimlik doğrulama türü");
            this.AddMsg(MsgCode.EncryptionType, "Şifreleme Türü");
            this.AddMsg(MsgCode.SignalStrength, "Sinyal gücü");
            this.AddMsg(MsgCode.UpTime, "Çalışma zamanı");
            this.AddMsg(MsgCode.MacAddress, "MAC Adresi");
            this.AddMsg(MsgCode.Kind, "Tür");
            this.AddMsg(MsgCode.BeaconInterval, "İşaret Aralığı");
            this.AddMsg(MsgCode.AccessStatus, "Erişim Durumu");
            this.AddMsg(MsgCode.AddressType, "Adres türü");
            this.AddMsg(MsgCode.Paired, "Eşleştirildi");
            this.AddMsg(MsgCode.Connected, "Bağlandı");
            this.AddMsg(MsgCode.ProtectionLevel, "Koruma Düzeyi");
            this.AddMsg(MsgCode.SecureConnection, "Güvenli bağlantı");
            this.AddMsg(MsgCode.Id, "ID");
            this.AddMsg(MsgCode.Allowed, "İzin verildi");
            this.AddMsg(MsgCode.Address, "Adres");
            this.AddMsg(MsgCode.DeviceClass, "Aygıt sınıfı");
            this.AddMsg(MsgCode.ServiceClass, "Servis sınıfı");
            this.AddMsg(MsgCode.LastSeen, "Last Seen");
            this.AddMsg(MsgCode.LastUsed, "Last Used");
            this.AddMsg(MsgCode.Authenticated, "Kimliği Doğrulandı");
            this.AddMsg(MsgCode.RemoteHost, "Uzak ana bilgisayar");
            this.AddMsg(MsgCode.RemoteService, "Uzak Hizmeti");
            this.AddMsg(MsgCode.Clear, "Temizle");


            //this.AddMsg(MsgCode., "");
        }


    }

}
