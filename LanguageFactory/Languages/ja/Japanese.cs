using LanguageFactory.data;
using LanguageFactory.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageFactory.Languages.ja {
    class Japanese : SupportedLanguage {
        public Japanese() : base() {
            this.SetLanguage(LangCode.Japanese, "日本語");

            // Common messages
            this.AddMsg(MsgCode.exit, "終了");
            this.AddMsg(MsgCode.start, "スタート");
            this.AddMsg(MsgCode.stop, "停止");
            this.AddMsg(MsgCode.language, "言語");
            //this.AddMsg(MsgCode., "");
        }

    }
}
