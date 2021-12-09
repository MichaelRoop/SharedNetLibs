using LanguageFactory.Net.data;
using LogUtils.Net;

namespace LanguageFactory.Net.Messaging {

    /// <summary>Base class that holds information for all messages of one language</summary>
    public class SupportedLanguage {

        private readonly ClassLog log = new("SupportedLanguage");

        public LanguageDataModel Language { get; protected set; } = new LanguageDataModel();
        public Dictionary<MsgCode, MessageDataModel> Messages { get; protected set; } = new Dictionary<MsgCode, MessageDataModel>();


        public SupportedLanguage() {
        }


        public bool HasMsg(MsgCode code) {
            return this.Messages.ContainsKey(code);
        }

        public MessageDataModel GetMsg(MsgCode code) {
            if (this.HasMsg(code)) {
                return this.Messages[code];
            }
            this.log.Error(9999, () => string.Format("Language:{0} does not have msg:{1}", this.Language.Code, code));
            return new MessageDataModel(code, "** Not defined **");
        }


        public string GetText(MsgCode code) {
            return this.GetMsg(code).Display;
        }


        protected void AddMsg(MsgCode code, string display) {
            if (this.HasMsg(code)) {
                this.log.Error(9999, () => string.Format(
                    "Msg:{0} : {1} for language:{2} already exists", 
                    code, display, this.Language.Code));
            }
            else {
                this.Messages.Add(code, new MessageDataModel(code, display));
            }
        }


        /// <summary>Set the language info for the derived language file</summary>
        /// <param name="code">Language code</param>
        /// <param name="display">Display string for language</param>
        protected void SetLanguage(LangCode code, string display) {
            this.Language = new LanguageDataModel(code, display);
        }

    }
}
