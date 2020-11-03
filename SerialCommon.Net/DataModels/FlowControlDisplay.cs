using SerialCommon.Net.Enumerations;
using VariousUtils.Net;

namespace SerialCommon.Net.DataModels {

    public class FlowControlDisplay {
        public string Display { get; set; } = string.Empty;
        
        public SerialFlowControlHandshake FlowControl { get; set; } = SerialFlowControlHandshake.None;

        public FlowControlDisplay(SerialFlowControlHandshake hs) {
            this.Display = hs.ToString().CamelCaseToSpaces();
            this.FlowControl = hs;
        }


    }
}
