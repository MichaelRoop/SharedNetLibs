using ChkUtils.Net;
using ChkUtils.Net.ErrObjects;
using LanguageFactory.Net.data;
using LanguageFactory.Net.interfaces;
using LanguageFactory.Net.Languages.ar;
using LanguageFactory.Net.Languages.bn;
using LanguageFactory.Net.Languages.ca;
using LanguageFactory.Net.Languages.cn;
using LanguageFactory.Net.Languages.cz;
using LanguageFactory.Net.Languages.de;
using LanguageFactory.Net.Languages.en;
using LanguageFactory.Net.Languages.es;
using LanguageFactory.Net.Languages.fr;
using LanguageFactory.Net.Languages.hi;
using LanguageFactory.Net.Languages.id;
using LanguageFactory.Net.Languages.it;
using LanguageFactory.Net.Languages.ja;
using LanguageFactory.Net.Languages.kr;
using LanguageFactory.Net.Languages.mr;
using LanguageFactory.Net.Languages.nl;
using LanguageFactory.Net.Languages.pl;
using LanguageFactory.Net.Languages.pr;
using LanguageFactory.Net.Languages.pt;
using LanguageFactory.Net.Languages.ro;
using LanguageFactory.Net.Languages.ru;
using LanguageFactory.Net.Languages.tr;
using LanguageFactory.Net.Languages.uk;
using LanguageFactory.Net.Languages.vi;
using LogUtils.Net;

namespace LanguageFactory.Net.Messaging {

    /// <summary>
    /// Implementation of factory that will deliver text based on 
    /// selected language. This is text for buttons, etc
    /// </summary>
    public class SupportedLanguageFactory : ILangFactory {

        #region events

        /// <summary>Event raised when the language is changed</summary>
        public event EventHandler<SupportedLanguage>? LanguageChanged;

        #endregion

        #region Data

        /// <summary>Set of supported language modules</summary>
        private readonly Dictionary<LangCode, SupportedLanguage> languages = new();
        /// <summary>Currently selected language module</summary>
        private SupportedLanguage current = new English();
        /// <summary>Default language module (English)</summary>
        private readonly SupportedLanguage defaultLang = new English();
        private readonly ClassLog log = new("SupportedLanguageFactory");

        #endregion

        #region Properties

        public List<LanguageDataModel> AvailableLanguages { get; } = new List<LanguageDataModel>();


        /// <summary>Get the currently selected language</summary>
        /// <returns>Current language module</returns>
        public SupportedLanguage CurrentLanguage { get { return this.current; } }

        /// <summary>Get the code for currently selected language</summary>
        /// <returns>Current language code</returns>
        public LangCode CurrentLanguageCode { get { return this.current.Language.Code; } }

        #endregion

        #region Constructors

        public SupportedLanguageFactory() {
            this.LoadLanguages();
        }

        #endregion

        #region Public

        /// <summary>Get the display string for the message code</summary>
        /// <param name="code">The message code</param>
        /// <returns>The display string</returns>
        public string GetMsgDisplay(MsgCode code) {
            return code switch {
                MsgCode.ReadTimeout => string.Format("{0}({1})", this.GetMsg(MsgCode.Timeout), this.GetMsg(MsgCode.Read)),
                MsgCode.WriteTimeout => string.Format("{0}({1})", this.GetMsg(MsgCode.Timeout), this.GetMsg(MsgCode.Write)),
                MsgCode.PairedWithSecureConnection => string.Format("{0} ({1})", this.GetMsg(MsgCode.Paired), this.GetMsg(MsgCode.SecureConnection)),
                MsgCode.PairingAllowed => string.Format("{0} ({1})", this.GetMsg(MsgCode.Pair), this.GetMsg(MsgCode.Allowed)),
                MsgCode.ServicesFailure => string.Format("{0} ({1})", this.GetMsg(MsgCode.ReadFailure), this.GetMsg(MsgCode.Services)),
                MsgCode.NotFoundSettings => string.Format("{0} ({1})", this.GetMsg(MsgCode.NotFound), this.GetMsg(MsgCode.Settings)),
                MsgCode.EmptySSID => string.Format("{0} ({1})", this.GetMsg(MsgCode.EmptyParameter), "SSID"),
                MsgCode.EmptyHostName => string.Format("{0} ({1})", this.GetMsg(MsgCode.EmptyParameter), this.GetMsg(MsgCode.HostName)),
                MsgCode.EmptyPort => string.Format("{0} ({1})", this.GetMsg(MsgCode.EmptyParameter), this.GetMsg(MsgCode.Port)),
                MsgCode.EmptyPwd => string.Format("{0} ({1})", this.GetMsg(MsgCode.EmptyParameter), this.GetMsg(MsgCode.Password)),
                MsgCode.DataTypeUnhandled => string.Format("{0} ({1})", this.GetMsg(MsgCode.Unknown), this.GetMsg(MsgCode.DataType)),

                _ => this.GetMsg(code),
            };
        }


