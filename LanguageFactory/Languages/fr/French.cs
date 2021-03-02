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
            this.AddMsg(MsgCode.commands, "Commandes");
            this.AddMsg(MsgCode.response, "Réponse");
            this.AddMsg(MsgCode.select, "Sélectionner");
            this.AddMsg(MsgCode.Search, "Rechercher");
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
            this.AddMsg(MsgCode.About, "À propos");
            this.AddMsg(MsgCode.Icons, "Icônes");
            this.AddMsg(MsgCode.Author, "Auteur");
            this.AddMsg(MsgCode.Services, "Services");
            this.AddMsg(MsgCode.Properties, "Propriétés");
            this.AddMsg(MsgCode.Delete, "Supprimer");
            this.AddMsg(MsgCode.UserManual, "Manuel de l'utilisateur");
            this.AddMsg(MsgCode.Vendor, "Fournisseur");
            this.AddMsg(MsgCode.Product, "Produit");
            this.AddMsg(MsgCode.Enabled, "Activé");
            this.AddMsg(MsgCode.Default, "Par défaut");
            this.AddMsg(MsgCode.BaudRate, "Vitesse (en bauds)");
            this.AddMsg(MsgCode.DataBits, "Bits de données");
            this.AddMsg(MsgCode.StopBits, "Bits d’arrêt");
            this.AddMsg(MsgCode.Parity, "Parité");
            this.AddMsg(MsgCode.FlowControl, "Contrôle de flux");
            this.AddMsg(MsgCode.Read, "Lecture");
            this.AddMsg(MsgCode.Write, "Écriture");
            this.AddMsg(MsgCode.Timeout, "Délai d’expiration");
            this.AddMsg(MsgCode.Log, "Journal");
            this.AddMsg(MsgCode.None, "Aucun");
            this.AddMsg(MsgCode.NotFound, "Introuvable");
            this.AddMsg(MsgCode.NotConnected, "Non connecté");
            this.AddMsg(MsgCode.ConnectionFailure, "Échec de la Connexion");
            this.AddMsg(MsgCode.ReadFailure, "Échec de Lecture");
            this.AddMsg(MsgCode.WriteFailue, "Échec D’écriture");
            this.AddMsg(MsgCode.UnknownError, "Erreur Inconnue");
            this.AddMsg(MsgCode.UnhandledError, "Erreur non Gérée");
            this.AddMsg(MsgCode.Support, "Support");
            this.AddMsg(MsgCode.Edit, "Modifier");
            this.AddMsg(MsgCode.Create, "Créer");
            this.AddMsg(MsgCode.NothingSelected, "Rien n’est sélectionné");
            this.AddMsg(MsgCode.DeleteFailure, "Échec de la suppression");
            this.AddMsg(MsgCode.Ethernet, "Ethernet");
            this.AddMsg(MsgCode.EmptyParameter, "Impossible d’ajouter un paramètre vide");
            this.AddMsg(MsgCode.AbandonChanges, "Abandonner les modifications?");
            this.AddMsg(MsgCode.Warning, "Avertissement");
            this.AddMsg(MsgCode.Run, "Exécuter");
            this.AddMsg(MsgCode.InsufficienPermissions, "Autorisation insuffisante");
            this.AddMsg(MsgCode.CodeSamples, "Exemples de code");
            this.AddMsg(MsgCode.AuthenticationType, "Type d’authentification");
            this.AddMsg(MsgCode.EncryptionType, "Type de chiffrement");
            this.AddMsg(MsgCode.SignalStrength, "Puissance du signal");
            this.AddMsg(MsgCode.UpTime, "Durée de fonctionnement");
            this.AddMsg(MsgCode.MacAddress, "Adresse MAC");
            this.AddMsg(MsgCode.Kind, "Type");
            this.AddMsg(MsgCode.BeaconInterval, "Intervalle de balise");
            this.AddMsg(MsgCode.AccessStatus, "État de l’accès");
            this.AddMsg(MsgCode.AddressType, "Type d'adresse");
            this.AddMsg(MsgCode.Paired, "Couplé");
            this.AddMsg(MsgCode.Connected, "Connecté");
            this.AddMsg(MsgCode.ProtectionLevel, "Niveau de protection");
            this.AddMsg(MsgCode.SecureConnection, "Connexion sécurisée");
            this.AddMsg(MsgCode.Id, "ID");
            this.AddMsg(MsgCode.Allowed, "Autorisé");
            this.AddMsg(MsgCode.Address, "Address");
            this.AddMsg(MsgCode.DeviceClass, "Classe de périphérique");
            this.AddMsg(MsgCode.ServiceClass, "Classe de service");
            this.AddMsg(MsgCode.LastSeen, "Dernière consultation");
            this.AddMsg(MsgCode.LastUsed, "Dernière utilisation");
            this.AddMsg(MsgCode.Authenticated, "Authentifié");
            this.AddMsg(MsgCode.RemoteHost, "Hôte distant");
            this.AddMsg(MsgCode.RemoteService, "Service distant");
            this.AddMsg(MsgCode.Clear, "Effacer");
            this.AddMsg(MsgCode.ResetAll, "Réinitialiser tout");
            this.AddMsg(MsgCode.Disconnected, "Déconnecté");
            this.AddMsg(MsgCode.Characteristic, "Caractéristique");
            this.AddMsg(MsgCode.Descriptor, "Descripteur");
            this.AddMsg(MsgCode.Min, "Min");
            this.AddMsg(MsgCode.Max, "Max");
            this.AddMsg(MsgCode.ReadOnly, "Lecture seule");
            this.AddMsg(MsgCode.InvalidInput, "Entrée non valide");
            this.AddMsg(MsgCode.ParseFailed, "Échec de l'analyse");
            this.AddMsg(MsgCode.OutOfRange, "Hors de portée");
            this.AddMsg(MsgCode.email, "E-mail");
            this.AddMsg(MsgCode.CrashReport, "Rapport d’incident");
            this.AddMsg(MsgCode.DataType, "Type de données");
            this.AddMsg(MsgCode.Service, "Service");
            this.AddMsg(MsgCode.Notifications, "Notifications");
            this.AddMsg(MsgCode.Disabled, "Désactivé");
            this.AddMsg(MsgCode.Description, "Description");
            this.AddMsg(MsgCode.Unit, "Unité");
            this.AddMsg(MsgCode.Exponent, "Exposant");
            this.AddMsg(MsgCode.True, "Vrai");
            this.AddMsg(MsgCode.False, "Faux");
            this.AddMsg(MsgCode.Even, "Paire");
            this.AddMsg(MsgCode.Odd, "Impaire");
            this.AddMsg(MsgCode.Mark, "Marque");
            this.AddMsg(MsgCode.Space, "Espace");

        }

    }




}
