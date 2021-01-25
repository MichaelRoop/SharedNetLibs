using BluetoothLE.Net.Enumerations;
using LogUtils.Net;
using System;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Descriptor {

    /// <summary>
    /// Parse out the values from the Report Reference Descriptor
    /// (0x2908) Data type: uint8, uint8 ? 
    /// TODO - I only have uint  8
    /// </summary>
    public class DescParser_ReportReference : DescParser_Base {

        private ClassLog log = new ClassLog("DescParser_ReportReference");


        public ReportType TypeOfReport { get; set; } = ReportType.Input;

        public byte ConvertedData { get; set; }

        public override int RequiredBytes { get; protected set; } = BYTE_LEN;



        protected override void DoParse(byte[] data) {
            this.ConvertedData = data.ToByte(0);
            this.TypeOfReport = this.GetReportType(this.ConvertedData);
            this.DisplayString = this.TypeOfReport.ToString();
            this.log.Info("Parse", () => string.Format("Display:{0}", this.DisplayString));
        }


        protected override void ResetMembers() {
            this.ConvertedData = 0;
            this.TypeOfReport = ReportType.Input;
        }


        private ReportType GetReportType(byte value) {
            // Report ID   uint8  0-255 - report ID and Type
            // Report Type uint8 1-3 (Input Report=1, Output Report=2, Feature Report=3
            switch (value) {
                case 1:
                    return ReportType.Input;
                case 2:
                    return ReportType.Output;
                case 3:
                    return ReportType.Feature;
                default:
                    return ReportType.Undefined;
            }
        }

    }

}
