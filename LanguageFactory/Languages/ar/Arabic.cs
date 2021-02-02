using LanguageFactory.Net.data;
using LanguageFactory.Net.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageFactory.Net.Languages.ar {

    public class Arabic : SupportedLanguage {

        public Arabic() {
            this.SetLanguage(LangCode.Arabic, "العربية");

            // Common messages
            this.AddMsg(MsgCode.save, "يحفظ");
            this.AddMsg(MsgCode.login, "تسجيل الدخول");
            this.AddMsg(MsgCode.logoff, "تسجيل الخروج");
            this.AddMsg(MsgCode.copy, "نسخ");
            this.AddMsg(MsgCode.no, "لا");
            this.AddMsg(MsgCode.yes, "نعم فعلا");
            this.AddMsg(MsgCode.New, "جديد");
            this.AddMsg(MsgCode.Ok, "حسنا");
            this.AddMsg(MsgCode.exit, "خروج");
            this.AddMsg(MsgCode.start, "ابدأ");
            this.AddMsg(MsgCode.stop, "إيقاف");
            this.AddMsg(MsgCode.language, "اللغات");
            this.AddMsg(MsgCode.send, "إرسال");
            this.AddMsg(MsgCode.command, "الأمر");
            this.AddMsg(MsgCode.commands, "‏‏الأوامر");
            this.AddMsg(MsgCode.response, "الاستجابة");
            this.AddMsg(MsgCode.select, "تحديد");
            this.AddMsg(MsgCode.Search, "بحث");
            this.AddMsg(MsgCode.connect, "الاتصال");
            this.AddMsg(MsgCode.Connected, "متصل");
            this.AddMsg(MsgCode.ConnectionFailure, "فشل الاتصال");
            this.AddMsg(MsgCode.Disconnect, "قطع الاتصال");
            this.AddMsg(MsgCode.NotConnected, "غير متصل");
            this.AddMsg(MsgCode.cancel, "إلغاء الأمر");
            this.AddMsg(MsgCode.info, "معلومات");
            this.AddMsg(MsgCode.Settings, "الإعدادات");
            this.AddMsg(MsgCode.Terminators, "نهايات");
            this.AddMsg(MsgCode.Name, "الاسم");
            this.AddMsg(MsgCode.Error, "خطأ");
            this.AddMsg(MsgCode.Warning, "تحذير");
            this.AddMsg(MsgCode.EmptyName, "لا يمكن أن يكون الاسم فارغًا!");
            this.AddMsg(MsgCode.LoadFailed, "فشل التحميل");
            this.AddMsg(MsgCode.SaveFailed, "فشل الحفظ");
            this.AddMsg(MsgCode.EnterName, "إدخال اسم");
            this.AddMsg(MsgCode.Continue, "متابعة?");
            this.AddMsg(MsgCode.Configure, "‏‏تكوين");
            this.AddMsg(MsgCode.NoServices, "لا توجد خدمات");
            this.AddMsg(MsgCode.PairBluetooth, "إقران Bluetooth");
            this.AddMsg(MsgCode.EnterPin, "أدخل رمز PIN");
            this.AddMsg(MsgCode.PairedDevices, "الأجهزة المقترنة");
            this.AddMsg(MsgCode.Pair, "اقتران");
            this.AddMsg(MsgCode.Unpair, "إلغاء الاقتران");
            this.AddMsg(MsgCode.Password, "كلمة المرور");
            this.AddMsg(MsgCode.HostName, "اسم المضيف");
            this.AddMsg(MsgCode.NetworkService, "خدمة الشبكة");
            this.AddMsg(MsgCode.Port, "منفذ");
            this.AddMsg(MsgCode.NetworkSecurityKey, "مفتاح أمان الشبكة");
            this.AddMsg(MsgCode.Network, "شبكة");
            this.AddMsg(MsgCode.Socket, "‏‏مأخذ توصيل");
            this.AddMsg(MsgCode.Credentials, "بيانات الاعتماد");
            this.AddMsg(MsgCode.About, "نبذة");
            this.AddMsg(MsgCode.Icons, "الرموز");
            this.AddMsg(MsgCode.Author, "الكاتب");
            this.AddMsg(MsgCode.Services, "الخدمات");
            this.AddMsg(MsgCode.Properties, "خصائص");
            this.AddMsg(MsgCode.UserManual, "دليل المستخدم");
            this.AddMsg(MsgCode.Vendor, "المورد");
            this.AddMsg(MsgCode.Product, "منتج");
            this.AddMsg(MsgCode.Enabled, "تم التنشيط");
            this.AddMsg(MsgCode.Default, "افتراضي");
            this.AddMsg(MsgCode.BaudRate, "معدل الباود");
            this.AddMsg(MsgCode.DataBits, "وحدات بت البيانات");
            this.AddMsg(MsgCode.StopBits, "وحدات بت التوقف");
            this.AddMsg(MsgCode.Parity, "التماثل");
            this.AddMsg(MsgCode.FlowControl, "التحكم بالتدفق");
            this.AddMsg(MsgCode.Read, "قراءة");
            this.AddMsg(MsgCode.ReadFailure, "فشلت القراءة");
            this.AddMsg(MsgCode.Write, "كتابة");
            this.AddMsg(MsgCode.WriteFailue, "فشلت كتابة");
            this.AddMsg(MsgCode.Delete, "يحذف");
            this.AddMsg(MsgCode.DeleteFailure, "فشل الحذف");
            this.AddMsg(MsgCode.CannotDeleteLast, "لا يمكن حذف تعريف الأخير");
            this.AddMsg(MsgCode.Timeout, "نفذ الوقت");
            this.AddMsg(MsgCode.Log, "يسجل");
            this.AddMsg(MsgCode.None, "بلا");
            this.AddMsg(MsgCode.NotFound, "غير موجود");
            this.AddMsg(MsgCode.UnknownError, "‏‏خطأ غير معروف");
            this.AddMsg(MsgCode.UnhandledError, "خطأ لم تتم معالجته");
            this.AddMsg(MsgCode.Support, "دعم");
            this.AddMsg(MsgCode.Edit, "تحرير");
            this.AddMsg(MsgCode.Create, "إنشاء");
            this.AddMsg(MsgCode.NothingSelected, "تحديد لا شيء");
            this.AddMsg(MsgCode.Ethernet, "Ethernet");
            this.AddMsg(MsgCode.EmptyParameter, "Can'لا يمكن إضافة معلمة فارغة");
            this.AddMsg(MsgCode.AbandonChanges, "يتجاهل التغييرات?");
            this.AddMsg(MsgCode.Run, "يشغّل");
            this.AddMsg(MsgCode.InsufficienPermissions, "‏‏الأذونات غير كافية");
            this.AddMsg(MsgCode.CodeSamples, "نماذج التعليمات");
            this.AddMsg(MsgCode.AuthenticationType, "نوع المصادقة");
            this.AddMsg(MsgCode.EncryptionType, "نوع التشفير");
            this.AddMsg(MsgCode.SignalStrength, "قوة الإشارة");
            this.AddMsg(MsgCode.UpTime, "زمن التشغيل");
            this.AddMsg(MsgCode.MacAddress, "عنوان MAC");
            this.AddMsg(MsgCode.Kind, "نوع");
            this.AddMsg(MsgCode.BeaconInterval, "الفاصل الزمني Beacon");
            this.AddMsg(MsgCode.AccessStatus, "الحالة");
            this.AddMsg(MsgCode.AddressType, "نوع العنوان");
            this.AddMsg(MsgCode.Paired, "مقترن");
            this.AddMsg(MsgCode.ProtectionLevel, "مستوى الحماية");
            this.AddMsg(MsgCode.SecureConnection, "اتصال آمن");
            this.AddMsg(MsgCode.Id, "معرّف");
            this.AddMsg(MsgCode.Allowed, "مسموح به");
            this.AddMsg(MsgCode.Address, "العنوان");
            this.AddMsg(MsgCode.DeviceClass, "فئة الجهاز");
            this.AddMsg(MsgCode.ServiceClass, "فئة الخدمة");
            this.AddMsg(MsgCode.LastSeen, "Last Seen");
            this.AddMsg(MsgCode.LastUsed, "Last Used");
            this.AddMsg(MsgCode.Authenticated, "مصدّق");
            this.AddMsg(MsgCode.RemoteHost, "المضيف البعيد");
            this.AddMsg(MsgCode.RemoteService, "الخدمة البعيد");
            this.AddMsg(MsgCode.Clear, "مسح");
            this.AddMsg(MsgCode.ResetAll, "إعادة تعيين الكل");
            this.AddMsg(MsgCode.Disconnected, "غير متصل");


            //this.AddMsg(MsgCode., "");

        }

    }
}
