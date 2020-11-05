using SerialCommon.Net.Enumerations;

namespace SerialCommon.Net.DataModels {

    public class SerialUsbError {
        public string PortName { get; set; } = string.Empty;
        public SerialErrorCode Code { get; set; } = SerialErrorCode.None;
        public string Message { get; set; } = string.Empty;

        public SerialUsbError() { }

        public SerialUsbError(string portName, SerialErrorCode code) {
            this.PortName = portName;
            this.Code = code;
        }

        public SerialUsbError(SerialErrorCode code) {
            this.Code = code;
        }

    }

}
