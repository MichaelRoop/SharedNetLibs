using LanguageFactory.data;
using LanguageFactory.Messaging;
using System;
using System.Collections.Generic;

namespace LanguageFactory.interfaces {

    public interface ILangFactory {

        /// <summary>Event raised when the language is changed</summary>
        event EventHandler<SupportedLanguage> LanguageChanged;


        /// <summary>Get a list of supported languages</summary>
        List<LanguageDataModel> AvailableLanguages { get; }


        /// <summary>Set the current language for system</summary>
        /// <param name="code">Language code</param>
        void SetCurrentLanguage(LangCode code);


        /// <summary>Get the code for currently selected language</summary>
        /// <returns>Current language code</returns>
        LangCode GetCurrentLanguage();


        /// <summary>Get the display for message corresponding to code</summary>
        /// <param name="code">Message code</param>
        /// <returns>The display string</returns>
        string GetMsgDisplay(MsgCode code);

    }

}
