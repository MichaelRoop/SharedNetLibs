namespace LanguageFactory.data {

    /// <summary>Holds information for one message</summary>
    public class MessageDataModel {
        public MsgCode Code { get; set; } = MsgCode.undefined;
        public string Display { get; set; } = "NA";


        public MessageDataModel() {
        }

        public MessageDataModel(MsgCode code, string display) {
            this.Code = code;
            this.Display = display;
        }
    }

}
