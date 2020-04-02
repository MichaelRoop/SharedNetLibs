using LanguageFactory.data;
using LanguageFactory.Messaging;

namespace LanguageFactory.Languages.fr {
    public class French : SupportedLanguage {
        public French() : base() {
            this.SetLanguage(LangCode.French, "Français");

            // Common messages
            this.AddMsg(MsgCode.exit, "Quitter");
            this.AddMsg(MsgCode.start, "Démarrer");
            this.AddMsg(MsgCode.stop, "Arrêter");
            this.AddMsg(MsgCode.language, "Langues");
            this.AddMsg(MsgCode.send, "Envoyer");
            this.AddMsg(MsgCode.command, "Commande");
            this.AddMsg(MsgCode.response, "Réponse");
            this.AddMsg(MsgCode.select, "Sélectionner");
            this.AddMsg(MsgCode.discover, "Découvrir");
            this.AddMsg(MsgCode.connect, "Connecter");
            this.AddMsg(MsgCode.cancel, "Annuler");
            this.AddMsg(MsgCode.info, "Info");


            //this.AddMsg(MsgCode., "");
        }

    }




}
