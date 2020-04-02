using LanguageFactory.data;
using LanguageFactory.Messaging;

namespace LanguageFactory.Languages.ja {
    class Japanese : SupportedLanguage {
        public Japanese() : base() {
            this.SetLanguage(LangCode.Japanese, "日本語");

            // Common messages
            this.AddMsg(MsgCode.exit, "終了");
            this.AddMsg(MsgCode.start, "スタート");
            this.AddMsg(MsgCode.stop, "停止");
            this.AddMsg(MsgCode.language, "言語");
            this.AddMsg(MsgCode.send, "送信");
            this.AddMsg(MsgCode.command, "コマンド");
            this.AddMsg(MsgCode.response, "応答");
            this.AddMsg(MsgCode.select, "選択する");
            this.AddMsg(MsgCode.discover, "発見する");
            this.AddMsg(MsgCode.connect, "接続");
            this.AddMsg(MsgCode.cancel, "キャンセル");
            this.AddMsg(MsgCode.info, "情報");



            //this.AddMsg(MsgCode., "");
        }

    }
}
