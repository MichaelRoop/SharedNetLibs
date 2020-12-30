﻿using LanguageFactory.Net.data;
using LanguageFactory.Net.Messaging;

namespace LanguageFactory.Net.Languages.ja {
    class Japanese : SupportedLanguage {
        public Japanese() : base() {
            this.SetLanguage(LangCode.Japanese, "日本語");

            // Common messages
            this.AddMsg(MsgCode.save, "保存");
            this.AddMsg(MsgCode.login, "ログオンする");
            this.AddMsg(MsgCode.logoff, "ログオフする");
            this.AddMsg(MsgCode.copy, "コピー");
            this.AddMsg(MsgCode.no, "ノー");
            this.AddMsg(MsgCode.yes, "はい");
            this.AddMsg(MsgCode.New, "新");
            this.AddMsg(MsgCode.Ok, "OK");
            this.AddMsg(MsgCode.exit, "終了");
            this.AddMsg(MsgCode.start, "スタート");
            this.AddMsg(MsgCode.stop, "停止");
            this.AddMsg(MsgCode.language, "言語");
            this.AddMsg(MsgCode.send, "送信");
            this.AddMsg(MsgCode.command, "コマンド");
            this.AddMsg(MsgCode.commands, "コマンド");
            this.AddMsg(MsgCode.response, "応答");
            this.AddMsg(MsgCode.select, "選択する");
            this.AddMsg(MsgCode.Search, "検索");
            this.AddMsg(MsgCode.connect, "接続");
            this.AddMsg(MsgCode.cancel, "キャンセル");
            this.AddMsg(MsgCode.info, "情報");
            this.AddMsg(MsgCode.Settings, "設定");
            this.AddMsg(MsgCode.Terminators, "終端文字");
            this.AddMsg(MsgCode.Name, "名前");
            this.AddMsg(MsgCode.Error, "エラー");
            this.AddMsg(MsgCode.CannotDeleteLast, "凡例には最低 1 つの凡例文字列が含まれていなければなりません");
            this.AddMsg(MsgCode.EmptyName, "名前を空にすることはできません");
            this.AddMsg(MsgCode.LoadFailed, "読み込めませんでした");
            this.AddMsg(MsgCode.SaveFailed, "保存に失敗しました");
            this.AddMsg(MsgCode.EnterName, "名前の入力");
            this.AddMsg(MsgCode.Continue, "続行");
            this.AddMsg(MsgCode.Configure, "設定");
            this.AddMsg(MsgCode.NoServices, "サービスが見つかりません");
            this.AddMsg(MsgCode.PairBluetooth, "Bluetooth のペアリング");
            this.AddMsg(MsgCode.EnterPin, "PINの入力");
            this.AddMsg(MsgCode.PairedDevices, "ペアリングされたデバイス");
            this.AddMsg(MsgCode.Pair, "ペアリング");
            this.AddMsg(MsgCode.Unpair, "ペアリングの解除");
            this.AddMsg(MsgCode.Disconnect, "切断");
            this.AddMsg(MsgCode.Password, "パスワード");
            this.AddMsg(MsgCode.HostName, "ホスト名");
            this.AddMsg(MsgCode.NetworkService, "ネットワーク サービス");
            this.AddMsg(MsgCode.Port, "ポート");
            this.AddMsg(MsgCode.NetworkSecurityKey, "ネットワーク セキュリティ キ");
            this.AddMsg(MsgCode.Network, "ネットワーク");
            this.AddMsg(MsgCode.Socket, "ソケット");
            this.AddMsg(MsgCode.Credentials, "資格証明");
            this.AddMsg(MsgCode.About, "情報");
            this.AddMsg(MsgCode.Icons, "アイコン");
            this.AddMsg(MsgCode.Author, "作成者");
            this.AddMsg(MsgCode.Services, "サービス");
            this.AddMsg(MsgCode.Properties, "のプロパティ");
            this.AddMsg(MsgCode.Delete, "削除");
            this.AddMsg(MsgCode.UserManual, "ユーザー マニュアル");
            this.AddMsg(MsgCode.Vendor, "ベンダー");
            this.AddMsg(MsgCode.Product, "製品");
            this.AddMsg(MsgCode.Enabled, "有効");
            this.AddMsg(MsgCode.Default, "既定値");
            this.AddMsg(MsgCode.BaudRate, "ボー レート");
            this.AddMsg(MsgCode.DataBits, "データ ビット");
            this.AddMsg(MsgCode.StopBits, "ストップ ビット");
            this.AddMsg(MsgCode.Parity, "パリティ");
            this.AddMsg(MsgCode.FlowControl, "フロー制御");
            this.AddMsg(MsgCode.Read, "読み取り");
            this.AddMsg(MsgCode.Write, "書き込み");
            this.AddMsg(MsgCode.Timeout, "タイムアウト");
            this.AddMsg(MsgCode.Log, "ログ");
            this.AddMsg(MsgCode.None, "なし");
            this.AddMsg(MsgCode.NotFound, "見つかりません");
            this.AddMsg(MsgCode.NotConnected, "未接続");
            this.AddMsg(MsgCode.ConnectionFailure, "接続の失敗");
            this.AddMsg(MsgCode.ReadFailure, "読み取りエラーです");
            this.AddMsg(MsgCode.WriteFailue, "書き込み失敗");
            this.AddMsg(MsgCode.UnknownError, "不明なエラー");
            this.AddMsg(MsgCode.UnhandledError, "未処理のエラー");
            this.AddMsg(MsgCode.Support, "サポート");
            this.AddMsg(MsgCode.Edit, "編集");
            this.AddMsg(MsgCode.Create, "作成");
            this.AddMsg(MsgCode.NothingSelected, "選択されていません");
            this.AddMsg(MsgCode.DeleteFailure, "削除に失敗しました");
            this.AddMsg(MsgCode.Ethernet, "イーサネット");
            this.AddMsg(MsgCode.EmptyParameter, "空のパラメーターを追加することはできません");
            this.AddMsg(MsgCode.AbandonChanges, "変更の破棄?");
            this.AddMsg(MsgCode.Warning, "警告");
            this.AddMsg(MsgCode.Run, "実行");
            this.AddMsg(MsgCode.InsufficienPermissions, "アクセス許可が不十分です");
            this.AddMsg(MsgCode.CodeSamples, "コード サンプル");
            this.AddMsg(MsgCode.AuthenticationType, "認証の種類");
            this.AddMsg(MsgCode.EncryptionType, "暗号化の種類");
            this.AddMsg(MsgCode.SignalStrength, "シグナルの強さ");
            this.AddMsg(MsgCode.UpTime, "稼働時間");
            this.AddMsg(MsgCode.MacAddress, "MAC アドレス");
            this.AddMsg(MsgCode.Kind, "分類");
            this.AddMsg(MsgCode.BeaconInterval, "ビーコン間隔");
            this.AddMsg(MsgCode.AccessStatus, "アクセス状態");
            this.AddMsg(MsgCode.AddressType, "アドレスの種類");
            this.AddMsg(MsgCode.Paired, "ペアリング済み");
            this.AddMsg(MsgCode.Connected, "接続しました");
            this.AddMsg(MsgCode.ProtectionLevel, "保護レベル");
            this.AddMsg(MsgCode.SecureConnection, "セキュリティで保護された接続 ");
            this.AddMsg(MsgCode.Id, "ID");
            this.AddMsg(MsgCode.Allowed, "許可");
            this.AddMsg(MsgCode.Address, "住所");
            this.AddMsg(MsgCode.DeviceClass, "デバイス クラス");
            this.AddMsg(MsgCode.ServiceClass, "サービス クラス");
            this.AddMsg(MsgCode.LastSeen, "最終表示日");
            this.AddMsg(MsgCode.LastUsed, "使用日時");
            this.AddMsg(MsgCode.Authenticated, "認証済み");
            this.AddMsg(MsgCode.RemoteHost, "リモート ホスト");
            this.AddMsg(MsgCode.RemoteService, "リモート サービス");
            this.AddMsg(MsgCode.Clear, "解除");


            //this.AddMsg(MsgCode., "");
        }

    }
}
