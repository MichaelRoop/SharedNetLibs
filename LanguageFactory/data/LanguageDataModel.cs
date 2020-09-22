namespace LanguageFactory.Net.data {

    public class LanguageDataModel {
        public LangCode Code { get; set; } = LangCode.English;
        public string Display { get; set; } = "NA";


        public LanguageDataModel() {
        }


        public LanguageDataModel(LangCode code, string display) {
            this.Code = code;
            this.Display = display;
        }

    }
}
