using LanguageFactory.data;
using LanguageFactory.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageFactory.Languages.kr {
    class Korean : SupportedLanguage {
        public Korean() : base() {
            this.SetLanguage(LangCode.Korean, "한국어");

            // Common messages
            this.AddMsg(MsgCode.exit, "종료");
            this.AddMsg(MsgCode.start, "시작");
            this.AddMsg(MsgCode.stop, "중지");
            this.AddMsg(MsgCode.language, "언어");
            //this.AddMsg(MsgCode., "");
        }

    }
}
