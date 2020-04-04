using ChkUtils.Net;
using ChkUtils.Net.ErrObjects;
using LanguageFactory.data;
using LanguageFactory.interfaces;
using LanguageFactory.Languages.cn;
using LanguageFactory.Languages.en;
using LanguageFactory.Languages.es;
using LanguageFactory.Languages.fr;
using LanguageFactory.Languages.ja;
using LanguageFactory.Languages.kr;
using LogUtils.Net;
using System;
using System.Collections.Generic;

namespace LanguageFactory.Messaging {

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
            this.LoadLanguage(new English());
            this.LoadLanguage(new French());
            this.LoadLanguage(new Spanish());
            this.LoadLanguage(new Chinese());
            this.LoadLanguage(new Japanese());
            this.LoadLanguage(new Korean());
            //this.LoadLanguage(new);
        }


        /// <summary>Safely load a language module or flag error</summary>
        /// <param name="language">The language module to load</param>
        private void LoadLanguage(SupportedLanguage language) {
            this.log.Info("LoadLanguage", () => string.Format("Loading language: {0}", language.Language.Code));
            if (!this.languages.ContainsKey(language.Language.Code)) {
                this.languages.Add(language.Language.Code, language);
                this.AvailableLanguages.Add(language.Language);
            }
            else {
                this.log.Error(9999, () => string.Format("Language {0} already loaded", language.Language.Code));
            }
        }

        #endregion

    }
}
