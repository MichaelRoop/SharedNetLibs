using BluetoothLE.Net.Parsers.Characteristics.DataTypes;
using System;
using System.Collections.Generic;
using System.Text;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_CurrentTime : CharParser_Base {

        private TypeParser_ExactTime256 timeParser = new TypeParser_ExactTime256();
        int timeParserBytes = 0;

        public CharParser_CurrentTime() : base() { this.Setup(); }
        public CharParser_CurrentTime(byte[] data) : base(data) { this.Setup(); }


        protected override bool DoParse(byte[] data) {
            if (this.CopyToRawData(data, this.RequiredBytes())) {
                int pos = 0;
                byte[] timeBlock = ByteHelpers.ToByteArray(this.RawData, this.timeParserBytes, ref pos);
                byte adjustReason = this.RawData.ToByte(ref pos);
                StringBuilder sb = new StringBuilder();
                sb.Append(this.timeParser.Parse(timeBlock))
                    .Append(" ")
                    .Append(adjustReason.CurrentTimeAdjustReasonStr());
                this.strValue = sb.ToString();
                return true;
            }
            return false;
        }


        public override int RequiredBytes() {
            return this.timeParserBytes + 1;
        }


        private void Setup() {
            this.timeParserBytes = this.timeParser.RequiredBytes() ;
        }


        //private string AdjustReason(byte bitmap) {
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("Manual Update:").Append(bitmap.IsBitSet(0) ? "Enabled" : "Disabled")
        //      .Append("External Reference Cime Change:").Append(bitmap.IsBitSet(1) ? "Enabled" : "Disabled")
        //      .Append("Time zone Change:").Append(bitmap.IsBitSet(2) ? "Enabled" : "Disabled")
        //      .Append("DST Change:").Append(bitmap.IsBitSet(3) ? "Enabled" : "Disabled");
        //    return sb.ToString();
        //}

    }
}
