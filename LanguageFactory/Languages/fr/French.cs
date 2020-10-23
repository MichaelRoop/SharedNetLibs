using LanguageFactory.Net.data;
using LanguageFactory.Net.Messaging;

namespace LanguageFactory.Net.Languages.fr {
    public class French : SupportedLanguage {
        public French() : base() {
            this.SetLanguage(LangCode.French, "Français");

            // Common messages
            this.AddMsg(MsgCode.save, "Enregistrer");
            this.AddMsg(MsgCode.login, "Ouvrir une session");
            this.AddMsg(MsgCode.logoff, "Fermer la session");
            this.AddMsg(MsgCode.copy, "Copier");
            this.AddMsg(MsgCode.no, "Non");
            this.AddMsg(MsgCode.yes, "Oui");
            this.AddMsg(MsgCode.New, "Nouveau");
            this.AddMsg(MsgCode.Ok, "OK");
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
            this.AddMsg(MsgCode.Settings, "Paramètres");
            this.AddMsg(MsgCode.Terminators, "Terminateurs");
            this.AddMsg(MsgCode.Name, "Nom");
            this.AddMsg(MsgCode.Error, "Erreur");
            this.AddMsg(MsgCode.CannotDeleteLast, "Impossible de supprimer la dernière entrée");
            this.AddMsg(MsgCode.EmptyName, "Le nom ne peut être vide");
            this.AddMsg(MsgCode.LoadFailed, "Échec de chargement");
            this.AddMsg(MsgCode.SaveFailed, "Impossible d’enregistrer");
            this.AddMsg(MsgCode.EnterName, "Entrer un nom");
            this.AddMsg(MsgCode.Continue, "Continuer?");
            this.AddMsg(MsgCode.Configure, "Configurer");
            this.AddMsg(MsgCode.NoServices, "Aucun service détecté");
            this.AddMsg(MsgCode.PairBluetooth, "Coupler Bluetooth");
            this.AddMsg(MsgCode.EnterPin, "Entrer le PIN");
            this.AddMsg(MsgCode.PairedDevices, "Appareils appariés");
            this.AddMsg(MsgCode.Pair, "Coupler");
            this.AddMsg(MsgCode.Unpair, "Découpler");
            this.AddMsg(MsgCode.Disconnect, "Déconnecter");
            this.AddMsg(MsgCode.Password, "Mot de passe");
            this.AddMsg(MsgCode.HostName, "Nom d'hôte");
            this.AddMsg(MsgCode.NetworkService, "Service réseau");
            this.AddMsg(MsgCode.Port, "Port");
            this.AddMsg(MsgCode.NetworkSecurityKey, "Clé de sécurité réseau");
            this.AddMsg(MsgCode.Network, "Réseau");
            this.AddMsg(MsgCode.Socket, "Socket");
            this.AddMsg(MsgCode.Credentials, "Info. d'identification");

            //this.AddMsg(MsgCode., "");
        }

    }




}
