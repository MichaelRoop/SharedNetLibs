using LanguageFactory.data;
using LanguageFactory.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageFactory.Languages.en {
    public class English : SupportedLanguage {

        public English() : base() {
            this.SetLanguage(LangCode.English, "English");

            // Common messages
            this.AddMsg(MsgCode.exit, "Exit");
            this.AddMsg(MsgCode.start, "Start");
            this.AddMsg(MsgCode.stop, "Stop");
            this.AddMsg(MsgCode.language, "Language");
            //this.AddMsg(MsgCode., "");
        }

    }
}
