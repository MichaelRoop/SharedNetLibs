using LogUtils.Net;
using System;
using System.Collections.Generic;
using System.Text;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Descriptor {

    /// <summary>List of attribute handles (0x2905) Data type: List<uint16></uint16>
    /// </summary>
    public class DescParser_CharacteristicAggregateFormat :DescParser_Base {

        private ClassLog log = new ClassLog("DescParser_CharacteristicAggregateFormat");


        /// <summary>List of attribute handles</summary>
        public List<ushort> AttributeHandles { get; set; } = new List<ushort>();

        protected override bool IsDataVariableLength { get; set; } = true;


        /// <summary>
        /// Reset with values parsed from the bytes retrieved from the Descriptor
        /// </summary>
        /// <param name="data">The bytes of data returned from the OS descriptor</param>
        protected override void DoParse(byte[] data) {
            this.log.Info("DoParse", () => string.Format("Length:{0} Bytes:{1}", data.Length, data.ToFormatedByteString()));

            int count = data.Length / UINT16_LEN;
            int pos = 0;
            for (int i = 0; i < count; i++) {
                this.AttributeHandles.Add(data.ToUint16(ref pos));
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("Aggregate Format - Format Handles (");
            bool first = true;
            foreach (ushort val in this.AttributeHandles) {
                if (first) {
                    first = false;
                }
                else {
                    sb.Append(", ");
                }
                sb.Append(val);
            }
            sb.Append(")");
            this.DisplayString = sb.ToString();
            this.log.Info("DoParse", this.DisplayString);
        }


        protected override void ResetMembers() {
            this.AttributeHandles = new List<ushort>();
            base.ResetMembers();
        }

    }

}
