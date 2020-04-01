using LanguageFactory.data;
using LanguageFactory.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageFactory.Languages.fr {
    public class French : SupportedLanguage {
        public French() : base() {
            this.SetLanguage(LangCode.French, "Français");

            // Common messages
            this.AddMsg(MsgCode.exit, "Quitter");
            this.AddMsg(MsgCode.start, "Démarrer");
            this.AddMsg(MsgCode.stop, "Arrêter");
            this.AddMsg(MsgCode.language, "Langues");
            //this.AddMsg(MsgCode., "");

        }

    }




}
