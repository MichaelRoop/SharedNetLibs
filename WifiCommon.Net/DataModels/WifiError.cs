using WifiCommon.Net.Enumerations;

namespace WifiCommon.Net.DataModels {

    public class WifiError {
        public WifiErrorCode Code { get; set; } = WifiErrorCode.Unknown;
        public string ExtraInfo { get; set; } = string.Empty;

        public WifiError() { }
        public WifiError(WifiErrorCode code) {
            this.Code = code;
        }
    }
}
