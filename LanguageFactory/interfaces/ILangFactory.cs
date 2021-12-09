using LanguageFactory.Net.data;
using LanguageFactory.Net.Messaging;

namespace LanguageFactory.Net.interfaces {

    public interface ILangFactory {

        /// <summary>Event raised when the language is changed</summary>
        event EventHandler<SupportedLanguage> LanguageChanged;

        /// <summary>Get a list of supported languages</summary>
        List<LanguageDataModel> AvailableLanguages { get; }


        /// <summary>Get the current language</summary>
        SupportedLanguage CurrentLanguage { get; }


        /// <summary>Get the code for currently selected language</summary>
        /// <returns>Current language code</returns>
        LangCode CurrentLanguageCode { get; }


        /// <summary>Set the current language for system</summary>
        /// <param name="code">Language code</param>
        void SetCurrentLanguage(LangCode code);


        /// <summary>Get the display for message corresponding to code</summary>
        /// <param name="code">Message code</param>
        /// <returns>The display string</returns>
        string GetMsgDisplay(MsgCode code);


        /// <summary>Load a language</summary>
        /// <remarks>Standard set of all languages loaded in constructor</remarks>
        /// <param name="language">The language to load</param>
        void LoadLanguage(SupportedLanguage language);


        /// <summary>Unloads a language if loaded</summary>
        /// <param name="code">The language to unload</param>
        /// <returns>true on success, otherwise false if not found or failure</returns>
        bool UnloadLanguage(LangCode code);


    }

}
