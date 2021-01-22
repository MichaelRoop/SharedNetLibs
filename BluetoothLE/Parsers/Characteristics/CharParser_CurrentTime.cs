using BluetoothLE.Net.Parsers.Characteristics.DataTypes;
using System;
using System.Collections.Generic;
using System.Text;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Characteristics {

    public class CharParser_CurrentTime : CharParser_Base {

        private TypeParser_ExactTime256 timeParser = new TypeParser_ExactTime256();

        public override int RequiredBytes { get; protected set; } = 0;


        public CharParser_CurrentTime() : base() { this.Setup(); }


        protected override bool DoParse(byte[] data) {
            if (this.CopyToRawData(data)) {
                int pos = 0;
                byte[] timeBlock = ByteHelpers.ToByteArray(this.RawData, this.timeParser.RequiredBytes, ref pos);
                byte adjustReason = this.RawData.ToByte(ref pos);
                StringBuilder sb = new StringBuilder();
                sb.Append(this.timeParser.Parse(timeBlock))
                    .Append(" ")
                    .Append(adjustReason.CurrentTimeAdjustReasonStr());
                this.DisplayString = sb.ToString();
                return true;
            }
            return false;
        }


        private void Setup() {
            this.RequiredBytes = this.timeParser.RequiredBytes + 1;
        }

    }
}
