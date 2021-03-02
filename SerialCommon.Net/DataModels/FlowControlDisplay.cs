using SerialCommon.Net.Enumerations;
using System;
using VariousUtils.Net;

namespace SerialCommon.Net.DataModels {

    public class FlowControlDisplay {
        public string Display { get; set; } = string.Empty;
        
        public SerialFlowControlHandshake FlowControl { get; set; } = SerialFlowControlHandshake.None;

        public FlowControlDisplay(SerialFlowControlHandshake hs) {
            this.Display = hs.ToString().CamelCaseToSpaces();
            this.FlowControl = hs;
        }


        public FlowControlDisplay(
            SerialFlowControlHandshake hs, 
            Func<SerialFlowControlHandshake, string> translator) {
            this.Display = translator(hs);
            this.FlowControl = hs;
        }


    }
}
