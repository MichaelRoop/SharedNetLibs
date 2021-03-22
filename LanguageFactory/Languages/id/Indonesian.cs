﻿using LanguageFactory.Net.data;
using LanguageFactory.Net.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageFactory.Net.Languages.id {
    public class Indonesian : SupportedLanguage {
        public Indonesian() : base() {
            this.SetLanguage(LangCode.Indonesian, "Indonesia");

            // Common messages
            this.AddMsg(MsgCode.save, "Simpan");
            this.AddMsg(MsgCode.login, "Log-masuk");
            this.AddMsg(MsgCode.logoff, "Log Keluar");
            this.AddMsg(MsgCode.copy, "Salin");
            this.AddMsg(MsgCode.no, "Tidak");
            this.AddMsg(MsgCode.yes, "Ya");
            this.AddMsg(MsgCode.New, "Baru");
            this.AddMsg(MsgCode.Ok, "OK");
            this.AddMsg(MsgCode.exit, "Keluar");
            this.AddMsg(MsgCode.start, "Mulai");
            this.AddMsg(MsgCode.stop, "Hentikan");
            this.AddMsg(MsgCode.language, "Bahasa");
            this.AddMsg(MsgCode.send, "Kirim");
            this.AddMsg(MsgCode.command, "Perintah");
            this.AddMsg(MsgCode.commands, "Perintah");
            this.AddMsg(MsgCode.response, "Respons");
            this.AddMsg(MsgCode.select, "Pilih");
            this.AddMsg(MsgCode.Search, "Pencarian");
            this.AddMsg(MsgCode.connect, "Sambung");
            this.AddMsg(MsgCode.Connected, "Tersambung");
            this.AddMsg(MsgCode.Disconnected, "Sambungan terputus");
            this.AddMsg(MsgCode.ConnectionFailure, "Kegagalan koneksi");
            this.AddMsg(MsgCode.Disconnect, "Putuskan sambungan");
            this.AddMsg(MsgCode.NotConnected, "Tidak tersambung");
            this.AddMsg(MsgCode.cancel, "Batal");
            this.AddMsg(MsgCode.info, "Info");
            this.AddMsg(MsgCode.Settings, "Pengaturan");
            this.AddMsg(MsgCode.Terminators, "Terminators");
            this.AddMsg(MsgCode.Name, "Nama");
            this.AddMsg(MsgCode.Error, "Kesalahan");
            this.AddMsg(MsgCode.Warning, "Peringatan");
            this.AddMsg(MsgCode.EmptyName, "Nama tidak boleh kosong");
            this.AddMsg(MsgCode.LoadFailed, "Gagal memuat");
            this.AddMsg(MsgCode.SaveFailed, "Gagal menyimpan");
            this.AddMsg(MsgCode.EnterName, "Masukkan nama");
            this.AddMsg(MsgCode.Continue, "Lanjutkan?");
            this.AddMsg(MsgCode.Configure, "Konfigurasikan");
            this.AddMsg(MsgCode.NoServices, "Tidak Tersedia Layanan");
            this.AddMsg(MsgCode.PairBluetooth, "Pasangkan Bluetooth");
            this.AddMsg(MsgCode.EnterPin, "Masukkan PIN");
            this.AddMsg(MsgCode.PairedDevices, "Perangkat terpasang");
            this.AddMsg(MsgCode.Pair, "Pasangkan");
            this.AddMsg(MsgCode.Unpair, "Pisahkan");
            this.AddMsg(MsgCode.Password, "Kata sandi");
            this.AddMsg(MsgCode.HostName, "Nama host");
            this.AddMsg(MsgCode.NetworkService, "Layanan Jaringan");
            this.AddMsg(MsgCode.Port, "Port");
            this.AddMsg(MsgCode.NetworkSecurityKey, "Kunci Keamanan Jaringan");
            this.AddMsg(MsgCode.Network, "Jaringan");
            this.AddMsg(MsgCode.Socket, "Soket");
            this.AddMsg(MsgCode.Credentials, "Kredensial");
            this.AddMsg(MsgCode.About, "Tentang");
            this.AddMsg(MsgCode.Icons, "Ikon");
            this.AddMsg(MsgCode.Author, "Penulis");
            this.AddMsg(MsgCode.Services, "Layanan");
            this.AddMsg(MsgCode.Properties, "Properti");
            this.AddMsg(MsgCode.UserManual, "Panduan pengguna");
            this.AddMsg(MsgCode.Vendor, "Vendor");
            this.AddMsg(MsgCode.Product, "Produk");
            this.AddMsg(MsgCode.Enabled, "Difungsikan");
            this.AddMsg(MsgCode.Default, "Bawaan");
            this.AddMsg(MsgCode.BaudRate, "Laju Baud");
            this.AddMsg(MsgCode.DataBits, "Bit data");
            this.AddMsg(MsgCode.StopBits, "Stop Bits");
            this.AddMsg(MsgCode.Parity, "Paritas");
            this.AddMsg(MsgCode.FlowControl, "Flow Control");
            this.AddMsg(MsgCode.Read, "Baca");
            this.AddMsg(MsgCode.ReadFailure, "Pembacaan gagal");
            this.AddMsg(MsgCode.Write, "Menulis");
            this.AddMsg(MsgCode.WriteFailue, "Menulis gagal");
            this.AddMsg(MsgCode.Delete, "Hapus");
            this.AddMsg(MsgCode.DeleteFailure, "Penghapusan gagal");
            this.AddMsg(MsgCode.CannotDeleteLast, "Tidak dapat menghapus entri terakhir");
            this.AddMsg(MsgCode.Timeout, "Batas waktu");
            this.AddMsg(MsgCode.Log, "Log");
            this.AddMsg(MsgCode.None, "Tidak ada");
            this.AddMsg(MsgCode.NotFound, "Tidak ditemukan");
            this.AddMsg(MsgCode.UnknownError, "Kesalahan tidak dikenal");
            this.AddMsg(MsgCode.UnhandledError, "Kesalahan yang tidak tertangani");
            this.AddMsg(MsgCode.Support, "Dukungan");
            this.AddMsg(MsgCode.Edit, "Edit");
            this.AddMsg(MsgCode.Create, "Buat");
            this.AddMsg(MsgCode.NothingSelected, "Tidak ada yang dipilih");
            this.AddMsg(MsgCode.Ethernet, "Ethernet");
            this.AddMsg(MsgCode.EmptyParameter, "Harus memiliki nilai");
            this.AddMsg(MsgCode.AbandonChanges, "Keluar tanpa menyimpan?");
            this.AddMsg(MsgCode.Run, "Jalankan");
            this.AddMsg(MsgCode.InsufficienPermissions, "Izin Tidak Memadai");
            this.AddMsg(MsgCode.CodeSamples, "Contoh kode");
            this.AddMsg(MsgCode.AuthenticationType, "Jenis autentikasi");
            this.AddMsg(MsgCode.EncryptionType, "Jenis enkripsi");
            this.AddMsg(MsgCode.SignalStrength, "Kekuatan sinyal");
            this.AddMsg(MsgCode.UpTime, "Waktu aktif");
            this.AddMsg(MsgCode.MacAddress, "Alamat MAC");
            this.AddMsg(MsgCode.Kind, "Jenis");
            this.AddMsg(MsgCode.BeaconInterval, "Beacon Interval");
            this.AddMsg(MsgCode.AccessStatus, "Status Akses");
            this.AddMsg(MsgCode.AddressType, "Jenis Alamat");
            this.AddMsg(MsgCode.Paired, "Dipasangkan");
            this.AddMsg(MsgCode.ProtectionLevel, "Tingkat perlindungan");
            this.AddMsg(MsgCode.SecureConnection, "Koneksi Aman");
            this.AddMsg(MsgCode.Id, "ID");
            this.AddMsg(MsgCode.Allowed, "Diperbolehkan");
            this.AddMsg(MsgCode.Address, "Alamat");
            this.AddMsg(MsgCode.DeviceClass, "Device Class");
            this.AddMsg(MsgCode.ServiceClass, "Service Class");
            this.AddMsg(MsgCode.LastSeen, "Last Seen");
            this.AddMsg(MsgCode.LastUsed, "Last Used");
            this.AddMsg(MsgCode.Authenticated, "Diotentikasi");
            this.AddMsg(MsgCode.RemoteHost, "Host Jarak Jauh");
            this.AddMsg(MsgCode.RemoteService, "Layanan Jarak Jauh");
            this.AddMsg(MsgCode.Clear, "Bersihkan");
            this.AddMsg(MsgCode.ResetAll, "Atur Ulang Semua");
            this.AddMsg(MsgCode.Characteristic, "Karakteristik");
            this.AddMsg(MsgCode.Descriptor, "Pendeskripsi");
            this.AddMsg(MsgCode.Min, "Min");
            this.AddMsg(MsgCode.Max, "Max");
            this.AddMsg(MsgCode.ReadOnly, "Baca saja");
            this.AddMsg(MsgCode.InvalidInput, "Input tidak valid");
            this.AddMsg(MsgCode.ParseFailed, "Penguraian Gagal");
            this.AddMsg(MsgCode.OutOfRange, "Di Luar Rentang");
            this.AddMsg(MsgCode.email, "Email");
            this.AddMsg(MsgCode.CrashReport, "Laporan Crash");
            this.AddMsg(MsgCode.DataType, "Jenis data");
            this.AddMsg(MsgCode.Service, "Layanan");
            this.AddMsg(MsgCode.Notifications, "Pemberitahuan");
            this.AddMsg(MsgCode.Disabled, "Dinonaktifkan");
            this.AddMsg(MsgCode.Description, "Deskripsi");
            this.AddMsg(MsgCode.Unit, "Satuan");
            this.AddMsg(MsgCode.Exponent, "Eksponen");
            this.AddMsg(MsgCode.True, "Benar");
            this.AddMsg(MsgCode.False, "Salah");
            this.AddMsg(MsgCode.Even, "Genap");
            this.AddMsg(MsgCode.Odd, "Ganjil");
            this.AddMsg(MsgCode.Mark, "Tanda");
            this.AddMsg(MsgCode.Space, "Spasi");

        }
    }
}
