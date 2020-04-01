using LanguageFactory.data;
using LanguageFactory.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageFactory.Languages.es {
    class Spanish : SupportedLanguage {
        public Spanish() : base() {

            this.SetLanguage(LangCode.Spanish, "Español");

            // Common messages
            this.AddMsg(MsgCode.exit, "Salir");
            this.AddMsg(MsgCode.start, "Iniciar");
            this.AddMsg(MsgCode.stop, "Detener");
            this.AddMsg(MsgCode.language, "Idiomas");
            //this.AddMsg(MsgCode., "");
        }

    }
}
