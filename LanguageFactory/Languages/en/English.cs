﻿using LanguageFactory.data;
using LanguageFactory.Messaging;

namespace LanguageFactory.Languages.en {
    public class English : SupportedLanguage {

        public English() : base() {
            this.SetLanguage(LangCode.English, "English");

            // Common messages
            this.AddMsg(MsgCode.save, "Save");

            this.AddMsg(MsgCode.login, "Login");
            this.AddMsg(MsgCode.logoff, "Logoff");
            this.AddMsg(MsgCode.copy, "Copy");
            this.AddMsg(MsgCode.no, "No");
            this.AddMsg(MsgCode.yes, "Yes");
            this.AddMsg(MsgCode.New, "New");
            this.AddMsg(MsgCode.Ok, "OK");
            this.AddMsg(MsgCode.exit, "Exit");
            this.AddMsg(MsgCode.start, "Start");
            this.AddMsg(MsgCode.stop, "Stop");
            this.AddMsg(MsgCode.language, "Language");
            this.AddMsg(MsgCode.send, "Send");
            this.AddMsg(MsgCode.command, "Command");
            this.AddMsg(MsgCode.response, "Response");
            this.AddMsg(MsgCode.select, "Select");
            this.AddMsg(MsgCode.discover, "Discover");
            this.AddMsg(MsgCode.connect, "Connect");
            this.AddMsg(MsgCode.cancel, "Cancel");
            this.AddMsg(MsgCode.info, "Info");

            //this.AddMsg(MsgCode., "");
        }

    }
}