using ChkUtils.Net;
using ChkUtils.Net.ErrObjects;
using LanguageFactory.Net.data;
using LanguageFactory.Net.interfaces;
using LanguageFactory.Net.Languages.ar;
using LanguageFactory.Net.Languages.bn;
using LanguageFactory.Net.Languages.cn;
using LanguageFactory.Net.Languages.cz;
using LanguageFactory.Net.Languages.de;
using LanguageFactory.Net.Languages.en;
using LanguageFactory.Net.Languages.es;
using LanguageFactory.Net.Languages.fr;
using LanguageFactory.Net.Languages.hi;
using LanguageFactory.Net.Languages.it;
using LanguageFactory.Net.Languages.ja;
using LanguageFactory.Net.Languages.kr;
using LanguageFactory.Net.Languages.nl;
using LanguageFactory.Net.Languages.pl;
using LanguageFactory.Net.Languages.pt;
using LanguageFactory.Net.Languages.ru;
using LanguageFactory.Net.Languages.tr;
using LanguageFactory.Net.Languages.uk;
using LanguageFactory.Net.Languages.vi;
using LogUtils.Net;
using System;
using System.Collections.Generic;

namespace LanguageFactory.Net.Messaging {

    /// <summary>
    /// Implementation of factory that will deliver text based on 
    /// selected language. This is text for buttons, etc
    /// </summary>
    public class SupportedLanguageFactory : ILangFactory {

        #region events

        /// <summary>Event raised when the language is changed</summary>
        public event EventHandler<SupportedLanguage> LanguageChanged;

        #endregion

        #region Data

        /// <summary>Set of supported language modules</summary>
        private Dictionary<LangCode, SupportedLanguage> languages = new Dictionary<LangCode, SupportedLanguage>();
        /// <summary>Currently selected language module</summary>
        private SupportedLanguage current = new English();
        /// <summary>Default language module (English)</summary>
        private SupportedLanguage defaultLang = new English();
        private ClassLog log = new ClassLog("SupportedLanguageFactory");

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
            switch (code) {
                case MsgCode.ReadTimeout:
                    return string.Format("{0}({1})", this.GetMsg(MsgCode.Timeout), this.GetMsg(MsgCode.Read));
                case MsgCode.WriteTimeout:
                    return string.Format("{0}({1})", this.GetMsg(MsgCode.Timeout), this.GetMsg(MsgCode.Write));
                case MsgCode.PairedWithSecureConnection:
                    return string.Format("{0} ({1})", this.GetMsg(MsgCode.Paired), this.GetMsg(MsgCode.SecureConnection));
                case MsgCode.PairingAllowed:
                    return string.Format("{0} ({1})", this.GetMsg(MsgCode.Pair), this.GetMsg(MsgCode.Allowed));
                case MsgCode.ServicesFailure:
                    return string.Format("{0} ({1})", this.GetMsg(MsgCode.ReadFailure), this.GetMsg(MsgCode.Services));
                case MsgCode.NotFoundSettings:
                    return string.Format("{0} ({1})", this.GetMsg(MsgCode.NotFound), this.GetMsg(MsgCode.Settings));
                default:
                    return this.GetMsg(code);
            }
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

        #endregion

        #region Private

        /// <summary>Load all available languages</summary>
        private void LoadLanguages() {
            this.LoadLanguage(new Czech());
            this.LoadLanguage(new English());
            this.LoadLanguage(new Spanish());
            this.LoadLanguage(new German());
            this.LoadLanguage(new French());
            this.LoadLanguage(new Italian());
            this.LoadLanguage(new Dutch()); // Nederlands
            this.LoadLanguage(new Polish());
            this.LoadLanguage(new Portuguese());
            this.LoadLanguage(new Russian());
            this.LoadLanguage(new Turkish());
            this.LoadLanguage(new Ukranian());
            this.LoadLanguage(new Vietnamese());
            this.LoadLanguage(new Hindi());
            this.LoadLanguage(new Bengali());
            this.LoadLanguage(new Chinese());
            this.LoadLanguage(new Japanese());
            this.LoadLanguage(new Korean());
            this.LoadLanguage(new Arabic());
            //this.LoadLanguage(new);
        }


        /// <summary>Safely load a language module or flag error</summary>
        /// <param name="language">The language module to load</param>
        private void LoadLanguage(SupportedLanguage language) {
            //this.log.Info("LoadLanguage", () => string.Format("Loading language: {0}", language.Language.Code));
            if (!this.languages.ContainsKey(language.Language.Code)) {
                this.languages.Add(language.Language.Code, language);
                this.AvailableLanguages.Add(language.Language);
            }
            else {
                this.log.Error(9999, () => string.Format("Language {0} already loaded", language.Language.Code));
            }
        }



        /// <summary>Get the display string for the message code</summary>
        /// <param name="code">The message code</param>
        /// <returns>The display string</returns>
        private string GetMsg(MsgCode code) {
            ErrReport report;
            string msg = WrapErr.ToErrReport(out report, 0, () => string.Format(""), () => {
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