        /// <summary>Set the language that the system will be using</summary>
        /// <param name="code"></param>
        public void SetCurrentLanguage(LangCode code) {
            if (this.languages.ContainsKey(code)) {
                this.current = this.languages[code];
                if (this.LanguageChanged != null) {
                    this.LanguageChanged(this, this.current);
                }
                else {
                    this.log.Error(9999, "No subscribers to LanguageChanged event");
                }
            }
            else {
                this.log.Error(9999, () => string.Format("Could not fine language {0}", code));
            }
        }


        /// <summary>Safely load a language module or flag error</summary>
        /// <param name="language">The language module to load</param>
        public void LoadLanguage(SupportedLanguage language) {
            //this.log.Info("LoadLanguage", () => string.Format("Loading language: {0}", language.Language.Code));
            if (!this.languages.ContainsKey(language.Language.Code)) {
                this.languages.Add(language.Language.Code, language);
                this.AvailableLanguages.Add(language.Language);
            }
            else {
                this.log.Error(9999, () => string.Format("Language {0} already loaded", language.Language.Code));
            }
        }


        public bool UnloadLanguage(LangCode code) {
            LanguageDataModel? dm = this.AvailableLanguages.FirstOrDefault(x => x.Code == code);
            bool result = this.languages.ContainsKey(code);
            if (result == true) {
                result = this.languages.Remove(code);
            }
            // Make sure it is also removed from the list
            if (dm != null) {
                result = this.AvailableLanguages.Remove(dm);
            }
            return result;
        }

        #endregion

        #region Private

        /// <summary>Load all available languages</summary>
        private void LoadLanguages() {
            this.LoadLanguage(new Arabic());    // earabiin - arabionne
            this.LoadLanguage(new Bengali());   // pronounced Bangla
            this.LoadLanguage(new Catalan());   // Català - north east Spain
            this.LoadLanguage(new Czech());     // Chez - pronounced seksha
            this.LoadLanguage(new English());   // English
            this.LoadLanguage(new Spanish());   // Espanol
            this.LoadLanguage(new German());    // Deutsch
            this.LoadLanguage(new French());    // Francais
            this.LoadLanguage(new Korean());    // hangug-eo
            this.LoadLanguage(new Chinese());   // Pronounced Han Yu
            this.LoadLanguage(new Hindi());     // Pronounced Hindi
            this.LoadLanguage(new Indonesian());// Indonesia
            this.LoadLanguage(new Italian());   // Italian
            this.LoadLanguage(new Marathi());   // Marathi (India)
            this.LoadLanguage(new Dutch());     // Nederlands
            this.LoadLanguage(new Japanese());  // Nihongo
            this.LoadLanguage(new Polish());    // Polski
            this.LoadLanguage(new Portuguese());// Portugaisa
            this.LoadLanguage(new Punjabi());   // Punjabi
            this.LoadLanguage(new Romanian());  // Romana
            this.LoadLanguage(new Russian());   // Pronounced Ruski
            this.LoadLanguage(new Vietnamese());// Tiếng Việt Nam
            this.LoadLanguage(new Turkish());   // Turce
            this.LoadLanguage(new Ukranian());  // Ukraiinska
            //this.LoadLanguage(new);
        }



        /// <summary>Get the display string for the message code</summary>
        /// <param name="code">The message code</param>
        /// <returns>The display string</returns>
        private string GetMsg(MsgCode code) {
            string msg = WrapErr.ToErrReport(out ErrReport report, 0, () => string.Format(""), () => {
                if (this.current.HasMsg(code)) {
                    return this.current.GetMsg(code).Display;
                }
                this.log.Error(9999, () =>
                    string.Format("Language:{0} does not have msg:{1}", this.current.Language.Code, code));
                return this.defaultLang.GetMsg(code).Display;
            });
            return (report.Code == 0) ? msg : "** ERROR **";
        }



        #endregion

    }
}
